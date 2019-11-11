using System;
using System.ComponentModel;

namespace SangAdv.Updater.Common
{
    [Browsable(false)]
    public abstract class ASAUpdaterAzureBlobBaseRepository : ASAUpdaterRepositoryBase
    {
        #region Variables

        public SAUpdaterRepositorySettings<SAHAzureBlobRepositoryConfig> mSettings = new SAUpdaterRepositorySettings<SAHAzureBlobRepositoryConfig>();
        public const string mTestFolder = @"testfolder/";

        #endregion Variables

        #region General Properties

        public SAHAzureBlobRepositoryConfig RepositoryConfig => mSettings.Settings;

        #endregion General Properties

        #region Abstract Properties

        public abstract Uri RepositoryRootFolderUri { get; }

        #endregion Abstract Properties

        #region Abstract Methods

        public override bool ConnectionChecker()
        {
            //try
            //{
            //    using (var client = new WebClient())
            //    using (client.OpenRead("http://clients3.google.com/generate_204"))
            //    {
            //        return true;
            //    }
            //}
            //catch
            //{
            //    return false;
            //}

            return true;
        }

        #endregion Abstract Methods
    }
}