using SangAdv.Updater.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SangAdv.Updater.Client
{
    [ToolboxBitmap("..\\Resources\\SAUpdater_16.png")]
    public partial class SAUpdaterExecute : UserControl
    {
        #region Events

        public event UpdaterBooleanDelegate InitialisationCompleted = b => { };

        public event UpdaterEmptyDelegate InstallStarted = () => { };

        public event UpdaterBooleanDelegate InstallCompleted = b => { };

        public event UpdaterEmptyDelegate CloseInstaller = () => { };

        public event UpdaterBooleanDelegate ChangeControlBoxStatus = b => { };

        private void RaiseInstallCompleted(bool success) => InstallCompleted(success);

        private void RaiseCloseInstallerEvent() => CloseInstaller();

        private void RaiseChangeControlBoxStatusEvent(bool enabled) => ChangeControlBoxStatus(enabled);

        #endregion Events

        #region Variables

        private Control uc1;
        private SAUpdaterNavigation mNavigation;
        private bool mHasNotes = false;

        private SAUpdaterEventArgs mError = new SAUpdaterEventArgs();

        private string mInstallerVersion = string.Empty;
        private bool mMustAcceptLicense;
        private Image mLogo;
        private string mLicense = string.Empty;
        private bool mLicenseScrollBars = false;

        private List<object> mModules = new List<object>();

        #endregion Variables

        #region Properties

        public bool IsInitialised => SAUpdaterGlobal.IsInitialised;

        public bool HasNotes => IsInitialised && mHasNotes;

        public SAUpdaterCheck Checker => SAUpdaterClient.Checker;
        public SAUpdaterInstaller Installer => SAUpdaterClient.Installer;

        public string InstallerVersion
        {
            set => mInstallerVersion = value;
        }

        public bool MustAcceptLicense
        {
            set => mMustAcceptLicense = value;
        }

        public Image Logo
        {
            set => mLogo = value;
        }

        public string License
        {
            set => mLicense = value;
        }

        public bool LicenseScrollBars
        {
            set => mLicenseScrollBars = value;
        }

        public SAUpdaterStartupSettings StartupSettings => SAUpdaterGlobal.Client.StartupSettings;

        #endregion Properties

        #region Constructor

        public SAUpdaterExecute()
        {
            //Register objects in IoC Conatiner
            InitializeComponent();
            mNavigation = new SAUpdaterNavigation(clientPanel);
            mNavigation.CloseInstaller += RaiseCloseInstallerEvent;
            mNavigation.InstallCompleted += InstallDone;
            mNavigation.ChangeControlBoxStatus += RaiseChangeControlBoxStatusEvent;

            displayInitialiseControl();
        }

        #endregion Constructor

        #region Process UI

        private void SAUpdaterExec_Load(object sender, System.EventArgs e)
        {
            if (DesignMode) DisplayDesignControl();
        }

        #endregion Process UI

        #region Methods

        public void AddModule(ucBaseControl control) => mModules.Add(control);

        public void AddModule(SAUpdaterModuleType applicationType) => mModules.Add(applicationType);

        public void AddDefaultModules()
        {
            AddModule(SAUpdaterModuleType.KillProcess);
            AddModule(SAUpdaterModuleType.Download);
            AddModule(SAUpdaterModuleType.DownloadFiles);
            AddModule(SAUpdaterModuleType.Install);
            AddModule(SAUpdaterModuleType.InstallEnd);
        }

        public async Task InitialiseAsync(SAUpdaterWinOSVersion osVersion, SAUpdaterFrameworkVersions framework, string downloadServerUri, string downloadServerFolder, string applicationTitle, string applicationLaunchFilename, string applicationLaunchFolder, string installerFilename, string[] commandlineOptions = null)
        {
            mError.ClearErrorMessage();

            checkErrors();
            if (mError.HasError)
            {
                InitialisationCompleted(false);
                return;
            }

            //var repository = new SAUpdaterFTPRepository(downloadServerUri, downloadServerFolder);

            var repository = new SAUpdaterAzureBlobRepository(downloadServerUri, downloadServerFolder);
            var client = new SAUpdaterWinClient();
            var options = new SAUpdaterUpdateOptions { ApplicationTitle = applicationTitle, LaunchFilename = applicationLaunchFilename, ApplicationFolder = applicationLaunchFolder, ChooseApplicationFolder = true, InstallerFilename = installerFilename };
            if (commandlineOptions != null) options.UpdateFromCommandLine(commandlineOptions);

            //Prepare the installation folder if options.ApplicationFolder = ""
            if (options.ChooseApplicationFolder)
            {
                var f = new frmChooseFolder(options.ApplicationTitle, options.ApplicationFolder)
                {
                    InstallerVersion = mInstallerVersion,
                    License = mLicense,
                    Logo = mLogo,
                    MustAcceptLicense = mMustAcceptLicense,
                    LicenseScrollBars = mLicenseScrollBars
                };
                f.ShowDialog(this);

                if (string.IsNullOrEmpty(f.SelectedFolder))
                {
                    mError = new SAUpdaterEventArgs("An installation folder was not selected", SAUpdaterResults.FilesFolderMissing);
                    await processInitialisationErrorAsync();
                    InitialisationCompleted(false);
                    return;
                }

                options.ApplicationFolder = f.SelectedFolder;
            }

            await SAUpdaterClient.InitialiseAsync(repository, client, options);

            SAUpdaterGlobal.AddLog("SAUpdaterExecute", "Initialise", $"options.ChooseApplicationFolder: {options.ChooseApplicationFolder}");
            SAUpdaterGlobal.AddLog("SAUpdaterExecute", "Initialise", $"options.ApplicationFolder: {options.ApplicationFolder}");
            SAUpdaterGlobal.AddLog("SAUpdaterExecute", "Initialise", $"CanInstall: {Checker.CanInstall}");

            //Process the Initialisation results
            if (!Checker.CanInstall)
            {
                if (await processCannotInstallAsync(repository, client, options)) return;
            }

            Checker.SetInstallerRequirements(osVersion, framework);

            mHasNotes = Checker.HasNotes;

            SAUpdaterGlobal.IsInitialised = true;

            addModules();

            var success = await showFirstAsync();
            if (!success) mError.SetErrorMessage("Error showing first module");

            InitialisationCompleted(success);
        }

        #endregion Methods

        #region Private Methods

        private async Task<bool> showFirstAsync()
        {
            if (!SAUpdaterGlobal.IsInitialised)
            {
                await processInitialisationErrorAsync();
                return false;
            }

            if (mNavigation.Count == 0)
            {
                await mNavigation.DisplayErrorAsync("Error Occurred", string.IsNullOrEmpty(mError.Message) ? "There are no views defined for navigation" : mError.Message, SAUpdaterStatusIcon.Warning);
                return false;
            }

            await mNavigation.ShowFirstAsync();
            InstallStarted();
            return true;
        }

        private async Task processInitialisationErrorAsync()
        {
            var tHeading = "Initialisation Error";
            var tMessage = "The control's data structure is not initialised";
            var tIcon = SAUpdaterStatusIcon.Warning;

            switch (mError.Result)
            {
                case SAUpdaterResults.NewUpdateNotAvailable:
                    tHeading = "No Update Available";
                    tMessage = mError.Message;
                    tIcon = SAUpdaterStatusIcon.Info;
                    break;

                case SAUpdaterResults.NotConnected:
                    tHeading = "Not Connected";
                    tMessage = mError.Message;
                    tIcon = SAUpdaterStatusIcon.Warning;
                    break;

                case SAUpdaterResults.InstallerUpdateAvailable:
                    tHeading = "Installer Update";
                    tMessage = mError.Message;
                    tIcon = SAUpdaterStatusIcon.Warning;
                    break;

                case SAUpdaterResults.InstallerNotAvailable:
                    tHeading = "Installer Error";
                    tMessage = mError.Message;
                    tIcon = SAUpdaterStatusIcon.Stop;
                    break;

                case SAUpdaterResults.MissingVersionFile:
                    tHeading = "Version Error";
                    tMessage = mError.Message;
                    tIcon = SAUpdaterStatusIcon.Stop;
                    break;

                case SAUpdaterResults.FilesFolderMissing:
                    tHeading = "Missing Installation Folder";
                    tMessage = mError.Message;
                    tIcon = SAUpdaterStatusIcon.Stop;
                    break;

                case SAUpdaterResults.InvalidOSArchitecture:
                    tHeading = "64Bit OS Required";
                    tMessage = mError.Message;
                    tIcon = SAUpdaterStatusIcon.Stop;
                    break;

                default:
                    tMessage = string.IsNullOrEmpty(mError.Message) ? tMessage : mError.Message;
                    break;
            }
            await mNavigation.DisplayErrorAsync(tHeading, tMessage, tIcon);
        }

        private async Task<bool> processCannotInstallAsync(ASAUpdaterRepositoryBase repository, ASAUpdaterClientBase client, SAUpdaterUpdateOptions options)
        {
            if (!Checker.IsRequiredOSArchitecture)
            {
                mError = new SAUpdaterEventArgs($"{options.ApplicationTitle} needs a 64Bit OS.", SAUpdaterResults.InvalidOSArchitecture);
                InitialisationCompleted(false);
                return true;
            }

            //If a new update is not available, make sure the files were installed
            if (Checker.Error.Result == SAUpdaterResults.NewUpdateNotAvailable)
            {
                await repository.GetUpdateFileListAsync(Checker.NewApplicationVersion);
                if (repository.HasError)
                {
                    mError = new SAUpdaterEventArgs("Could not retrieve update file list from repository", SAUpdaterResults.GeneralError);
                    InitialisationCompleted(false);
                    return true;
                }

                client.UpdateFiles.Prepare(repository.UpdateFiles.List);
                mError = client.UpdateFiles.CheckAfterInstall();
                if (!mError.HasError)
                {
                    mError = Checker.Error;
                    InitialisationCompleted(false);
                    return true;
                }

                mError = new SAUpdaterEventArgs();
                Checker.Error = new SAUpdaterEventArgs();
            }
            else
            {
                try
                {
                    var isDefaultInstaller = getCurrentPath() == client.UpdateFolder;
                    if (!options.IsUpdate & Checker.HasNewInstallerRelease & !isDefaultInstaller)
                    {
                        mNavigation.AddInstallInstaller(repository, client, options, Checker.ApplicationTitle);
                    }
                    else
                    {
                        switch (Checker.Error.Result)
                        {
                            case SAUpdaterResults.NotConnected:
                                mError = new SAUpdaterEventArgs($"Please connect to the internet to install {options.ApplicationTitle}.", SAUpdaterResults.NotConnected);
                                break;

                            case SAUpdaterResults.InstallerUpdateAvailable:
                                mError = new SAUpdaterEventArgs("An installer update is available.", SAUpdaterResults.InstallerUpdateAvailable);
                                break;

                            case SAUpdaterResults.InstallerNotAvailable:
                                mError = new SAUpdaterEventArgs("An installer can not be found.\nPlease contact support.", SAUpdaterResults.InstallerNotAvailable);
                                break;

                            case SAUpdaterResults.MissingVersionFile:
                            case SAUpdaterResults.NewUpdateNotAvailable:
                                mError = Checker.Error;
                                break;

                            default:
                                mError = new SAUpdaterEventArgs($"Error: {Checker.ErrorMessage}", SAUpdaterResults.GeneralError);
                                break;
                        }

                        InitialisationCompleted(false);
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    mError = new SAUpdaterEventArgs($"Undefined Error: {ex.Message}", SAUpdaterResults.GeneralError);
                    InitialisationCompleted(false);
                    return true;
                }
            }

            return false;
        }

        private string getCurrentPath()
        {
            var currentStartupPath = string.Empty;
            try
            {
                currentStartupPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            }
            catch
            {
                currentStartupPath = string.Empty;
            }

            if (string.IsNullOrEmpty(currentStartupPath))
            {
                try
                {
                    currentStartupPath = Application.StartupPath;
                }
                catch
                {
                    currentStartupPath = string.Empty;
                }
            }

            return currentStartupPath;
        }

        private void addModules()
        {
            foreach (var item in mModules)
            {
                if (item.GetType() == typeof(ucBaseControl)) mNavigation.Add((ucBaseControl)item);
                else mNavigation.Add((SAUpdaterModuleType)item);
            }
        }

        private void checkErrors()
        {
            if (mModules.Count == 0)
            {
                mError.SetErrorMessage("No install modules defined");
                return;
            }
        }

        #region Display Controls

        private void DisplayDesignControl()
        {
            ControlLoadState();
            uc1 = new ucDesigner();
            DisplayControl(uc1);
        }

        private void displayInitialiseControl()
        {
            ControlLoadState();
            uc1 = new ucInitialise();
            DisplayControl(uc1);
        }

        private void DisplayControl(Control control)
        {
            clientPanel.Controls.Add(control);
            control.BringToFront();
            control.Dock = DockStyle.Fill;
            Cursor = Cursors.Default;
            Enabled = true;
        }

        private void ControlLoadState()
        {
            Cursor = Cursors.WaitCursor;
            clientPanel.Controls.Clear();
        }

        private void InstallDone(bool success)
        {
            if (success && SAUpdaterGlobal.Options.CreateStartupSettings && SAUpdaterGlobal.Options.ResetStartupSettings) SAUpdaterGlobal.Client.StartupSettings.Save();
            RaiseInstallCompleted(success);
        }

        #endregion Display Controls

        #endregion Private Methods
    }
}