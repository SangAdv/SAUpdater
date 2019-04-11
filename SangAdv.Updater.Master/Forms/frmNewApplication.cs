using SangAdv.Updater.Common;
using System;
using System.Windows.Forms;

namespace SangAdv.Updater.Master
{
    public partial class frmNewApplication : Form
    {
        #region Variables

        private MasterDataFile mDataFile = SAUpdaterMasterCommon.MasterData;

        #endregion Variables

        #region Constructor

        public frmNewApplication()
        {
            InitializeComponent();
            txtAppDescription.Text = string.Empty;
            btnAppAdd.Enabled = false;
        }

        #endregion Constructor

        #region Process UI

        private void frmNewApplication_Shown(object sender, EventArgs e)
        {
            LoadCategories();
        }

        private void btnAppCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAppAdd_Click(object sender, EventArgs e)
        {
            var tAppId = AddApplication();
            Close();
            SAUpdaterMasterCommon.RaiseEventAppSelected(tAppId);
        }

        private void txtAppDescription_TextChanged(object sender, EventArgs e)
        {
            btnAppAdd.Enabled = !string.IsNullOrEmpty(txtAppDescription.Text);
        }

        #endregion Process UI

        #region Private Methods

        private void LoadCategories()
        {
            cmbCategory.DataSource = mDataFile.Categories.List;
            cmbCategory.SelectedIndex = 0;
        }

        private int AddApplication()
        {
            var na = new MasterDataApplicationItem()
            {
                ApplicationTitle = txtAppDescription.Text.Trim(),
                CategoryId = cmbCategory.SelectedValue.Value<int>(),
                AppStatus = (int)SAUpdaterAppStatus.New,
                IsBackedUp = false,
                HasDatabase = true
            };
            return mDataFile.Applications.Add(na);
        }

        #endregion Private Methods
    }
}