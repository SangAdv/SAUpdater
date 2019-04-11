using System.Diagnostics;
using System.IO;

namespace SangAdv.Updater.Common
{
    public class SAUpdaterWinClientFileList : ASAUpdaterClientFileList
    {
        #region Abstract Methods

        public override SAUpdaterEventArgs InstallFiles(int retryCount)
        {
            var tClient = SAUpdaterGlobal.Client;

            var tResult = ExtractFiles(retryCount);
            if (tResult.Result != SAUpdaterResults.Success) return tResult;

            RaiseMessageChangedEvent("Copying extracted files to installation folder ....");

            foreach (var item in List)
            {
                var tInstall = false;
                var tSubDirectory = item.InstallFolder(tClient.ApplicationFolder);
                if (!Directory.Exists(tSubDirectory)) Directory.CreateDirectory(tSubDirectory);
                var tDestFilename = item.DestinationFilename(tClient.ApplicationFolder);

                var tExists = File.Exists(tDestFilename);
                if (tExists)
                {
                    if (!item.ForceDownload)
                    {
                        if (tDestFilename.GenerateFileMD5().Trim() != item.MD5) tInstall = true;
                    }
                    else tInstall = true;
                }
                else tInstall = true;

                if (tInstall)
                {
                    tInstall = DetermineInstallStatus((SAUpdaterOption)item.UpdateRuleOption, item.UpdateRuleValue, GetFileVersion(item.DestinationFilename(tClient.ApplicationFolder)));
                }

                if (tInstall)
                {
                    if (File.Exists(tDestFilename))
                    {
                        if (!SAUpdaterFile.Delete(tDestFilename)) return new SAUpdaterEventArgs($"Could not delete {tDestFilename}", SAUpdaterResults.FileFolderDeleteError);
                    }

                    RaiseProgressChangedEvent($"Copying file: {item.Filename}");

                    File.Copy(item.ExtractFilename(tClient.ExtractFolder), tDestFilename);
                    if (!SAUpdaterGlobal.Options.IsUpdate)
                    {
                        if (item.ShortCut)
                        {
                            //DisplayMessage("Creating shortcuts.")
                            var tName = item.Filename.Substring(0, item.Filename.IndexOf("."));
                            SAUpdaterWinShortCut.Create(tName, tDestFilename, null, null, tName, string.Empty, null);
                        }
                    }
                }
            }

            CleanupOldFiles();
            return new SAUpdaterEventArgs("", SAUpdaterResults.Success);
        }

        public override SAUpdaterEventArgs CheckAfterInstall()
        {
            var tClient = SAUpdaterGlobal.Client;

            foreach (var item in List)
            {
                var tSubDirectory = item.InstallFolder(tClient.ApplicationFolder);
                if (!Directory.Exists(tSubDirectory)) Directory.CreateDirectory(tSubDirectory);
                var tDestFilename = item.DestinationFilename(tClient.ApplicationFolder);

                var tExists = File.Exists(tDestFilename);
                if (!tExists) return new SAUpdaterEventArgs("Files are not installed", SAUpdaterResults.FilesFolderMissing);

                var tMD5 = tDestFilename.GenerateFileMD5();
                if (tMD5.Trim() != item.MD5) return new SAUpdaterEventArgs("Files are not the correct version", SAUpdaterResults.MissingVersionFile);
            }

            return new SAUpdaterEventArgs("", SAUpdaterResults.Success);
        }

        private string GetFileVersion(string filename)
        {
            if (!File.Exists(filename)) return SAUpdaterConstants.NoVersion;

            var tClient = SAUpdaterGlobal.Client;

            try
            {
                var tFileVersion = FileVersionInfo.GetVersionInfo(filename).FileVersion;
                if (string.IsNullOrEmpty(tFileVersion)) tFileVersion = tClient.UpdateDefinition.ReleaseVersion;
                return tFileVersion;
            }
            catch
            {
                return SAUpdaterConstants.NoVersion;
            }
        }

        #endregion Abstract Methods
    }
}