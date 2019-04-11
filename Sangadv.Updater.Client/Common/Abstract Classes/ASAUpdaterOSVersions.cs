using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SangAdv.Updater.Common
{
    [Browsable(false)]
    public abstract class ASAUpdaterOSVersions
    {
        #region Propert

        public Dictionary<int, string> VersionList = new Dictionary<int, string>();
        public Enum InstalledOSVersion { get; set; }
        public string VersionDescription => VersionList[InstalledOSVersion.Value<int>()];
        public SAUpdaterVersionNumber Version { get; set; }

        #endregion Propert

        #region Methods

        public bool IsRequiredVersion(int requiredVersion) => requiredVersion <= InstalledOSVersion.Value<int>();

        public string GetVersionDescription(int requiredVersion) => VersionList[requiredVersion];

        #endregion Methods
    }
}