using System;
using System.Collections.Generic;
using System.Linq;

namespace SangAdv.Updater.Common
{
    public class SAUpdaterUpdateOptions
    {
        #region Properties

        public List<string> ProcessNameList { get; set; } = new List<string>();
        public SAUpdaterReleaseType AllowedReleaseType { get; set; } = SAUpdaterReleaseType.Release;
        public string LaunchFilename { get; set; } = string.Empty;

        public bool IsUpdate { get; set; } = true;
        public string ApplicationTitle { get; set; } = string.Empty;
        public string ApplicationFolder { get; set; } = string.Empty;
        public bool ChooseApplicationFolder { get; set; } = false;
        public string InstallerFilename { get; set; } = "updater.exe";

        public bool LaunchApplicationAfterInstall => !string.IsNullOrEmpty(LaunchFilename);

        public bool CreateStartupSettings { get; set; } = false;
        public bool ResetStartupSettings { get; set; } = false;

        #endregion Properties

        #region Methods

        public void UpdateFromCommandLine(string[] commandLineArgs)
        {
            SAUpdaterGlobal.AddLog("SAUpdaterCommandLine", "UpdateOptions", "Start updating from the command line");

            try
            {
                if (commandLineArgs.Length == 0) throw new Exception();

                var tUpdateOptions = commandLineArgs[0].InflateString().SAUpdaterDeserialise<SAUpdaterCommandLineOptions>();

                ApplicationFolder = tUpdateOptions.ApplicationFolder;
                AllowedReleaseType = (SAUpdaterReleaseType)tUpdateOptions.AllowedReleaseType;
                ChooseApplicationFolder = string.IsNullOrEmpty(ApplicationFolder);
                IsUpdate = true;
                ResetStartupSettings = tUpdateOptions.ResetStartupSettings;

                SAUpdaterGlobal.AddLog("SAUpdaterCommandLine", "UpdateOptions", "Updated from the command line");
            }
            catch
            {
                ResetStartupSettings = true;
                IsUpdate = false;
                ChooseApplicationFolder = true;

                SAUpdaterGlobal.AddLog("SAUpdaterCommandLine", "UpdateOptions", "Updated from the defaults");
            }
        }

        public void AddProcessName(string processName)
        {
            var a = ProcessNameList.Where(x => string.Equals(x, processName, StringComparison.CurrentCultureIgnoreCase)).ToList();
            if (!a.Any()) ProcessNameList.Add(processName);
        }

        #endregion Methods
    }
}