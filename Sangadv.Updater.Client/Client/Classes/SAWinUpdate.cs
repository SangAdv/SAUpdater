using SangAdv.Updater.Common;
using System.Threading.Tasks;

namespace SangAdv.Updater.Client
{
    public class SAWinUpdate
    {
        #region Events

        public event UpdaterStringDelegate MessageChanged = s => { };

        #endregion Events

        #region Variables

        //private SAUpdaterFTPRepository mRepository;

        private ASAUpdaterRepositoryBase mRepository;
        private SAUpdaterWinClient mClient;
        private SAUpdaterUpdateOptions mOptions;

        private bool mIsInitialised = false;
        private string mApplicationLaunchFolder = string.Empty;

        #endregion Variables

        #region Properties

        public SAUpdaterEventArgs Error { get; private set; } = new SAUpdaterEventArgs();

        public bool DoInstallerUpdate { get; private set; } = false;

        public bool HasNewApplicationRelease { get; private set; } = false;

        public string NewApplicationVersion => SAUpdaterClient.Checker.NewApplicationVersion;

        #endregion Properties

        #region Methods

        public async Task InitialiseAsync(string downloadServerUri, string downloadServerFolder, string applicationTitle, string applicationLaunchFilename, string applicationLaunchFolder, string installerFilename, SAUpdaterRepositoryType repositoryType)
        {
            DoInitialise(downloadServerUri, downloadServerFolder, applicationTitle, applicationLaunchFilename, applicationLaunchFolder, installerFilename, repositoryType);

            await SAUpdaterClient.InitialiseAsync(mRepository, mClient, mOptions);

            if (SAUpdaterClient.Error.HasError)
            {
                if (SAUpdaterClient.Error.Result == SAUpdaterResults.InstallerUpdateAvailable)
                {
                    DoInstallerUpdate = SAUpdaterClient.Installer.DoInstallerUpdate;
                }
                else
                {
                    Error = SAUpdaterClient.Error;
                    return;
                }
            }
            HasNewApplicationRelease = SAUpdaterClient.Checker.HasNewApplicationRelease;
        }

        public void Initialise(string downloadServerUri, string downloadServerFolder, string applicationTitle, string applicationLaunchFilename, string applicationLaunchFolder, string installerFilename, SAUpdaterRepositoryType repositoryType)
        {
            DoInitialise(downloadServerUri, downloadServerFolder, applicationTitle, applicationLaunchFilename, applicationLaunchFolder, installerFilename, repositoryType);

            SAUpdaterClient.Initialise(mRepository, mClient, mOptions);

            if (SAUpdaterClient.Error.HasError)
            {
                if (SAUpdaterClient.Error.Result == SAUpdaterResults.InstallerUpdateAvailable)
                {
                    DoInstallerUpdate = SAUpdaterClient.Installer.DoInstallerUpdate;
                }
                else
                {
                    Error = SAUpdaterClient.Error;
                    return;
                }
            }
            HasNewApplicationRelease = SAUpdaterClient.Checker.HasNewApplicationRelease;
        }

        //public void UpdateOptionsFromCommandLine()
        //{
        //}

        public async Task<bool> UpdateInstallerAsync()
        {
            if (!DoInstallerUpdate) return false;
            if (!mIsInitialised) return false;

            MessageChanged("Doing Installer update ...");
            var tSuccess = await SAUpdaterClient.Installer.UpdateAsync();
            if (!tSuccess) return false;

            HasNewApplicationRelease = SAUpdaterClient.Checker.HasNewApplicationRelease;

            return true;
        }

        public bool UpdateInstaller()
        {
            if (!DoInstallerUpdate) return false;
            if (!mIsInitialised) return false;

            MessageChanged("Doing Installer update ...");
            var tSuccess = SAUpdaterClient.Installer.Update();
            if (!tSuccess) return false;

            HasNewApplicationRelease = SAUpdaterClient.Checker.HasNewApplicationRelease;

            return true;
        }

        public bool UpdateApplication(SAUpdaterReleaseType releaseType = SAUpdaterReleaseType.Release, bool resetStartupSettings = false)
        {
            if (!mIsInitialised) return false;
            var clo = new SAUpdaterCommandLineOptions { AllowedReleaseType = releaseType, ApplicationFolder = mApplicationLaunchFolder, ResetStartupSettings = resetStartupSettings };

            SAUpdaterClient.Checker.StartUpdate(clo);
            return true;
        }

        private void DoInitialise(string downloadServerUri, string downloadServerFolder, string applicationTitle, string applicationLaunchFilename, string applicationLaunchFolder, string installerFilename, SAUpdaterRepositoryType repositoryType)
        {
            Error.ClearErrorMessage();

            MessageChanged("Checking for update ...");

            mIsInitialised = true;
            mApplicationLaunchFolder = applicationLaunchFolder;

            switch (repositoryType)
            {
                case SAUpdaterRepositoryType.FTP:
                    mRepository = new SAUpdaterFTPRepository(downloadServerUri, downloadServerFolder);
                    break;

                case SAUpdaterRepositoryType.AzureBlob:
                    mRepository = new SAUpdaterAzureBlobRepository(downloadServerUri, downloadServerFolder);
                    break;
            }

            mClient = new SAUpdaterWinClient();
            mOptions = new SAUpdaterUpdateOptions { ApplicationTitle = applicationTitle, LaunchFilename = applicationLaunchFilename, ApplicationFolder = mApplicationLaunchFolder, ChooseApplicationFolder = true, InstallerFilename = installerFilename };
        }

        #endregion Methods
    }
}