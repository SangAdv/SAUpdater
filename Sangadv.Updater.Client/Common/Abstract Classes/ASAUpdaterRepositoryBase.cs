using System;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;

namespace SangAdv.Updater.Common
{
    [Browsable(false)]
    public abstract class ASAUpdaterRepositoryBase : SAUpdaterErrorBase
    {
        #region Events

        public event UpdaterStringBooleanDelegate MessageChanged = (s, b) => { };

        public event UpdaterIntegerDelegate FileDownloadProgressChanged = i => { };

        public event UpdaterIntegerDelegate FileUploadProgressChanged = i => { };

        public void RaiseMessageChangedEvent(string message, bool removeLastEntry = false) => MessageChanged(message, removeLastEntry);

        public void RaiseFileDownloadProgressChangedEvent(int percentage) => FileDownloadProgressChanged(percentage);

        public void RaiseFileUploadProgressChangedEvent(int percentage) => FileUploadProgressChanged(percentage);

        #endregion Events

        #region Variables

        internal bool mConnected;

        #endregion Variables

        #region Abstract Properties

        public abstract SAUpdaterRepositoryType RepositoryType { get; }

        #endregion Abstract Properties

        #region Properties

        public string RepositoryBackupFolder => "backup";
        public string RepositoryDefinitionsFolder => "definitions";
        public string RepositoryDownloadFolder => "download";

        public bool HasUpdateDefinition { get; private set; } = false;
        public SAUpdateDefinitionItem UpdateDefinition { get; private set; } = new SAUpdateDefinitionItem();

        public SAUpdaterFileList UpdateFiles { get; } = new SAUpdaterFileList();

        #endregion Properties

        #region Methods

        public string RepositoryVersionDefinitionsFolder(string selectedVersion)
        {
            switch (RepositoryType)
            {
                case SAUpdaterRepositoryType.FTP: return Path.Combine(selectedVersion, "definitions");
                case SAUpdaterRepositoryType.AzureBlob: return $"{selectedVersion}/definitions";
            }

            return null;
        }

        public string RepositoryVersionFilesFolder(string selectedVersion)
        {
            switch (RepositoryType)
            {
                case SAUpdaterRepositoryType.FTP: return Path.Combine(selectedVersion, "files");
                case SAUpdaterRepositoryType.AzureBlob: return $"{selectedVersion}/files";
            }

            return null;
        }

        public bool Connected(bool checkConnection)
        {
            if (!checkConnection)
            {
                return mConnected;
            }

            mConnected = ConnectionChecker();
            return mConnected;
        }

        public void SetUpdateFileList(string selectedVersion)
        {
            Error.ClearErrorMessage();
            try
            {
                var tFileName = DefinitionFileName(SAUpdaterDefinitionType.Files);
                var tDestinationFilename = Path.Combine(SAUpdaterGlobal.Master.UploadFolder, tFileName);
                if (HasError) return;

                if (!SAUpdaterFile.Delete(tDestinationFilename)) throw new Exception($"Could not delete {tDestinationFilename}");
                SAUpdaterFile.Write(tDestinationFilename, UpdateFiles.ToString(), true);

                UploadFile(tDestinationFilename, RepositoryVersionDefinitionsFolder(selectedVersion), tFileName);
            }
            catch (Exception ex)
            {
                Error.SetErrorMessage(ex.Message);
            }
        }

        public async Task<bool> GetUpdateFileListAsync(string selectedVersion)
        {
            Error.ClearErrorMessage();
            try
            {
                var tResult = await DownloadFileContentsAsync(RepositoryVersionDefinitionsFolder(selectedVersion), SAUpdaterConstants.RepositoryUpdateFilesFileName);
                if (string.IsNullOrEmpty(tResult)) return false;
                tResult = tResult.InflateString();
                UpdateFiles.FromString(tResult);
                return true;
            }
            catch (Exception ex)
            {
                Error.SetErrorMessage(ex.Message);
                return false;
            }
        }

        public void SetNotes(string selectedVersion, string content)
        {
            Error.ClearErrorMessage();
            try
            {
                var tFileName = DefinitionFileName(SAUpdaterDefinitionType.Notes);
                var tDestinationFilename = Path.Combine(SAUpdaterGlobal.Master.UploadFolder, tFileName);
                if (HasError) return;

                if (!SAUpdaterFile.Delete(tDestinationFilename)) throw new Exception($"Could not delete {tDestinationFilename}");
                SAUpdaterFile.Write(tDestinationFilename, content, true);

                UploadFile(tDestinationFilename, RepositoryVersionDefinitionsFolder(selectedVersion), tFileName);
            }
            catch (Exception ex)
            {
                Error.SetErrorMessage(ex.Message);
            }
        }

        public async Task<string> GetNotesAsync(string selectedVersion)
        {
            return (await DownloadFileContentsAsync(RepositoryVersionDefinitionsFolder(selectedVersion), SAUpdaterConstants.RepositoryUpdateNotesFileName)).InflateString();
        }

