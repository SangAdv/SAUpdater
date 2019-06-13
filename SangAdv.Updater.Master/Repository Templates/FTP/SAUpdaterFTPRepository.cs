using SangAdv.Updater.Common;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SangAdv.Updater.Master

{
    public class SAUpdaterFTPRepository : ASAUpdaterFTPBaseRepository
    {
        #region Variables

        private const string mFTPTestFolder = @"testfolder/";
        private SAUpdaterFTPClient mFtpClient;

        #endregion Variables

        #region Abstract Properties

        public override Uri RepositoryRootFolderUri => new Uri(RepositoryConfig.FTPServer).AddUriSegment(RepositoryConfig.ApplicationFolder);

        #endregion Abstract Properties

        #region Constructor

        public SAUpdaterFTPRepository(string repositorySettings)
        {
            mSettings.FromString(repositorySettings);
            mFtpClient = new SAUpdaterFTPClient(RepositoryRootFolderUri, RepositoryConfig.FTPUsername, RepositoryConfig.FTPPassword);
            mFtpClient.UploadProgressChanged += RaiseFileUploadProgressChangedEvent;
        }

        #endregion Constructor

        #region Methods

        #region Not Implemented in Master

        public override Task<string> DownloadFileContentsAsync(string remoteDirectory, string remoteFileName)
        {
            throw new NotImplementedException();
        }

        public override string DownloadFileContents(string remoteDirectory, string remoteFileName)
        {
            throw new NotImplementedException();
        }

        public override async Task<bool> DownloadFileAsync(string remoteDirectory, string remoteFileName, string destinationFilename)
        {
            try
            {
                var tDlownloadUri = new Uri(new Uri(RepositoryConfig.FTPDownloadUri.FixURLDirectoryLink()), new Uri(RepositoryConfig.ApplicationFolder.FixURLDirectoryLink(), UriKind.Relative)).ToString();
                var tDownload = new SAUpdaterFileDownload(tDlownloadUri);
                await tDownload.DownloadFileAsync(mFTPTestFolder, "Test.html", destinationFilename);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public override bool DownloadFile(string remoteDirectory, string remoteFileName, string destinationFilename)
        {
            throw new NotImplementedException();
        }

        #endregion Not Implemented in Master

        public override bool PrepareFolders(string selectedVersion)
        {
            RaiseMessageChangedEvent("Preparing root folder");
            if (!PrepareFolders("", "root folder")) return false;
            if (!PrepareFolders(RepositoryBackupFolder, "backup folder")) return false;
            if (!PrepareFolders(RepositoryDefinitionsFolder, "definitions folder")) return false;
            if (!PrepareFolders(RepositoryDownloadFolder, "download folder")) return false;

            if (!PrepareFolders(RepositoryVersionFilesFolder(selectedVersion), "version files folder")) return false;
            if (!PrepareFolders(RepositoryVersionDefinitionsFolder(selectedVersion), "version definitions folder")) return false;

            return true;
        }

        public override bool FolderExists(string folder)
        {
            return mFtpClient.DirectoryExists(folder);
        }

        public override void CreateFolder(string folder)
        {
            mFtpClient.CreateDirectory(folder);
        }

        public override bool UploadFile(string originFile, string destinationFolder, string destinationFile)
        {
            return mFtpClient.UploadFile(originFile, destinationFolder, destinationFile);
        }

        public override bool ReplaceFile(string remoteDirectory, string currentFileName, string newFileName)
        {
            if (mFtpClient.FileExists(remoteDirectory, newFileName)) mFtpClient.DeleteFile(remoteDirectory, newFileName);
            mFtpClient.RenameFile(remoteDirectory, currentFileName, newFileName);
            return mFtpClient.FileExists(remoteDirectory, newFileName);
        }

        public override bool UploadTestFile()
        {
            if (!PrepareFolders("", "root folder")) return false;

            try
            {
                var tResult = false;
                //Check if the directory exists
                RaiseMessageChangedEvent("Check if FTP test directory exists .... ");
                tResult = FolderExists(mFTPTestFolder);
                RaiseMessageChangedEvent($"Check if FTP test directory exists .... {tResult}", true);

                //Create the directory if it does not exist
                if (!tResult)
                {
                    RaiseMessageChangedEvent("Creating FTP test directory .... ");
                    CreateFolder(mFTPTestFolder);
                    tResult = !mFtpClient.HasError;
                    RaiseMessageChangedEvent($"Creating FTP test directory .... {tResult}", true);
                }

                //Upload the test file to the server
                if (tResult)
                {
                    var tTestApp = Path.Combine(Application.StartupPath, "Test.html");
                    RaiseMessageChangedEvent($"Uploading the test file to FTP test directory .... ");
                    tResult = UploadFile(tTestApp, mFTPTestFolder, "Test.html");
                    RaiseMessageChangedEvent($"Uploading the test file to FTP test directory .... {tResult.ToString()}", true);
                }

                return true;
            }
            catch (Exception ex)
            {
                RaiseMessageChangedEvent($"An error occurred: {ex.Message}");
                return false;
            }
        }

        public override async Task<bool> DownloadTestFileAsync(string localTestFolder)
        {
            var tResult = false;
            try
            {
                string tLocalTestDirectory = Path.Combine(Application.StartupPath, localTestFolder);
                string tLocalTestFile = Path.Combine(tLocalTestDirectory, "Test.html");

                //Create local Test folder
                RaiseMessageChangedEvent($"Creating local test directory .... ");
                if (!Directory.Exists(tLocalTestDirectory))
                {
                    Directory.CreateDirectory(tLocalTestDirectory);
                }

                RaiseMessageChangedEvent($"Creating local test directory .... {true}", true);

                RaiseMessageChangedEvent($"Downloading the test file to local test directory .... ");

                await DownloadFileAsync(mFTPTestFolder, "Test.html", tLocalTestFile);

                tResult = File.Exists(tLocalTestFile);
                RaiseMessageChangedEvent($"Downloading the test file to local test directory .... {true}", true);

                if (tResult)
                {
                    RaiseMessageChangedEvent($"Comparing the two files .... ");
                    var tOriginal = Path.Combine(Application.StartupPath, "Test.html");
                    var tOriginalMD5 = tOriginal.GenerateFileMD5();
                    var tTestMD5 = tLocalTestFile.GenerateFileMD5();
                    tResult = tTestMD5 == tOriginalMD5;
                    RaiseMessageChangedEvent($"Comparing the two files .... {tResult}", true);
                }
            }
            catch (Exception ex)
            {
                tResult = false;
                RaiseMessageChangedEvent($"An error occurred: {ex.Message}");
            }

            return tResult;
        }

        public override bool TestCleaningUp(string localTestFolder)
        {
            try
            {
                var tLocalTestDirectory = Path.Combine(Application.StartupPath, localTestFolder);
                var tLocalTestFile = Path.Combine(tLocalTestDirectory, "Test.html");

                //=================================================================================================================================
                //Delete local test file
                RaiseMessageChangedEvent($"Delete local test file .... ");
                if (File.Exists(tLocalTestFile))
                {
                    SAUpdaterFile.Delete(tLocalTestFile);
                }

                RaiseMessageChangedEvent($"Delete local test file .... {true}", true);

                //Delete test directory
                RaiseMessageChangedEvent($"Delete local test directory .... ");
                if (Directory.Exists(tLocalTestDirectory))
                {
                    SAUpdaterFolder.Delete(tLocalTestDirectory);
                }

                RaiseMessageChangedEvent($"Delete local test directory .... {true}", true);

                //=================================================================================================================================
                //FTP Cleanup
                var wFTP = new SAUpdaterFTPClient(RepositoryRootFolderUri, RepositoryConfig.FTPUsername, RepositoryConfig.FTPPassword);

                //Delete test FTP directory
                RaiseMessageChangedEvent("Delete FTP test directory .... ");
                if (wFTP.FileExists(mFTPTestFolder, "Test.html"))
                {
                    wFTP.DeleteFile(mFTPTestFolder, "Test.html");
                }

                RaiseMessageChangedEvent($"Delete FTP test directory .... {true}", true);

                return true;
            }
            catch (Exception ex)
            {
                RaiseMessageChangedEvent($"An error occurred: {ex.Message}");
                return false;
            }
        }

        public override bool CleanUp(string selectedVersion)
        {
            var tSuccess = mFtpClient.RemoveDirectory(RepositoryVersionFilesFolder(selectedVersion));
            if (!tSuccess) return false;
            tSuccess = mFtpClient.RemoveDirectory(RepositoryVersionDefinitionsFolder(selectedVersion));
            return tSuccess;
        }

        #endregion Methods

        #region Private Methods

        private bool PrepareFolders(string folder, string folderDescription)
        {
            try
            {
                //Check if the directory exists
                RaiseMessageChangedEvent($"Check if FTP {folderDescription} exists .... ");
                var tResult = FolderExists(folder);

                //Create the root directory if it does not exist
                if (!tResult)
                {
                    RaiseMessageChangedEvent($"Check if FTP {folderDescription} exists .... {tResult}", true);
                    RaiseMessageChangedEvent($"Trying to create FTP {folderDescription} .... ");
                    CreateFolder(folder);
                    RaiseMessageChangedEvent($"Check if FTP {folderDescription} exists .... ");
                    tResult = FolderExists(folder);
                }

                RaiseMessageChangedEvent($"Check if FTP {folderDescription} exists .... {tResult}", true);
                if (!tResult)
                {
                    throw new Exception($"Could not create {folderDescription}");
                }

                return tResult;
            }
            catch (Exception ex)
            {
                RaiseMessageChangedEvent($"An error occurred: {ex.Message}");
                return false;
            }
        }

        #endregion Private Methods
    }
}