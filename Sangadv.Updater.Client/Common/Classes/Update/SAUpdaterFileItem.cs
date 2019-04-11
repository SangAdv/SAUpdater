using System.ComponentModel;

namespace SangAdv.Updater.Common
{
    [Browsable(false)]
    public class SAUpdaterFileItem
    {
        #region Variables

        private string mFolder = string.Empty;

        #endregion Variables

        #region Properties

        public string Filename { get; set; } = string.Empty;
        public string UniqueFilename { get; set; } = string.Empty;
        public string Folder { get; set; } = string.Empty;
        public string MD5 { get; set; } = string.Empty;
        public string CompressedMD5 { get; set; } = string.Empty;
        public int UpdateRuleOption { get; set; } = (int)SAUpdaterOption.NeverUpdate;
        public string UpdateRuleValue { get; set; } = string.Empty;
        public bool ShortCut { get; set; } = false;
        public bool ReferenceFile { get; set; } = true;
        public bool ForceDownload { get; set; } = false;
        public string UpdateVersion { get; set; } = "0.0.0.0";

        #endregion Properties

        #region Methods

        public string DownloadFilename(string downloadFolder) => $"{downloadFolder}{UniqueFilename}.ZIP";

        public string ExtractFilename(string extractFolder) => $"{extractFolder}{Filename}";

        public string DestinationFilename(string applicationFolder) => $"{InstallFolder(applicationFolder)}{Filename}";

        public string InstallFolder(string appFolder)
        {
            if (string.IsNullOrEmpty(mFolder)) mFolder = SAUpdaterFolder.InstallFolder(appFolder, Folder);
            return mFolder;
        }

        #endregion Methods
    }
}