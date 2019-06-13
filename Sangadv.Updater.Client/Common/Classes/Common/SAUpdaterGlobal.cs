using System.Collections.Generic;
using System.Threading.Tasks;

namespace SangAdv.Updater.Common
{
    public static class SAUpdaterGlobal
    {
        #region Variables

        private static SAUpdaterLogger mlogger = null;
        private static List<string> mIgnoreList = new List<string>();

        #endregion Variables

        #region Properties

        public static bool Connected { get; private set; }
        public static SAUpdaterMaster Master { get; set; }
        public static SAUpdaterUpdateOptions Options { get; set; }
        public static ASAUpdaterClientBase Client { get; set; }
        public static ASAUpdaterRepositoryBase Repository { get; set; }
        public static bool IsInitialised { get; set; } = false;

        public static SAUpdaterEventArgs Error { get; private set; } = new SAUpdaterEventArgs();

        #endregion Properties

        #region Methods

        internal static async Task<bool> InitialiseAsync(ASAUpdaterRepositoryBase repository, ASAUpdaterClientBase client, SAUpdaterUpdateOptions options)
        {
            if (IsInitialised) return true;

            Error.ClearErrorMessage();

            PrepareIgnoreList();

            await InitialiseLocalsAsync(options, repository, client);
            if (Error.HasError) return false;

            mlogger = new SAUpdaterLogger(client.LoggingFolder);

            Connected = repository.Connected(true);
            if (!Connected)
            {
                Error = new SAUpdaterEventArgs($"Please connect to the internet to install {options.ApplicationTitle}.", SAUpdaterResults.NotConnected);
                return false;
            }

            IsInitialised = true;
            return true;
        }

        internal static bool Initialise(ASAUpdaterRepositoryBase repository, ASAUpdaterClientBase client, SAUpdaterUpdateOptions options)
        {
            if (IsInitialised) return true;

            Error.ClearErrorMessage();

            PrepareIgnoreList();

            InitialiseLocals(options, repository, client);
            if (Error.HasError) return false;

            mlogger = new SAUpdaterLogger(client.LoggingFolder);

            Connected = repository.Connected(true);
            if (!Connected)
            {
                Error = new SAUpdaterEventArgs($"Please connect to the internet to install {options.ApplicationTitle}.", SAUpdaterResults.NotConnected);
                return false;
            }

            IsInitialised = true;
            return true;
        }

        public static void AddLog(string className, string methodName, string message)
        {
            mlogger?.Add(className, methodName, message);
        }

        internal static bool IsInIgnoreList(string filename)
        {
            return mIgnoreList.Contains(filename.Trim().ToUpper());
        }

        private static async Task InitialiseLocalsAsync(SAUpdaterUpdateOptions options, ASAUpdaterRepositoryBase repository, ASAUpdaterClientBase client)
        {
            InitialiseLocalVariables(options, repository, client);

            //Get repository update definition
            if (!await repository.GetUpdateDefinitionAsync())
            {
                Error = new SAUpdaterEventArgs("Could not read update definition", SAUpdaterResults.MissingVersionFile);
                return;
            }

            AddLog("SAUpdaterCommon", "SAUpdaterCommon", $"Repository Installer Version: {repository.UpdateDefinition.InstallerVersion}");

            if (!repository.HasUpdateDefinition)
            {
                Error = new SAUpdaterEventArgs("Could not read update definition", SAUpdaterResults.MissingVersionFile);
                return;
            }

            IsInitialised = true;
        }

        private static void InitialiseLocals(SAUpdaterUpdateOptions options, ASAUpdaterRepositoryBase repository, ASAUpdaterClientBase client)
        {
            InitialiseLocalVariables(options, repository, client);

            //Get repository update definition
            if (!repository.GetUpdateDefinition())
            {
                Error = new SAUpdaterEventArgs("Could not read update definition", SAUpdaterResults.MissingVersionFile);
                return;
            }

            AddLog("SAUpdaterCommon", "SAUpdaterCommon", $"Repository Installer Version: {repository.UpdateDefinition.InstallerVersion}");

            if (!repository.HasUpdateDefinition)
            {
                Error = new SAUpdaterEventArgs("Could not read update definition", SAUpdaterResults.MissingVersionFile);
                return;
            }

            IsInitialised = true;
        }

        private static void InitialiseLocalVariables(SAUpdaterUpdateOptions options, ASAUpdaterRepositoryBase repository, ASAUpdaterClientBase client)
        {
            //==================================================
            //Do this first - Required by the Global variables
            //Register SAUpdaterUpdateOptions
            Options = options;

            //Register SAUpdaterRepository
            Repository = repository;

            //Register SAUpdaterClient
            Client = client;
            //==================================================

            //Check if the client has an error
            if (client.ErrorMessage != string.Empty)
            {
                Error.SetErrorMessage(client.ErrorMessage);
                return;
            }
            //Initialise the client
            client.Initialise();

            //Check if the client has an error
            if (client.ErrorMessage != string.Empty)
            {
                Error.SetErrorMessage(client.ErrorMessage);
            }
        }

        private static void PrepareIgnoreList()
        {
            mIgnoreList.Add(SAUpdaterConstants.ClientStartupFileName.Trim().ToUpper());
        }

        #endregion Methods
    }
}