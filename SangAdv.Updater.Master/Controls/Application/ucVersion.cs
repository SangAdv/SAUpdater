using SangAdv.Updater.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SangAdv.Updater.Master
{
    public partial class ucVersion : ucTemplate
    {
        #region Variables

        private int mSelectedAppId = 0;
        private AppDataFile mAppDataFile = SAUpdaterMasterCommon.AppData;
        private AppDataVersionItem mCurrentVersion = new AppDataVersionItem();
        private bool mIsloadingVersions = false;
        private ASAUpdaterRepositoryBase mRepositoryBase;

        #endregion Variables

        #region Constructor

        public ucVersion(int selectedAppId)
        {
            InitializeComponent();
            mSelectedAppId = selectedAppId;

            mRepositoryBase = SAUpdaterMasterCommon.Repository();
        }

        #endregion Constructor

        #region Override Methods

        public override void LoadStartData()
        {
            SuspendLayout();
            Application.DoEvents();

            btnVersionAdd.Enabled = false;

            RaiseEventStatusMessageChanged("");

            lblVersionHeader.Text = $"Versions: {mAppDataFile.Application.CurrentApplication.ApplicationTitle}";

            DefineFileListviewLayout();

            ResetFields();
            LoadVersions();
            LoadReleaseType();

            RaiseEventStatusMessageChanged("");
            ResumeLayout();
        }

        #endregion Override Methods

        #region Process UI

        private void btnVersionAdd_Click(object sender, EventArgs e)
        {
            if (mCurrentVersion.Id == 0)
            {
                rtbNotes.Text = string.Empty;
                var tVersionId = mAppDataFile.Versions.Add(txtAppVersion.Text.Trim(), cmbRelease.SelectedValue.Value<int>(), rtbNotes.Rtf.DeflateString());
                mCurrentVersion = mAppDataFile.Versions.Get(tVersionId);
            }
            else
            {
                mCurrentVersion.VersionNumber = txtAppVersion.Text.Trim();
                mCurrentVersion.DateTimePublished = string.Empty;
                mCurrentVersion.VersionNotes = rtbNotes.Rtf.DeflateString();
                mCurrentVersion.HasNotes = !string.IsNullOrEmpty(rtbNotes.Text);
                mCurrentVersion.VersionStatus = mAppDataFile.VersionFiles.Count(mCurrentVersion.Id) > 0 ? (int)SAUpdaterAppVersionStatus.Defined : (int)SAUpdaterAppVersionStatus.New;
                mAppDataFile.Versions.Update(mCurrentVersion);
            }
            ResetFields();
            LoadVersions();
        }

        private void btnAddFiles_Click(object sender, EventArgs e)
        {
            RaiseEventDisableMainAndStatusChanged("Adding Files, Please wait...");

            for (var z = 0; z <= lvwAppFiles.Items.Count - 1; z++)
            {
                var tFileId = lvwAppFiles.Items[z].Tag.Value<int>();
                if (lvwAppFiles.Items[z].Checked)
                {
                    AddVersionFile(tFileId, lvwAppFiles.Items[z].SubItems[3].Text);
                    mAppDataFile.ReleaseTypeFiles.Delete(tFileId, (SAUpdaterReleaseType)cmbRelease.SelectedValue.Value<int>());
                }
                lvwAppFiles.Items[z].Checked = false;
            }
            mAppDataFile.Versions.Update(mCurrentVersion);

            LoadVersionFiles();
            LoadAppFiles();

            RaiseEventEnableMainAndStatusChanged("Files added successfully");
            RaiseEventStatusMessageChanged("");
        }

        private void lvwVersions_Click(object sender, EventArgs e)
        {
            if (lvwVersions.SelectedItems.Count > 0)
            {
                var tSelectedVersionId = lvwVersions.SelectedItems[0].Tag.Value<int>();

                mCurrentVersion = mAppDataFile.Versions.Get(tSelectedVersionId);

                txtAppVersion.Text = mCurrentVersion.VersionNumber;
                lblCreatedDate.Text = string.IsNullOrEmpty(mCurrentVersion.DateTimeCreated) ? "" : mCurrentVersion.DateTimeCreated.ToDateTime().ToString("F");
                lblPublishedDate.Text = string.IsNullOrEmpty(mCurrentVersion.DateTimePublished) ? "" : mCurrentVersion.DateTimePublished.ToDateTime().ToString("F");
                rtbNotes.Rtf = mCurrentVersion.VersionNotes.InflateString();

                LoadVersionFiles();
                btnVersionAdd.Text = "Update";
                btnDelete.Enabled = CheckCanDeleteVersion();
                tabVersion.Enabled = true;
                cmbRelease.Enabled = false;

                LoadAppFiles();
                //Set the publish button
                btnPublishFiles.Enabled = CheckCanPublish();
                btnPublishVersion.Enabled = mAppDataFile.Versions.PublishedCount > 0;
            }
            btnUpdateOptions.Enabled = false;
            SetFilesButtons();
        }

        private void txtAppVersion_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAppVersion.Text)) txtAppVersion.Text = string.Empty;
            btnVersionAdd.Enabled = txtAppVersion.Text.CheckVersionNumberFormat();
        }

        private void btnVersionCancel_Click(object sender, EventArgs e)
        {
            ResetFields();
        }

        private void btnClearFiles_Click(object sender, EventArgs e)
        {
            mAppDataFile.VersionFiles.Delete(mCurrentVersion.Id);
            LoadVersionFiles();
        }

        private void lvwVersionFiles_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (mIsloadingVersions) return;
            SetFilesButtons();
        }

        private void btnSelAllVerFiles_Click(object sender, EventArgs e)
        {
            for (var z = 0; z <= lvwVersionFiles.Items.Count - 1; z++) lvwVersionFiles.Items[z].Checked = true;
        }

        private void btnClrAllVerFiles_Click(object sender, EventArgs e)
        {
            UnselectAllVersionFiles();
        }

        private void btnUpdateOptions_Click(object sender, EventArgs e)
        {
            var f = new frmUpdateOptions();
            if (f.ShowDialog(this) != DialogResult.OK) return;

            SetUpdateOption(f.UpdateOptionID, f.UpdateOptionValue);
        }

        private void lvwAppFiles_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            SetFilesButtons();
        }

        private void btnPublishFiles_Click(object sender, EventArgs e)
        {
            var f = new frmPublishFiles(mCurrentVersion.Id);
            f.ShowDialog(this);

            LoadVersions();
            LoadAppFiles();
        }

        private void btnPublishVersion_Click(object sender, EventArgs e)
        {
            var f = new frmPublishVersion();
            f.ShowDialog(this);

            LoadVersions();
        }

        private void btnSelAll_Click(object sender, EventArgs e)
        {
            for (var z = 0; z <= lvwAppFiles.Items.Count - 1; z++) lvwAppFiles.Items[z].Checked = true;
        }

        private void btnClrAll_Click(object sender, EventArgs e)
        {
            for (var z = 0; z <= lvwAppFiles.Items.Count - 1; z++) lvwAppFiles.Items[z].Checked = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteVersion();
        }

        private void btnTagMissing_Click(object sender, EventArgs e)
        {
            TagMissingFiles();
            btnTagMissing.Enabled = false;
        }

        #endregion Process UI

        #region Methods

        private void LoadReleaseType()
        {
            var cbis = new ComboBoxItems();
            cbis.Add<SAUpdaterReleaseType>();
            cmbRelease.DataSource = cbis.Items;
            cmbRelease.SelectedValue = ((int)SAUpdaterReleaseType.Release).ToString();
        }

        private void DefineFileListviewLayout()
        {
            var tExtensions = new Dictionary<string, string>();
            tExtensions.Add("exe", "Executable(s)");
            tExtensions.Add("dll", "Assemblies or dll(s)");
            tExtensions.Add("oth", "Other Included Files(s)");
            tExtensions.Add("ref", "Reference Files(s)");

            foreach (var kvp in tExtensions)
            {
                lvwAppFiles.Groups.Add(kvp.Key, kvp.Value);
                lvwVersionFiles.Groups.Add(kvp.Key, kvp.Value);
            }

            lvwAppFiles.FullRowSelect = true;
            ListViewExtender extender = new ListViewExtender(lvwAppFiles);

            ListViewImageColumn imageColumn1 = new ListViewImageColumn(4);
            extender.AddColumn(imageColumn1);
        }

        private void ResetFields()
        {
            mCurrentVersion.Id = 0;
            txtAppVersion.Text = string.Empty;
            btnVersionAdd.Text = "Add";
            lblCreatedDate.Text = string.Empty;
            lblPublishedDate.Text = string.Empty;
            btnPublishFiles.Enabled = false;
            btnAddFiles.Enabled = false;
            btnClearFiles.Enabled = false;
            btnDelete.Enabled = false;
            lvwVersionFiles.Items.Clear();
            btnAddFiles.Enabled = false;
            btnUpdateOptions.Enabled = false;
            tabVersion.Enabled = false;
            rtbNotes.Text = string.Empty;
            cmbRelease.Enabled = true;
            btnTagMissing.Enabled = false;

            btnPublishVersion.Enabled = mAppDataFile.Versions.PublishedCount > 0;
        }

        private void LoadVersions()
        {
            var items = new List<ListViewItem>();
            //Reset menu
            lvwVersions.Groups.Clear();
            lvwVersions.Items.Clear();
            //Add items
            var a = mAppDataFile.Versions.List.OrderByDescending(x => x.VersionIndex);
            foreach (var item in a)
            {
                var itm = new ListViewItem { ImageIndex = item.VersionStatus.Value<int>(), Text = $"{item.VersionNumber} > {item.EnumReleaseType}", Tag = item.Id };
                items.Add(itm);
            }

            lvwVersions.BeginUpdate();
            lvwVersions.Items.AddRange(items.ToArray());
            lvwVersions.EndUpdate();
        }

        private void LoadVersionFiles()
        {
            mIsloadingVersions = true;

            SAUpdaterAppVersionStatus tStatus;
            var strExtension = string.Empty;

            UseWaitCursor = true;
            Enabled = false;
            RaiseEventDisableMainAndStatusChanged("Loading version files ...");

            var items = new List<ListViewItem>();

            var tFiles = mAppDataFile.Files.List;
            var tFolders = mAppDataFile.Folders.List;

            #region Method Methods

            AppDataFileItem GetFile(int fileId)
            {
                var a = tFiles.Where(x => x.Id == fileId).ToList();
                return a.Any() ? a.First() : new AppDataFileItem();
            }

            AppDataFolderItem GetFolder(int folderId)
            {
                var a = tFolders.Where(x => x.Id == folderId).ToList();
                return a.Any() ? a.First() : new AppDataFolderItem();
            }

            #endregion Method Methods

            foreach (var ap in mAppDataFile.VersionFiles.GetAll(mCurrentVersion.Id))
            {
                var tAppFileItem = GetFile(ap.FileId);
                var tFullName = Path.Combine(mAppDataFile.Application.CurrentApplication.SourceFolder, tAppFileItem.Filename);

                if (tAppFileItem.ReferenceFile) ap.MD5 = "";
                else
                {
                    try
                    {
                        ap.MD5 = tFullName.GenerateFileMD5();
                    }
                    catch
                    {
                        ap.MD5 = "";
                    }
                    strExtension = Path.GetExtension(tAppFileItem.Filename).ToLower().TrimStart('.');
                }

                var lvi = new ListViewItem(tAppFileItem.Filename) { Checked = false };

                lvi.SubItems.Add(GetFolder(tAppFileItem.FolderId).Folder);
                lvi.SubItems.Add(UpdateOptionDescription((SAUpdaterOption)ap.UpdateOptionId, ap.UpdateOptionValue));

                lvi.Tag = ap.FileId;
                lvi.Group = lvwVersionFiles.Groups[SAUpdaterMasterCommon.ReturnGroupIndicator(tAppFileItem.ReferenceFile, strExtension)];

                items.Add(lvi);
            }

            lvwVersionFiles.BeginUpdate();
            lvwVersionFiles.ListViewItemSorter = null;

            lvwVersionFiles.Items.Clear();
            lvwVersionFiles.Items.AddRange(items.ToArray());

            lvwVersionFiles.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvwVersionFiles.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvwVersionFiles.Columns[2].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);

            lvwVersionFiles.EndUpdate();

            if (mAppDataFile.VersionFiles.GetAll(mCurrentVersion.Id).Count == 0) tStatus = SAUpdaterAppVersionStatus.New;
            else
            {
                if (mCurrentVersion.Status == SAUpdaterAppVersionStatus.Uploaded) tStatus = mCurrentVersion.Status;
                else tStatus = SAUpdaterAppVersionStatus.Defined;
            }

            mIsloadingVersions = false;

            SetStatusButtons(tStatus);
            UpdateVersionStatus(tStatus);

            Enabled = true;
            UseWaitCursor = false;

            RaiseEventEnableMainAndStatusChanged("");
        }

        private void LoadAppFiles()
        {
            UseWaitCursor = true;
            RaiseEventDisableMainAndStatusChanged("Loading application files ...");

            var items = new List<ListViewItem>();

            foreach (var ap in mAppDataFile.Files.List.Where(x => x.IncludeStatus).ToList())
            {
                var tFullName = Path.Combine(mAppDataFile.Application.CurrentApplication.SourceFolder, ap.Filename);

                if (!ap.IncludeStatus) continue;

                var tFileNewVersion = string.Empty;
                var tFilePublishedVersion = string.Empty;
                var tVersion = string.Empty;

                var strExtension = "";
                if (ap.ReferenceFile)
                {
                    strExtension = string.Empty;
                }
                else
                {
                    strExtension = Path.GetExtension(ap.Filename).ToLower().TrimStart('.');

                    try
                    {
                        tFileNewVersion = FileVersionInfo.GetVersionInfo(tFullName).FileVersion ?? string.Empty;
                    }
                    catch
                    {
                        tFileNewVersion = string.Empty;
                    }
                }

                if (mCurrentVersion.Id == 0) tFilePublishedVersion = string.Empty;
                else
                {
                    var tTempVersionId = mAppDataFile.ReleaseTypeFiles.GetVersionId(ap.Id, (SAUpdaterReleaseType)cmbRelease.SelectedValue.Value<int>());
                    tVersion = mAppDataFile.Versions.Get(tTempVersionId).VersionNumber;
                    tFilePublishedVersion = mAppDataFile.VersionFiles.Get(tTempVersionId, ap.Id).Version;
                }

                var lvi = new ListViewItem(ap.Filename);

                lvi.SubItems.Add(tFilePublishedVersion);
                lvi.SubItems.Add(tVersion);
                lvi.SubItems.Add(tFileNewVersion);
                lvi.SubItems.Add(ap.FileStatusImageIndex(mAppDataFile.Application.CurrentApplication.SourceFolder));

                if (tFileNewVersion.Trim().IsNewerVersion(tFilePublishedVersion) && !mAppDataFile.VersionFiles.Contains(mCurrentVersion.Id, ap.Id)) lvi.Checked = true;

                lvi.Tag = ap.Id;
                lvi.Group = lvwAppFiles.Groups[SAUpdaterMasterCommon.ReturnGroupIndicator(ap.ReferenceFile, strExtension)];

                items.Add(lvi);
            }

            lvwAppFiles.BeginUpdate();
            lvwAppFiles.ListViewItemSorter = null;

            lvwAppFiles.Items.Clear();
            lvwAppFiles.Items.AddRange(items.ToArray());

            lvwAppFiles.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvwAppFiles.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvwAppFiles.Columns[2].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvwAppFiles.Columns[3].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvwAppFiles.Columns[4].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);

            if (lvwAppFiles.Columns[1].Width < 65) lvwAppFiles.Columns[1].Width = 65;
            if (lvwAppFiles.Columns[2].Width < 65) lvwAppFiles.Columns[2].Width = 65;
            if (lvwAppFiles.Columns[3].Width < 65) lvwAppFiles.Columns[3].Width = 65;
            if (lvwAppFiles.Columns[4].Width > 60) lvwAppFiles.Columns[4].Width = 60;

            lvwAppFiles.EndUpdate();

            UseWaitCursor = false;
            RaiseEventEnableMainAndStatusChanged("");
        }

        private string UpdateOptionDescription(SAUpdaterOption updateOptionId, string updateOptionValue)
        {
            var tString = EnumFunctions.SplitCapitalizedWords(updateOptionId.ToString());
            switch (updateOptionId)
            {
                case SAUpdaterOption.UpdateIfOlderThan: return $"{tString} > {updateOptionValue}";
                default: return tString;
            }
        }

        private void SetStatusButtons(SAUpdaterAppVersionStatus versionStatus)
        {
            if (versionStatus == SAUpdaterAppVersionStatus.New | versionStatus == SAUpdaterAppVersionStatus.Defined)
            {
                btnAddFiles.Enabled = true;
                btnClearFiles.Enabled = true;
            }

            SetFilesButtons();
            btnUpdateOptions.Enabled = true;
        }

        private void UpdateVersionStatus(SAUpdaterAppVersionStatus versionStatus)
        {
            if (versionStatus == SAUpdaterAppVersionStatus.Uploaded)
            {
                mCurrentVersion.DateTimePublished = DateTime.Now.ToDateTimeString();
                lblPublishedDate.Text = mCurrentVersion.DateTimePublished.ToDateTime().ToString("F");
            }
            if (mCurrentVersion.VersionStatus != (int)versionStatus)
            {
                mCurrentVersion.VersionStatus = (int)versionStatus;
                mAppDataFile.Versions.Update(mCurrentVersion);
                LoadVersions();
            }
            mAppDataFile.Application.UpdateStatus(versionStatus);
        }

        private void AddVersionFile(int fileId, string version)
        {
            var tAppFileItem = mAppDataFile.Files.Get(fileId);
            var tUpdateOptionID = SAUpdaterOption.AlwaysUpdate;
            if (tAppFileItem.ReferenceFile) tUpdateOptionID = SAUpdaterOption.NeverUpdate;

            AppDataVersionFileItem tVersionFileitem;

            try
            {
                tVersionFileitem = mAppDataFile.VersionFiles.GetAll(mCurrentVersion.Id).First(x => x.FileId == fileId);
            }
            catch
            {
                tVersionFileitem = new AppDataVersionFileItem
                {
                    FileId = fileId,
                    VersionId = mCurrentVersion.Id,
                    Uploaded = false,
                    CompressedMD5 = string.Empty,
                    MD5 = string.Empty,
                    UpdateOptionId = (int)tUpdateOptionID,
                    Version = version,
                    UpdateOptionValue = string.Empty
                };
            }
            tVersionFileitem.Version = version;
            mAppDataFile.VersionFiles.Update(tVersionFileitem);
        }

        private void SetFilesButtons()
        {
            //Set the status of the Add Files button
            if (mCurrentVersion.Id > 0) btnAddFiles.Enabled = lvwAppFiles.CheckedItems.Count > 0;

            //Set the status of the Clear Files button
            if (lvwVersionFiles.CheckedItems.Count > 0)
            {
                btnUpdateOptions.Enabled = true;
                btnClearFiles.Enabled = true;
            }
            else
            {
                btnUpdateOptions.Enabled = false;
                btnClearFiles.Enabled = false;
            }
        }

        private void UnselectAllVersionFiles()
        {
            for (var z = 0; z <= lvwVersionFiles.Items.Count - 1; z++) lvwVersionFiles.Items[z].Checked = false;
        }

        private void SetUpdateOption(int updateOptionId, string updateOptionValue)
        {
            foreach (ListViewItem z in lvwVersionFiles.CheckedItems)
            {
                var tFileId = z.Tag.Value<int>();
                var tVersionFileitem = mAppDataFile.VersionFiles.Get(mCurrentVersion.Id, tFileId);
                tVersionFileitem.UpdateOptionId = updateOptionId;
                tVersionFileitem.UpdateOptionValue = updateOptionValue;
                mAppDataFile.VersionFiles.Update(tVersionFileitem);
                z.Checked = false;
            }
            LoadVersionFiles();
        }

        private void DeleteVersion()
        {
            // Clean the repo
            var tSuccess = mRepositoryBase.CleanUp(mCurrentVersion.VersionNumber);
            if (!tSuccess) RaiseEventStatusMessageChanged($"Could not clean repository for Version: {mCurrentVersion.VersionNumber}");

            //Remove all version info
            //App version files
            mAppDataFile.VersionFiles.Delete(mCurrentVersion.Id);
            //App version
            mAppDataFile.Versions.Delete(mCurrentVersion.Id);

            LoadVersions();
            ResetFields();
        }

        private bool CheckCanPublish()
        {
            btnTagMissing.Enabled = false;

            //Check if a version has been defined
            if (mAppDataFile.Versions.List.Count == 0) return false;

            //Check if all the application files have been defined for the selected version type
            foreach (var ap in mAppDataFile.Files.List.Where(x => x.IncludeStatus).ToList())
            {
                if (!mAppDataFile.VersionFiles.ContainsFile(ap.Id))
                {
                    btnTagMissing.Enabled = true;
                    RaiseEventStatusMessageChanged($"All files not defined for release type: {mCurrentVersion.EnumReleaseType}");
                    return false;
                }
            }

            if (mCurrentVersion.Status == SAUpdaterAppVersionStatus.Defined || mCurrentVersion.Status == SAUpdaterAppVersionStatus.Uploaded) return true;
            return false;
        }

        private bool CheckCanDeleteVersion()
        {
            foreach (var ap in mAppDataFile.Files.List.Where(x => x.IncludeStatus))
            {
                var tTempVersionId = mAppDataFile.ReleaseTypeFiles.GetVersionId(ap.Id, (SAUpdaterReleaseType)cmbRelease.SelectedValue.Value<int>());
                if (tTempVersionId == mCurrentVersion.Id) return false;
            }

            return true;
        }

        private void TagMissingFiles()
        {
            foreach (var ap in mAppDataFile.Files.List.Where(x => x.IncludeStatus).ToList())
            {
                if (!mAppDataFile.VersionFiles.ContainsFile(ap.Id))
                {
                    for (var z = 0; z <= lvwAppFiles.Items.Count - 1; z++)
                    {
                        if (lvwAppFiles.Items[z].Tag.Value<int>() == ap.Id)
                        {
                            lvwAppFiles.Items[z].Checked = true;
                            break;
                        }
                    }
                }
            }
        }

        #endregion Methods
    }
}