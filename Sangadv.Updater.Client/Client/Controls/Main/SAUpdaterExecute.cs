using SangAdv.Updater.Common;
using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace SangAdv.Updater.Client
{
    [ToolboxBitmap("..\\Resources\\SAUpdater_16.png")]
    public partial class SAUpdaterExecute : UserControl
    {
        #region Events

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
        }

        #endregion Constructor

        #region Process UI

        private void SAUpdaterExec_Load(object sender, System.EventArgs e)
        {
            if (DesignMode) DisplayDesignControl();
        }

        #endregion Process UI

        #region Methods

        public void Add(ucBaseControl control) => mNavigation.Add(control);

        public void Add(SAApplicationType applicationType) => mNavigation.Add(applicationType);

        public bool ShowFirst()
        {
            //SAUpdaterDebugLog.Add($"SAUpdaterGlobal.IsInitialised: {SAUpdaterGlobal.IsInitialised}", "SAUpdaterExecute", "ShowFirst");

            if (!SAUpdaterGlobal.IsInitialised)
            {
                ProcessInitialisationError();
                return false;
            }

            if (mNavigation.Count == 0)
            {
                mNavigation.DisplayError("Error Occurred", string.IsNullOrEmpty(mError.Message) ? "There are no views defined for navigation" : mError.Message, SAUpdaterStatusIcon.Warning);
                return false;
            }

            mNavigation.ShowFirst();
            InstallStarted();
            return true;
        }

        public bool Initialise(SAUpdaterWinOSVersion osVersion, SAUpdaterFrameworkVersions framework, ASAUpdaterRepositoryBase repository, ASAUpdaterClientBase client, SAUpdaterUpdateOptions options)
        {
            mError.ClearErrorMessage();

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
                    ProcessInitialisationError();
                    return false;
                }

                options.ApplicationFolder = f.SelectedFolder;
            }

            SAUpdaterClient.Initialise(repository, client, options);

            SAUpdaterGlobal.AddLog("SAUpdaterExecute", "Initialise", $"options.ChooseApplicationFolder: {options.ChooseApplicationFolder}");
            SAUpdaterGlobal.AddLog("SAUpdaterExecute", "Initialise", $"options.ApplicationFolder: {options.ApplicationFolder}");
            SAUpdaterGlobal.AddLog("SAUpdaterExecute", "Initialise", $"CanInstall: {Checker.CanInstall}");

            var isDefaultInstaller = GetCurrentPath() == client.UpdateFolder;

            //Process the Initialisation results
            if (!Checker.CanInstall)
            {
                //If a new update is not available, make sure the files were installed
                if (Checker.Error.Result == SAUpdaterResults.NewUpdateNotAvailable)
                {
                    repository.GetUpdateFileList(Checker.NewApplicationVersion);
                    if (repository.HasError)
                    {
                        mError = new SAUpdaterEventArgs("Could not retrieve update file list from repository", SAUpdaterResults.GeneralError);
                        return false;
                    }

                    client.UpdateFiles.Prepare(repository.UpdateFiles.List);
                    mError = client.UpdateFiles.CheckAfterInstall();
                    if (!mError.HasError)
                    {
                        mError = Checker.Error;
                        return false;
                    }

                    mError = new SAUpdaterEventArgs();
                    Checker.Error = new SAUpdaterEventArgs();
                }
                else
                {
                    try
                    {
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

                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        mError = new SAUpdaterEventArgs($"Undefined Error: {ex.Message}", SAUpdaterResults.GeneralError);
                        return false;
                    }
                }
            }

            Checker.SetInstallerRequirements(osVersion, framework);

            mHasNotes = Checker.HasNotes;

            SAUpdaterGlobal.IsInitialised = true;

            return true;
        }

        #endregion Methods

        #region Private Methods

        private string GetCurrentPath()
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

        private void ProcessInitialisationError()
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

                default:
                    tMessage = string.IsNullOrEmpty(mError.Message) ? tMessage : mError.Message;
                    break;
            }
            mNavigation.DisplayError(tHeading, tMessage, tIcon);
        }

        #region Display Controls

        private void DisplayDesignControl()
        {
            ControlLoadState();
            uc1 = new ucDesigner();
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