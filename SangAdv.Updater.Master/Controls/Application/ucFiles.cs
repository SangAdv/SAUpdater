using SangAdv.Updater.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SangAdv.Updater.Master
{
    public partial class ucFiles : ucTemplate
    {
        #region Variables

        private AppDataFile mAppDataFile = SAUpdaterMasterCommon.AppData;
        private int mSelectedAppId = 0;

        #endregion Variables

        #region Properties

        public Dictionary<string, string> Extensions { get; private set; }

        #endregion Properties

        #region Constructor

        public ucFiles(int selectedAppId)
        {
            InitializeComponent();
            mSelectedAppId = selectedAppId;
        }

        #endregion Constructor

        #region Override Methods

        public override void LoadStartData()
        {
            SuspendLayout();

            mAppDataFile.Load();

            if (string.IsNullOrEmpty(mAppDataFile.Application.CurrentApplication.SourceFolder))
            {
                Enabled = false;
                RaiseEventStatusMessageChanged("Source directory not defined");
                return;
            }

            lblUpdateFolder.Text = mAppDataFile.Application.CurrentApplication.SourceFolder;

            lblAppFileHeader.Text = $"Application Files: {mAppDataFile.Application.CurrentApplication.ApplicationTitle}";

            PrepareListviewLayout();

            Extensions = new Dictionary<string, string>();
            Extensions.Add("exe", "Executable(s)");
            Extensions.Add("dll", "Assemblies or dll(s)");
            Extensions.Add("oth", "Other Included Files(s)");
            Extensions.Add("ref", "Reference Files(s)");

            foreach (var kvp in Extensions) lvwAppFiles.Groups.Add(kvp.Key, kvp.Value);

            LoadAppDirectories();
            LoadAppFiles(chkInclude.Checked);

            ResumeLayout();
        }

        #endregion Override Methods

        #region Process UI

        private void lvwAppFiles_DragDrop(object sender, DragEventArgs e)
        {
            ProcessFiles((string[])e.Data.GetData(DataFormats.FileDrop));
        }

        private void lvwAppFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                // allow them to continue
                // (without this, the cursor stays a "NO" symbol
                e.Effect = DragDropEffects.All;
            }
        }

        private void btnAddFiles_Click(object sender, EventArgs e)
        {
            openFile1.CheckFileExists = true;
            openFile1.Multiselect = true;
            openFile1.FileName = string.Empty;
            openFile1.Filter = ".All Files|*.*";
            openFile1.InitialDirectory = mAppDataFile.Application.CurrentApplication.SourceFolder;

            if (openFile1.ShowDialog() == DialogResult.OK) ProcessFiles(openFile1.FileNames);
        }

        private void btnDelAllFiles_Click(object sender, EventArgs e)
        {
            for (var z = 0; z <= lvwAppFiles.Items.Count - 1; z++) mAppDataFile.Files.Delete(lvwAppFiles.Items[z].Tag.Value<int>());
            LoadAppFiles(chkInclude.Checked);
            mAppDataFile.SetApplicationFileStatus();
        }

        private void btnAddRefFiles_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtReferenceFile.Text)) return;
            var tAppFileitem = new AppDataFileItem
            {
                Filename = txtReferenceFile.Text.Trim(),
                FolderId = 1,
                Id = 0,
                ReferenceFile = true,
                UniqueFilename = "",
                CreateShortCut = false
            };
            mAppDataFile.Files.Update(tAppFileitem);

            LoadAppFiles(chkInclude.Checked);
        }

        private void txtReferenceFile_TextChanged(object sender, EventArgs e)
        {
            btnAddRefFiles.Enabled = !string.IsNullOrEmpty(txtReferenceFile.Text);
        }

        private void btnDelFiles_Click(object sender, EventArgs e)
        {
            for (var z = 0; z <= lvwAppFiles.Items.Count - 1; z++)
            {
                if (lvwAppFiles.Items[z].Checked) mAppDataFile.Files.Delete(lvwAppFiles.Items[z].Tag.Value<int>());
            }
            LoadAppFiles(chkInclude.Checked);
        }

        private void btnSetShortcut_Click(object sender, EventArgs e)
        {
            SetCreateShortCutStatus(true);
        }

        private void btnUnsetShortcut_Click(object sender, EventArgs e)
        {
            SetCreateShortCutStatus(false);
        }

        private void btnIncludeFiles_Click(object sender, EventArgs e)
        {
            SetIncludeStatus(true);
        }

        private void btnExcludeFiles_Click(object sender, EventArgs e)
        {
            SetIncludeStatus(false);
        }

        private void lvwAppFiles_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            EnableFileFunctions(lvwAppFiles.CheckedItems.Count != 0);
        }

        private void chkInclude_CheckedChanged(object sender, EventArgs e)
        {
            LoadAppFiles(chkInclude.Checked);
        }

        private void btnDirUpdate_Click(object sender, EventArgs e)
        {
            SetAppFolder(cmbDirectories.SelectedValue.Value<int>());
        }

        #endregion Process UI

        #region Methods

        private void PrepareListviewLayout()
        {
            lvwAppFiles.FullRowSelect = true;
            ListViewExtender extender = new ListViewExtender(lvwAppFiles);
            // extend 4th column
            ListViewImageColumn imageColumn1 = new ListViewImageColumn(3);
            // extend 5th column
            ListViewImageColumn imageColumn2 = new ListViewImageColumn(4);
            // extend 6th column
            ListViewImageColumn imageColumn3 = new ListViewImageColumn(5);

            extender.AddColumn(imageColumn1);
            extender.AddColumn(imageColumn2);
            extender.AddColumn(imageColumn3);
        }

        private void LoadAppDirectories()
        {
            var cbis = new ComboBoxItems();
            foreach (var item in mAppDataFile.Folders.List) cbis.Add(item.Folder, item.Id.ToString());
            cmbDirectories.DataSource = cbis.Items;
            cmbDirectories.SelectedIndex = 0;
        }

        private void ProcessFiles(string[] filenames)
        {
            RaiseEventMainFormEnabledChanged(false);
            Enabled = false;

            RaiseEventDisableMainAndStatusChanged("Adding files, Please wait ...");

            var tFiles = new AddFiles();

            for (var i = 0; i <= filenames.Length - 1; i++)
            {
                if (File.Exists(filenames[i]))
                {
                    var fi = new FileInfo(filenames[i]);

                    if (fi.DirectoryName.FixFolderText() != mAppDataFile.Application.CurrentApplication.SourceFolder.FixFolderText())
                    {
                        RaiseEventEnableMainAndStatusChanged("Files can not be added");
                        var mb = MessageBox.Show($"Files are not in the defined Application Update Folder:\n{mAppDataFile.Application.CurrentApplication.SourceFolder}\n\nNo Files will be added!", "Update files selection error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        RaiseEventMainFormEnabledChanged(true);
                        Enabled = true;
                        return;
                    }

                    if (!mAppDataFile.Files.ContainsFile(fi.Name)) tFiles.Add(fi);
                }
                else if (Directory.Exists(filenames[i]))
                {
                    string[] files = Directory.GetFiles(filenames[i]);
                    ProcessFiles(files);

                    string[] directories = Directory.GetDirectories(filenames[i]);
                    ProcessFiles(directories);
                }
            }

            foreach (var item in tFiles.Files) UpdateFile(item.Filename, 1, item.FileId, false, item.UniqueName, item.ShortCut);

            LoadAppFiles(chkInclude.Checked);

            mAppDataFile.SetApplicationFileStatus();

            RaiseEventEnableMainAndStatusChanged("");
            Enabled = true;
        }

        private void LoadAppFiles(bool showIncludeOnly)
        {
            EnableFileFunctions(false);
            btnAddRefFiles.Enabled = false;

            RaiseEventDisableMainAndStatusChanged("Loading files, Please wait ...");
            UseWaitCursor = true;
            Enabled = false;

            var items = new List<ListViewItem>();

            btnDelAllFiles.Enabled = mAppDataFile.Files.List.Any();

            foreach (var ap in mAppDataFile.Files.List.OrderBy(x => x.Filename))
            {
                var tInclude = (!showIncludeOnly || ap.IncludeStatus);

                if (tInclude)
                {
                    var lvi = new ListViewItem(ap.Filename);

                    var strExtension = ap.ReferenceFile ? string.Empty : Path.GetExtension(ap.Filename).ToLower().TrimStart('.');

                    lvi.SubItems.Add(SAUpdaterFolder.InstallFolder("...", mAppDataFile.Folders.GetName(ap.FolderId)));
                    lvi.SubItems.Add(ap.UniqueFilename);
                    lvi.SubItems.Add(ap.FileStatusImageIndex(mAppDataFile.Application.CurrentApplication.SourceFolder));
                    lvi.SubItems.Add(ap.IncludeStatusImageIndex);
                    lvi.SubItems.Add(ap.CreateShortCutImageIndex);

                    lvi.Tag = ap.Id;
                    lvi.Group = lvwAppFiles.Groups[SAUpdaterMasterCommon.ReturnGroupIndicator(ap.ReferenceFile, strExtension)];

                    items.Add(lvi);
                }
            }

            if (mAppDataFile.Files.List.Count > 0) btnAddRefFiles.Enabled = true;

            mAppDataFile.SetApplicationFileStatus();

            lvwAppFiles.BeginUpdate();
            lvwAppFiles.Items.Clear();

            lvwAppFiles.ListViewItemSorter = null;

            lvwAppFiles.Items.AddRange(items.ToArray());

            lvwAppFiles.Columns[0].Width = -1;
            lvwAppFiles.Columns[1].Width = -1;
            if (lvwAppFiles.Columns[1].Width < 65) lvwAppFiles.Columns[1].Width = 65;

            lvwAppFiles.Columns[2].Width = -2;
            lvwAppFiles.Columns[3].Width = 65;
            lvwAppFiles.Columns[4].Width = 65;
            lvwAppFiles.Columns[5].Width = 65;

            lvwAppFiles.EndUpdate();

            RaiseEventEnableMainAndStatusChanged("");

            Enabled = true;
            UseWaitCursor = false;
        }

        private void UpdateFile(string filename, int appDirectoryId, int appFileId, bool isReferenceFile, string uniqueFilename, bool createShortCut)
        {
            var p = new FileInfo(filename);
            var tAppFileitem = new AppDataFileItem
            {
                Filename = p.Name,
                FolderId = appDirectoryId,
                Id = appFileId,
                ReferenceFile = isReferenceFile,
                UniqueFilename = uniqueFilename,
                CreateShortCut = createShortCut
            };
            mAppDataFile.Files.Update(tAppFileitem);
        }

        private void SetCreateShortCutStatus(bool status)
        {
            for (int z = 0; z <= lvwAppFiles.Items.Count - 1; z++)
            {
                if (lvwAppFiles.Items[z].Checked)
                {
                    var tAppFileitem = mAppDataFile.Files.Get(lvwAppFiles.Items[z].Tag.Value<int>());
                    tAppFileitem.CreateShortCut = status;
                    mAppDataFile.Files.Update(tAppFileitem);
                    lvwAppFiles.Items[z].Checked = false;
                }
            }
            LoadAppFiles(chkInclude.Checked);
        }

        private void SetIncludeStatus(bool status)
        {
            for (var z = 0; z <= lvwAppFiles.Items.Count - 1; z++)
            {
                if (lvwAppFiles.Items[z].Checked)
                {
                    var tAppFileitem = mAppDataFile.Files.Get(lvwAppFiles.Items[z].Tag.Value<int>());
                    tAppFileitem.IncludeStatus = status;
                    mAppDataFile.Files.Update(tAppFileitem);
                    lvwAppFiles.Items[z].Checked = false;
                }
            }
            LoadAppFiles(chkInclude.Checked);
        }

        private void EnableFileFunctions(bool isEnabled)
        {
            btnSetShortcut.Enabled = isEnabled;
            btnUnsetShortcut.Enabled = isEnabled;
            btnIncludeFiles.Enabled = isEnabled;
            btnExcludeFiles.Enabled = isEnabled;
            btnDelFiles.Enabled = isEnabled;
            btnDirUpdate.Enabled = isEnabled;
        }

        private void SetAppFolder(int folderId)
        {
            foreach (ListViewItem z in lvwAppFiles.CheckedItems)
            {
                var tAppFileitem = mAppDataFile.Files.Get(z.Tag.Value<int>());
                tAppFileitem.FolderId = folderId;
                mAppDataFile.Files.Update(tAppFileitem);
                z.Checked = false;
            }
            LoadAppFiles(chkInclude.Checked);
        }

        #endregion Methods
    }
}