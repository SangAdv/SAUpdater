using LiteDB;
using SangAdv.Updater.Common;
using System.IO;

namespace SangAdv.Updater.Master
{
    internal class MasterDataFile
    {
        #region Variables

        private LiteDatabase mDatabase;

        #endregion Variables

        #region Properties

        internal MasterDataApplication Applications { get; private set; }
        internal MasterDataCategory Categories { get; private set; }

        #endregion Properties

        #region Constructor

        public MasterDataFile()
        {
            mDatabase = new LiteDatabase(Path.Combine(SAUpdaterGlobal.Master.DataFolder, @"Data.db"));
        }

        #endregion Constructor

        #region Methods

        internal void Load()
        {
            Applications = new MasterDataApplication(mDatabase.GetCollection<MasterDataApplicationItem>("updateapps"));
            Categories = new MasterDataCategory(mDatabase.GetCollection<MasterDataCategoryItem>("updatecategories"));
        }

        #endregion Methods
    }
}