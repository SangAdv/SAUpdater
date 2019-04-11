using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace SangAdv.Updater.Common
{
    [Browsable(false)]
    public abstract class ASAUpdaterClientFileList : SAUpdaterFileList
    {
        #region Events

        public event UpdaterStringDelegate MessageChanged = (s) => { };

        public event UpdaterStringDelegate ProgressChanged = (s) => { };

        public void RaiseMessageChangedEvent(string message) => MessageChanged(message);

        public void RaiseProgressChangedEvent(string progress) => ProgressChanged(progress);

        #endregion Events

        #region Variables

        internal string mFilename = string.Empty;

        #endregion Variables

        #region Properties

        public List<SAUpdaterFileItem> DownloadList { get; } = new List<SAUpdaterFileItem>();

        public int DownloadCount => DownloadList.Count;

        #endregion Properties

        #region Methods

        internal void Initialise(string filename)
        {
            mFilename = filename;

            if (!File.Exists(mFilename)) Save();
            Read();
        }

        public void Save()
        {
            SAUpdaterFile.Write(mFilename, ToString());
        }

        internal void Read()
        {
            FromString(SAUpdaterFile.Read(mFilename)[0]);
        }

        #region Clean Up

        public void CleanupOldFiles()
        {
            var tClient = SAUpdaterGlobal.Client;
            var fileDeleteList = new List<string>();

            RaiseMessageChangedEvent("Cleaning up old files ...");
            RaiseProgressChangedEvent("");

            foreach (var item in Directory.GetFiles(tClient.ApplicationFolder))
            {
                if (!InUpdateList(item)) fileDeleteList.Add(item);
            }
            foreach (var item in fileDeleteList) SAUpdaterFile.Delete(item);
        }

        private bool InUpdateList(string filename)
        {
            if (SAUpdaterGlobal.IsInIgnoreList(filename)) return true;
            var a = List.Where(x => string.Equals(x.Filename.Trim(), new FileInfo(filename).Name.Trim(), StringComparison.CurrentCultureIgnoreCase));
            return a.Any() ? true : false;
        }

        #endregion Clean Up

        #region Extract

        public SAUpdaterEventArgs ExtractFiles(int retryCount)
        {
            var tClient = SAUpdaterGlobal.Client;

            var success = true;

            RaiseMessageChangedEvent("Extracting files ...");

            foreach (var item in List)
            {
                var tArchiveFile = item.DownloadFilename(tClient.DownloadFolder);
                var tDestinationFile = item.ExtractFilename(tClient.ExtractFolder);
                var tExtract = false;

                string tMD5 = null;
                if (item.ForceDownload) tExtract = true;
                else if (File.Exists(tDestinationFile))
                {
                    tMD5 = tDestinationFile.GenerateFileMD5();
                    if (tMD5.Trim() != item.MD5.Trim()) tExtract = true;
                }
                else tExtract = true;

                if (tExtract)
                {
                    //Delete the file if it exists
                    if (File.Exists(tDestinationFile))
                    {
                        if (!SAUpdaterFile.Delete(tDestinationFile)) return new SAUpdaterEventArgs($"Could not delete {tDestinationFile}", SAUpdaterResults.FileFolderDeleteError);
                    }

                    var t = 0;
                    while (t < retryCount)
                    {
                        success = false;

                        var tMessage = $"Extracting archive {item.UniqueFilename}.ZIP";
                        if (t > 0) tMessage = $"{tMessage} (Attempt:{t})";

                        RaiseProgressChangedEvent(tMessage);

                        t += 1;

                        SAUpdaterZip.Extract(tArchiveFile, tClient.ExtractFolder);

                        tMD5 = tDestinationFile.GenerateFileMD5();
                        if (tMD5 == item.MD5)
                        {
                            t = retryCount + 1;
                            success = true;
                        }
                    }
                    if (success == false) return new SAUpdaterEventArgs("", SAUpdaterResults.GeneralError);
                }
            }
            return new SAUpdaterEventArgs();
        }

        public bool DetermineInstallStatus(SAUpdaterOption updateOption, string ruleValue, string currentVersion)
        {
            if (updateOption == SAUpdaterOption.UpdateIfOlderThan) return ruleValue.IsNewerVersion(currentVersion);
            return updateOption == SAUpdaterOption.NeverUpdate ? false : true;
        }

        #endregion Extract

        public void Prepare(List<SAUpdaterFileItem> repositoryFileList)
        {
            //Copy the repository list to the client list
            List.Clear();
            foreach (var item in repositoryFileList) List.Add(item);

            //Build the download list
            DownloadList.Clear();
            foreach (var item in List)
            {
                //If it is a reference file, break;
                if (item.ReferenceFile) break;
                var tIsPresent = true;
                //Check if the item is available and add if not
                var tFilename = item.DownloadFilename(SAUpdaterGlobal.Client.DownloadFolder);
                if (!File.Exists(tFilename)) tIsPresent = false;
                if (tIsPresent && tFilename.GenerateFileMD5() != item.CompressedMD5) tIsPresent = false;

                if (!tIsPresent) DownloadList.Add(item);
            }
        }

        public SAUpdaterEventArgs CheckAfterDownload(string downloadFolder)
        {
            var tSuccess = true;

            foreach (var item in DownloadList)
            {
                var tDownloadFile = item.DownloadFilename(downloadFolder);
                var tMD5 = "AA";
                if (File.Exists(tDownloadFile)) tMD5 = tDownloadFile.GenerateFileMD5();

                if (tMD5.Trim() != item.CompressedMD5.Trim())
                {
                    tSuccess = false;
                    break; // TODO: might not be correct. Was : Exit For
                }
            }

            return !tSuccess ? new SAUpdaterEventArgs("", SAUpdaterResults.GeneralError) : new SAUpdaterEventArgs("", SAUpdaterResults.Success);
        }

        #endregion Methods

        #region Abstract Methods

        public abstract SAUpdaterEventArgs InstallFiles(int retryCount);

        public abstract SAUpdaterEventArgs CheckAfterInstall();

        #endregion Abstract Methods
    }
}