using SangAdv.Updater.Common;

namespace SangAdv.Updater.Master
{
    public class SAUpdaterWinClient : ASAUpdaterClientBase
    {
        #region Constructor

        public SAUpdaterWinClient() : base(new SAUpdaterNetFramework(), new SAUpdaterWinClientFileList())
        {
            ClientOSVersion = new SAUpdaterWinOSVersions();
        }

        #endregion Constructor
    }
}