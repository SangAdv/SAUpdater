using SangAdv.Updater.Client;
using SAUpdateInstaller;
using System;
using System.Windows.Forms;

namespace SangAdv.Updater.Win.Updater
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            Global.CommandLineArgs = args;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}