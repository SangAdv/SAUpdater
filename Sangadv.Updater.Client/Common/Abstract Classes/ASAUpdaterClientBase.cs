using System;
using System.ComponentModel;
using System.IO;

namespace SangAdv.Updater.Common
{
    [Browsable(false)]
    public abstract class ASAUpdaterClientBase : SAUpdaterErrorBase
    {
        #region Variables

        private const string ClientUpdateFolder = @"Updater\";

        #endregion Variables

        #region Properties

        public ASAUpdaterClientFileList UpdateFiles { get; private set; }
        public string ApplicationFolder => SAUpdaterGlobal.Options.ApplicationFolder;
        public SAUpdateDefinitionItem UpdateDefinition { get; } = new SAUpdateDefinitionItem();
        public SAUpdaterStartupSettings StartupSettings { get; private set; }
        public ASAUpdaterClientFramework ClientFramework { get; private set; }
        public ASAUpdaterOSVersions ClientOSVersion { get; set; }
        public bool Is64BitOS { get; set; } = false;

        #endregion Properties

        #region Derived Repository Properties

        public string DownloadFolder => Path.Combine(ApplicationFolder, ClientUpdateFolder, @"Download\");
        public string UpdateFolder => Path.Combine(ApplicationFolder, ClientUpdateFolder, @"Update\");
        public string ExtractFolder => Path.Combine(ApplicationFolder, ClientUpdateFolder, @"Extract\");
        internal string LoggingFolder => Path.Combine(ApplicationFolder, ClientUpdateFolder, @"Logs\");
        internal string UpdateDefinitionFilename => Path.Combine(UpdateFolder, SAUpdaterConstants.ClientUpdateDefinitionFileName);

        #endregion Derived Repository Properties

        #region Constructor

        public ASAUpdaterClientBase(ASAUpdaterClientFramework clientFramework, ASAUpdaterClientFileList clientFileList)
        {
            ClientFramework = clientFramework;
            UpdateFiles = clientFileList;
        }

        #endregion Constructor

        #region Methods

        internal void Initialise()
        {
            if (!PrepareFolders()) return;

            if (SAUpdaterGlobal.Options.CreateStartupSettings) StartupSettings = new SAUpdaterStartupSettings(ApplicationFolder);

            if (!File.Exists(UpdateDefinitionFilename)) SaveUpdateDefinition();
            ReadUpdateDefinition();

            UpdateFiles.Initialise(Path.Combine(UpdateFolder, SAUpdaterConstants.ClientUpdateFilesFileName));
        }

        public void SaveUpdateDefinition()
        {
            UpdateDefinition.Save(UpdateDefinitionFilename);
        }

        public bool IsRequiredOSType(SAUpdaterOSType requiredOsType) => requiredOsType == ClientFramework.ClientOSType;

        public bool IsRequiredOSArchitecture(bool require64BitOS)
        {
            if (!Is64BitOS)
            {
                if (require64BitOS) return false;
            }

            return true;
        }

        public string FullInstallerFilename(string filename) => Path.Combine(UpdateFolder, filename);

        public string CompressedInstallerFilename(string filename) => $"{Path.Combine(DownloadFolder, filename)}.ZIP";

        public string TempInstallerFilename(string filename) => $"{Path.Combine(ExtractFolder, filename)}";

        #endregion Methods

        #region Private Methods

        private bool PrepareFolders()
        {
            Error.ClearErrorMessage();

            try
            {
                SAUpdaterFolder.Create(ApplicationFolder);
                SAUpdaterFolder.Create(DownloadFolder);
                SAUpdaterFolder.Create(UpdateFolder);
                SAUpdaterFolder.Create(ExtractFolder);
                SAUpdaterFolder.Create(LoggingFolder);

                return true;
            }
            catch (Exception ex)
            {
                Error.SetErrorMessage(ex.Message);
                return false;
            }
        }

        private void ReadUpdateDefinition()
        {
            if (File.Exists(UpdateDefinitionFilename)) UpdateDefinition.Read(UpdateDefinitionFilename);
        }

        #endregion Private Methods
    }
}