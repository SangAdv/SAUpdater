using SangAdv.Updater.Common;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace SangAdv.Updater.Client
{
    [ToolboxItem(false)]
    public partial class ucInstall : ucBaseControl
    {
        #region Constructor

        public ucInstall()
        {
            InitializeComponent();
        }

        #endregion Constructor

        #region Methods

        public override void ExecuteStart()
        {
            SuspendLayout();
            PrepareUpdateFiles();
            SetUI();
            Application.DoEvents();
            ResumeLayout();

            DoInstall();
            UpdateClient();
        }

        private void PrepareUpdateFiles()
        {
            DisplayMessage("Loading update files list ...");
            SAUpdaterGlobal.Repository.GetUpdateFileList(SAUpdaterClient.Checker.NewApplicationVersion);
            if (SAUpdaterGlobal.Repository.HasError)
            {
                RaiseErrorOccuredEvent("Update files...", "Could not retrieve update file list from repository", SAUpdaterStatusIcon.Stop);
                return;
            }

            SAUpdaterGlobal.Client.UpdateFiles.Prepare(SAUpdaterGlobal.Repository.UpdateFiles.List);
        }

        private void SetUI()
        {
            DisplayMessage("");
            DisplayErrorMessage("");

            lblDirectory.Text = SAUpdaterGlobal.Client.ApplicationFolder;

            //Check that all files downloaded successfully
            if (SAUpdaterGlobal.Client.UpdateFiles.DownloadCount > 0)
            {
                RaiseErrorOccuredEvent("Install files not found", "All the required files did not download successfully.\nAll affected files will be redownloaded.", SAUpdaterStatusIcon.Warning);
                return;
            }

            //Install the files
            if (SAUpdaterGlobal.Options.IsUpdate)
            {
                btnAction.Text = "Update";
                lblVersion.Text = $"Update {SAUpdaterGlobal.Options.ApplicationTitle} to version {SAUpdaterClient.Checker.NewApplicationVersion}";
            }
            else
            {
                lblVersion.Text = $"Install {SAUpdaterGlobal.Options.ApplicationTitle} {SAUpdaterClient.Checker.NewApplicationVersion}";
            }
            if (SAUpdaterClient.Checker.NewReleaseType != SAUpdaterReleaseType.Release) lblVersion.Text += $" {SAUpdaterClient.Checker.NewReleaseType}";

            Application.DoEvents();
        }

        private void DoInstall()
        {
            btnAction.Enabled = false;

            SAUpdaterGlobal.Client.UpdateFiles.MessageChanged += DisplayMessage;
            SAUpdaterGlobal.Client.UpdateFiles.ProgressChanged += DisplayErrorMessage;

            try
            {
                var tResult = SAUpdaterGlobal.Client.UpdateFiles.InstallFiles(5);

                if (tResult.Result != SAUpdaterResults.Success) RaiseErrorOccuredEvent("Could not install files", $"Error: {tResult.Message}", SAUpdaterStatusIcon.Stop);

                RaiseActionButtonClickedEvent();
            }
            catch (Exception ex)
            {
                DisplayErrorMessage(ex.Message);
                DisplayMessage("Please contact support.");

                RaiseCloseInstallerEvent();
            }

            SAUpdaterGlobal.Client.UpdateFiles.MessageChanged -= DisplayMessage;
            SAUpdaterGlobal.Client.UpdateFiles.ProgressChanged -= DisplayErrorMessage;
        }

        private void UpdateClient()
        {
            SAUpdaterGlobal.Client.UpdateFiles.Save();
            SAUpdaterGlobal.Client.UpdateDefinition.FromString(SAUpdaterGlobal.Repository.UpdateDefinition.ToString());
            SAUpdaterGlobal.Client.SaveUpdateDefinition();
        }

        #endregion Methods
    }
}