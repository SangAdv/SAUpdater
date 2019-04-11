using System.Windows.Forms;

namespace SangAdv.Updater.Master
{
    internal partial class ucApplicationContainer : ucTemplate
    {
        #region Variables

        private AppDataFile mAppDataFile;

        #endregion Variables

        #region Properties

        internal static int SelectedAppId { get; private set; }

        #endregion Properties

        #region Constructor

        internal ucApplicationContainer(MasterDataApplicationItem item)
        {
            InitializeComponent();
            tsMenu.Renderer = new MainFormToolStripRenderer();

            SetUIDefaults();

            SelectedAppId = item.Id;

            SAUpdaterMasterCommon.AppData = new AppDataFile(SelectedAppId);
            mAppDataFile = SAUpdaterMasterCommon.AppData;
            mAppDataFile.Load();
            mAppDataFile.Application.Get(SelectedAppId);

            mAppDataFile = SAUpdaterMasterCommon.AppData;

            DisplayControl(new ucApplication(SelectedAppId));
        }

        #endregion Constructor

        #region Private Methods

        private void DisplayControl(ucTemplate userControl)
        {
            foreach (ucTemplate uc in clientPanel.Controls) DetachEvents(uc);
            AttachEvents(userControl);

            clientPanel.SuspendLayout();
            clientPanel.Controls.Clear();

            userControl.Dock = DockStyle.Fill;
            clientPanel.ResumeLayout();

            clientPanel.Controls.Add(userControl);

            userControl.Visible = false;
            Application.DoEvents();

            userControl.LoadStartData();
            userControl.Visible = true;
        }

        private void AttachEvents(ucTemplate userControl)
        {
            userControl.StatusMessageChanged += RaiseEventStatusMessageChanged;
            userControl.MainFormEnabledChanged += RaiseEventMainFormEnabledChanged;
            userControl.ProgressChanged += RaiseEventProgressChanged;
            userControl.ButtonsEnabled += SetNonApplicationButtons;
        }

        private void DetachEvents(ucTemplate userControl)
        {
            userControl.StatusMessageChanged -= RaiseEventStatusMessageChanged;
            userControl.MainFormEnabledChanged -= RaiseEventMainFormEnabledChanged;
            userControl.ProgressChanged -= RaiseEventProgressChanged;
            userControl.ButtonsEnabled -= SetNonApplicationButtons;
        }

        private void SetNonApplicationButtons(bool enabled)
        {
            tsbFiles.Enabled = enabled;
            tsbVersions.Enabled = enabled;
        }

        #endregion Private Methods

        #region Process UI

        private void tsbCurrentApplication_Click(object sender, System.EventArgs e)
        {
            if (SelectedAppId < 1) return;
            DisplayControl(new ucApplication(SelectedAppId));
        }

        private void tsbFiles_Click(object sender, System.EventArgs e)
        {
            if (SelectedAppId < 1) return;
            DisplayControl(new ucFiles(SelectedAppId));
        }

        private void tsbVersions_Click(object sender, System.EventArgs e)
        {
            if (SelectedAppId < 1) return;
            DisplayControl(new ucVersion(SelectedAppId));
        }

        #endregion Process UI

        #region Prepare UI

        private void SetUIDefaults()
        {
            tsbCurrentApplication.Text = "\nApplication";
            tsbFiles.Text = " \nFiles";
            tsbVersions.Text = "\nVersions";
        }

        #endregion Prepare UI
    }
}