namespace SangAdv.Updater.Common
{
    public class SAUpdateDefinitionDataItem
    {
        #region Properties

        public string ReleaseVersion { get; set; }
        public string PreReleaseVersion { get; set; }
        public string InstallerVersion { get; set; }
        public int IntReleaseType { get; set; }
        public int IntRequiredFramework { get; set; }
        public int IntRequiredOSType { get; set; }
        public int IntRequiredOSVersion { get; set; }
        public string InstallerCompressedMD5 { get; set; }
        public string InstallerMD5 { get; set; }
        public bool HasReleaseNotes { get; set; }
        public bool HasPreReleaseNotes { get; set; }
        public bool Is64BitOSRequired { get; set; }

        #endregion Properties

        #region Constructor

        public SAUpdateDefinitionDataItem()
        {
            Reset();
        }

        #endregion Constructor

        #region Methods

        internal void Reset()
        {
            ReleaseVersion = "0.0.0.0";
            PreReleaseVersion = "0.0.0.0";
            InstallerVersion = "0.0.0.0";
            IntReleaseType = (int)SAUpdaterReleaseType.Beta;
            IntRequiredFramework = (int)SAUpdaterFrameworkVersions.Version45;
            IntRequiredOSType = (int)SAUpdaterOSType.Windows;
            IntRequiredOSVersion = (int)SAUpdaterWinOSVersion.Win8;
            InstallerCompressedMD5 = string.Empty;
            InstallerMD5 = string.Empty;
            Is64BitOSRequired = false;
        }

        public override string ToString()
        {
            return this.SAUpdaterSerialise();
        }

        public void FromString(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                Reset();
                return;
            }

            SAUpdaterGlobal.AddLog("SAUpdateDefinitionItem", "FromString", $"Update Definition: {data}");

            var a = data.SAUpdaterDeserialise<SAUpdateDefinitionDataItem>();

            SAUpdaterGlobal.AddLog("SAUpdateDefinitionItem", "FromString", $"Update Definition InstallerCompressedMD5: {a.InstallerCompressedMD5}");
            SAUpdaterGlobal.AddLog("SAUpdateDefinitionItem", "FromString", $"Update Definition InstallerVersion: {a.InstallerVersion}");

            ReleaseVersion = a.ReleaseVersion;
            PreReleaseVersion = a.PreReleaseVersion;
            InstallerVersion = a.InstallerVersion;
            IntReleaseType = a.IntReleaseType;
            IntRequiredOSType = a.IntRequiredOSType;
            IntRequiredFramework = a.IntRequiredFramework;
            IntRequiredOSVersion = a.IntRequiredOSVersion;
            InstallerMD5 = a.InstallerMD5;
            InstallerCompressedMD5 = a.InstallerCompressedMD5;
            HasReleaseNotes = a.HasReleaseNotes;
            HasPreReleaseNotes = a.HasPreReleaseNotes;
            Is64BitOSRequired = a.Is64BitOSRequired;
        }

        #endregion Methods
    }
}