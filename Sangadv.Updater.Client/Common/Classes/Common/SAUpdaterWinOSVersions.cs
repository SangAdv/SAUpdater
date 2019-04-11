using System.Linq;
using System.Management;

namespace SangAdv.Updater.Common
{
    //Add reference to System.Management
    public class SAUpdaterWinOSVersions : ASAUpdaterOSVersions
    {
        #region Constructor

        public SAUpdaterWinOSVersions()
        {
            LoadVersions();

            var query = "SELECT * FROM Win32_OperatingSystem";
            var searcher = new ManagementObjectSearcher(query);
            var info = searcher.Get().Cast<ManagementObject>().FirstOrDefault();
            var caption = info.Properties["Caption"].Value.ToString();
            var version = info.Properties["Version"].Value.ToString();
            var spMajorVersion = info.Properties["ServicePackMajorVersion"].Value.ToString();
            var spMinorVersion = info.Properties["ServicePackMinorVersion"].Value.ToString();

            Version = new SAUpdaterVersionNumber(version);
            SetInstalledOsVersion();
        }

        #endregion Constructor

        #region Properties

        public bool IsWindows10 { get; private set; }

        #endregion Properties

        #region Methods

        private void SetInstalledOsVersion()
        {
            //Website definition
            //https://www.microsoft.com/en-us/itpro/windows-10/release-information

            IsWindows10 = false;
            if (Version.Major < 6) InstalledOSVersion = SAUpdaterWinOSVersion.Old;
            if (Version.Major == 6)
                switch (Version.Minor)
                {
                    case 1: InstalledOSVersion = SAUpdaterWinOSVersion.Win7; break;
                    case 2: InstalledOSVersion = SAUpdaterWinOSVersion.Win8; break;
                    case 3: InstalledOSVersion = SAUpdaterWinOSVersion.Win81; break;
                }
            if (Version.Major == 10)
            {
                IsWindows10 = true;

                switch (Version.Build)
                {
                    case 10240: InstalledOSVersion = SAUpdaterWinOSVersion.Win10; break;
                    case 10586: InstalledOSVersion = SAUpdaterWinOSVersion.Win101511; break;
                    case 14393: InstalledOSVersion = SAUpdaterWinOSVersion.Win101607; break;
                    case 15063: InstalledOSVersion = SAUpdaterWinOSVersion.Win101703; break;
                    case 16299: InstalledOSVersion = SAUpdaterWinOSVersion.Win101709; break;
                    case 17134: InstalledOSVersion = SAUpdaterWinOSVersion.Win101803; break;
                    case 17763: InstalledOSVersion = SAUpdaterWinOSVersion.Win101809; break;
                    case int n when n > 17763: InstalledOSVersion = SAUpdaterWinOSVersion.vNext; break;
                    default: InstalledOSVersion = SAUpdaterWinOSVersion.Unknown; break;
                }
            }
        }

        private void LoadVersions()
        {
            VersionList.Clear();
            VersionList.Add((int)SAUpdaterWinOSVersion.Unknown, "Unknown");
            VersionList.Add((int)SAUpdaterWinOSVersion.Old, "Older than Windows 7");
            VersionList.Add((int)SAUpdaterWinOSVersion.Win7, "Windows 7");
            VersionList.Add((int)SAUpdaterWinOSVersion.Win8, "Windows 8");
            VersionList.Add((int)SAUpdaterWinOSVersion.Win81, "Windows 8.1");
            VersionList.Add((int)SAUpdaterWinOSVersion.Win10, "Windows 10");
            VersionList.Add((int)SAUpdaterWinOSVersion.Win101511, "Windows 10 November Update (1511)");
            VersionList.Add((int)SAUpdaterWinOSVersion.Win101607, "Windows 10 Anniversary Update (1607)");
            VersionList.Add((int)SAUpdaterWinOSVersion.Win101703, "Windows 10 Creators Update (1703)");
            VersionList.Add((int)SAUpdaterWinOSVersion.Win101709, "Windows 10 Fall Creators Update (1709)");
            VersionList.Add((int)SAUpdaterWinOSVersion.Win101803, "Windows 10 April 2018 Update (1803)");
            VersionList.Add((int)SAUpdaterWinOSVersion.Win101809, "Windows 10 September 2018 Update (1809)");
            VersionList.Add((int)SAUpdaterWinOSVersion.vNext, "Windows 10 vNext");
        }

        #endregion Methods
    }
}