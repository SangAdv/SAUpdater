using SangAdv.Updater;
using SangAdv.Updater.Client;
using SangAdv.Updater.Client.Properties;
using SangAdv.Updater.Common;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace SAUpdateInstaller
{
    public partial class frmMain : Form
    {
        #region Variables

        private bool mHasLoadedNotes = false;

        #endregion Variables

        #region Constructor

        public frmMain()
        {
            InitializeComponent();
            Text = "";
            pnlNotes.Visible = false;
            pnlInstall.Visible = false;
        }

        #endregion Constructor

        #region Process UI

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblVersion.Text = Application.ProductVersion;

            //var tDirectory = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.Personal)).FullName;
            //if (tDirectory.ToUpper().Contains("OneDrive".ToUpper())) tDirectory = Directory.GetParent(tDirectory).FullName;

            //tDirectory = Path.Combine(tDirectory, "saupdater");

            var tDirectory = @"c:\Test\TestInstall";

            var nrs = new SAUpdaterFTPRepository(@"http://repo.sanguine.online/applications/", "Test");
            var nc = new SAUpdaterWinClient();
            var uo = new SAUpdaterUpdateOptions { ApplicationTitle = "Test", LaunchFilename = "TestApp.exe", ApplicationFolder = tDirectory, ChooseApplicationFolder = true, InstallerFilename = "TestUpdater.exe" };
            uo.UpdateFromCommandLine(Global.CommandLineArgs);

            upExec.License = Resources.License;
            upExec.MustAcceptLicense = true;
            upExec.Logo = Resources.Logo;
            upExec.InstallerVersion = Application.ProductVersion;

            var tSuccess = upExec.Initialise(SAUpdaterWinOSVersion.Win7, SAUpdaterFrameworkVersions.Version45, nrs, nc, uo);

            if (!tSuccess) return;

            upExec.Add(SAApplicationType.KillProcess);
            upExec.Add(SAApplicationType.Download);
            upExec.Add(SAApplicationType.DownloadFiles);
            upExec.Add(SAApplicationType.Install);
            upExec.Add(SAApplicationType.InstallEnd);

            btnNotes.Visible = upExec.HasNotes;

            upExec.CloseInstaller += Close;
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();

            upExec.ShowFirst();
            pnlInstall.Visible = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNotes_Click(object sender, EventArgs e)
        {
            ShowNotes();
        }

        private void upExec_InstallCompleted(bool success)
        {
            ControlBox = true;
            btnNotes.Enabled = true;
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

        private void ShowInstaller()
        {
            pnlInstall.Visible = true;
        }

        private void ShowNotes()
        {
            pnlInstall.Visible = false;
            pnlNotes.Visible = true;

            if (!mHasLoadedNotes)
            {
                VersionNotes.LoadNotes();
                mHasLoadedNotes = true;
            }
        }

        private void HideNotes()
        {
            pnlNotes.Visible = false;
            pnlInstall.Visible = true;
        }

        #endregion Methods
    }
}