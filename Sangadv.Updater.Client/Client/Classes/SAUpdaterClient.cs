using SangAdv.Updater.Common;

namespace SangAdv.Updater.Client
{
    public static class SAUpdaterClient
    {
        #region Events

        public static event UpdaterStringDelegate MessageChanged = s => { };

        #endregion Events

        #region Properties

        internal static bool IsInitialised { get; private set; } = false;
        internal static SAUpdaterEventArgs Error { get; private set; } = new SAUpdaterEventArgs();

        public static SAUpdaterCheck Checker { get; private set; }

        public static SAUpdaterInstaller Installer { get; private set; }

        #endregion Properties

        #region Methods

        public static void Initialise(ASAUpdaterRepositoryBase repository, ASAUpdaterClientBase client, SAUpdaterUpdateOptions options)
        {
            if (IsInitialised) return;

            Error.ClearErrorMessage();

            //Process the commandline arguments
            if (!SAUpdaterGlobal.Initialise(repository, client, options))
            {
                Error = SAUpdaterGlobal.Error;
                MessageChanged($"{options.ApplicationTitle} can not be installed");
                return;
            }

            if (Error.HasError) return;

            IsInitialised = true;

            Installer = new SAUpdaterInstaller();
            if (Installer.HasError)
            {
                Error = Installer.Error;
                return;
            }

            Installer.CheckHasInstaller();
            if (Installer.HasError) Error = Installer.Error;

            MessageChanged(string.Empty);

            Checker = new SAUpdaterCheck();

            MessageChanged(string.Empty);
        }

        #endregion Methods
    }
}