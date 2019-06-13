using SangAdv.Updater.Common;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace SangAdv.Updater.Client
{
    public class SAUpdaterInstaller : SAUpdaterErrorBase
    {
        #region Events

        public event UpdaterStringDelegate MessageChanged = s => { };

        public event UpdaterIntegerDelegate FileDownloadProgressChanged = i => { };

        internal void RaiseFileDownloadProgressChangedEvent(int percentage) => FileDownloadProgressChanged(percentage);

        #endregion Events

        #region Variables

        private bool mHasInstaller = false;
        private bool mDoInstallerUpdate = false;

        #endregion Variables

        #region Properties

        public SAUpdaterFrameworkVersions InstallerRequiredFramework { get; private set; } = SAUpdaterFrameworkVersions.None;
        public SAUpdaterWinOSVersion InstallerRequiredOsVersion { get; private set; } = SAUpdaterWinOSVersion.Win7;
        public bool Connected => SAUpdaterGlobal.Connected;
        internal bool HasLocalInstaller => SAUpdaterClient.IsInitialised && File.Exists(SAUpdaterGlobal.Client.FullInstallerFilename(SAUpdaterGlobal.Options.InstallerFilename));

        internal bool HasInstaller
        {
            get => SAUpdaterClient.IsInitialised && mHasInstaller;
            private set => mHasInstaller = value;
        }

        internal bool HasNewInstallerRelease => SAUpdaterClient.IsInitialised && getHasNewInstaller();

        public bool DoInstallerUpdate
        {
            get => SAUpdaterClient.IsInitialised && mDoInstallerUpdate;
            private set => mDoInstallerUpdate = value;
        }

        #endregion Properties

        #region Methods

        internal void CheckHasInstaller()
        {
            Error.ClearErrorMessage();
            mDoInstallerUpdate = false;

            SAUpdaterGlobal.AddLog("SAUpdaterInstaller", "CheckHasInstaller", $"Has Repository Update Definition: {SAUpdaterGlobal.Repository.HasUpdateDefinition}");

            SAUpdaterGlobal.AddLog("SAUpdaterInstaller", "CheckHasInstaller", $"Repository Installer Version: {SAUpdaterGlobal.Repository.UpdateDefinition.InstallerVersion}");

            //Check if there is a published installer on the repository
            mHasInstaller = SAUpdaterGlobal.Repository.UpdateDefinition.InstallerVersion != SAUpdaterConstants.NoVersion;
            if (!HasInstaller)
            {
                Error = new SAUpdaterEventArgs("A valid installer could not be found", SAUpdaterResults.InstallerUpdateAvailable);
                return;
            }

            //Check if there is an installer installed locally
            if (!HasLocalInstaller)
            {
                Error = new SAUpdaterEventArgs("A valid installer could not be found locally", SAUpdaterResults.InstallerUpdateAvailable);
                mDoInstallerUpdate = true;
                return;
            }

            //Update the client details if they were deleted and the client version matches the repository version
            var tClientVersion = FileVersionInfo.GetVersionInfo(SAUpdaterGlobal.Client.FullInstallerFilename(SAUpdaterGlobal.Options.InstallerFilename)).FileVersion;
            if (tClientVersion == SAUpdaterGlobal.Repository.UpdateDefinition.InstallerVersion)
            {
                if (SAUpdaterGlobal.Client.FullInstallerFilename(SAUpdaterGlobal.Options.InstallerFilename).GenerateFileMD5() == SAUpdaterGlobal.Repository.UpdateDefinition.InstallerMD5) UpdateClientDefinition();
            }

            if (HasNewInstallerRelease)
            {
                Error = new SAUpdaterEventArgs("An installer update is available", SAUpdaterResults.InstallerUpdateAvailable);
                mDoInstallerUpdate = true;
            }
        }

        public async Task<bool> UpdateAsync()
        {
            Error.ClearErrorMessage();
            //Download the compressed installer file
            MessageChanged("Downloading installer archive ...");
            await DownloadInstallerAsync();
            if (HasError)
            {
                MessageChanged($"Error occurred: {ErrorMessage}");
                return false;
            }

            return completeUpdate();
        }

        public bool Update()
        {
            Error.ClearErrorMessage();
            //Download the compressed installer file
            MessageChanged("Downloading installer archive ...");
            DownloadInstaller();
            if (HasError)
            {
                MessageChanged($"Error occurred: {ErrorMessage}");
                return false;
            }

            return completeUpdate();
        }

        public void SetInstallerRequirements(SAUpdaterWinOSVersion osVersion, SAUpdaterFrameworkVersions framework)
        {
            InstallerRequiredFramework = framework;
            InstallerRequiredOsVersion = osVersion;
        }

        #endregion Methods

        #region Private Methods

        private bool completeUpdate()
        {
            //Extract the installer to a temp file
            MessageChanged("Extracting installer archive ...");
            ExtractInstaller();
            if (HasError)
            {
                MessageChanged($"Error occurred: {ErrorMessage}");
                return false;
            }

            //Move installer into place
            MessageChanged("Moving installer archive ...");
            MoveExtractedInstaller();
            if (HasError)
            {
                MessageChanged($"Error occurred: {ErrorMessage}");
                return false;
            }

            //Update the local update definition with the new data
            UpdateClientDefinition();

            MessageChanged(HasError ? $"Error occurred: {ErrorMessage}" : "Installer installed successfully");

            return Error.IsSuccess;
        }

        private bool getHasNewInstaller()
        {
            if (!File.Exists(SAUpdaterGlobal.Client.FullInstallerFilename(SAUpdaterGlobal.Options.InstallerFilename))) return true;
            var tNewVersion = SAUpdaterGlobal.Repository.UpdateDefinition.InstallerVersion.IsNewerVersion(SAUpdaterGlobal.Client.UpdateDefinition.InstallerVersion);
            if (tNewVersion) return true;
            if (SAUpdaterGlobal.Repository.UpdateDefinition.InstallerMD5 != SAUpdaterGlobal.Client.FullInstallerFilename(SAUpdaterGlobal.Options.InstallerFilename).GenerateFileMD5()) return true;
            return false;
        }

        private void UpdateClientDefinition()
        {
            var tData = SAUpdaterGlobal.Repository.UpdateDefinition;
            SAUpdaterGlobal.Client.UpdateDefinition.SetInstallerProperties(tData.InstallerVersion, tData.InstallerMD5, tData.InstallerCompressedMD5);
            SAUpdaterGlobal.Client.SaveUpdateDefinition();
        }

        private async Task DownloadInstallerAsync()
        {
            //var t = SAUpdaterGlobal.Client.CompressedInstallerFilename(SAUpdaterGlobal.Options.InstallerFilename);

            if (File.Exists(SAUpdaterGlobal.Client.CompressedInstallerFilename(SAUpdaterGlobal.Options.InstallerFilename))) File.Delete(SAUpdaterGlobal.Client.CompressedInstallerFilename(SAUpdaterGlobal.Options.InstallerFilename));

            SAUpdaterGlobal.Repository.FileDownloadProgressChanged += RaiseFileDownloadProgressChangedEvent;

            await SAUpdaterGlobal.Repository.DownloadFileAsync(SAUpdaterGlobal.Repository.RepositoryDownloadFolder, $"{SAUpdaterGlobal.Options.InstallerFilename}.ZIP", SAUpdaterGlobal.Client.CompressedInstallerFilename(SAUpdaterGlobal.Options.InstallerFilename));

            SAUpdaterGlobal.Repository.FileDownloadProgressChanged -= RaiseFileDownloadProgressChangedEvent;

            if (SAUpdaterGlobal.Repository.HasError)
            {
                Error = SAUpdaterGlobal.Repository.Error;
                return;
            }

            if (!File.Exists(SAUpdaterGlobal.Client.CompressedInstallerFilename(SAUpdaterGlobal.Options.InstallerFilename)))
            {
                Error = new SAUpdaterEventArgs("Failed to download installer", SAUpdaterResults.FilesFolderMissing);
                return;
            }

            if (SAUpdaterGlobal.Client.CompressedInstallerFilename(SAUpdaterGlobal.Options.InstallerFilename).GenerateFileMD5() != SAUpdaterGlobal.Repository.UpdateDefinition.InstallerCompressedMD5) Error = new SAUpdaterEventArgs("Installer signature does not match repository signature", SAUpdaterResults.DownloadError);
        }

        private void DownloadInstaller()
        {
            //var t = SAUpdaterGlobal.Client.CompressedInstallerFilename(SAUpdaterGlobal.Options.InstallerFilename);

            if (File.Exists(SAUpdaterGlobal.Client.CompressedInstallerFilename(SAUpdaterGlobal.Options.InstallerFilename))) File.Delete(SAUpdaterGlobal.Client.CompressedInstallerFilename(SAUpdaterGlobal.Options.InstallerFilename));

            SAUpdaterGlobal.Repository.FileDownloadProgressChanged += RaiseFileDownloadProgressChangedEvent;

            SAUpdaterGlobal.Repository.DownloadFile(SAUpdaterGlobal.Repository.RepositoryDownloadFolder, $"{SAUpdaterGlobal.Options.InstallerFilename}.ZIP", SAUpdaterGlobal.Client.CompressedInstallerFilename(SAUpdaterGlobal.Options.InstallerFilename));

            SAUpdaterGlobal.Repository.FileDownloadProgressChanged -= RaiseFileDownloadProgressChangedEvent;

            if (SAUpdaterGlobal.Repository.HasError)
            {
                Error = SAUpdaterGlobal.Repository.Error;
                return;
            }

            if (!File.Exists(SAUpdaterGlobal.Client.CompressedInstallerFilename(SAUpdaterGlobal.Options.InstallerFilename)))
            {
                Error = new SAUpdaterEventArgs("Failed to download installer", SAUpdaterResults.FilesFolderMissing);
                return;
            }

            if (SAUpdaterGlobal.Client.CompressedInstallerFilename(SAUpdaterGlobal.Options.InstallerFilename).GenerateFileMD5() != SAUpdaterGlobal.Repository.UpdateDefinition.InstallerCompressedMD5) Error = new SAUpdaterEventArgs("Installer signature does not match repository signature", SAUpdaterResults.DownloadError);
        }

        private void ExtractInstaller()
        {
            if (!SAUpdaterFile.Delete(SAUpdaterGlobal.Client.TempInstallerFilename(SAUpdaterGlobal.Options.InstallerFilename)))
            {
                Error = new SAUpdaterEventArgs($"Failed to delete {SAUpdaterGlobal.Client.TempInstallerFilename(SAUpdaterGlobal.Options.InstallerFilename)}", SAUpdaterResults.FileFolderDeleteError);
                return;
            }

            try
            {
                SAUpdaterZip.Extract(SAUpdaterGlobal.Client.CompressedInstallerFilename(SAUpdaterGlobal.Options.InstallerFilename), SAUpdaterGlobal.Client.ExtractFolder);
                if (!File.Exists(SAUpdaterGlobal.Client.TempInstallerFilename(SAUpdaterGlobal.Options.InstallerFilename))) throw new Exception();
            }
            catch (Exception ex)
            {
                var s = ex.Message;
                Error = new SAUpdaterEventArgs($"Failed to extract {SAUpdaterGlobal.Client.CompressedInstallerFilename(SAUpdaterGlobal.Options.InstallerFilename)}", SAUpdaterResults.ConversionError);
                return;
            }

            if (SAUpdaterGlobal.Client.TempInstallerFilename(SAUpdaterGlobal.Options.InstallerFilename).GenerateFileMD5() != SAUpdaterGlobal.Repository.UpdateDefinition.InstallerMD5)
            {
                Error = new SAUpdaterEventArgs("Installer signature does not match repository signature", SAUpdaterResults.DownloadError);
                return;
            }

            if (FileVersionInfo.GetVersionInfo(SAUpdaterGlobal.Client.TempInstallerFilename(SAUpdaterGlobal.Options.InstallerFilename)).FileVersion != SAUpdaterGlobal.Repository.UpdateDefinition.InstallerVersion)
            {
                Error = new SAUpdaterEventArgs("Installer version does not match repository version", SAUpdaterResults.DownloadError);
            }
        }

        private void MoveExtractedInstaller()
        {
            if (!SAUpdaterFile.Delete(SAUpdaterGlobal.Client.FullInstallerFilename(SAUpdaterGlobal.Options.InstallerFilename)))
            {
                Error = new SAUpdaterEventArgs($"{SAUpdaterGlobal.Client.FullInstallerFilename(SAUpdaterGlobal.Options.InstallerFilename)} could not be deleted", SAUpdaterResults.FileFolderDeleteError);
                return;
            }

            if (!SAUpdaterFile.Copy(SAUpdaterGlobal.Client.TempInstallerFilename(SAUpdaterGlobal.Options.InstallerFilename), SAUpdaterGlobal.Client.FullInstallerFilename(SAUpdaterGlobal.Options.InstallerFilename)))
            {
                Error = new SAUpdaterEventArgs($"{SAUpdaterGlobal.Client.TempInstallerFilename(SAUpdaterGlobal.Options.InstallerFilename)} could not be copied into position", SAUpdaterResults.FilesFolderCreateError);
                return;
            }

            if (SAUpdaterGlobal.Client.FullInstallerFilename(SAUpdaterGlobal.Options.InstallerFilename).GenerateFileMD5() != SAUpdaterGlobal.Repository.UpdateDefinition.InstallerMD5)
            {
                Error = new SAUpdaterEventArgs("Installer move failed", SAUpdaterResults.DownloadError);
                return;
            }

            if (!SAUpdaterFile.Delete(SAUpdaterGlobal.Client.TempInstallerFilename(SAUpdaterGlobal.Options.InstallerFilename))) Error = new SAUpdaterEventArgs($"{SAUpdaterGlobal.Client.TempInstallerFilename(SAUpdaterGlobal.Options.InstallerFilename)} could not be deleted", SAUpdaterResults.FileFolderDeleteError);
        }

        #endregion Private Methods
    }
}