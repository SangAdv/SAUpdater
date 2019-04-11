using LiteDB;
using SangAdv.Updater.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SangAdv.Updater.Master
{
    public class AppDataVersions
    {
        #region Variables

        private LiteCollection<AppDataVersionItem> mCollection;

        #endregion Variables

        #region Properties

        internal List<AppDataVersionItem> List => mCollection.FindAll().ToList();
        internal int PublishedCount => mCollection.Find(x => x.Status == SAUpdaterAppVersionStatus.Uploaded).Count();

        #endregion Properties

        #region Constructor

        public AppDataVersions(LiteCollection<AppDataVersionItem> collection)
        {
            mCollection = collection;
        }

        #endregion Constructor

        #region Methods

        internal int Add(string versionNumber, int releaseType, string versionNotes)
        {
            var nv = new AppDataVersionItem
            {
                VersionNumber = versionNumber,
                ReleaseType = releaseType,
                VersionNotes = versionNotes,
                DateTimeCreated = DateTime.Now.ToDateTimeString(),
                HasNotes = false
            };
            return Update(nv);
        }

        internal int Update(AppDataVersionItem item)
        {
            var tList = List;
            int GetNewVersionId()
            {
                try
                {
                    return tList.Select(x => x.Id).Max() + 1;
                }
                catch
                {
                    return 1;
                }
            }

            var a = tList.Where(x => x.Id == item.Id);
            if (a.Any())
            {
                mCollection.Update(item);
            }
            else
            {
                if (item.Id < 1) item.Id = GetNewVersionId();
                mCollection.Insert(item);
            }

            return item.Id;
        }

        internal AppDataVersionItem Get(int selectedVersionId)
        {
            var a = mCollection.Find(x => x.Id == selectedVersionId).ToList();
            return a.Any() ? a.First() : new AppDataVersionItem();
        }

        internal void Delete(int selectedVersionId)
        {
            mCollection.Delete(x => x.Id == selectedVersionId);
        }

        #endregion Methods
    }

    public class AppDataVersionItem
    {
        #region Properties

        public int Id { get; set; } = 0;

        public string VersionNumber { get; set; } = string.Empty;
        public string DateTimeCreated { get; set; } = string.Empty;
        public string DateTimePublished { get; set; } = string.Empty;
        public int VersionStatus { get; set; } = (int)SAUpdaterAppVersionStatus.New;
        public string VersionNotes { get; set; } = string.Empty;
        public int ReleaseType { get; set; } = (int)SAUpdaterReleaseType.Release;
        public bool HasNotes { get; set; } = false;

        internal long VersionIndex => VersionNumber.Replace(".", "").Value<long>();

        internal SAUpdaterAppVersionStatus Status => (SAUpdaterAppVersionStatus)VersionStatus;

        internal SAUpdaterReleaseType EnumReleaseType => (SAUpdaterReleaseType)ReleaseType;

        internal void SetVersionStatus(SAUpdaterAppVersionStatus status) => VersionStatus = (int)status;

        #endregion Properties
    }
}