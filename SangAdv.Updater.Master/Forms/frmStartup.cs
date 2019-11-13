using SangAdv.Updater.Client;
using SangAdv.Updater.Common;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SangAdv.Updater.Master
{
    public partial class frmStartup : Form
    {
        #region Variables

        private MasterDataFile mMasterDataFile;
        private SAUpdaterMaster mMaster;
        private SAWinUpdate mUpdate = new SAWinUpdate();

        #endregion Variables

        #region Properties

        public bool HasError { get; private set; } = false;

        #endregion Properties

        #region Constructor

        public frmStartup()
        {
            InitializeComponent();
            lblVersion.Text = Application.ProductVersion;
            btnContinue.Visible = false;
            DisplayMessage(string.Empty);
            btnUpdate.Visible = false;

            mUpdate.MessageChanged += displayMessage;
        }

        #endregion Constructor

        #region Process UI

        private async void frmStartup_Shown(object sender, EventArgs e)
        {
#if !DEBUG
            var success = await CheckUpdate();
            if (success) return;
#endif
            DisplayMessage("Preparing master data ...");
            Application.DoEvents();
            await Task.Delay(1);

            SAUpdaterGlobal.Master = new SAUpdaterMaster { ApplicationRootFolder = Application.StartupPath };

            mMaster = SAUpdaterGlobal.Master;
            if (!mMaster.PrepareFolders().IsSuccess)
            {
                SetButtons(false);
                return;
            }

            SAUpdaterMasterCommon.MasterData = new MasterDataFile();
            mMasterDataFile = SAUpdaterMasterCommon.MasterData;
            mMasterDataFile.Load();

            DisplayMessage("Master data prepared successfully.");
            SetButtons();
        }

        internal async Task<bool> CheckUpdate()
        {
            await mUpdate.InitialiseAsync("https://repo.sanguine.online/applications/", "saupdaterwin", "SAUpdater", "SAUpdater.exe", Application.StartupPath, "updater.exe", SAUpdaterRepositoryType.AzureBlob);

            if (mUpdate.DoInstallerUpdate)
            {
                var tSuccess = await mUpdate.UpdateInstallerAsync();
                if (!tSuccess)
                {
                    DisplayMessage("Installer update failed ...");
                    return false;
                }
            }

            if (mUpdate.HasNewApplicationRelease)
            {
                DisplayMessage("Update found. Please update ...");

                btnUpdate.Visible = true;
                btnUpdate.Enabled = true;
                btnContinue.Visible = false;
            }

            return mUpdate.HasNewApplicationRelease;
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            HasError = true;

            mUpdate.UpdateApplication();
            Close();
        }

        #endregion Process UI

        #region Private Methods

        private void SetButtons(bool isSuccess = true)
        {
            HasError = !isSuccess;

            btnContinue.Visible = true;
            btnContinue.Enabled = true;
        }

        private void displayMessage(string message) => DisplayMessage(message);

        private void DisplayMessage(string message, Color? messageColor = null)
        {
            lblMessage.SuspendLayout();
            lblMessage.ForeColor = messageColor ?? Color.FromArgb(65, 65, 65);
            lblMessage.Text = message;
            lblMessage.ResumeLayout();

            Application.DoEvents();
        }

        #endregion Private Methods
    }
}