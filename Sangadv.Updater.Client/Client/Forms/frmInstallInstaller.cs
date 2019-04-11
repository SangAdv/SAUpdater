using System.Windows.Forms;
using SangAdv.Updater.Common;

namespace SangAdv.Updater.Client
{
    public partial class frmInstallInstaller : Form
    {
        #region Variables

        private SAUpdaterCheck mChecker;
        
        #endregion Variables

        #region Properties

        public SAUpdaterEventArgs Error { get; private set; } = new SAUpdaterEventArgs();

        public bool IsSuccess => Error.IsSuccess;

        #endregion Properties

        #region Constructor

        public frmInstallInstaller(SAUpdaterCheck updaterCheck)
        {
            mChecker = updaterCheck;

            InitializeComponent();

            saUInstall.DisplaySuccessMessage = false;
            saUInstall.Completed += InstallerInstallCompleted;
        }

        #endregion Constructor

        #region Methods

        private void InstallerInstallCompleted(bool success)
        {
            Error.ClearErrorMessage();
            if (!success) Error.SetErrorMessage($"Application Installer setup failed.\nError: {saUInstall.Error.Message}");
            btnCancel.Text = "Close";
        }

        #endregion Methods

        #region Process UI

        private void frmInstallInstaller_Shown(object sender, System.EventArgs e)
        {
            saUInstall.Initialise(mChecker);
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        #endregion Process UI
    }
}