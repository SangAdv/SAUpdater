using SangAdv.Updater.Common;
using System;
using System.Windows.Forms;

namespace SangAdv.Updater.Master
{
    public partial class ucCategory : ucTemplate
    {
        #region Variables

        private int mCatId = 0;
        private MasterDataCategoryItem mCategoryItem;
        private MasterDataFile mDataFile = SAUpdaterMasterCommon.MasterData;

        #endregion Variables

        #region Constructor

        public ucCategory()
        {
            InitializeComponent();

            SuspendLayout();
            LoadCategories();
            ResetFields();
            ResumeLayout();
        }

        #endregion Constructor

        #region Private Methods

        private void LoadCategories()
        {
            lvwCategories.SuspendLayout();

            ListViewItem itm;
            //Reset menu
            lvwCategories.Groups.Clear();
            lvwCategories.Items.Clear();
            //Add items
            foreach (var item in mDataFile.Categories.List)
            {
                itm = new ListViewItem { ImageIndex = 0, Text = item.CategoryDesc, Tag = item.Id };
                lvwCategories.Items.Add(itm);
            }

            lvwCategories.ResumeLayout();
        }

        private void ResetFields()
        {
            mCategoryItem = new MasterDataCategoryItem();
            txtCategory.Text = string.Empty;
            btnAdd.Text = "Add";
            mCatId = 0;
        }

        #endregion Private Methods

        #region Process UI

        private void btnAdd_Click(object sender, EventArgs e)
        {
            mCategoryItem.CategoryDesc = txtCategory.Text.Trim();
            mCategoryItem.Id = mDataFile.Categories.Update(mCategoryItem);
            LoadCategories();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetFields();
        }

        private void lvwCategories_Click(object sender, EventArgs e)
        {
            if (lvwCategories.SelectedItems.Count > 0)
            {
                mCatId = lvwCategories.SelectedItems[0].Tag.Value<int>();
                mCategoryItem = mDataFile.Categories.Get(mCatId);
                txtCategory.Text = mCategoryItem.CategoryDesc;
                btnAdd.Text = "Update";
            }
            else
            {
                ResetFields();
            }
        }

        #endregion Process UI
    }
}