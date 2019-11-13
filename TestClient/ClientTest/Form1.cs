using SangAdv.Updater.Client;
using SangAdv.Updater.Common;
using System;
using System.Windows.Forms;

namespace ClientTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            var Update = new SAWinUpdate();
            Update.Initialise(@"http://repo.sanguine.online/applications/", "pharmatrackcore", "pharmatrack Core", "pharmatrack.exe", Application.StartupPath, "updater.exe", SAUpdaterRepositoryType.FTP);

            if (Update.DoInstallerUpdate)
            {
                var success = Update.UpdateInstaller();
            }
        }
    }
}