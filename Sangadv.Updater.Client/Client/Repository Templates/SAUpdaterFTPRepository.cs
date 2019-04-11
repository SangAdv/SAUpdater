﻿using SangAdv.Updater.Common;
using System;
using System.Threading.Tasks;

namespace SangAdv.Updater.Client
{
    public class SAUpdaterFTPRepository : ASAUpdaterFTPBaseRepository
    {
        #region Variables

        private SAUpdaterFileDownload mDownload;

        #endregion Variables

        #region Abstract Properties

        public override Uri RepositoryRootFolderUri => new Uri(RepositoryConfig.FTPDownloadUri);

        #endregion Abstract Properties

        #region Constructor

        public SAUpdaterFTPRepository(string downloadServerUri, string applicationFolder)
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

        public override string DownloadFileContents(string remoteDirectory, string remoteFileName)
        {
            Error.ClearErrorMessage();
            try
            {
                return mDownload.DownloadFileToString(remoteDirectory, remoteFileName);
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

                tSuccess = await mDownload.DownloadFileAsync(remoteDirectory, remoteFileName, destinationFilename);

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