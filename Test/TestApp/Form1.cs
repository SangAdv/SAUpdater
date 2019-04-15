using SangAdv.Updater.Client;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestApp.Common;

namespace Test
{
    public partial class Form1 : Form
    {
        private SAWinUpdate mUpdate = new SAWinUpdate();

        public Form1()
        {
            InitializeComponent();
            btnDoUpdate.Visible = false;
            btnDoUpdate.Enabled = false;
            mUpdate.MessageChanged += displayMessage;

            lblVersion.Text = $"Version: {MyVersion.Version}";
        }

        private async void Form1_Shown(object sender, EventArgs e)
        {
            var hasUpdate = await checkUpdateAsync();
            displayMessage("");
            if (hasUpdate) doUpdate();
        }

        private void btnSum_Click(object sender, EventArgs e)
        {
            try
            {
                lblSum.Text = new MyMaths().Sum(Convert.ToInt32(txtA.Text), Convert.ToInt32(txtB.Text)).ToString();
            }
            catch
            {
                lblSum.Text = "Please check A and B";
            }
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            try
            {
                lblSum.Text = new MyMaths().Minus(Convert.ToInt32(txtA.Text), Convert.ToInt32(txtB.Text)).ToString();
            }
            catch
            {
                lblMinus.Text = "Please check A and B";
            }
        }

        private async Task<bool> checkUpdateAsync()
        {
            await mUpdate.InitialiseAsync(@"http://repo.sanguine.online/applications/", "Test", "Test", "TestApp.exe", Application.StartupPath, "TestUpdater.exe");

            if (mUpdate.DoInstallerUpdate)
            {
                var success = await mUpdate.UpdateInstaller();
                if (!success)
                {
                    displayMessage("Error doing installer update");
                    return false;
                }
            }

            return mUpdate.HasNewApplicationRelease;
        }

        private void doUpdate()
        {
            displayMessage("Update found. Please update ...");

            btnDoUpdate.Visible = true;
            btnDoUpdate.Enabled = true;
        }

        private void displayMessage(string message)
        {
            lblMessage.Text = message;
            Application.DoEvents();
        }

        private void btnDoUpdate_Click(object sender, EventArgs e)
        {
            mUpdate.UpdateApplication();
            Close();
        }

        private void BtnDoUpdate_Click_1(object sender, EventArgs e)
        {
            mUpdate.UpdateApplication();
            Close();
        }
    }
}