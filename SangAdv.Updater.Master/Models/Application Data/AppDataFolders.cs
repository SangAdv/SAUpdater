using LiteDB;
using System.Collections.Generic;
using System.Linq;

namespace SangAdv.Updater.Master
{
    public class AppDataFolders
    {
        #region Variables

        private LiteCollection<AppDataFolderItem> mCollection;

        #endregion Variables

        #region Properties

        internal List<AppDataFolderItem> List => mCollection.FindAll().ToList();

        #endregion Properties

        #region Constructor

        public AppDataFolders(LiteCollection<AppDataFolderItem> collection)
        {
            mCollection = collection;
            if (!List.Any()) Add(SAUpdaterConstants.RootFolder);
        }

        #endregion Constructor

        #region Methods

        internal void Add(string appDirectory)
        {
            var a = mCollection.Find(x => x.Folder == appDirectory);
            if (!a.Any()) mCollection.Insert(new AppDataFolderItem { Id = GetNewId, Folder = appDirectory });
        }

        internal string GetName(int selectedFolderId)
        {
            var a = mCollection.Find(x => x.Id == selectedFolderId).ToList();
            return a.Any() ? a.First().Folder : string.Empty;
        }

        private int GetNewId
        {
            get
            {
                try
                {
                    return List.Select(x => x.Id).Max() + 1;
                }
                catch
                {
                    return 1;
                }
            }
        }

        #endregion Methods
    }

    public class AppDataFolderItem
    {
        public int Id { get; set; }

        public string Folder { get; set; }
    }
}