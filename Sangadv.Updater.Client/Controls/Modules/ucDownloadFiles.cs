using SangAdv.Updater.Common;
using System;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SangAdv.Updater.Client
{
    [ToolboxItem(false)]
    public partial class ucDownloadFiles : ucBaseControl
    {
        #region Variables

        private ASAUpdaterClientBase mClient = SAUpdaterGlobal.Client;
        private ASAUpdaterRepositoryBase mRepository = SAUpdaterGlobal.Repository;

        #endregion Variables

        #region Constructor

        public ucDownloadFiles()
        {
            InitializeComponent();

            DisplayMessage(string.Empty);
            DisplayErrorMessage(string.Empty);

            lblDownloadFile.Text = string.Empty;
            btnRetry.Visible = false;
            btnRetry.Enabled = false;
        }

        #endregion Constructor

        #region Methods

        public override async void ExecuteStart()
        {
            SuspendLayout();
            PrepareUpdateFiles();
            PrepareDownloadFiles();
            await DownloadDownloadFiles();
            ResumeLayout();
        }

        private void PrepareUpdateFiles()
        {
            DisplayMessage("Loading update files list ...");
            mRepository.GetUpdateFileList(SAUpdaterClient.Checker.NewApplicationVersion);
            if (mRepository.HasError)
            {
                RaiseErrorOccuredEvent("Update files...", "Could not retrieve update file list from repository", SAUpdaterStatusIcon.Stop);
                return;
            }

            mClient.UpdateFiles.Prepare(mRepository.UpdateFiles.List);
        }

        private SAUpdaterEventArgs PrepareDownloadFiles()
        {
            if (mClient.UpdateFiles.Count == 0) return new SAUpdaterEventArgs();

            var tSuccess = true;

            //Prepare for download by deleting existing files
            foreach (var item in mClient.UpdateFiles.DownloadList)
            {
                var tDestination = item.DownloadFilename(mClient.DownloadFolder);

                if (File.Exists(tDestination))
                {
                    var tCounter = 0;
                    var proc = SAUpdaterFile.WhoIsLocking(tDestination);

                    if (proc.Count > 0)
                    {
                        //TODO Extreme action to be resolved
                        var dResult = SAUpdaterFolder.Delete(mClient.DownloadFolder);
                        //Manually delete the directory if not successful
                        if (!dResult)
                        {
                            var tString = $"Error downloading files. Please delete the following directory manually:\n{mClient.DownloadFolder}\n\nAfter deleting the directory, please retry the installation";
                            RaiseErrorOccuredEvent("Delete Error", tString, SAUpdaterStatusIcon.Warning);
                            return new SAUpdaterEventArgs("Delete Error", SAUpdaterResults.FileFolderDeleteError);
                        }
                    }

                    do
                    {
                        tSuccess = SAUpdaterFile.Delete(tDestination);
                        if (!tSuccess) tCounter += 1;
                        else tCounter = 5;
                    } while (tCounter < 5);
                }
            }

            //If this was not sucessful then stop the program
            if (!tSuccess) RaiseErrorOccuredEvent("File preparation error", "Files could not be deleted", SAUpdaterStatusIcon.Stop);
            return tSuccess ? new SAUpdaterEventArgs() : new SAUpdaterEventArgs("File preparation error", SAUpdaterResults.GeneralError);
        }

        private async Task DownloadDownloadFiles()
        {
            var tString = string.Empty;

            var tDLResult = mClient.UpdateFiles.Count > 0 ? await DoRequiredDownloads(3) : new SAUpdaterEventArgs();

            if (tDLResult.Result == SAUpdaterResults.Success)
            {
                DisplayMessage("Download completed, please click next ...");
                btnAction.Enabled = true;
            }
            else
            {
                DisplayMessage("Download count not be done");
                DisplayErrorMessage($"Error: {tDLResult.Message}");
                btnRetry.Enabled = true;
            }
        }

        private async Task<SAUpdaterEventArgs> DoRequiredDownloads(int maxRetry)
        {
            var tDownloaded = 1;

            DisplayMessage("Downloading files ...");

            var tTotalDownloads = mClient.UpdateFiles.DownloadCount;
            ProgressBarVisible(true);

            mRepository.FileDownloadProgressChanged += DownloadProgressBarValue;

            foreach (var dlfile in mClient.UpdateFiles.DownloadList)
            {
                var tRetryCount = 0;
                var tMD5 = "AA";

                DisplayUpdate(tDownloaded, tTotalDownloads, $"Downloading: {dlfile.Filename}");

                var tDownloadFile = dlfile.DownloadFilename(mClient.DownloadFolder);

                do
                {
                    await mRepository.DownloadFileAsync(mRepository.RepositoryVersionFilesFolder(dlfile.UpdateVersion), $"{dlfile.UniqueFilename}.ZIP", tDownloadFile);
                    if (File.Exists(tDownloadFile)) tMD5 = tDownloadFile.GenerateFileMD5();
                    if (dlfile.CompressedMD5 == tMD5) tRetryCount = maxRetry;
                    else tRetryCount += 1;
                } while (tRetryCount < maxRetry);

                tDownloaded += 1;
            }

            mRepository.FileDownloadProgressChanged -= DownloadProgressBarValue;

            ProgressBarVisible(false);
            DisplayMessage("Doing file integrity check ...");

            if (mClient.UpdateFiles.CheckAfterDownload(mClient.DownloadFolder).Result == SAUpdaterResults.Success)
            {
                DisplayUpdate(100, 100, "");
                DisplayMessage("All files downloaded ...");
                btnAction.Enabled = true;
                return new SAUpdaterEventArgs("", SAUpdaterResults.Success);
            }

            return new SAUpdaterEventArgs("There was a problem downloading files ...", SAUpdaterResults.GeneralError);
        }

        private void ProgressBarVisible(bool visible)
        {
            pbTotalProgress.Visible = visible;
            pbDownloadProgress.Visible = visible;
            lblDownloadProgress.Visible = visible;
        }

        private void TotalProgressBarValue(int value)
        {
            pbTotalProgress.Value = value;
        }

        private void DownloadProgressBarValue(int value)
        {
            pbDownloadProgress.Value = value;
            lblDownloadProgress.Text = $"... {value}%";
        }

        private void DisplayUpdate(int downloaded, int totalDownloads, string downloadMessage)
        {
            lblDownloadFile.Text = downloadMessage;
            TotalProgressBarValue(Convert.ToInt32((float)downloaded * (float)100 / (float)totalDownloads));
            Application.DoEvents();
        }

        #endregion Methods
    }
}