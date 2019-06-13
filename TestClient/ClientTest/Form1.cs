using SangAdv.Updater.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void SimpleButton1_Click(object sender, EventArgs e)
        {
            var Update = new SAWinUpdate();
            await Update.InitialiseAsync(@"http://repo.sanguine.online/applications/", "pharmatrackcore", "pharmatrack Core", "pharmatrack.exe", Application.StartupPath, "updater.exe");

            if (Update.DoInstallerUpdate)
            {
                var success = await Update.UpdateInstallerAsync();

            }
        }
    }
}
