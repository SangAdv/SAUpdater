using SangAdv.Updater.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SangAdv.Updater.Client
{
    public partial class frmChooseFolder : Form
    {
        #region Variables

        private string mApplicationTitle = string.Empty;
        private string mInitialApplicationFolder = string.Empty;

        #endregion Variables

        #region Properties

        internal string SelectedFolder { get; private set; } = string.Empty;

        public string InstallerVersion
        {
            set
            {
                if (string.IsNullOrEmpty(value)) lblVersion.Visible = false;
                lblVersion.Text = $"Version: {value}";
            }
        }

        public bool MustAcceptLicense
        {
            set
            {
                chkAgree.Visible = value;
                CheckActionEnabled();
            }
        }

        public Image Logo
        {
            set
            {
                if (value == null) return;
                var size = value.Size;
                if (size.Height > 70 || size.Width > 632) return;

                pbLogo.Location = new Point(20 + 630 - size.Width, 17);
                pbLogo.Width = size.Width;
                pbLogo.Height = size.Height;
                pbLogo.Image = value;
            }
        }

        public string License
        {
            set => txtLicense.Text = value;
        }

        public bool LicenseScrollBars
        {
            set => txtLicense.ScrollBars = value ? ScrollBars.Vertical : ScrollBars.None;
        }

        #endregion Properties

        #region Constructor

        public frmChooseFolder(string applicationTitle, string initialApplicationFolder)
        {
            InitializeComponent();

            mApplicationTitle = applicationTitle;
            mInitialApplicationFolder = initialApplicationFolder;
            MustAcceptLicense = true;
        }

        #endregion Constructor

        #region Methods

        public void DisplayMessage(string message, bool isBold = false)
        {
            Font fnt = isBold ? new Font(lblMessage.Font.FontFamily, lblMessage.Font.Size, FontStyle.Bold) : new Font(lblMessage.Font.FontFamily, lblMessage.Font.Size);

            lblMessage.Font = fnt;
            lblMessage.Text = message;
            Application.DoEvents();
        }

        public void DisplayErrorMessage(string exMessage, Color? color = null)
        {
            if (color == null) lblError.ForeColor = Color.Black;
            lblError.Text = exMessage;
            Application.DoEvents();
        }

        private bool CheckUserAccess()
        {
            var tFolder = txtDir.Text;
            //Check if the directory can be created if it does not exist
            if (!Directory.Exists(tFolder))
            {
                if (!SAUpdaterFolder.Create(tFolder))
                {
                    DisplayMessage($"{tFolder} could not be created!");
                    return false;
                }
            }
            else
            {
                tFolder = Path.Combine(txtDir.Text, @"Test\");

                while (Directory.Exists(tFolder))
                {
                    tFolder = $"{tFolder}1";
                }

                if (!SAUpdaterFolder.Create(tFolder))
                {
                    DisplayMessage($"{tFolder} could not be created!");
                    return false;
                }
            }
            //Check if a file can be created
            var tFilename = Path.Combine(tFolder, "test.sautf");
            if (!SAUpdaterFile.Write(tFilename, "This is a test string", true))
            {
                if (!SAUpdaterFolder.Create(tFolder))
                {
                    DisplayMessage($"Test file could not be created! Error: {SAUpdaterFile.ErrorMessage}");
                    return false;
                }
            }

            SAUpdaterFile.Delete(tFilename);
            SAUpdaterFolder.Delete(tFolder);

            //Give warning if the folder is not empty
            if (HasContents()) DisplayMessage("Selected folder is not empty. Exisiting files and folders will be overwritten!");

            return true;
        }

        private bool HasContents()
        {
            if (Directory.EnumerateDirectories(txtDir.Text).Any()) return true;
            if (Directory.EnumerateFiles(txtDir.Text).Any()) return true;
            return false;
        }

        private void CheckActionEnabled()
        {
            var enabled = chkAgree.Visible ? chkAgree.Checked : true;

            if (string.IsNullOrEmpty(txtDir.Text)) enabled = false;
            btnAction.Enabled = enabled;
        }

        #endregion Methods

        #region Process UI

        private void frmChooseFolder_Shown(object sender, System.EventArgs e)
        {
            DisplayMessage("Please select installation folder");
            txtDir.Text = mInitialApplicationFolder;
            lblApplication.Text = mApplicationTitle;
            Text = mApplicationTitle;
            lblVersion.Text = $"Version: {Application.ProductVersion}";

            CheckActionEnabled();
            DisplayErrorMessage(!string.IsNullOrEmpty(txtDir.Text) ? "If in doubt accept the default" : string.Empty);
        }

        private void btnAction_Click(object sender, System.EventArgs e)
        {
            SelectedFolder = txtDir.Text;
            Close();
        }

        private void btnDir_Click(object sender, System.EventArgs e)
        {
            var tFolder = SAUpdaterWinUtils.ChooseInstallFolder();
            if (string.IsNullOrEmpty(tFolder)) return;

            txtDir.Text = tFolder;
            if (!CheckUserAccess()) return;

            SelectedFolder = tFolder;
            CheckActionEnabled();
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            SelectedFolder = string.Empty;
            Close();
        }

        private void chkAgree_CheckedChanged(object sender, System.EventArgs e)
        {
            CheckActionEnabled();
        }

        #endregion Process UI
    }
}