using LiteDB;
using SangAdv.Updater.Common;
using System.Linq;

namespace SangAdv.Updater.Master
{
    internal class AppDataApplication
    {
        #region Variables

        private MasterDataFile mMasterDataFile = SAUpdaterMasterCommon.MasterData;
        private LiteCollection<AppDataApplicationItem> mCollection;
        private int mSelectedAppId;

        #endregion Variables

        #region Properties

        internal AppDataApplicationItem CurrentApplication { get; set; } = new AppDataApplicationItem { Id = 1 };

        #endregion Properties

        #region Constructor

        internal AppDataApplication(LiteCollection<AppDataApplicationItem> collection)
        {
            mCollection = collection;
        }

        #endregion Constructor

        #region Methods

        internal void Get(int selectedAppId)
        {
            mSelectedAppId = selectedAppId;

            var a = mCollection.Find(x => x.Id == selectedAppId).ToList();
            if (a.Any()) CurrentApplication = a.First();
            else
            {
                var tApp = mMasterDataFile.Applications.Get(selectedAppId);

                CurrentApplication = new AppDataApplicationItem { Id = selectedAppId, ApplicationTitle = tApp.ApplicationTitle };
                mCollection.Insert(CurrentApplication);
            }
        }

        internal void Update()
        {
            mCollection.Update(CurrentApplication);
        }

        internal void UpdateStatus(SAUpdaterAppVersionStatus statusCode)
        {
            CurrentApplication.VersionStatus = (int)statusCode;
            Update();
        }

        #endregion Methods
    }

    internal class AppDataApplicationItem : MasterDataApplicationItem
    {
        public string SourceFolder { get; set; } = string.Empty;
        public string RepositorySettingsString { get; set; } = string.Empty;
        public int FileStatus { get; set; } = (int)SAUpdaterAppFileStatus.OK;
        public int VersionStatus { get; set; } = (int)SAUpdaterAppVersionStatus.New;
        public string InstallerVersion { get; set; } = SAUpdaterConstants.NoVersion;
        public string InstallerMD5 { get; set; } = string.Empty;
        public string InstallerCompressedMD5 { get; set; } = string.Empty;
        public int RequiredNetFramework { get; set; } = (int)SAUpdaterFrameworkVersions.Version45;
        public int RequiredOSType { get; set; } = (int)SAUpdaterOSType.Windows;
        public int RequiredOSVersion { get; set; } = (int)SAUpdaterWinOSVersion.Win7;
        public bool Requires64BitOS { get; set; } = false;
    }
}