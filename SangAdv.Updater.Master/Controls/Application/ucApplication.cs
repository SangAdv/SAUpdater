using SangAdv.Updater.Common;
using System;
using System.Windows.Forms;

namespace SangAdv.Updater.Master
{
    public partial class ucApplication : ucTemplate
    {
        #region Variables

        private AppDataFile mAppDataFile = SAUpdaterMasterCommon.AppData;
        private eucRepositoryBase mRepositoryBase;
        private SAUpdaterRepositoryType mStartRepositoryType = SAUpdaterRepositoryType.AzureBlob;
        private bool mHasLoadedRepository = false;

        #endregion Variables

        #region Constructor

        public ucApplication(int selectedAppId)
        {
            InitializeComponent();
            //Add any initialization after the InitializeComponent() call.
        }

        #endregion Constructor

        #region Override Methods

        public override void LoadStartData()
        {
            Application.DoEvents();
            SuspendLayout();

            LoadCategories();
            LoadNetFrameworkVersions();
            LoadOSTypes();
            LoadDirectories();

            ResetFields();

            btnUpdate.Text = "Update";
            lblAppHeader.Text = $"Update Application: {mAppDataFile.Application.CurrentApplication.ApplicationTitle}";

            SetVariableDefaults();

            LoadRepositoryType();
            LoadRepositoryData();

            CheckValidEntries();
            RaiseButtonsEnabledEvent(btnUpdate.Enabled);

            ResumeLayout();
        }

        #endregion Override Methods

        #region Private Methods

        private void CheckValidEntries()
        {
            lblMessage.Text = string.Empty;
            btnUpdate.Enabled = false;
            mRepositoryBase.SetTestButton(false);

            if (string.IsNullOrEmpty(txtLocalDirectory.Text)) { lblMessage.Text = "App source directory not specified"; return; }
            if (mRepositoryBase.HasError) { lblMessage.Text = mRepositoryBase.ErrorMessage; return; }

            btnUpdate.Enabled = true;
            mRepositoryBase.SetTestButton(true);
        }

        private void SetVariableDefaults()
        {
            txtAppDescription.Text = mAppDataFile.Application.CurrentApplication.ApplicationTitle;
            txtLocalDirectory.Text = mAppDataFile.Application.CurrentApplication.SourceFolder;
            lblCreatedOn.Text = mAppDataFile.Application.CurrentApplication.DateTimeCreated.ToDateTime().ToString("D");
            cmbNetVersion.SelectedValue = mAppDataFile.Application.CurrentApplication.RequiredNetFramework.ToString();
            cmbOSType.SelectedValue = mAppDataFile.Application.CurrentApplication.RequiredOSType.ToString();
            cmbOSVersion.SelectedValue = mAppDataFile.Application.CurrentApplication.RequiredOSVersion.ToString();
            chkRequire64BitOS.Checked = mAppDataFile.Application.CurrentApplication.Requires64BitOS;
        }

        private void AssignVariableValues()
        {
            mAppDataFile.Application.CurrentApplication.SourceFolder = txtLocalDirectory.Text;
            mAppDataFile.Application.CurrentApplication.RepositorySettingsString = mRepositoryBase.GetRepositoryDefinition;
            mAppDataFile.Application.CurrentApplication.RequiredNetFramework = cmbNetVersion.SelectedValue.Value<int>();
            mAppDataFile.Application.CurrentApplication.RequiredOSType = cmbOSType.SelectedValue.Value<int>();
            mAppDataFile.Application.CurrentApplication.RequiredOSVersion = cmbOSVersion.SelectedValue.Value<int>();
            mAppDataFile.Application.CurrentApplication.Requires64BitOS = chkRequire64BitOS.Checked;
            mAppDataFile.Application.CurrentApplication.RepositoryType = (SAUpdaterRepositoryType)(cmbRepositoryType.SelectedValue.Value<int>());
        }

        private void LoadDirectories()
        {
            lvwFolders.SuspendLayout();

            lvwFolders.Groups.Clear();
            lvwFolders.Items.Clear();
            //Add items
            foreach (var item in mAppDataFile.Folders.List)
            {
                var itm = new ListViewItem { ImageIndex = 0, Text = item.Folder, Tag = item.Id };
                lvwFolders.Items.Add(itm);
            }

            lvwFolders.ResumeLayout();
        }

        private void ResetFields()
        {
            mRepositoryBase?.ResetFields();

            lblMessage.Text = string.Empty;
            cmbNetVersion.SelectedValue = ((int)SAUpdaterFrameworkVersions.None).ToString();
            cmbOSType.SelectedValue = ((int)SAUpdaterOSType.Windows).ToString();
            cmbOSVersion.SelectedValue = ((int)SAUpdaterWinOSVersion.Win7).ToString();
            txtAppDescription.Text = string.Empty;
            txtLocalDirectory.Text = string.Empty;
            txtLocalDirectory.Text = string.Empty;
            lblCreatedOn.Text = string.Empty;
            btnDirDelete.Enabled = false;
        }

