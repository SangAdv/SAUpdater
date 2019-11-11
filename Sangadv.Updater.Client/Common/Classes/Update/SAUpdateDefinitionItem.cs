namespace SangAdv.Updater.Common
{
    public class SAUpdateDefinitionItem : SAUpdateDefinitionDataItem
    {
        #region Properties

        public SAUpdaterReleaseType ReleaseType
        {
            get => (SAUpdaterReleaseType)IntReleaseType;
            set => IntReleaseType = (int)value;
        }

        public SAUpdaterFrameworkVersions RequiredFramework
        {
            get => (SAUpdaterFrameworkVersions)IntRequiredFramework;
            set => IntRequiredFramework = (int)value;
        }

        public SAUpdaterOSType RequiredOSType
        {
            get => (SAUpdaterOSType)IntRequiredOSType;
            set => IntRequiredOSVersion = (int)value;
        }

        public SAUpdaterRepositoryType  RepositoryType
        {
            get => (SAUpdaterRepositoryType)IntRepositoryType;
            set => IntRepositoryType = (int)value;
        }

        public string NewApplicationVersion => getNewApplicationVersion();

        public bool IsPreRelease { get; private set; }

        public bool HasNotes => getHasNotes();

        #region Private Properties

        private bool IsPreReleaseAvailable => PreReleaseVersion.IsNewerVersion(ReleaseVersion);

        #endregion Private Properties

        #endregion Properties

        #region Methods

        public void Save(string filename)
        {
            SAUpdaterFile.Write(filename, ToString());
        }

        public void Read(string filename)
        {
            FromString(SAUpdaterFile.Read(filename)[0]);
        }

        public void SetInstallerProperties(string version, string md5, string compressedMD5)
        {
            InstallerVersion = version;
            InstallerMD5 = md5;
            InstallerCompressedMD5 = compressedMD5;
        }

        #endregion Methods

        #region Private Methods

        private string getNewApplicationVersion()
        {
            if (ReleaseType.Value<int>() < SAUpdaterGlobal.Options.AllowedReleaseType.Value<int>())
            {
                IsPreRelease = false;
                return ReleaseVersion;
            }

            IsPreRelease = IsPreReleaseAvailable;
            return IsPreReleaseAvailable ? PreReleaseVersion : ReleaseVersion;
        }

        private bool getHasNotes()
        {
            if (ReleaseType.Value<int>() < SAUpdaterGlobal.Options.AllowedReleaseType.Value<int>())
            {
                return HasReleaseNotes;
            }

            return IsPreReleaseAvailable ? HasPreReleaseNotes : HasReleaseNotes;
        }

        #endregion Private Methods
    }
}