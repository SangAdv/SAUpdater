using System;
using System.ComponentModel;
using System.Net;

namespace SangAdv.Updater.Common
{
    [Browsable(false)]
    public abstract class ASAUpdaterFTPBaseRepository : ASAUpdaterRepositoryBase
    {
        #region Variables

        public SAUpdaterRepositorySettings<SAHFTPRepositoryConfig> mSettings = new SAUpdaterRepositorySettings<SAHFTPRepositoryConfig>();

        #endregion Variables

        #region General Properties

        public SAHFTPRepositoryConfig RepositoryConfig => mSettings.Settings;

        #endregion General Properties

        #region Abstract Properties

        public abstract Uri RepositoryRootFolderUri { get; }

        #endregion Abstract Properties

        #region Abstract Methods

        public override bool ConnectionChecker()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://clients3.google.com/generate_204"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        #endregion Abstract Methods
    }
}