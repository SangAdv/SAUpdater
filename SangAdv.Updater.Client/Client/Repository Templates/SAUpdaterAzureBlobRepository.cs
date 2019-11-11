using SangAdv.Updater.Common;
using System;
using System.Threading.Tasks;

namespace SangAdv.Updater.Client
{
    internal class SAUpdaterAzureBlobRepository : ASAUpdaterAzureBlobBaseRepository
    {
        #region Variables

        private SAUpdaterFileDownload mDownload;

        #endregion Variables

        #region Abstract Properties

        public override Uri RepositoryRootFolderUri => new Uri(RepositoryConfig.FTPDownloadUri);

        public override SAUpdaterRepositoryType RepositoryType => SAUpdaterRepositoryType.AzureBlob;

        #endregion Abstract Properties

        #region Constructor

        public SAUpdaterAzureBlobRepository(string downloadServerUri, string applicationFolder)
        {
            RepositoryConfig.FTPDownloadUri = new Uri(new Uri(downloadServerUri.FixURLDirectoryLink()), new Uri(applicationFolder.FixURLDirectoryLink(), UriKind.Relative)).ToString();
            mDownload = new SAUpdaterFileDownload(RepositoryRootFolderUri);
        }

        #endregion Constructor

        #region Methods

        #region Not Implemeneted in Client

        public override bool PrepareFolders(string selectedVersion)
        {
            throw new NotImplementedException();
        }

        public override bool FolderExists(string folder)
        {
            throw new NotImplementedException();
        }

        public override void CreateFolder(string folder)
        {
            throw new NotImplementedException();
        }

        public override bool UploadFile(string originFile, string destinationFolder, string destinationFile)
        {
            throw new NotImplementedException();
        }

        public override bool ReplaceFile(string remoteDirectory, string currentFileName, string newFileName)
        {
            throw new NotImplementedException();
        }

        public override bool UploadTestFile()
        {
            throw new NotImplementedException();
        }

        public override Task<bool> DownloadTestFileAsync(string localTestFolder)
        {
            throw new NotImplementedException();
        }

        public override bool TestCleaningUp(string localTestFolder)
        {
            throw new NotImplementedException();
        }

        public override bool CleanUp(string selectedVersion)
        {
            throw new NotImplementedException();
        }

        #endregion Not Implemeneted in Client

        public override async Task<string> DownloadFileContentsAsync(string remoteDirectory, string remoteFileName)
        {
            Error.ClearErrorMessage();
            try
            {
                return await mDownload.DownloadFileToStringAsync(remoteDirectory, remoteFileName.ToUpper());
            }
            catch (Exception ex)
            {
                Error.SetErrorMessage(ex.Message);
                return string.Empty;
            }
        }

        public override async Task<bool> DownloadFileAsync(string remoteDirectory, string remoteFileName, string destinationFilename)
        {
            var tSuccess = false;
            Error.ClearErrorMessage();
            try
            {
                mDownload.ProgressChanged += RaiseFileDownloadProgressChangedEvent;

                tSuccess = await mDownload.DownloadFileAsync(remoteDirectory, remoteFileName.ToUpper(), destinationFilename);

                mDownload.ProgressChanged -= RaiseFileDownloadProgressChangedEvent;
            }
            catch (Exception ex)
            {
                Error.SetErrorMessage(ex.Message);
                tSuccess = false;
            }

            return tSuccess;
        }

        public override string DownloadFileContents(string remoteDirectory, string remoteFileName)
        {
            Error.ClearErrorMessage();
            try
            {
                return mDownload.DownloadFileToString(remoteDirectory, remoteFileName.ToUpper());
            }
            catch (Exception ex)
            {
                Error.SetErrorMessage(ex.Message);
                return string.Empty;
            }
        }

        public override bool DownloadFile(string remoteDirectory, string remoteFileName, string destinationFilename)
        {
            var tSuccess = false;
            Error.ClearErrorMessage();
            try
            {
                mDownload.ProgressChanged += RaiseFileDownloadProgressChangedEvent;

                tSuccess = mDownload.DownloadFile(remoteDirectory, remoteFileName.ToUpper(), destinationFilename);

                mDownload.ProgressChanged -= RaiseFileDownloadProgressChangedEvent;
            }
            catch (Exception ex)
            {
                Error.SetErrorMessage(ex.Message);
                tSuccess = false;
            }

            return tSuccess;
        }

        #endregion Methods
    }
}