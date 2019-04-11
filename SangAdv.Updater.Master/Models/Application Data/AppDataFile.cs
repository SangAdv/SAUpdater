using LiteDB;
using SangAdv.Updater.Common;
using System.IO;

namespace SangAdv.Updater.Master
{
    public class AppDataFile
    {
        #region Variables

        private LiteDatabase mDatabase;

        private static SAUpdaterMaster mMaster = SAUpdaterGlobal.Master;

        private bool mHasLoaded = false;

        #endregion Variables

        #region Properties

        internal AppDataApplication Application { get; private set; }
        internal AppDataFiles Files { get; private set; }
        internal AppDataFolders Folders { get; private set; }
        internal AppDataVersions Versions { get; private set; }
        internal AppDataVersionFiles VersionFiles { get; private set; }
        internal AppDataReleaseTypeFiles ReleaseTypeFiles { get; private set; }

        #endregion Properties

        #region Constructor

        public AppDataFile(int applicationId)
        {
            mDatabase = new LiteDatabase(DatabaseFilename(applicationId));
        }

        #endregion Constructor

        #region Methods

        internal void Load()
        {
            if (mHasLoaded) return;

            Application = new AppDataApplication(mDatabase.GetCollection<AppDataApplicationItem>("updateapp"));

            Files = new AppDataFiles(mDatabase.GetCollection<AppDataFileItem>("appfiles"));

            Folders = new AppDataFolders(mDatabase.GetCollection<AppDataFolderItem>("appfolders"));

            Versions = new AppDataVersions(mDatabase.GetCollection<AppDataVersionItem>("appversions"));

            VersionFiles = new AppDataVersionFiles(mDatabase.GetCollection<AppDataVersionFileItem>("appversionfiles"));

            ReleaseTypeFiles = new AppDataReleaseTypeFiles(mDatabase.GetCollection<AppDataReleaseTypeFileItem>("appreleasetypefiles"));

            mHasLoaded = true;
        }

        internal void SetApplicationFileStatus()
        {
            Application.CurrentApplication.FileStatus = (int)Files.HasIncludedItems;
        }

        #endregion Methods

        #region Static Methods

        internal static string DatabaseFilename(int applicationId)
        {
            return Path.Combine(mMaster.ApplicationDataFolder, $"{applicationId}.db");
        }

        #endregion Static Methods
    }
}