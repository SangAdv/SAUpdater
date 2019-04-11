using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace SangAdv.Updater.Common
{
    [Browsable(false)]
    public abstract class ASAUpdaterClientFramework
    {
        #region Abstract Properties

        public abstract SAUpdaterOSType ClientOSType { get; }

        #endregion Abstract Properties

        #region Properties

        public List<VersionListItem> VersionList = new List<VersionListItem>();
        public SAUpdaterFrameworkVersions InstalledVersion { get; set; } = SAUpdaterFrameworkVersions.None;
        public int InstalledVersionId { get; set; } = 0;
        public string InstalledVersionDescription { get; set; } = string.Empty;

        #endregion Properties

        #region Methods

        public bool IsRequiredVersion(SAUpdaterFrameworkVersions requiredVersion)
        {
            var rv = VersionList.Where(x => x.Version == requiredVersion).ToList();
            return rv.First().VersionId <= InstalledVersionId;
        }

        public string GetVersionDescription(SAUpdaterFrameworkVersions requiredVersion)
        {
            var rv = VersionList.Where(x => x.Version == requiredVersion).ToList();
            return rv.First().Description;
        }

        #endregion Methods

        #region Structures

        public struct VersionListItem
        {
            public int VersionId { get; set; }
            public SAUpdaterFrameworkVersions Version { get; set; }
            public string Description { get; set; }
        }

        #endregion Structures
    }
}