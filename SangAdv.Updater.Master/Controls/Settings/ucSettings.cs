using SangAdv.Updater.Common;
using System.Windows.Forms;

namespace SangAdv.Updater.Master
{
    public partial class ucSettings : UserControl
    {
        #region Constructor

        public ucSettings()
        {
            InitializeComponent();
        }

        #endregion Constructor

        #region Methods

        private void LoadRepositoryType()
        {
            var cbis = new ComboBoxItems();
            cbis.Add(SAUpdaterRepositoryType.FTP.ToString(), ((int)SAUpdaterRepositoryType.FTP).ToString());
            cmbRepositoryType.DataSource = cbis.Items;
            if (cbis.Items.Count < 2) cmbRepositoryType.Enabled = false;
        }

        #endregion Methods
    }
}