        public void SetUpdateDefinition()
        {
            Error.ClearErrorMessage();
            try
            {
                var tDestinationFilename = Path.Combine(SAUpdaterGlobal.Master.UploadFolder, SAUpdaterConstants.RepositoryUpdateDefinitionFileName);
                if (HasError) return;

                if (!SAUpdaterFile.Delete(tDestinationFilename)) throw new Exception($"Could not delete {tDestinationFilename}");
                SAUpdaterFile.Write(tDestinationFilename, UpdateDefinition.ToString(), true);

                UploadFile(tDestinationFilename, RepositoryDefinitionsFolder, SAUpdaterConstants.RepositoryUpdateDefinitionFileName);
            }
            catch (Exception ex)
            {
                Error.SetErrorMessage(ex.Message);
            }
        }

        public async Task<bool> GetUpdateDefinitionAsync()
        {
            Error.ClearErrorMessage();
            try
            {
                UpdateDefinition = new SAUpdateDefinitionItem();
                var tResult = await DownloadFileContentsAsync(RepositoryDefinitionsFolder, SAUpdaterConstants.RepositoryUpdateDefinitionFileName);

                SAUpdaterGlobal.AddLog("ASAUpdaterRepositoryBase", "GetUpdateDefinition", $"Raw Update Definition: {tResult}");

                if (string.IsNullOrEmpty(tResult))
                {
                    UpdateDefinition.Reset();
                    Error.SetErrorMessage("Could not read repository update file");
                    return false;
                }

                tResult = tResult.InflateString();
                SAUpdaterGlobal.AddLog("ASAUpdaterRepositoryBase", "GetUpdateDefinition", $"Inflated Update Definition: {tResult}");

                UpdateDefinition.FromString(tResult);
                HasUpdateDefinition = true;
                return true;
            }
            catch (Exception ex)
            {
                Error.SetErrorMessage(ex.Message);
                return false;
            }
        }

        public bool GetUpdateDefinition()
        {
            Error.ClearErrorMessage();
            try
            {
                UpdateDefinition = new SAUpdateDefinitionItem();
                var tResult = DownloadFileContents(RepositoryDefinitionsFolder, SAUpdaterConstants.RepositoryUpdateDefinitionFileName);

                SAUpdaterGlobal.AddLog("ASAUpdaterRepositoryBase", "GetUpdateDefinition", $"Raw Update Definition: {tResult}");

                if (string.IsNullOrEmpty(tResult))
                {
                    UpdateDefinition.Reset();
                    Error.SetErrorMessage("Could not read repository update file");
                    return false;
                }

                tResult = tResult.InflateString();
                SAUpdaterGlobal.AddLog("ASAUpdaterRepositoryBase", "GetUpdateDefinition", $"Inflated Update Definition: {tResult}");

                UpdateDefinition.FromString(tResult);
                HasUpdateDefinition = true;
                return true;
            }
            catch (Exception ex)
            {
                Error.SetErrorMessage(ex.Message);
                return false;
            }
        }

        #endregion Methods

        #region Abstract Methods

        public abstract bool ConnectionChecker();

        #region Folder

        public abstract bool PrepareFolders(string selectedVersion);

        public abstract bool FolderExists(string folder);

        public abstract void CreateFolder(string folder);

        #endregion Folder

        #region File

        public abstract bool UploadFile(string originFile, string destinationFolder, string destinationFile);

        public abstract bool ReplaceFile(string remoteDirectory, string currentFileName, string newFileName);

        public abstract Task<string> DownloadFileContentsAsync(string remoteDirectory, string remoteFileName);

        public abstract string DownloadFileContents(string remoteDirectory, string remoteFileName);

        public abstract Task<bool> DownloadFileAsync(string remoteDirectory, string remoteFileName, string destinationFilename);

        public abstract bool DownloadFile(string remoteDirectory, string remoteFileName, string destinationFilename);

        #endregion File

        #region Testing

        public abstract bool UploadTestFile();

        public abstract Task<bool> DownloadTestFileAsync(string localTestFolder);

        public abstract bool TestCleaningUp(string localTestFolder);

        #endregion Testing

        #region Clean Up

        public abstract bool CleanUp(string selectedVersion);

        #endregion Clean Up

        #endregion Abstract Methods

        #region Private Methods

        internal string DefinitionFileName(SAUpdaterDefinitionType type)
        {
            Error.ClearErrorMessage();
            try
            {
                var tString = string.Empty;
                switch (type)
                {
                    case SAUpdaterDefinitionType.Notes: tString = SAUpdaterConstants.RepositoryUpdateNotesFileName; break;
                    case SAUpdaterDefinitionType.Files: tString = SAUpdaterConstants.RepositoryUpdateFilesFileName; break;
                }

                return tString;
            }
            catch (Exception ex)
            {
                Error.SetErrorMessage(ex.Message);
                return string.Empty;
            }
        }

        #endregion Private Methods
    }

    //Config Templates
    public class SAHFTPRepositoryConfig
    {
        public string FTPServer { get; set; } = string.Empty;
        public string ApplicationFolder { get; set; } = string.Empty;
        public string FTPUsername { get; set; } = string.Empty;
        public string FTPPassword { get; set; } = string.Empty;
        public string FTPDownloadUri { get; set; } = @"http://www.google.com";
    }

    public class SAHAzureBlobRepositoryConfig
    {
        public string AzureBlobConnectionString { get; set; } = string.Empty;
        public string AzureBlobContainerName { get; set; } = string.Empty;
        public string ApplicationFolder { get; set; } = string.Empty;
        public string FTPDownloadUri { get; set; } = @"http://www.google.com";
    }
}