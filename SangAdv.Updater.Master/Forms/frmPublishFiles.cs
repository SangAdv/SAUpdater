using SangAdv.Updater.Common;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SangAdv.Updater.Master
{
    public partial class frmPublishFiles : Form
    {
        #region Variables

        private AppDataFile mAppDataFile = SAUpdaterMasterCommon.AppData;
        private SAUpdaterMaster mMaster = SAUpdaterGlobal.Master;
        private ASAUpdaterRepositoryBase mRepositoryBase;

        private int mSelectedVersionId = 0;
        private volatile bool mIsCanceled = false;

        #endregion Variables

        #region Constructor

        public frmPublishFiles(int selectedVersionId)
        {
            InitializeComponent();

            SuspendLayout();
            pbProgress.ProgressStyle = eucSAUpdaterProgressBar.SAProgressStyle.Continuous;
            pbProgress.Value = 0;
            ResumeLayout();

            mSelectedVersionId = selectedVersionId;

            mRepositoryBase = SAUpdaterMasterCommon.Repository();

            DisplayHeading("");
            DisplayProgress("Ready to publish files ...");
            DisplayMessage("");
            SetButtonsEnabled(true, false);

            SetContinuousBar(0);
        }

        #endregion Constructor

        #region Process UI

        private void btnAppCancel_Click(object sender, EventArgs e)
        {
            StopMarqueeBar();

            mIsCanceled = true;
            btnAppCancel.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPublish_Click(object sender, EventArgs e)
        {
            StartMarqueeBar();

            btnPublish.Enabled = false;
            btnAppCancel.Enabled = true;
            btnClose.Enabled = false;

            Publish();

            btnPublish.Enabled = true;
            btnAppCancel.Enabled = false;
            btnClose.Enabled = true;
        }

        #endregion Process UI

        #region Methods

        private void Publish()
        {
            DisplayHeading("Preparing Folders ...");

            mRepositoryBase.MessageChanged += DisplayProgress;

            if (!mRepositoryBase.PrepareFolders(mAppDataFile.Versions.Get(mSelectedVersionId).VersionNumber))
            {
                DisplayProgress("Folder preparation failed!");
                return;
            }

            DisplayProgress("Folder preparation completed successfully ...");
            DisplayProgress(string.Empty);

            StartContinuousBar(1, 100);

            SetContinuousBar(0);
            DisplayHeading("Preparing Files ...");
            DisplayProgress("Compressing files and moving to upload folder ...");
            if (!PrepareArchives()) return;
            DisplayProgress(string.Empty);

            SetContinuousBar(0);
            DisplayHeading("Staging Files ...");
            DisplayProgress("Staging files in selected version folder ...");
            if (!ExecuteStagingUpload()) return;
            DisplayProgress(string.Empty);

            SetContinuousBar(0);
            DisplayHeading("Replacing Files ...");
            DisplayProgress("Replacing files with staged versions ...");
            if (!ReplaceCurrentFiles()) return;
            DisplayProgress(string.Empty);

            SetContinuousBar(0);
            DisplayHeading("Definition Files ...");
            DisplayProgress("Uploading definition files ...");
            if (!UploadDefinitionFiles()) return;

            var tVersion = mAppDataFile.Versions.Get(mSelectedVersionId);
            tVersion.VersionStatus = (int)SAUpdaterAppVersionStatus.Uploaded;
            tVersion.DateTimePublished = DateTime.Now.ToDateTimeString();
            mAppDataFile.Versions.Update(tVersion);
        }

        private bool PrepareArchives()
        {
            var tVersionFiles = mAppDataFile.VersionFiles.GetAll(mSelectedVersionId);

            var counter = 1;
            var count = tVersionFiles.Count;
            var tError = string.Empty;

            foreach (var fileId in tVersionFiles)
            {
                var tVersionFile = mAppDataFile.VersionFiles.Get(fileId.Id);
                var tAppFileItem = mAppDataFile.Files.Get(tVersionFile.FileId);
                DisplayProgress($"Compressing: {tAppFileItem.Filename}", counter != 1);

                if (!tAppFileItem.ReferenceFile)
                {
                    var tOriginFilename = Path.Combine(mAppDataFile.Application.CurrentApplication.SourceFolder, tAppFileItem.Filename);

                    //Delete the archive and create a new one
                    if (!mMaster.CompressFile(tOriginFilename, $"{tAppFileItem.UniqueFilename}.ZIP"))
                    {
                        DisplayProgress($"Error: {mMaster.ErrorMessage}");
                        break;
                    }

                    //Check if the progress has been cancelled
                    if (mIsCanceled)
                    {
                        tError = "Publish cancelled by the user";
                        break;
                    }

                    var tCompressedMD5 = mMaster.CompressedMD5($"{tAppFileItem.UniqueFilename}.ZIP");
                    if (string.IsNullOrEmpty(tCompressedMD5))
                    {
                        DisplayProgress($"Error: {mMaster.ErrorMessage}");
                        break;
                    }

                    tVersionFile.MD5 = tOriginFilename.GenerateFileMD5();
                    tVersionFile.CompressedMD5 = tCompressedMD5;

                    mAppDataFile.VersionFiles.Update(tVersionFile);
                }
                var tPercentage = ((counter * 100).Value<float>() / count.Value<float>()).Value<int>();
                SetContinuousBar(tPercentage);

                counter += 1;
            }

            if (!string.IsNullOrEmpty(tError)) DisplayMessage(tError);
            else DisplayProgress("File preparation completed successfully...", true);
            return string.IsNullOrEmpty(tError);
        }

        private bool ExecuteStagingUpload()
        {
            var tVersionFiles = mAppDataFile.VersionFiles.GetAll(mSelectedVersionId);

            var counter = 1;
            var count = tVersionFiles.Count;
            var tError = string.Empty;

            var tSelectedVersion = mAppDataFile.Versions.Get(mSelectedVersionId).VersionNumber;

            mRepositoryBase.FileUploadProgressChanged += DisplayUploadProgress;

            foreach (var fileId in tVersionFiles)
            {
                if (mIsCanceled)
                {
                    DisplayProgress("Upload cancelled by user");
                    break;
                }

                var tVersionFile = mAppDataFile.VersionFiles.Get(fileId.Id);
                var tAppFileItem = mAppDataFile.Files.Get(tVersionFile.FileId);
                DisplayProgress($"Uploading: {tAppFileItem.Filename}", counter != 1);

                if (!tAppFileItem.ReferenceFile)
                {
                    var tFilename = $"{tAppFileItem.UniqueFilename}.ZIP";
                    var tOriginFilename = Path.Combine(mMaster.UploadFolder, tFilename);

                    if (!mRepositoryBase.UploadFile(tOriginFilename, mRepositoryBase.RepositoryVersionFilesFolder(tSelectedVersion), $"{tFilename}.TMP"))
                    {
                        DisplayProgress($"Error: {tAppFileItem.Filename} could not be uploaded");
                        break;
                    }

                    tVersionFile.Uploaded = true;

                    mAppDataFile.VersionFiles.Update(tVersionFile);
                }
                var tPercentage = ((counter * 100).Value<float>() / count.Value<float>()).Value<int>();
                SetContinuousBar(tPercentage);

                counter += 1;
            }

            mIsCanceled = false;

            mRepositoryBase.FileUploadProgressChanged -= DisplayUploadProgress;

            if (!string.IsNullOrEmpty(tError)) DisplayMessage(tError);
            else DisplayProgress("File staging completed successfully...", true);
            return string.IsNullOrEmpty(tError);
        }

        private void DisplayUploadProgress(int progress)
        {
            DisplayMessage(progress != 100 ? $"Uploaded {progress}% ..." : "Uploaded 100%");
        }

        private bool ReplaceCurrentFiles()
        {
            mRepositoryBase.UpdateFiles.Reset();
            var tVersionFiles = mAppDataFile.VersionFiles.GetAll(mSelectedVersionId);

            var counter = 1;
            var count = tVersionFiles.Count;
            var tError = string.Empty;

            var tSelectedVersion = mAppDataFile.Versions.Get(mSelectedVersionId);

            foreach (var fileId in tVersionFiles)
            {
                var tVersionFile = mAppDataFile.VersionFiles.Get(fileId.Id);
                var tAppFileItem = mAppDataFile.Files.Get(tVersionFile.FileId);
                DisplayProgress($"Processing: {tAppFileItem.Filename}", counter != 1);

                if (!tAppFileItem.ReferenceFile)
                {
                    var tFilename = $"{tAppFileItem.UniqueFilename}.ZIP";

                    if (!mRepositoryBase.ReplaceFile(mRepositoryBase.RepositoryVersionFilesFolder(tSelectedVersion.VersionNumber), $"{tFilename}.TMP", tFilename))
                    {
                        DisplayProgress($"Error: {tAppFileItem.Filename} could not be replaced");
                        break;
                    }

                    tVersionFile.Uploaded = true;
                    mAppDataFile.VersionFiles.Update(tVersionFile);

                    mAppDataFile.ReleaseTypeFiles.Update(new AppDataReleaseTypeFileItem { FileId = fileId.FileId, VersionId = tSelectedVersion.Id, ReleaseType = tSelectedVersion.ReleaseType });
                }
                var tPercentage = ((counter * 100).Value<float>() / count.Value<float>()).Value<int>();
                SetContinuousBar(tPercentage);

                counter += 1;
            }

            if (!string.IsNullOrEmpty(tError)) DisplayMessage(tError);
            else DisplayProgress("File replacement completed successfully...", true);
            return string.IsNullOrEmpty(tError);
        }

        private void CreateFilesDefinition()
        {
            mRepositoryBase.UpdateFiles.Reset();

            foreach (var file in mAppDataFile.Files.List.Where(x => x.IncludeStatus).ToList())
            {
                var tVersion = mAppDataFile.Versions.Get(mAppDataFile.ReleaseTypeFiles.GetVersionId(file.Id, mAppDataFile.Versions.Get(mSelectedVersionId).EnumReleaseType));
                var tVersionFile = mAppDataFile.VersionFiles.Get(tVersion.Id, file.Id);

                var tUpdateItem = new SAUpdaterFileItem
                {
                    Filename = file.Filename,
                    UniqueFilename = file.UniqueFilename,
                    Folder = mAppDataFile.Folders.GetName(file.FolderId),
                    MD5 = tVersionFile.MD5,
                    CompressedMD5 = tVersionFile.CompressedMD5,
                    UpdateRuleOption = tVersionFile.UpdateOptionId,
                    UpdateRuleValue = tVersionFile.UpdateOptionValue,
                    ShortCut = file.CreateShortCut,
                    ReferenceFile = file.ReferenceFile,
                    ForceDownload = false,
                    UpdateVersion = tVersion.VersionNumber
                };

                mRepositoryBase.UpdateFiles.Add(tUpdateItem);
            }
        }

        private bool UploadDefinitionFiles()
        {
            mRepositoryBase.Error.ClearErrorMessage();
            var tSelectedVersion = mAppDataFile.Versions.Get(mSelectedVersionId);

            //Create the files file
            CreateFilesDefinition();
            mRepositoryBase.SetUpdateFileList(tSelectedVersion.VersionNumber);

            //Create the notes file
            //Notes are stored deflated, so inflate otherwise they will be doube deflated
            mRepositoryBase.SetNotes(tSelectedVersion.VersionNumber, tSelectedVersion.VersionNotes.InflateString());

            if (!string.IsNullOrEmpty(mRepositoryBase.ErrorMessage)) DisplayMessage(mRepositoryBase.ErrorMessage);
            else DisplayProgress("Definition file upload completed successfully...", true);
            return string.IsNullOrEmpty(mRepositoryBase.ErrorMessage);
        }

        #endregion Methods

        #region Private Methods

        private void SetButtonsEnabled(bool publishEnabled, bool cancelEnabled)
        {
            btnPublish.Enabled = publishEnabled;
            btnAppCancel.Enabled = cancelEnabled;
        }

        private void DisplayMessage(string message, Color? messageColor = null)
        {
            lblMessage.ForeColor = messageColor ?? Color.FromArgb(65, 65, 65);
            lblMessage.Text = message;
            Application.DoEvents();
        }

        private void DisplayHeading(string heading)
        {
            lblHeading.Text = heading;
            Application.DoEvents();
        }

        private void DisplayProgress(string message, bool removeLastEntry = false)
        {
            if (removeLastEntry) lstBox.Items.RemoveAt(lstBox.Items.Count - 1);
            lstBox.Items.Add(message);
            Application.DoEvents();
        }

        private void StartMarqueeBar()
        {
            pbProgress.ProgressStyle = eucSAUpdaterProgressBar.SAProgressStyle.Marquee;
            pbProgress.TimerInterVal = 500;
            pbProgress.MarqueeStepSize = 5;
            pbProgress.StartMarqueeAnimation();
            Application.DoEvents();
        }

        private void StartContinuousBar(int minimum, int maximum)
        {
            pbProgress.ProgressStyle = eucSAUpdaterProgressBar.SAProgressStyle.Continuous;
            pbProgress.Minimum = minimum;
            pbProgress.Maximum = maximum;
            pbProgress.Value = 0;
            Application.DoEvents();
        }

        private void StopMarqueeBar()
        {
            pbProgress.StopMarqueeAnimation();
            Application.DoEvents();
        }

        private void SetContinuousBar(int value)
        {
            pbProgress.Value = value;
            Application.DoEvents();
        }

        #endregion Private Methods
    }
}