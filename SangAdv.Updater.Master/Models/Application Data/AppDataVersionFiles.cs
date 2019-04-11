using LiteDB;
using System.Collections.Generic;
using System.Linq;

namespace SangAdv.Updater.Master
{
    public class AppDataVersionFiles
    {
        #region Variables

        private LiteCollection<AppDataVersionFileItem> mCollection;

        #endregion Variables

        #region Constructor

        public AppDataVersionFiles(LiteCollection<AppDataVersionFileItem> collection)
        {
            mCollection = collection;
            mCollection.EnsureIndex(x => x.Id, true);
        }

        #endregion Constructor

        #region Methods

        internal List<AppDataVersionFileItem> GetAll(int selectedVersionId)
        {
            return mCollection.Find(x => x.VersionId == selectedVersionId).ToList();
        }

        internal int Count(int selectedVersionId)
        {
            return mCollection.Find(x => x.VersionId == selectedVersionId).Count();
        }

        internal AppDataVersionFileItem Get(int selectedVersionId, int fileId)
        {
            var cvf = mCollection.Find(x => x.FileId == fileId && x.VersionId == selectedVersionId).ToList();
            if (cvf.Any()) return cvf.First();
            return new AppDataVersionFileItem { FileId = fileId, VersionId = selectedVersionId };
        }

        internal bool Contains(int selectedVersionId, int fileId)
        {
            var cvf = mCollection.Find(x => x.FileId == fileId && x.VersionId == selectedVersionId).ToList();
            return cvf.Any();
        }

        internal bool ContainsFile(int fileId)
        {
            return mCollection.Find(x => x.FileId == fileId).Any();
        }

        internal AppDataVersionFileItem Get(string versionFileId)
        {
            var cvf = mCollection.Find(x => x.Id == versionFileId).ToList();
            if (cvf.Any()) return cvf.First();
            return new AppDataVersionFileItem { FileId = 0, VersionId = 0 };
        }

        internal void Update(AppDataVersionFileItem item)
        {
            var avf = GetAll(item.VersionId).Where(x => x.FileId == item.FileId).ToList();
            if (avf.Any()) mCollection.Delete(x => x.VersionId == item.VersionId && x.FileId == item.FileId);
            mCollection.Insert(item);
        }

        internal void Delete(int selectedVersionId)
        {
            var cvfs = mCollection.Find(x => x.VersionId == selectedVersionId).ToList();
            foreach (var vf in cvfs)
                mCollection.Delete(x => x.VersionId == selectedVersionId && x.FileId == vf.FileId);
        }

        #endregion Methods
    }

    public class AppDataVersionFileItem
    {
        private string mId;

        public string Id
        {
            get => $"{VersionId:0000000000}-{FileId:0000000000}";
            set => mId = value;
        }

        public int VersionId { get; set; } = 0;
        public int FileId { get; set; } = 0;
        public string MD5 { get; set; } = string.Empty;
        public string CompressedMD5 { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;
        public bool Uploaded { get; set; } = false;
        public int UpdateOptionId { get; set; } = 1;
        public string UpdateOptionValue { get; set; } = string.Empty;
    }
}