using SangAdv.Updater.Common;
using System;

namespace SangAdv.Updater.Master
{
    public partial class eucFTPRepository : eucRepositoryBase
    {
        #region Variables

        private SAUpdaterRepositorySettings<SAHFTPRepositoryConfig> mSettings = new SAUpdaterRepositorySettings<SAHFTPRepositoryConfig>();

        #endregion Variables

        #region Properties

        internal override string SettingsToString => mSettings.ToString();

        #endregion Properties

        #region Constructor

        public eucFTPRepository()
        {
            InitializeComponent();
            CheckValidRepositoryEntries();
        }

        #endregion Constructor

        #region Override Methods

        internal override void SetVariableDefaults()
        {
            txtFTPServer.Text = new Uri(mSettings.Settings.FTPServer.FixURLDirectoryLink(), UriKind.Absolute).ToString();
            txtApplicationFolder.Text = mSettings.Settings.ApplicationFolder;
            txtFTPUsername.Text = mSettings.Settings.FTPUsername;
            txtFTPPassword.Text = mSettings.Settings.FTPPassword;
            txtFTPServerDownloadUri.Text = new Uri(mSettings.Settings.FTPDownloadUri.FixURLDirectoryLink(), UriKind.Absolute).ToString();
        }

        internal override void GetVariableDefaults()
        {
            if (!CheckValidRepositoryEntries()) return;
            mSettings.Settings.FTPServer = txtFTPServer.Text;
            mSettings.Settings.ApplicationFolder = txtApplicationFolder.Text;
            mSettings.Settings.FTPUsername = txtFTPUsername.Text;
            mSettings.Settings.FTPPassword = txtFTPPassword.Text;
            mSettings.Settings.FTPDownloadUri = txtFTPServerDownloadUri.Text;
        }

        internal override void ResetFields()
        {
            txtFTPServer.Text = string.Empty;
            txtApplicationFolder.Text = string.Empty;
            txtFTPUsername.Text = string.Empty;
            txtFTPPassword.Text = string.Empty;
            txtFTPServerDownloadUri.Text = string.Empty;
        }

        internal override void ResetSettings()
        {
            mSettings.Reset();
        }

        internal override void SettingsFromString(string repositoryString)
        {
            mSettings.FromString(repositoryString);
        }

        internal override void DoRepositoryTest()
        {
            var repository = new SAUpdaterFTPRepository(SettingsToString);
            var f = new frmTestRepositorySettings(repository);
            f.ShowDialog(this);
        }

        #endregion Override Methods

        #region Private Methods

        private bool CheckValidRepositoryEntries()
        {
            ErrorMessage = string.Empty;
            var tIsValid = true;

            if (tIsValid && string.IsNullOrEmpty(txtApplicationFolder.Text)) { ErrorMessage = "App Repository not specified"; tIsValid = false; }
            if (tIsValid && string.IsNullOrEmpty(txtFTPServer.Text)) { ErrorMessage = "FTP Server not specified"; tIsValid = false; }
            if (tIsValid && string.IsNullOrEmpty(txtFTPUsername.Text)) { ErrorMessage = "FTP Username not specified"; tIsValid = false; }
            if (tIsValid && string.IsNullOrEmpty(txtFTPPassword.Text)) { ErrorMessage = "FTP Password not specified"; tIsValid = false; }
            if (tIsValid && !txtFTPServer.Text.ToUpper().Contains(@"FTP://")) { ErrorMessage = "Not a valid FTP Url"; tIsValid = false; }
            if (tIsValid && string.IsNullOrEmpty(txtFTPServerDownloadUri.Text)) { ErrorMessage = "FTP Download Server not specified"; tIsValid = false; }
            if (tIsValid && !txtFTPServerDownloadUri.Text.ToUpper().Contains(@"HTTP")) { ErrorMessage = "Not a valid HTTP Url"; tIsValid = false; }
            RaiseValidityChangedEvent(tIsValid);

            return tIsValid;
        }

        #endregion Private Methods

        #region Process UI

        private void txtFTPServer_TextChanged(object sender, System.EventArgs e)
        {
            CheckValidRepositoryEntries();
        }

        private void txtApplicationFolder_TextChanged(object sender, System.EventArgs e)
        {
            CheckValidRepositoryEntries();
        }

        private void txtFTPUsername_TextChanged(object sender, System.EventArgs e)
        {
            CheckValidRepositoryEntries();
        }

        private void txtFTPPassword_TextChanged(object sender, System.EventArgs e)
        {
            CheckValidRepositoryEntries();
        }

        private void txtFTPServerDownloadUri_TextChanged(object sender, System.EventArgs e)
        {
            CheckValidRepositoryEntries();
        }

        private void chkShowPassword_CheckedChanged(object sender, System.EventArgs e)
        {
            txtFTPPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '*';
        }

        #endregion Process UI
    }
}