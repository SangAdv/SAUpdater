using SangAdv.Updater.Common;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SangAdv.Updater.Client
{
    [ToolboxItem(false)]
    public partial class ucEnd : ucBaseControl
    {
        #region Variables

        private bool mLaunch = true;
        private string mLaunchFilename = string.Empty;
        private SAUpdaterUpdateOptions mOptions = SAUpdaterGlobal.Options;

        #endregion Variables

        #region Constructor

        public ucEnd()
        {
            InitializeComponent();

            btnAction.Visible = false;
            btnLaunch.Visible = false;

            DisplayMessage(string.Empty);
            DisplayErrorMessage(string.Empty);
        }

        #endregion Constructor

        #region Methods

        public override async Task ExecuteStartAsync()
        {
            SuspendLayout();
            SetDefaults();
            Application.DoEvents();
            ResumeLayout();
            await Task.Delay(0);
        }

        private void SetDefaults()
        {
            SetLaunchDefaults();

            var tString = mOptions.IsUpdate ? " updated successfully." : " installed successfully.";

            lblSuccess.Text = $"{mOptions.ApplicationTitle}{tString}";

            lblEndMessage.Text = !mLaunch ? $"Please close installer and start {mOptions.ApplicationTitle} ..." : $"Please click launch when ready ...";
        }

        private void SetLaunchDefaults()
        {
            mLaunch = mOptions.LaunchApplicationAfterInstall;
            if (mLaunch)
            {
                mLaunchFilename = Path.Combine(mOptions.ApplicationFolder, mOptions.LaunchFilename);
                if (!File.Exists(mLaunchFilename)) mLaunch = false;
            }

            RaiseInstallCompletedEvent();
            btnLaunch.Visible = mLaunch;
        }

        #endregion Methods

        #region Process UI

        private void btnLaunch_Click(object sender, System.EventArgs e)
        {
            Process.Start(mLaunchFilename);
            RaiseCloseInstallerEvent();
        }

        #endregion Process UI
    }
}