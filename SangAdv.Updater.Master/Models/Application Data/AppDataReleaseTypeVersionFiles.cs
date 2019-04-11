using LiteDB;
using SangAdv.Updater.Common;
using System.Linq;

namespace SangAdv.Updater.Master
{
    internal class AppDataReleaseTypeFiles
    {
        #region Variables

        private LiteCollection<AppDataReleaseTypeFileItem> mCollection;

        #endregion Variables

        #region Constructor

        public AppDataReleaseTypeFiles(LiteCollection<AppDataReleaseTypeFileItem> collection)
        {
            mCollection = collection;
            mCollection.EnsureIndex(x => x.Id, true);
        }

        #endregion Constructor

        #region Methods

        internal int GetVersionId(int fileId, SAUpdaterReleaseType releaseType)
        {
            var cvf = mCollection.Find(x => x.FileId == fileId && x.ReleaseType == (int)releaseType).ToList();
            if (cvf.Any()) return cvf.First().VersionId;
            return 0;
        }

        internal void Update(AppDataReleaseTypeFileItem item)
        {
            var avf = mCollection.Find(x => x.FileId == item.FileId && x.ReleaseType == item.ReleaseType).ToList();
            if (avf.Any()) mCollection.Delete(x => x.FileId == item.FileId && x.ReleaseType == item.ReleaseType);
            mCollection.Insert(item);
        }

        internal void Delete(int fileId, SAUpdaterReleaseType releaseType)
        {
            var cvfs = mCollection.Find(x => x.FileId == fileId && x.ReleaseType == (int)releaseType).ToList();
            foreach (var vf in cvfs)
                mCollection.Delete(x => x.FileId == fileId && x.ReleaseType == (int)releaseType);
        }

        #endregion Methods
    }

    internal class AppDataReleaseTypeFileItem
    {
        #region Properties

        private string mId;

        public string Id
        {
            get => $"{FileId:0000000000}-{ReleaseType:0}";
            set => mId = value;
        }

        public int FileId { get; set; } = 0;
        public int ReleaseType { get; set; } = (int)SAUpdaterReleaseType.Release;
        public int VersionId { get; set; } = 0;

        #endregion Properties
    }
}