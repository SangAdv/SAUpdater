using SangAdv.Updater.Common;
using System;

namespace SangAdv.Updater.Client
{
    internal class SAUpdaterWinClient : ASAUpdaterClientBase
    {
        #region Constructor

        public SAUpdaterWinClient() : base(new SAUpdaterNetFramework(), new SAUpdaterWinClientFileList())
        {
            ClientOSVersion = new SAUpdaterWinOSVersions();
            Is64BitOS = Environment.Is64BitOperatingSystem;
        }

        #endregion Constructor
    }
}