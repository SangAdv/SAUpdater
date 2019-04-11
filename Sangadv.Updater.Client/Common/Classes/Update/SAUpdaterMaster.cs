using System;
using System.IO;

namespace SangAdv.Updater.Common
{
    public class SAUpdaterMaster : SAUpdaterErrorBase
    {
        #region General Properties

        public string ApplicationRootFolder { get; set; }

        #endregion General Properties

        #region Derived Properties

        #region Folders

        public string DataFolder => Path.Combine(ApplicationRootFolder, "Data");
        public string ApplicationDataFolder => Path.Combine(ApplicationRootFolder, "Applications");
        public string UploadFolder => Path.Combine(ApplicationDataFolder, "Upload");

        #endregion Folders

        #endregion Derived Properties

        #region Methods

        public SAUpdaterEventArgs PrepareFolders()
        {
            if (!SAUpdaterFolder.Create(DataFolder)) return new SAUpdaterEventArgs(SAUpdaterFolder.ErrorMessage, SAUpdaterResults.FilesFolderCreateError);
            if (!SAUpdaterFolder.Create(ApplicationDataFolder)) return new SAUpdaterEventArgs(SAUpdaterFolder.ErrorMessage, SAUpdaterResults.FilesFolderCreateError);
            if (!SAUpdaterFolder.Create(UploadFolder)) return new SAUpdaterEventArgs(SAUpdaterFolder.ErrorMessage, SAUpdaterResults.FilesFolderCreateError);
            return new SAUpdaterEventArgs();
        }

        public bool CompressFile(string originalFile, string compressedFilename)
        {
            Error.ClearErrorMessage();
            try
            {
                var tDestinationFilename = Path.Combine(UploadFolder, compressedFilename);
                if (!SAUpdaterFile.Delete(tDestinationFilename)) throw new Exception($"Could not delete {tDestinationFilename}");
                SAUpdaterZip.Add(Path.Combine(UploadFolder, compressedFilename), originalFile);
                return true;
            }
            catch (Exception ex)
            {
                Error.SetErrorMessage(ex.Message);
                return false;
            }
        }

        public string CompressedMD5(string compressedFilename)
        {
            try
            {
                var tDestinationFilename = Path.Combine(UploadFolder, compressedFilename);
                if (!File.Exists(tDestinationFilename)) throw new Exception($"{tDestinationFilename} not found to generate MD5");
                return tDestinationFilename.GenerateFileMD5();
            }
            catch (Exception ex)
            {
                Error.SetErrorMessage(ex.Message);
                return string.Empty;
            }
        }

        #endregion Methods
    }
}