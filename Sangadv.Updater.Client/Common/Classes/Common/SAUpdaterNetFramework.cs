using Microsoft.Win32;
using System.Linq;

namespace SangAdv.Updater.Common
{
    public class SAUpdaterNetFramework : ASAUpdaterClientFramework
    {
        #region Variables

        private int mMinFWVersion;
        private int mMaxFWVersion;

        #endregion

        #region Abstract Properties

        public override SAUpdaterOSType ClientOSType => SAUpdaterOSType.Windows;

        #endregion Abstract Properties

        #region Properties

        public string DownloadURL => @"https://www.microsoft.com/net/download/dotnet-framework-runtime";

        #endregion Properties

        #region Constructor

        public SAUpdaterNetFramework()
        {
            LoadVersions();

            try
            {
                using (var ndpKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\"))
                {
                    InstalledVersionId = ndpKey.GetValue("Release").Value<int>();

                    var iv = VersionList.Where(x => x.VersionId == InstalledVersionId).ToList();
                    if (iv.Any())
                    {
                        InstalledVersionDescription = iv.First().Description;
                        InstalledVersion = iv.First().Version;
                    }
                    else
                    {
                        if (InstalledVersionId < mMinFWVersion)
                        {
                            InstalledVersionDescription = "Old .NET Framework";
                            InstalledVersion = SAUpdaterFrameworkVersions.None;
                        }
                        else if (InstalledVersionId > mMaxFWVersion)
                        {
                            InstalledVersionDescription = "Latest .NET Framework";
                            InstalledVersion = SAUpdaterFrameworkVersions.Version472;
                        }
                    }
                }
            }
            catch
            {
                InstalledVersionDescription = ".NET Framework not installed";
                InstalledVersion = SAUpdaterFrameworkVersions.None;
                InstalledVersionId = 0;
            }
        }

        #endregion Constructor

        #region Methods

        private void LoadVersions()
        {
            //Website definition
            //https://docs.microsoft.com/en-us/dotnet/framework/migration-guide/how-to-determine-which-versions-are-installed#net_b

            VersionList.Clear();

            VersionList.Add(new VersionListItem { VersionId = 378389, Version = SAUpdaterFrameworkVersions.Version45, Description = ".NET Framework 4.5" });

            VersionList.Add(new VersionListItem { VersionId = 378675, Version = SAUpdaterFrameworkVersions.Version451, Description = ".NET Framework 4.5.1 installed with Windows 8.1 or Windows Server 2012 R2" });
            VersionList.Add(new VersionListItem { VersionId = 378758, Version = SAUpdaterFrameworkVersions.Version451, Description = ".NET Framework 4.5.1 installed on Windows 8, Windows 7 SP1, or Windows Vista SP2" });

            VersionList.Add(new VersionListItem { VersionId = 379893, Version = SAUpdaterFrameworkVersions.Version452, Description = ".NET Framework 4.5.2" });

            VersionList.Add(new VersionListItem { VersionId = 393295, Version = SAUpdaterFrameworkVersions.Version46, Description = ".NET Framework 4.6 On Windows 10" });
            VersionList.Add(new VersionListItem { VersionId = 393297, Version = SAUpdaterFrameworkVersions.Version46, Description = ".NET Framework 4.6" });

            VersionList.Add(new VersionListItem { VersionId = 394254, Version = SAUpdaterFrameworkVersions.Version461, Description = ".NET Framework 4.6.1 On Windows 10 November Update" });
            VersionList.Add(new VersionListItem { VersionId = 394271, Version = SAUpdaterFrameworkVersions.Version461, Description = ".NET Framework 4.6.1" });

            VersionList.Add(new VersionListItem { VersionId = 394802, Version = SAUpdaterFrameworkVersions.Version462, Description = ".NET Framework 4.6.2 On Windows 10 Anniversary Update" });
            VersionList.Add(new VersionListItem { VersionId = 394806, Version = SAUpdaterFrameworkVersions.Version462, Description = ".NET Framework 4.6.2" });

            VersionList.Add(new VersionListItem { VersionId = 460798, Version = SAUpdaterFrameworkVersions.Version47, Description = ".NET Framework 4.7 On Windows 10 Creators Update" });
            VersionList.Add(new VersionListItem { VersionId = 460805, Version = SAUpdaterFrameworkVersions.Version47, Description = ".NET Framework 4.7" });

            VersionList.Add(new VersionListItem { VersionId = 461308, Version = SAUpdaterFrameworkVersions.Version471, Description = ".NET Framework 4.7.1 On Windows 10 Fall Creators Update" });
            VersionList.Add(new VersionListItem { VersionId = 461310, Version = SAUpdaterFrameworkVersions.Version471, Description = ".NET Framework 4.7.1" });

            VersionList.Add(new VersionListItem { VersionId = 461808, Version = SAUpdaterFrameworkVersions.Version472, Description = ".NET Framework 4.7.2 On Windows 10 April 2018 Update" });
            VersionList.Add(new VersionListItem { VersionId = 461814, Version = SAUpdaterFrameworkVersions.Version472, Description = ".NET Framework 4.7.2" });

            VersionList.Add(new VersionListItem { VersionId = 528040, Version = SAUpdaterFrameworkVersions.Version48, Description = ".NET Framework 4.8 On Windows 10 May 2019 Update" });
            VersionList.Add(new VersionListItem { VersionId = 528049, Version = SAUpdaterFrameworkVersions.Version48, Description = ".NET Framework 4.8" });

            VersionList.Add(new VersionListItem { VersionId = 0, Version = SAUpdaterFrameworkVersions.None, Description = "Unknown .NET Framework" });

            mMinFWVersion = 378389;
            mMaxFWVersion = 528049;
        }

        #endregion Methods
    }
}