using SangAdv.Updater.Common;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SangAdv.Updater.Master
{
    public partial class ucApplications : ucTemplate
    {
        #region Variables

        private MasterDataFile mDataFile = SAUpdaterMasterCommon.MasterData;

        #endregion Variables

        #region Constructor

        public ucApplications()
        {
            InitializeComponent();
            DefineListviewLayout();
        }

        #endregion Constructor

        #region Override Methods

        public override void LoadStartData()
        {
            SuspendLayout();
            CleanApplicationTable();
            LoadDefinedApplications();
            ResumeLayout();
        }

        #endregion Override Methods

        #region Process UI

        private void ucApplications_Load(object sender, EventArgs e)
        {
        }

        private void OnButtonActionClick(object sender, ListViewColumnMouseEventArgs e)
        {
            var tSelectedAppId = 0;
            switch (e.SubItem.Text.ToUpper())
            {
                case "OPEN":
                    tSelectedAppId = e.SubItem.Tag.Value<int>();
                    SAUpdaterMasterCommon.RaiseEventAppSelected(tSelectedAppId);
                    break;

                case "REMOVE":
                    tSelectedAppId = e.SubItem.Tag.Value<int>();
                    RemoveApplication(tSelectedAppId);
                    LoadDefinedApplications();
                    break;

                default:
                    throw new Exception("Unknown command");
            }
        }

        private void lvwApplications_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            e.Item.Selected = false;
        }

        #endregion Process UI

        #region Private Methods

        private void DefineListviewLayout()
        {
            lvwApplications.FullRowSelect = true;
            ListViewExtender extender = new ListViewExtender(lvwApplications);

            ListViewImageColumn imageColumn1 = new ListViewImageColumn(4);
            ListViewImageColumn imageColumn2 = new ListViewImageColumn(5);
            ListViewButtonColumn buttonAction1 = new ListViewButtonColumn(6);
            buttonAction1.Click += OnButtonActionClick;
            buttonAction1.FixedWidth = true;
            ListViewButtonColumn buttonAction2 = new ListViewButtonColumn(7);
            buttonAction2.Click += OnButtonActionClick;
            buttonAction2.FixedWidth = true;

            extender.AddColumn(imageColumn1);
            extender.AddColumn(imageColumn2);
            extender.AddColumn(buttonAction1);
            extender.AddColumn(buttonAction2);
        }

        private void CleanApplicationTable()
        {
            //foreach (UpdateAppItem item in mDataFile.AppAllData)
            //{
            //if (string.IsNullOrEmpty(item.ApplicationTitle)) mDataFile.AppRemove(item);
            //}
        }

        private void LoadDefinedApplications()
        {
            lvwApplications.SuspendLayout();

            //Reset menu
            lvwApplications.Groups.Clear();
            lvwApplications.Items.Clear();
            //Add items
            foreach (var citem in mDataFile.Categories.List)
            {
                var cat = new ListViewGroup { Header = citem.CategoryDesc, HeaderAlignment = HorizontalAlignment.Left };
                lvwApplications.Groups.Add(cat);
                var apps = mDataFile.Applications.GetAll(citem.Id);
                if (apps.Any())
                {
                    foreach (var item in apps)
                    {
                        var itm = new ListViewItem { ImageIndex = item.AppStatusImageIndex, Text = item.ApplicationTitle, Tag = item.Id, Group = cat };

                        itm.SubItems.Add(new ListViewItem.ListViewSubItem { Text = string.IsNullOrEmpty(item.ReleaseVersion()) ? "" : item.ReleaseVersion() });
                        itm.SubItems.Add(new ListViewItem.ListViewSubItem { Text = string.IsNullOrEmpty(item.HighestPreReleaseVersion()) ? "" : item.HighestPreReleaseVersion() });
                        itm.SubItems.Add(new ListViewItem.ListViewSubItem { Text = string.IsNullOrEmpty(item.HighestPreReleaseVersion()) ? "" : item.HighestPreReleaseType().ToString() });
                        itm.SubItems.Add(new ListViewItem.ListViewSubItem { Text = item.HasDatabaseImageIndex });
                        itm.SubItems.Add(new ListViewItem.ListViewSubItem { Text = item.PublishedImageIndex });
                        itm.SubItems.Add(new ListViewItem.ListViewSubItem { Text = "Open", Tag = item.Id });
                        itm.SubItems.Add(new ListViewItem.ListViewSubItem { Text = "Remove", Tag = item.Id });
                        lvwApplications.Items.Add(itm);
                    }
                }
            }

            lvwApplications.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvwApplications.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvwApplications.Columns[2].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);

            if (lvwApplications.Columns[0].Width < 200) lvwApplications.Columns[0].Width = 200;
            if (lvwApplications.Columns[1].Width < 110) lvwApplications.Columns[1].Width = 110;
            if (lvwApplications.Columns[2].Width < 110) lvwApplications.Columns[2].Width = 110;

            lvwApplications.ResumeLayout();
        }

        private void RemoveApplication(int selectedApplication)
        {
            if (mDataFile.Applications.Remove(selectedApplication) > 0)
            {
                SAUpdaterFile.Delete(AppDataFile.DatabaseFilename(selectedApplication));
            }
        }

        #endregion Private Methods
    }
}