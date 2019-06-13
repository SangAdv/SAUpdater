using SangAdv.Updater.Common;
using System.Windows.Forms;

namespace SangAdv.Updater.Client
{
    public partial class SAUpdaterInstallInstaller : UserControl
    {
        #region Events

        public event UpdaterBooleanDelegate Completed = (b) => { };

        #endregion Events

        #region Properties

        public bool DisplaySuccessMessage { get; set; } = true;

        public SAUpdaterEventArgs Error => SAUpdaterClient.Installer.Error;
        public bool IsSuccess => Error.IsSuccess;

        #endregion Properties

        #region Constructor

        public SAUpdaterInstallInstaller()
        {
            InitializeComponent();

            btnAction.Visible = false;
            btnAction.Enabled = false;
            SetProgressVisibility(false);

            DisplayProgress(0);
            DisplayMessage(string.Empty);
        }

        #endregion Constructor

        #region Methods

        public void Initialise()
        {
            ReInitialise();
        }

        public void ReInitialise()
        {
            pbProgress.Value = 0;
            if (!SAUpdaterClient.Installer.HasInstaller)
            {
                DisplayMessage("An installer is not available");
                return;
            }

            if (string.IsNullOrEmpty(SAUpdaterGlobal.Options.ApplicationFolder))
            {
                DisplayMessage("Please select an installation folder");
                return;
            }

            if (SAUpdaterClient.Installer.HasNewInstallerRelease)
            {
                btnAction.Visible = true;
                btnAction.Enabled = true;
            }
            else
            {
                DisplayMessage("A new installer is not available");
            }
        }

        private void DisplayProgress(int value)
        {
            pbProgress.Value = value;
            lblProgress.Text = $"... {value}%";
            Application.DoEvents();
        }

        private void DisplayMessage(string message)
        {
            lblMessage.Text = message;
            Application.DoEvents();
        }

        private void SetProgressVisibility(bool isVisible)
        {
            pbProgress.Visible = isVisible;
            lblProgress.Visible = isVisible;
        }

        #endregion Methods

        #region Process UI

        private async void btnAction_Click(object sender, System.EventArgs e)
        {
            btnAction.Visible = false;
            SetProgressVisibility(true);
            Application.DoEvents();

            SAUpdaterClient.Installer.FileDownloadProgressChanged += DisplayProgress;
            SAUpdaterClient.Installer.MessageChanged += DisplayMessage;

            await SAUpdaterClient.Installer.UpdateAsync();

            SAUpdaterClient.Installer.FileDownloadProgressChanged -= DisplayProgress;
            SAUpdaterClient.Installer.MessageChanged -= DisplayMessage;

            Completed(SAUpdaterClient.Installer.Error.IsSuccess);

            SetProgressVisibility(false);
            if (!DisplaySuccessMessage) DisplayMessage(string.Empty);
        }

        private void SAUpdaterInstallInstaller_Paint(object sender, PaintEventArgs e)
        {
            if (DesignMode)
            {
                lblProgress.Visible = true;
                lblProgress.Text = "Design Mode";
                lblMessage.Text = "Remember to initialise";
                BorderStyle = BorderStyle.FixedSingle;
            }
            else
            {
                BorderStyle = BorderStyle.None;
            }
        }

        #endregion Process UI
    }
}