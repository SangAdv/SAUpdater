using SangAdv.Updater.Common;
using System;
using System.Windows.Forms;

namespace SangAdv.Updater.Master
{
    public partial class frmUpdateOptions : Form
    {
        #region Properties

        public int UpdateOptionID { get; private set; }
        public string UpdateOptionValue { get; private set; }

        #endregion Properties

        #region Constructor

        public frmUpdateOptions()
        {
            InitializeComponent();
        }

        #endregion Constructor

        #region Process UI

        private void frmUpdateOptions_Load(object sender, EventArgs e)
        {
            lblInput.Visible = false;
            txtInput.Visible = false;
            keyValuePairBindingSource.DataSource = EnumFunctions.ListFrom<SAUpdaterOption>();
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInput.Text)) txtInput.Text = string.Empty;
            btnOK.Enabled = txtInput.Text.CheckVersionNumberFormat();
        }

        private void cmbUpdateOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblInput.Visible = false;
            txtInput.Visible = false;
            txtInput.Text = string.Empty;
            switch (cmbUpdateOptions.SelectedValue)
            {
                case (int)SAUpdaterOption.UpdateIfOlderThan:
                    lblInput.Text = "Version:";
                    lblInput.Visible = true;
                    txtInput.Visible = true;
                    break;

                default:
                    break;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            UpdateOptionID = Convert.ToInt32(cmbUpdateOptions.SelectedValue);
            UpdateOptionValue = txtInput.Text;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            UpdateOptionID = 0;
            UpdateOptionValue = string.Empty;
            this.Close();
        }

        #endregion Process UI
    }
}