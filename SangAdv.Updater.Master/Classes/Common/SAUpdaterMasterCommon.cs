using SangAdv.Updater.Common;

namespace SangAdv.Updater.Master
{
    internal class SAUpdaterMasterCommon
    {
        #region Static Properties

        internal static AppDataFile AppData { get; set; }
        internal static MasterDataFile MasterData { get; set; }

        #endregion Static Properties

        #region Events

        public static event UpdaterIntegerDelegate AppSelected = (i) => { };

        internal static void RaiseEventAppSelected(int selectedAppId) => AppSelected(selectedAppId);

        #endregion Events

        #region Properties

        internal static bool UpdateAvailable { get; set; }

        #endregion Properties

        #region Methods

        internal static string ReturnGroupIndicator(bool referenceFile, string extension)
        {
            if (referenceFile) return "ref";
            if (extension == "exe" || extension == "dll") return extension;
            return "oth";
        }

        internal static ASAUpdaterRepositoryBase Repository()
        {
            switch (AppData.Application.CurrentApplication.RepositoryType)
            {
                case SAUpdaterRepositoryType.FTP:
                    return new SAUpdaterFTPRepository(AppData.Application.CurrentApplication.RepositorySettingsString);

                case SAUpdaterRepositoryType.AzureBlob:
                    return new SAUpdaterAzureBlobRepository(AppData.Application.CurrentApplication.RepositorySettingsString);

                default:
                    break;
            }

            return null;
        }

        #endregion Methods
    }
}