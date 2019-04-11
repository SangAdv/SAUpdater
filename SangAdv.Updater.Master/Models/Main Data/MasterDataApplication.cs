using LiteDB;
using SangAdv.Updater.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SangAdv.Updater.Master
{
    internal class MasterDataApplication
    {
        #region Variables

        private LiteCollection<MasterDataApplicationItem> mCollection;

        #endregion Variables

        #region Properties

        internal int Count => mCollection.FindAll().Count();

        #endregion Properties

        #region Constructor

        internal MasterDataApplication(LiteCollection<MasterDataApplicationItem> collection)
        {
            mCollection = collection;
        }

        #endregion Constructor

        #region Methods

        internal int Add(MasterDataApplicationItem item)
        {
            try
            {
                item.Id = mCollection.FindAll().Select(x => x.Id).Max() + 1;
            }
            catch
            {
                item.Id = 1;
            }
            mCollection.Insert(item);
            return item.Id;
        }

        internal MasterDataApplicationItem Get(int applicationId)
        {
            var a = mCollection.Find(x => x.Id == applicationId).ToList();
            return a.Any() ? a.First() : new MasterDataApplicationItem();
        }

        internal List<MasterDataApplicationItem> GetAll(int categoryId)
        {
            return mCollection.Find(x => x.CategoryId == categoryId).ToList();
        }

        internal void Update(MasterDataApplicationItem item)
        {
            var a = mCollection.Find(x => x.Id == item.Id).ToList();
            if (!a.Any()) throw new Exception($"Application {item.Id} not found!");
            var tCurrentApplication = a.First();
            tCurrentApplication.AppStatus = item.AppStatus;
            mCollection.Update(tCurrentApplication);
        }

        internal int Remove(int applicationId)
        {
            return mCollection.Delete(x => x.Id == applicationId);
        }

        #endregion Methods
    }

    internal class MasterDataApplicationItem
    {
        #region Properties

        public int Id { get; set; } = 0;
        public string ApplicationTitle { get; set; } = string.Empty;
        public string DateTimeCreated { get; set; } = DateTime.Now.ToDateTimeString();
        public int CategoryId { get; set; } = 1;
        public int AppStatus { get; set; } = (int)SAUpdaterAppStatus.New;
        public bool IsBackedUp { get; set; } = false;
        public bool HasDatabase { get; set; } = false;
        public SAUpdaterRepositoryType RepositoryType { get; set; } = SAUpdaterRepositoryType.FTP;

        public Dictionary<int, string> PublishedVersion { get; set; } = new Dictionary<int, string>();

        #endregion Properties

        #region Methods

        public void AddVersion(SAUpdaterReleaseType releaseType, string version)
        {
            PublishedVersion[(int)releaseType] = version;
        }

        public Dictionary<SAUpdaterReleaseType, string> GetVersions()
        {
            var tVersions = new Dictionary<SAUpdaterReleaseType, string>();
            foreach (var item in PublishedVersion) tVersions.Add((SAUpdaterReleaseType)item.Key, item.Value);
            return tVersions;
        }

        public string ReleaseVersion()
        {
            return PublishedVersion.ContainsKey((int)SAUpdaterReleaseType.Release) ? PublishedVersion[(int)SAUpdaterReleaseType.Release] : string.Empty;
        }

        public string HighestPreReleaseVersion()
        {
            var a = PublishedVersion.Where(x => x.Key != (int)SAUpdaterReleaseType.Release).OrderBy(x => x.Key).ToList();
            if (!a.Any()) return string.Empty;

            return a.Last().Value;
        }

        public SAUpdaterReleaseType HighestPreReleaseType()
        {
            var a = PublishedVersion.Where(x => x.Key != (int)SAUpdaterReleaseType.Release).OrderBy(x => x.Key).ToList();
            if (!a.Any()) return SAUpdaterReleaseType.Alpha;

            return (SAUpdaterReleaseType)a.Last().Key;
        }

        public string PublishedImageIndex => IsBackedUp ? "4" : "5"; //Image index for imlStatus

        public string HasDatabaseImageIndex => HasDatabase ? "4" : "5"; //Image index for imlStatus

        public int AppStatusImageIndex => AppStatus - 1;

        #endregion Methods
    }
}