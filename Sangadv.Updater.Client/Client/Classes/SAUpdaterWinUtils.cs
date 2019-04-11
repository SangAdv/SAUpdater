using System.Windows.Forms;

namespace SangAdv.Updater.Client
{
    internal class SAUpdaterWinUtils
    {
        internal static string ChooseInstallFolder()
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    return fbd.SelectedPath;
                }
            }

            return string.Empty;
        }
    }
}