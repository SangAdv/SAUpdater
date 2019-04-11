using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace SangAdv.Updater.Master
{
    public partial class ucOpenSource : ucTemplate
    {
        public ucOpenSource()
        {
            InitializeComponent();

            lblVersion.Text = Application.ProductVersion;

            var JsonFileVersionInfo = FileVersionInfo.GetVersionInfo(Path.Combine(Application.StartupPath, "Newtonsoft.Json.dll"));
            lblJsonVersion.Text = JsonFileVersionInfo.FileVersion;

            var LiteDbFileVersionInfo = FileVersionInfo.GetVersionInfo(Path.Combine(Application.StartupPath, "LiteDb.dll"));
            lblLiteDbVersion.Text = LiteDbFileVersionInfo.FileVersion;
        }

        private void ucOpenSource_Resize(object sender, EventArgs e)
        {
            pnlLibrary.Left = (this.Width - pnlLibrary.Width) / 2;
            pnlLibrary.Top = (this.Height - pnlLibrary.Height) / 2;
        }

        private void llLiteDb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/SangAdv/SAStor");
        }

        private void llIcons8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://icons8.com/");
        }

        private void llJson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.newtonsoft.com/json");
        }
    }
}