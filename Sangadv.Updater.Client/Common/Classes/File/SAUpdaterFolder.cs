using System;
using System.IO;

namespace SangAdv.Updater.Common
{
    public static class SAUpdaterFolder
    {
        internal static string ErrorMessage;

        public static bool Create(string folder)
        {
            ErrorMessage = string.Empty;
            try
            {
                if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }
        }

        public static bool Delete(string folder)
        {
            ErrorMessage = string.Empty;
            if (!Directory.Exists(folder)) return true;

            try
            {
                var objDir = new DirectoryInfo(folder) { Attributes = FileAttributes.Normal };
                objDir.Delete(true);
                objDir = null;

                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }
        }

        public static string InstallFolder(string appFolder, string selectedFolder)
        {
            var tString = selectedFolder.Replace(SAUpdaterConstants.RootFolder, "").FixFolderText();
            if (tString == @"\") return appFolder.FixFolderText();
            return $"{appFolder.FixFolderText()}{tString}";
        }
    }
}