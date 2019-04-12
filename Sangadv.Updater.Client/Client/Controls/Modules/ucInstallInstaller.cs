using SangAdv.Updater.Common;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SangAdv.Updater.Client
{
    [ToolboxItem(false)]
    public partial class ucInstallInstaller : ucBaseControl
    {
        #region Constructor

        public ucInstallInstaller()
        {
            InitializeComponent();

            saUInstall.DisplaySuccessMessage = false;

            saUInstall.Completed += InstallerInstallCompleted;
        }

        #endregion Constructor

        #region Methods

        private void ResetUI()
        {
            btnAction.Visible = false;
            DisplayMessage("Install Application Installer before installing application.");
            DisplayErrorMessage(string.Empty);
        }

        private void SetDefaultUI()
        {
            try
            {
                btnFWDownload.Enabled = SetUI();
            }
            catch (Exception ex)
            {
                DisplayErrorMessage(ex.Message);
            }
        }

        private bool SetUI()
        {
            btnAction.Enabled = true;
            btnFWDownload.Enabled = false;

            if (SAUpdaterGlobal.Client.ClientOSVersion.IsRequiredVersion((int)SAUpdaterClient.Installer.InstallerRequiredOsVersion))
            {
                lblOS.Text = $"{SAUpdaterGlobal.Client.ClientOSVersion.VersionDescription} installed";
                pbOSStatus.Image = ImageList1.Images[1];
            }
            else
            {
                lblFramework.Text = $"{SAUpdaterGlobal.Options.ApplicationTitle} require {SAUpdaterGlobal.Client.ClientOSVersion.GetVersionDescription((int)SAUpdaterClient.Installer.InstallerRequiredOsVersion)} or better to install.";
                pbOSStatus.Image = ImageList1.Images[0];
            }

            if (SAUpdaterGlobal.Client.ClientFramework.IsRequiredVersion(SAUpdaterClient.Installer.InstallerRequiredFramework))
            {
                lblFramework.Text = SAUpdaterGlobal.Client.ClientFramework.InstalledVersionDescription;
                pbFWStatus.Image = ImageList1.Images[1];
            }
            else
            {
                lblFramework.Text = $"{SAUpdaterGlobal.Client.ClientFramework.GetVersionDescription(SAUpdaterClient.Installer.InstallerRequiredFramework)} or above required. Please download and install.";
                btnFWDownload.Visible = true;
                btnAction.Enabled = false;
                pbFWStatus.Image = ImageList1.Images[0];
            }

            //Check for connection and stop
            if (!SAUpdaterClient.Installer.Connected)
            {
                DisplayMessage($"Please connect to the internet to install {SAUpdaterGlobal.Options.ApplicationTitle}.");
                lblVersion.Text = $"{SAUpdaterGlobal.Options.ApplicationTitle} can not be installed.";
                lblConnected.Text = "Not connected to the Net";
                pbConnected.Image = ImageList1.Images[0];
                btnAction.Enabled = false;
            }
            else
            {
                pbConnected.Image = ImageList1.Images[1];
                lblConnected.Text = "Connected to the Net";
            }

            return btnAction.Enabled;
        }

        public override async  Task ExecuteStartAsync()
        {
            SuspendLayout();
            saUInstall.Initialise();
            ResetUI();
            SetDefaultUI();
            Application.DoEvents();
            ResumeLayout();
            await Task.Delay(0);
        }

        private void InstallerInstallCompleted(bool success)
        {
            if (!success)
            {
                RaiseErrorOccuredEvent($"Application Installer setup failed.\nError: {saUInstall.Error.Message}", "Error occurred", SAUpdaterStatusIcon.Stop);
                return;
            }

            DisplayMessage("Successfully installed Application Installer.");
            DisplayErrorMessage("Please install application by clicking Install ...");

            btnAction.Visible = true;
            btnAction.Enabled = true;
        }

        #endregion Methods
    }
}