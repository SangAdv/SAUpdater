using SangAdv.Updater.Client;
using SangAdv.Updater.Client.Properties;
using SangAdv.Updater.Common;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAUpdateInstaller
{
    public partial class frmMain : Form
    {
        #region Constructor

        public frmMain()
        {
            InitializeComponent();
            Text = "";
            pnlNotes.Visible = false;
            btnNotes.Enabled = false;
        }

        #endregion Constructor

        #region Process UI

        private async void frmMain_Load(object sender, EventArgs e)
        {
            lblVersion.Text = Application.ProductVersion;

            var tDirectory = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.Personal)).FullName;
            if (tDirectory.ToUpper().Contains("OneDrive".ToUpper())) tDirectory = Directory.GetParent(tDirectory).FullName;

            tDirectory = Path.Combine(tDirectory, "saupdater");

            upExec.License = Resources.License;
            upExec.MustAcceptLicense = true;
            upExec.Logo = Resources.Logo;
            upExec.InstallerVersion = Application.ProductVersion;

            upExec.AddDefaultModules();

            await upExec.InitialiseAsync(SAUpdaterWinOSVersion.Win7, SAUpdaterFrameworkVersions.Version45,
                @"http://repo.sanguine.online/applications/", "saupdaterwin", "SAUpdater", "SAUpdater.exe", tDirectory,
                "updater.exe", SAUpdaterRepositoryType.FTP, Global.CommandLineArgs);
        }

        private async void btnNotes_Click(object sender, EventArgs e)
        {
            await ShowNotesAsync();
        }

        private void upExec_InstallCompleted(bool success)
        {
            ControlBox = true;
            btnNotes.Enabled = true;
        }

        private void UpExec_InitialisationCompleted(bool success)
        {
            btnNotes.Visible = upExec.HasNotes;
        }

        private void upExec_InstallStarted()
        {
            btnNotes.Enabled = false;
        }

        private void lblPoweredBy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(@"http://www.sanguineadvantage.com/");
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            HideNotes();
        }

        private void upExec_CloseInstaller()
        {
            Close();
        }

        private void upExec_ChangeControlBoxStatus(bool enabled)
        {
            ControlBox = enabled;
        }

        #endregion Process UI

        #region Methods

        private async Task ShowNotesAsync()
        {
            pnlInstall.Visible = false;
            pnlNotes.Visible = true;

            await VersionNotes.LoadNotesAsync();
        }

        private void HideNotes()
        {
            pnlNotes.Visible = false;
            pnlInstall.Visible = true;
        }

        #endregion Methods
    }
}