        private void LoadCategories()
        {
            cmbCategory.DataSource = SAUpdaterMasterCommon.MasterData.Categories.List;
            cmbCategory.SelectedValue = mAppDataFile.Application.CurrentApplication.CategoryId;
        }

        private void LoadRepositoryType()
        {
            var cbis = new ComboBoxItems();
            cbis.Add<SAUpdaterRepositoryType>();
            cmbRepositoryType.DataSource = cbis.Items;
            if (cbis.Items.Count < 2)
            {
                cmbRepositoryType.Enabled = false;
            }
            else
            {
                cmbRepositoryType.SelectedValue =
                    mAppDataFile.Application.CurrentApplication.RepositoryType.Value<int>().ToString();
            }
            mHasLoadedRepository = true;
        }

        private void LoadOSTypes()
        {
            var cbis = new ComboBoxItems();
            cbis.Add<SAUpdaterOSType>();
            cmbOSType.DataSource = cbis.Items;
        }

        private void LoadOSVersions(SAUpdaterOSType osType)
        {
            cmbOSVersion.Enabled = true;
            var cbis = new ComboBoxItems();
            switch (osType)
            {
                case SAUpdaterOSType.Windows:

                    var os = new SAUpdaterWinOSVersions();
                    foreach (var item in os.VersionList) cbis.Add(item.Value, Convert.ToInt32(item.Key).ToString());
                    cmbOSVersion.DataSource = cbis.Items;

                    break;

                default:
                    cmbOSVersion.Enabled = false;
                    break;
            }
        }

        private void LoadNetFrameworkVersions()
        {
            var cbis = new ComboBoxItems();
            cbis.Add("Unknown", ((int)SAUpdaterFrameworkVersions.None).ToString());
            cbis.Add("4.5", ((int)SAUpdaterFrameworkVersions.Version45).ToString());
            cbis.Add("4.5.1", ((int)SAUpdaterFrameworkVersions.Version451).ToString());
            cbis.Add("4.5.2", ((int)SAUpdaterFrameworkVersions.Version452).ToString());
            cbis.Add("4.6", ((int)SAUpdaterFrameworkVersions.Version46).ToString());
            cbis.Add("4.6.1", ((int)SAUpdaterFrameworkVersions.Version461).ToString());
            cbis.Add("4.6.2", ((int)SAUpdaterFrameworkVersions.Version462).ToString());
            cbis.Add("4.7", ((int)SAUpdaterFrameworkVersions.Version47).ToString());
            cbis.Add("4.7.1", ((int)SAUpdaterFrameworkVersions.Version471).ToString());
            cbis.Add("4.7.2", ((int)SAUpdaterFrameworkVersions.Version472).ToString());
            cmbNetVersion.DataSource = cbis.Items;
        }

        private void DisplayRepositoryControl()
        {
            mRepositoryBase.Dock = DockStyle.Fill;

            pnlRepository.Controls.Clear();
            pnlRepository.Controls.Add(mRepositoryBase);
        }

        private void UpdateRepositoryValidity(bool valid)
        {
            CheckValidEntries();
        }

        private void LoadRepositoryData()
        {
            switch ((SAUpdaterRepositoryType)cmbRepositoryType.SelectedValue.Value<int>())
            {
                case SAUpdaterRepositoryType.FTP:
                    mRepositoryBase = new eucFTPRepository();
                    break;

                case SAUpdaterRepositoryType.AzureBlob:
                    mRepositoryBase = new eucAzureBlobRepository();
                    break;

                default:
                    break;
            }

            DisplayRepositoryControl();

            mRepositoryBase.ResetFields();
            mRepositoryBase.SetRepositoryDefinition(mAppDataFile.Application.CurrentApplication.RepositorySettingsString);

            mRepositoryBase.ValidityChanged += UpdateRepositoryValidity;
        }

        #endregion Private Methods

        #region Process UI

        private void cmbRepositoryType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!mHasLoadedRepository) return;
            LoadRepositoryData();
        }

        private void btnChooseDirectory_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    txtLocalDirectory.Text = fbd.SelectedPath;
                }
            }

            CheckValidEntries();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            AssignVariableValues();
            mAppDataFile.Application.Update();
            RaiseButtonsEnabledEvent(btnUpdate.Enabled);
        }

        private void btnAppCancel_Click(object sender, EventArgs e)
        {
            ResetFields();
        }

        private void cmbOSType_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadOSVersions((SAUpdaterOSType)(cmbOSType.SelectedValue.Value<int>()));
        }

        private void btnDirAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAppFolder.Text)) return;
            txtAppFolder.Text = txtAppFolder.Text.FixFolderText();
            mAppDataFile.Folders.Add($"{SAUpdaterConstants.RootFolder}{txtAppFolder.Text}");
            LoadDirectories();
        }

        private void btnDirCancel_Click(object sender, EventArgs e)
        {
            txtAppFolder.Text = string.Empty;
        }

        #endregion Process UI
    }
}