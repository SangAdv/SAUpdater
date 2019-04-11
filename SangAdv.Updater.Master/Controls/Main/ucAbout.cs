using System;
using System.Drawing;
using System.Windows.Forms;

namespace SangAdv.Updater.Master
{
    public partial class ucAbout : ucTemplate
    {
        #region Constructor

        public ucAbout()
        {
            InitializeComponent();
            lblVersion.Text = Application.ProductVersion;
            pnlAbout.Anchor = System.Windows.Forms.AnchorStyles.None;
            lblVersion.Text = System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString();
        }

        #endregion Constructor

        #region Override Methods

        public override void LoadStartData()
        {
        }

        #endregion Override Methods

        #region Process UI

        private void ucAbout_Resize(object sender, EventArgs e)
        {
            pnlAbout.Location = new Point((this.ClientSize.Width - pnlAbout.Width) / 2, (this.ClientSize.Height - pnlAbout.Height) / 2);
        }

        #endregion Process UI
    }
}