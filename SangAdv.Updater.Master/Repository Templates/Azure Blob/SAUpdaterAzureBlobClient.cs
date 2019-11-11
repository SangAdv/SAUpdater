using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Core.Util;
using SangAdv.Common;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace SangAdv.Updater.Common
{
    public class SAUpdaterAzureBlobClient : SAUpdaterErrorBase
    {
        #region Events

        public event UpdaterIntegerDelegate UploadProgressChanged = i => { };

        #endregion Events

        #region Variables

        internal string mBlobConnString;
        internal string mAzureContainer;
        private string mContainerFolder;
        private volatile int mFilestreamSize;
        private volatile int mPercentage = 0;
        private CloudBlobContainer mBlobContainer;
        internal FileProgress mFileProgress;

        #endregion Variables

        #region Constructor

        public SAUpdaterAzureBlobClient(string blobConnString, string azureContainerName, string containerFolder)
        {
            mBlobConnString = blobConnString;
            mAzureContainer = azureContainerName;
            mContainerFolder = containerFolder;

            mBlobContainer = SAAsyncHelper.RunSync(GetCloudBlobContainerAsync);
        }

        #endregion Constructor

        #region Methods

        public void DeleteFile(string remoteDirectory, string deleteFile)
        {
            SAUpdaterAsyncHelper.RunSync<SAEventArgs>(() => DeleteAsync(remoteDirectory, deleteFile));
        }

        public void RenameFile(string remoteDirectory, string currentFileName, string newFileName)
        {
            SAUpdaterAsyncHelper.RunSync<SAEventArgs>(() => MoveAsync(remoteDirectory, currentFileName.ToUpper(), remoteDirectory, newFileName.ToUpper()));
        }

        public bool DirectoryExists(string checkDirectory)
        {
            //throw new NotImplementedException();
            return true;
        }

        public void CreateDirectory(string newDirectory)
        {
            throw new NotImplementedException();
        }

        public bool RemoveDirectory(string deleteDirectory)
        {
            throw new NotImplementedException();
        }

        public string GetFileCreatedDateTime(string remoteDirectory, string fileName)
        {
            throw new NotImplementedException();
        }

        public bool FileExists(string remoteDirectory, string fileName)
        {
            try
            {
                var blob = GetCloudBlockBlob(remoteDirectory, fileName);
                var exists = blob.Exists();
                return exists;
            }
            catch
            {
                return false;
            }
        }

        public long GetFileSize(string remoteDirectory, string fileName)
        {
            throw new NotImplementedException();
        }

        public bool UploadFile(string originFilePath, string remoteDirectory, string remoteFile, int kbPacketSize = 64)
        {
            var result = SAUpdaterAsyncHelper.RunSync<SAEventArgs>(() => UploadAsync(originFilePath, remoteDirectory, remoteFile));
            return result.IsSuccess;
        }

        public string[] DirectoryListSimple(string directory)
        {
            throw new NotImplementedException();
        }

        public string[] DirectoryListDetailed(string directory)
        {
            throw new NotImplementedException();
        }

        public async Task<SAEventArgs> UploadAsync(string originalFileName, string cloudDirectory, string blobFilename)
        {
            try
            {
                var progressHandler = new Progress<StorageProgress>(ProgressHandler);
                var progress = (IProgress<StorageProgress>)progressHandler;

                var blob = GetCloudBlockBlob(cloudDirectory, blobFilename);
                if (blob == null) throw new Exception("Blob could not be created.");

                await blob.DeleteIfExistsAsync();

                var fi = new FileInfo(originalFileName);

                mFileProgress = new FileProgress(fi.Length);
                mFileProgress.ProgressChanged += UploadProgressChanged;

                await blob.UploadFromFileAsync(originalFileName, null, null, null, progress, CancellationToken.None);

                mFileProgress.ProgressChanged -= UploadProgressChanged;

                return new SAEventArgs();
            }
            catch (Exception ex)
            {
                return new SAEventArgs(ex.Message, SAResults.Cloud.BlobUploadError);
            }
        }

        public async Task<SAEventArgs> DeleteAsync(string cloudDirectory, string blobFilename)
        {
            try
            {
                var blob = GetCloudBlockBlob(cloudDirectory, blobFilename);
                await blob.DeleteAsync();
                return new SAEventArgs();
            }
            catch (Exception ex)
            {
                return new SAEventArgs(ex.Message, SAResults.Cloud.BlobDownloadError);
            }
        }

        public async Task<SAEventArgs> MoveAsync(string sourceCloudDirectory, string sourceFilename, string destinationCloudDirectory, string destinationFilename)
        {
            var result = await CopyAsync(sourceCloudDirectory, sourceFilename, destinationCloudDirectory, destinationFilename).ConfigureAwait(false);
            if (result.HasError) return new SAEventArgs(result.Message, SAResults.General.Error);

            return await DeleteAsync(sourceCloudDirectory, sourceFilename).ConfigureAwait(false);
        }

        public async Task<SAUpdaterEventArgs> CopyAsync(string sourceCloudDirectory, string sourceFilename, string destinationCloudDirectory, string destinationFilename)
        {
            Error.ClearErrorMessage();
            try
            {
                var sourceBlob = GetCloudBlockBlob(sourceCloudDirectory, sourceFilename);
                if (sourceBlob == null) throw new Exception("Source does not exist");

                var destinationBlob = GetCloudBlockBlob(destinationCloudDirectory, destinationFilename);
                if (destinationBlob == null) throw new Exception("Destination could not be defined");

                await CopyAsync(sourceBlob, destinationBlob);

                if (Error.HasError) throw new Exception(ErrorMessage);
            }
            catch (Exception ex)
            {
                Error = new SAUpdaterEventArgs(ex.Message, SAUpdaterResults.GeneralError);
            }

            return Error;
        }

        #endregion Methods

        #region Private Methods

        private async Task<CloudBlobContainer> GetCloudBlobContainerAsync()
        {
            Error.ClearErrorMessage();
            try
            {
                //Get the reference of the Storage Account
                var storageAccount = CloudStorageAccount.Parse(mBlobConnString);

                //Get the reference of the Storage Blob
                var blobClient = storageAccount.CreateCloudBlobClient();

                //Get the reference of the Container.
                var blobContainer = blobClient.GetContainerReference(mAzureContainer);
                //If the container does not exist, we need to create it.
                if (await blobContainer.CreateIfNotExistsAsync())
                {
                    //Let us put public permissions on the container so we can access the file from anywhere.
                    await blobContainer.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Container });
                }

                return blobContainer;
            }
            catch (Exception ex)
            {
                Error = new SAUpdaterEventArgs(ex.Message, SAUpdaterResults.GeneralError);
                return null;
            }
        }

        private void ProgressHandler(StorageProgress progress)
        {
            if (mFileProgress == null) return;

            mFileProgress.BytesTransferred = progress.BytesTransferred;
        }

        private CloudBlockBlob GetCloudBlockBlob(string cloudDirectory, string fileName)
        {
            try
            {
                if (string.IsNullOrEmpty(cloudDirectory)) return mBlobContainer?.GetBlockBlobReference(fileName.ToUpper().Trim());
                return GetCloudBlobDirectory(cloudDirectory)?.GetBlockBlobReference(fileName.ToUpper().Trim());
            }
            catch (Exception ex)
            {
                Error = new SAUpdaterEventArgs(ex.Message, SAUpdaterResults.GeneralError);
                return null;
            }
        }

        private CloudBlobDirectory GetCloudBlobDirectory(string directoryName)
        {
            Error.ClearErrorMessage();
            try
            {
                if (mBlobContainer == null) throw new Exception("Cloud container not defined");
                return mBlobContainer.GetDirectoryReference(directoryName);
            }
            catch (Exception ex)
            {
                Error = new SAUpdaterEventArgs(ex.Message, SAUpdaterResults.GeneralError);
                return null;
            }
        }

        private async Task CopyAsync(CloudBlockBlob sourceBlob, CloudBlockBlob destinationBlob)
        {
            Error.ClearErrorMessage();
            try
            {
                if (sourceBlob == null) throw new Exception("Source blob cannot be null.");

                if (destinationBlob == null) throw new Exception("Destination container does not exist.");

                //Copy source blob to destination container
                await destinationBlob.StartCopyAsync(sourceBlob);
            }
            catch (Exception ex)
            {
                Error = new SAUpdaterEventArgs(ex.Message, SAUpdaterResults.GeneralError);
            }
        }

        #endregion Private Methods

        #region Classes

        internal class FileProgress
        {
            #region Events

            public event UpdaterIntegerDelegate ProgressChanged = (i) => { };

            #endregion Events

            #region Variables

            private readonly long mFileLengthBytes = 0;
            private long mCurrentPercentage = 0;

            #endregion Variables

            #region Properties

            public long BytesTransferred
            {
                set
                {
                    var newPercentage = (value.Value<float>() / mFileLengthBytes.Value<float>() * 100).Value<int>();

                    if (newPercentage == mCurrentPercentage) return;

                    mCurrentPercentage = newPercentage;
                    ProgressChanged(newPercentage);
                }
            }

            #endregion Properties

            #region Constructor

            public FileProgress(long fileLengthBytes)
            {
                mFileLengthBytes = fileLengthBytes;
            }

            #endregion Constructor
        }

        #endregion Classes
    }
}