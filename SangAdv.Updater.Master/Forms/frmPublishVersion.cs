using SangAdv.Updater.Common;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SangAdv.Updater.Master
{
    public partial class frmPublishVersion : Form
    {
        #region Variables

        private SAUpdaterMaster mMaster = SAUpdaterGlobal.Master;
        private AppDataFile mAppDataFile = SAUpdaterMasterCommon.AppData;

        private ASAUpdaterRepositoryBase mRepositoryBase;

        private string mInstallerFilename;

        #endregion Variables

        #region Constructor

        public frmPublishVersion()
        {
            InitializeComponent();

            SAUpdaterGlobal.Options = new SAUpdaterUpdateOptions();

            SetRepository();

            LoadPreReleaseTypes();

            lblCurrentInstallerVersion.Text = mAppDataFile.Application.CurrentApplication.InstallerVersion;
            lblSelectedInstallerVersion.Text = SAUpdaterConstants.NoVersion;

            DisplayMessage("");
        }

        #endregion Constructor

        #region Process UI

        private void frmPublishVersion_Shown(object sender, EventArgs e)
        {
            LoadReleaseVersions();
        }

        private void cmbPreReleaseType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPreReleaseVersions(((SAUpdaterReleaseType)cmbPreReleaseType.SelectedValue.Value<int>()));
        }

        private void btnPublish_Click(object sender, EventArgs e)
        {
            SetButtons(false);

            DisplayMessage("Publishing version definition ...");

            mRepositoryBase.UpdateDefinition.ReleaseVersion = string.IsNullOrEmpty(cmbReleaseVersion.Text) ? SAUpdaterConstants.NoVersion : cmbReleaseVersion.Text;
            mRepositoryBase.UpdateDefinition.PreReleaseVersion = string.IsNullOrEmpty(cmbPreReleaseVersion.Text) ? SAUpdaterConstants.NoVersion : cmbPreReleaseVersion.Text;
            mRepositoryBase.UpdateDefinition.InstallerVersion = string.IsNullOrEmpty(mAppDataFile.Application.CurrentApplication.InstallerVersion) ? SAUpdaterConstants.NoVersion : mAppDataFile.Application.CurrentApplication.InstallerVersion;
            mRepositoryBase.UpdateDefinition.IntRequiredFramework = mAppDataFile.Application.CurrentApplication.RequiredNetFramework;
            mRepositoryBase.UpdateDefinition.IntRequiredOSType = mAppDataFile.Application.CurrentApplication.RequiredOSType;
            mRepositoryBase.UpdateDefinition.IntRequiredOSVersion = mAppDataFile.Application.CurrentApplication.RequiredOSVersion;
            mRepositoryBase.UpdateDefinition.IntReleaseType = cmbPreReleaseType.SelectedValue.Value<int>();
            mRepositoryBase.UpdateDefinition.InstallerMD5 = mAppDataFile.Application.CurrentApplication.InstallerMD5;
            mRepositoryBase.UpdateDefinition.InstallerCompressedMD5 = mAppDataFile.Application.CurrentApplication.InstallerCompressedMD5;
            mRepositoryBase.UpdateDefinition.HasReleaseNotes = VersionHasNotes(!string.IsNullOrEmpty(cmbReleaseVersion.Text) ? cmbReleaseVersion.SelectedValue.Value<int>() : 0);
            mRepositoryBase.UpdateDefinition.HasPreReleaseNotes = VersionHasNotes(!string.IsNullOrEmpty(cmbPreReleaseVersion.Text) ? cmbPreReleaseVersion.SelectedValue.Value<int>() : 0);
            mRepositoryBase.UpdateDefinition.Is64BitOSRequired = mAppDataFile.Application.CurrentApplication.Requires64BitOS;

            mRepositoryBase.SetUpdateDefinition();

            DisplayMessage("Version definition published");

            SetButtons(true);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnInstallerSelect_Click(object sender, EventArgs e)
        {
            SetButtons(false);

            ChooseInstallerFiles();

            SetButtons(true);
        }

        private void btnUploadInstaller_Click(object sender, EventArgs e)
        {
            SetButtons(false);

            UploadInstaller();

            SetButtons(true);
        }

        #endregion Process UI

        #region Private Methods

        private void LoadReleaseVersions()
        {
            var cbis = new ComboBoxItems();
            foreach (var item in mAppDataFile.Versions.List.Where(x => x.VersionStatus == (int)SAUpdaterAppVersionStatus.Uploaded && x.ReleaseType == (int)SAUpdaterReleaseType.Release).OrderByDescending(x => x.VersionIndex))
            {
                cbis.Add(item.VersionNumber, item.Id.ToString());
            }
            cmbReleaseVersion.DataSource = cbis.Items;
            cmbReleaseVersion.Enabled = cbis.Items.Count > 0;
        }

        private void LoadPreReleaseVersions(SAUpdaterReleaseType releaseType)
        {
            var cbis = new ComboBoxItems();
            foreach (var item in mAppDataFile.Versions.List.Where(x => x.VersionStatus == (int)SAUpdaterAppVersionStatus.Uploaded && x.ReleaseType == (int)releaseType).OrderByDescending(x => x.VersionIndex))
            {
                cbis.Add(item.VersionNumber, item.Id.ToString());
            }
            cmbPreReleaseVersion.DataSource = cbis.Items;
            cmbPreReleaseVersion.Enabled = cbis.Items.Count > 0;
        }

        private void SetRepository()
        {
            switch (mAppDataFile.Application.CurrentApplication.RepositoryType)
            {
                case SAUpdaterRepositoryType.FTP:
                    mRepositoryBase = new SAUpdaterFTPRepository(mAppDataFile.Application.CurrentApplication.RepositorySettingsString);
                    break;

                default:
                    break;
            }
        }

        private void LoadPreReleaseTypes()
        {
            var cbis = new ComboBoxItems();
            foreach (var item in Enum<SAUpdaterReleaseType>.GetAllValues())
            {
                if (item != SAUpdaterReleaseType.Release) cbis.Add(item.ToString(), item.Value<int>().ToString());
            }
            cmbPreReleaseType.DataSource = cbis.Items;
        }

        private void ChooseInstallerFiles()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Filter = "Installer Files (*.exe)|*.exe",
                FilterIndex = 1,
                Multiselect = false,
                CheckFileExists = true,
                CheckPathExists = true
            };
            var UserClickedOK = openFileDialog1.ShowDialog();

            if ((UserClickedOK == DialogResult.OK) & (openFileDialog1.FileNames.Length > 0))
            {
                mInstallerFilename = openFileDialog1.FileName;
                lblSelectedInstallerVersion.Text = FileVersionInfo.GetVersionInfo(mInstallerFilename).FileVersion;
                if (!lblSelectedInstallerVersion.Text.CheckVersionNumberFormat())
                {
                    DisplayMessage("Invalid version number", Color.Red);
                    btnUploadInstaller.Enabled = false;
                }
                else
                {
                    btnUploadInstaller.Enabled = true;
                }
            }
        }

        private void UploadInstaller()
        {
            DisplayMessage("Uploading Installer ...");

            var tMD5 = "";
            var tCompressedMD5 = "";
            var tCompressedFilename = "";

            //Create compressed installer file
            var tFilename = new FileInfo(mInstallerFilename).Name;
            tCompressedFilename = $"{tFilename}.ZIP";

            if (!mMaster.CompressFile(mInstallerFilename, tCompressedFilename))
            {
                DisplayMessage($"Error: {mMaster.ErrorMessage}", Color.Red);
                return;
            }

            if (!string.IsNullOrEmpty(tCompressedFilename))
            {
                tMD5 = mInstallerFilename.GenerateFileMD5();
                tCompressedMD5 = Path.Combine(mMaster.UploadFolder, tCompressedFilename).GenerateFileMD5();
            }

            //Do staging upload
            //Upload compressed version
            DisplayMessage($"Staging {tCompressedFilename} ...");
            if (!mRepositoryBase.UploadFile(Path.Combine(mMaster.UploadFolder, tCompressedFilename), mRepositoryBase.RepositoryDownloadFolder, $"{tCompressedFilename}.TMP"))
            {
                DisplayMessage($"Error: {tCompressedFilename} could not be uploaded");
                return;
            }
            //Upload normal version
            DisplayMessage($"Staging {tFilename} ...");
            if (!mRepositoryBase.UploadFile(mInstallerFilename, mRepositoryBase.RepositoryDownloadFolder, $"{tFilename}.TMP"))
            {
                DisplayMessage($"Error: {tCompressedFilename} could not be uploaded");
                return;
            }

            //Replace the current installer with the new one
            //Replace compressed version
            DisplayMessage($"Preparing {tCompressedFilename} ...");
            if (!mRepositoryBase.ReplaceFile(mRepositoryBase.RepositoryDownloadFolder, $"{tCompressedFilename}.TMP", tCompressedFilename))
            {
                DisplayMessage($"Error: {tCompressedFilename} could not be replaced");
                return;
            }
            //Replace compressed version
            DisplayMessage($"Preparing {tFilename} ...");
            if (!mRepositoryBase.ReplaceFile(mRepositoryBase.RepositoryDownloadFolder, $"{tFilename}.TMP", tFilename))
            {
                DisplayMessage($"Error: {tCompressedFilename} could not be replaced");
                return;
            }

            //Update the application installer details
            mAppDataFile.Application.CurrentApplication.InstallerVersion = lblSelectedInstallerVersion.Text;
            mAppDataFile.Application.CurrentApplication.InstallerMD5 = tMD5;
            mAppDataFile.Application.CurrentApplication.InstallerCompressedMD5 = tCompressedMD5;
            mAppDataFile.Application.Update();

            DisplayMessage("Installer upload completed successfully.");
        }

        private void SetButtons(bool enabled)
        {
            btnUploadInstaller.Enabled = enabled;
            btnInstallerSelect.Enabled = enabled;
            btnClose.Enabled = enabled;
            btnPublish.Enabled = enabled;
        }

        private void DisplayMessage(string message, Color? foreColor = null)
        {
            if (foreColor == null) foreColor = Color.Black;
            lblMessage.ForeColor = (Color)foreColor;
            lblMessage.Text = message;
            Application.DoEvents();
        }

        private bool VersionHasNotes(int versionId)
        {
            return versionId != 0 && mAppDataFile.Versions.Get(versionId).HasNotes;
        }

        #endregion Private Methods
    }
}