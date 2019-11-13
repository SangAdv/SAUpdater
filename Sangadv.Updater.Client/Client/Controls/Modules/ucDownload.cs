using SangAdv.Updater.Common;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SangAdv.Updater.Client
{
    [ToolboxItem(false)]
    public partial class ucDownload : ucBaseControl 
    {
        #region Constructor

        public ucDownload()
        {
            InitializeComponent();
        }

        #endregion Constructor

        #region Methods

        public override async Task ExecuteStartAsync()
        {
            SuspendLayout();
            ResetUI();
            await PrepareUpdateFiles();
            SetDefaultUI();
            Application.DoEvents();
            ResumeLayout();
        }

        private void ResetUI()
        {
            DisplayMessage(string.Empty);
            DisplayErrorMessage(string.Empty);
        }

        private async Task PrepareUpdateFiles()
        {
            DisplayMessage("Loading update files list ...");
            await SAUpdaterGlobal.Repository.GetUpdateFileListAsync(SAUpdaterClient.Checker.NewApplicationVersion);
            if (SAUpdaterGlobal.Repository.HasError)
            {
                RaiseErrorOccuredEvent("Update files...", "Could not retrieve update file list from repository", SAUpdaterStatusIcon.Stop);
                return;
            }

            SAUpdaterGlobal.Client.UpdateFiles.Prepare(SAUpdaterGlobal.Repository.UpdateFiles.List);
        }

        private void SetDefaultUI()
        {
            var tContinue = SetUI();

            try
            {
                SetInstallTitle(SAUpdaterClient.Checker.ApplicationTitle);

                btnAction.Enabled = true;
                btnFWDownload.Enabled = true;

                if (!tContinue)
                {
                    btnAction.Enabled = false;
                    btnFWDownload.Enabled = true;
                }
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
            lblMessage.Text = "";
            lblVersion.Text = "";
            lblFileCount.Text = "";
            lblError.Visible = false;

            #region Check OS

            if (SAUpdaterGlobal.Client.ClientOSVersion.IsRequiredVersion(SAUpdaterGlobal.Repository.UpdateDefinition.IntRequiredOSVersion))
            {
                lblOS.Text = $"{SAUpdaterGlobal.Client.ClientOSVersion.VersionDescription} installed";
                pbOSStatus.Image = ImageList1.Images[1];
            }
            else
            {
                lblOS.Text = $"{SAUpdaterClient.Checker.ApplicationTitle} require {SAUpdaterGlobal.Client.ClientOSVersion.GetVersionDescription(SAUpdaterGlobal.Repository.UpdateDefinition.IntRequiredOSVersion)} or better to operate.";
                pbOSStatus.Image = ImageList1.Images[0];
            }

            #endregion Check OS

            #region Check .NET Framework

            if (SAUpdaterGlobal.Client.ClientFramework.IsRequiredVersion(SAUpdaterGlobal.Repository.UpdateDefinition.RequiredFramework))
            {
                lblFramework.Text = SAUpdaterGlobal.Client.ClientFramework.InstalledVersionDescription;
                pbFWStatus.Image = ImageList1.Images[1];
            }
            else
            {
                lblFramework.Text = $"{SAUpdaterGlobal.Client.ClientFramework.GetVersionDescription(SAUpdaterGlobal.Repository.UpdateDefinition.RequiredFramework)} or above not installed. Please download and install.";
                btnFWDownload.Visible = true;
                btnAction.Enabled = false;
                pbFWStatus.Image = ImageList1.Images[0];
            }

            #endregion Check .NET Framework

            #region Check Connectivity

            if (!SAUpdaterClient.Checker.Connected)
            {
                DisplayMessage("Please connect to the internet to install pharmatrack.");
                lblVersion.Text = "pharmatrack can not be installed.";
                lblConnected.Text = "Not connected to the Net";
                pbConnected.Image = ImageList1.Images[0];
                btnAction.Enabled = false;
            }
            else
            {
                pbConnected.Image = ImageList1.Images[1];
                lblConnected.Text = "Connected to the Net";
            }

            #endregion Check Connectivity

            pbSettingsfile.Image = null;
            lblSettingsFile.Text = "";

            var tString = string.Empty;
            switch (SAUpdaterGlobal.Client.UpdateFiles.DownloadCount)
            {
                case 0: tString = "No files to download"; break;
                case 1: tString = "1 file to download"; break;
                default: tString = $"{SAUpdaterGlobal.Client.UpdateFiles.DownloadCount} files to download"; break;
            }

            lblFileCount.Text = tString;

            return btnAction.Enabled;
        }

        private void SetInstallTitle(string title)
        {
            //Check if the file version is valid
            if (SAUpdaterClient.Checker.IsUpdate)
            {
                lblVersion.Text = $"Update {title} to {SAUpdaterClient.Checker.NewApplicationVersion} (Current: {SAUpdaterGlobal.Client.UpdateDefinition.ReleaseVersion})";
            }
            else
            {
                lblVersion.Text = $"Install {title} {SAUpdaterClient.Checker.NewApplicationVersion}";
            }

            if (SAUpdaterClient.Checker.NewReleaseType != SAUpdaterReleaseType.Release) lblVersion.Text += $" {SAUpdaterClient.Checker.NewReleaseType}";

            pbConnected.Image = ImageList1.Images[1];
        }

        public override void BeforeExecuteAction()
        {
            RaiseChangeControlBoxStatusEvent(false);
        }

        #endregion Methods

        #region Process UI

        private void btnFWDownload_Click(object sender, EventArgs e)
        {
            Process.Start(@"https://www.microsoft.com/net/download");
        }

        #endregion Process UI
    }
}