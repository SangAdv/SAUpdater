using LiteDB;
using System.Collections.Generic;
using System.Linq;

namespace SangAdv.Updater.Master
{
    internal class MasterDataCategory
    {
        #region Variables

        private LiteCollection<MasterDataCategoryItem> mCollection;

        #endregion Variables

        #region Properties

        internal List<MasterDataCategoryItem> List => mCollection.FindAll().ToList();

        #endregion Properties

        #region Constructor

        internal MasterDataCategory(LiteCollection<MasterDataCategoryItem> collection)
        {
            mCollection = collection;

            if (!mCollection.FindAll().Any()) mCollection.Insert(new MasterDataCategoryItem { Id = 1, CategoryDesc = "General" });
        }

        #endregion Constructor

        #region Methods

        internal MasterDataCategoryItem Get(int categoryId)
        {
            return mCollection.Find(x => x.Id == categoryId).First();
        }

        internal int Update(MasterDataCategoryItem categoryItem)
        {
            categoryItem.Id = mCollection.FindAll().Select(x => x.Id).Max() + 1;
            mCollection.Insert(categoryItem);
            return categoryItem.Id;
        }

        #endregion Methods
    }

    internal class MasterDataCategoryItem
    {
        public int Id { get; set; } = 0;

        public string CategoryDesc { get; set; } = string.Empty;
    }
}