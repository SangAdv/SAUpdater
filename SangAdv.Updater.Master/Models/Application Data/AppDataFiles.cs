using LiteDB;
using SangAdv.Updater.Common;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SangAdv.Updater.Master
{
    public class AppDataFiles
    {
        #region Variables

        private LiteCollection<AppDataFileItem> mCollection;

        #endregion Variables

        #region Properties

        internal List<AppDataFileItem> List => mCollection.FindAll().ToList();

        internal SAUpdaterAppStatus HasIncludedItems
        {
            get
            {
                var a = mCollection.Find(x => x.IncludeStatus);
                return a.Any() ? SAUpdaterAppStatus.Defined : SAUpdaterAppStatus.New;
            }
        }

        #endregion Properties

        #region Constructor

        public AppDataFiles(LiteCollection<AppDataFileItem> collection)
        {
            mCollection = collection;
            mCollection.EnsureIndex(x => x.Id, true);
        }

        #endregion Constructor

        #region Methods

        internal AppDataFileItem Get(int selectedFileId)
        {
            var a = mCollection.Find(x => x.Id == selectedFileId).ToList();
            return a.Any() ? a.First() : new AppDataFileItem();
        }

        internal void Update(AppDataFileItem item)
        {
            Delete(item.Id);
            mCollection.Insert(item);
        }

        internal void Delete(int fileId)
        {
            var cf = mCollection.Find(x => x.Id == fileId).ToList();
            if (cf.Any()) mCollection.Delete(x => x.Id == fileId);
        }

        internal bool ContainsFile(string fileName)
        {
            var a = mCollection.Find(x => x.Filename.ToUpper() == fileName.ToUpper());
            return a.Any();
        }

        #endregion Methods
    }

    public class AppDataFileItem
    {
        #region Properties

        public int Id { get; set; } = 0;

        public string Filename { get; set; } = string.Empty;
        public bool ReferenceFile { get; set; } = false;
        public string UniqueFilename { get; set; } = string.Empty;
        public int FolderId { get; set; } = 1;
        public bool IncludeStatus { get; set; } = true;
        public bool CreateShortCut { get; set; } = false;

        #endregion Properties

        #region Derived Properties

        public string IncludeStatusImageIndex => IncludeStatus ? GetAppStatusImageIndex(SAUpdaterAppFileStatus.OK) : GetAppStatusImageIndex(SAUpdaterAppFileStatus.No);
        public string CreateShortCutImageIndex => CreateShortCut ? GetAppStatusImageIndex(SAUpdaterAppFileStatus.OK) : GetAppStatusImageIndex(SAUpdaterAppFileStatus.Blank);

        public string FileStatusImageIndex(string sourceFolder)
        {
            return ((int)GetAppStatusImageIndex(sourceFolder)).ToString();
        }

        private SAUpdaterAppFileStatus GetAppStatusImageIndex(string sourceFolder)
        {
            if (ReferenceFile) return SAUpdaterAppFileStatus.Dot;
            return File.Exists(Path.Combine(sourceFolder, Filename)) ? SAUpdaterAppFileStatus.OK : SAUpdaterAppFileStatus.No;
        }

        private string GetAppStatusImageIndex(SAUpdaterAppFileStatus type)
        {
            return ((int)type).ToString();
        }

        #endregion Derived Properties
    }
}