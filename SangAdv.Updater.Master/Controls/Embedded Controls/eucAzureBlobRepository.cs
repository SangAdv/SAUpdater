using SangAdv.Updater.Common;
using System;

namespace SangAdv.Updater.Master
{
    public partial class eucAzureBlobRepository : eucRepositoryBase
    {
        #region Variables

        private SAUpdaterRepositorySettings<SAHAzureBlobRepositoryConfig> mSettings = new SAUpdaterRepositorySettings<SAHAzureBlobRepositoryConfig>();

        #endregion Variables

        #region Properties

        internal override string SettingsToString => mSettings.ToString();

        #endregion Properties

        #region Constructor

        public eucAzureBlobRepository()
        {
            InitializeComponent();
            CheckValidRepositoryEntries();
        }

        #endregion Constructor

        #region Override Methods

        internal override void SetVariableDefaults()
        {
            txtAzureBlobConnectionString.Text = mSettings.Settings.AzureBlobConnectionString;
            txtAzureBlobCotainerName.Text = mSettings.Settings.AzureBlobContainerName;
            txtApplicationFolder.Text = mSettings.Settings.ApplicationFolder;
            //txtFTPUsername.Text = mSettings.Settings.FTPUsername;
            //txtFTPPassword.Text = mSettings.Settings.FTPPassword;
            txtAzureBlobDownloadUri.Text = !string.IsNullOrEmpty(mSettings.Settings.FTPDownloadUri) ? new Uri(mSettings.Settings.FTPDownloadUri.FixURLDirectoryLink(), UriKind.Absolute).ToString() : string.Empty;
        }

        internal override void GetVariableDefaults()
        {
            if (!CheckValidRepositoryEntries()) return;
            mSettings.Settings.AzureBlobConnectionString = txtAzureBlobConnectionString.Text;
            mSettings.Settings.AzureBlobContainerName = txtAzureBlobCotainerName.Text;
            mSettings.Settings.ApplicationFolder = txtApplicationFolder.Text;
            //mSettings.Settings.FTPUsername = txtFTPUsername.Text;
            //mSettings.Settings.FTPPassword = txtFTPPassword.Text;
            mSettings.Settings.FTPDownloadUri = txtAzureBlobDownloadUri.Text;
        }

        internal override void ResetFields()
        {
            txtAzureBlobConnectionString.Text = string.Empty;
            txtApplicationFolder.Text = string.Empty;
            txtAzureBlobCotainerName.Text = string.Empty;
            //txtFTPUsername.Text = string.Empty;
            //txtFTPPassword.Text = string.Empty;
            txtAzureBlobDownloadUri.Text = string.Empty;
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
            //var repository = new SAUpdaterFTPRepository(SettingsToString);
            var repository = new SAUpdaterAzureBlobRepository(SettingsToString);
            var f = new frmTestRepositorySettings(repository);
            f.ShowDialog(this);
        }

        #endregion Override Methods

        #region Private Methods

        private bool CheckValidRepositoryEntries()
        {
            ErrorMessage = string.Empty;
            var tIsValid = true;

            //if (tIsValid && string.IsNullOrEmpty(txtApplicationFolder.Text)) { ErrorMessage = "App Repository not specified"; tIsValid = false; }
            //if (tIsValid && string.IsNullOrEmpty(txtAzureBlobConnectionString.Text)) { ErrorMessage = "FTP Server not specified"; tIsValid = false; }
            ////if (tIsValid && string.IsNullOrEmpty(txtFTPUsername.Text)) { ErrorMessage = "FTP Username not specified"; tIsValid = false; }
            ////if (tIsValid && string.IsNullOrEmpty(txtFTPPassword.Text)) { ErrorMessage = "FTP Password not specified"; tIsValid = false; }
            //if (tIsValid && !txtAzureBlobConnectionString.Text.ToUpper().Contains(@"FTP://")) { ErrorMessage = "Not a valid FTP Url"; tIsValid = false; }
            //if (tIsValid && string.IsNullOrEmpty(txtAzureBlobDownloadUri.Text)) { ErrorMessage = "FTP Download Server not specified"; tIsValid = false; }
            //if (tIsValid && !txtAzureBlobDownloadUri.Text.ToUpper().Contains(@"HTTP")) { ErrorMessage = "Not a valid HTTP Url"; tIsValid = false; }
            RaiseValidityChangedEvent(tIsValid);

            return tIsValid;
        }

        #endregion Private Methods

        #region Process UI

        private void txtAzureBlobConnectionString_TextChanged(object sender, EventArgs e)
        {
            CheckValidRepositoryEntries();
        }

        private void txtAzureBlobCotainerName_TextChanged(object sender, EventArgs e)
        {
            CheckValidRepositoryEntries();
        }

        private void txtAzureBlobDownloadUri_TextChanged(object sender, EventArgs e)
        {
            CheckValidRepositoryEntries();
        }

        private void txtApplicationFolder_TextChanged(object sender, EventArgs e)
        {
            CheckValidRepositoryEntries();
        }

        #endregion Process UI
    }
}