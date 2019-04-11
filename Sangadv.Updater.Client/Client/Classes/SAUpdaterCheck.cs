using SangAdv.Updater.Common;
using System.Diagnostics;

namespace SangAdv.Updater.Client
{
    public class SAUpdaterCheck : SAUpdaterErrorBase
    {
        #region Events

        public event UpdaterStringDelegate MessageChanged = s => { };

        #endregion Events

        #region Properties

        public bool Connected => SAUpdaterGlobal.Connected;
        public bool HasNewApplicationRelease => SAUpdaterGlobal.Repository.UpdateDefinition.NewApplicationVersion.IsNewerVersion(SAUpdaterGlobal.Client.UpdateDefinition.ReleaseVersion);
        public SAUpdaterReleaseType NewReleaseType => SAUpdaterGlobal.Repository.UpdateDefinition.IsPreRelease ? SAUpdaterGlobal.Repository.UpdateDefinition.ReleaseType : SAUpdaterReleaseType.Release;
        public string NewApplicationVersion => SAUpdaterGlobal.Repository.UpdateDefinition.NewApplicationVersion;

        public bool IsUpdate => SAUpdaterGlobal.Options.IsUpdate;
        public string ApplicationTitle => SAUpdaterGlobal.Options.ApplicationTitle;

        public bool IsRequiredOSType => SAUpdaterGlobal.Client.IsRequiredOSType(SAUpdaterGlobal.Repository.UpdateDefinition.RequiredOSType);
        public bool IsRequiredOSVersion => SAUpdaterGlobal.Client.ClientOSVersion.IsRequiredVersion(SAUpdaterGlobal.Repository.UpdateDefinition.IntRequiredOSVersion);

        public bool IsRequiredOSArchitecture => SAUpdaterGlobal.Client.IsRequiredOSArchitecture(SAUpdaterGlobal.Repository.UpdateDefinition.Is64BitOSRequired);

        public bool HasNotes => SAUpdaterGlobal.Repository.UpdateDefinition.HasNotes;

        public bool CanInstall
        {
            get
            {
                if (SAUpdaterClient.Installer.DoInstallerUpdate) return false;
                if (!SAUpdaterClient.Installer.HasInstaller) return false;

                if (!SAUpdaterGlobal.Connected) return false;
                if (!IsRequiredOSType) return false;
                if (!IsRequiredOSVersion) return false;
                if (!IsRequiredOSArchitecture)
                {
                    Error = new SAUpdaterEventArgs("The OS Architecture does not meet the requirement.", SAUpdaterResults.NewUpdateNotAvailable);
                    return false;
                }
                if (!HasNewApplicationRelease)
                {
                    Error = new SAUpdaterEventArgs("A new update is not available\nPlease contact support if you want to force an update.", SAUpdaterResults.NewUpdateNotAvailable);
                    return false;
                }
                return true;
            }
        }

        public bool HasNewInstallerRelease => SAUpdaterClient.Installer.HasNewInstallerRelease;

        #endregion Properties

        #region Methods

        public void StartUpdate(SAUpdaterCommandLineOptions options)
        {
            if (HasError) return;
            var startInfo = new ProcessStartInfo
            {
                FileName = SAUpdaterGlobal.Client.FullInstallerFilename(SAUpdaterGlobal.Options.InstallerFilename),
                Arguments = $"\"{options.SAUpdaterSerialise().DeflateString()}\""
            };

            Process.Start(startInfo);
        }

        public void SetInstallerRequirements(SAUpdaterWinOSVersion osVersion, SAUpdaterFrameworkVersions framework)
        {
            SAUpdaterClient.Installer.SetInstallerRequirements(osVersion, framework);
        }

        #endregion Methods

        #region Private Methods

        private bool GetRepositoryUpdateDefinition()
        {
            MessageChanged("Getting update definition");
            return SAUpdaterGlobal.Repository.GetUpdateDefinition();
        }

        #endregion Private Methods
    }
}