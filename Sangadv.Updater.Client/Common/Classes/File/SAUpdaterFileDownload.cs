using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace SangAdv.Updater.Common
{
    public class SAUpdaterFileDownload
    {
        #region Events

        public event UpdaterIntegerDelegate ProgressChanged = i => { };

        #endregion Events

        #region Variables

        private volatile bool mCompleted;
        private volatile bool mCancelled;
        private volatile int mProgress;
        private readonly Uri mHost;
        private readonly string mUser;
        private readonly string mPass;
        private readonly bool mRequiresAuthentication = true;

        #endregion Variables

        #region Properties

        public SAUpdaterEventArgs Error { get; } = new SAUpdaterEventArgs();
        public bool HasErrors => Error.HasError;
        public bool HasCompleted => mCompleted;
        public bool WasCancelled => mCancelled;

        #endregion Properties

        #region Constructor

        public SAUpdaterFileDownload(Uri hostUri, string userName = "", string password = "")
        {
            mHost = hostUri.FixURLDirectoryLink();
            mUser = userName;
            mPass = password;

            if (string.IsNullOrEmpty(mUser) && string.IsNullOrEmpty(mPass)) mRequiresAuthentication = false;
        }

        public SAUpdaterFileDownload(string hostUri, string userName = "", string password = "") : this(new Uri(hostUri), userName, password)
        { }

        #endregion Constructor

        #region Methods

        public async Task<bool> DownloadFileAsync(string remoteDirectory, string remoteFile, string destinationFilePath)
        {
            Error.ClearErrorMessage();

            mProgress = 0;

            using (var client = new WebClient())
            {
                if (mRequiresAuthentication) client.Credentials = new NetworkCredential(mUser, mPass);
                client.DownloadFileCompleted += Completed;
                client.DownloadProgressChanged += DownloadProgress;

                try
                {
                    await client.DownloadFileTaskAsync(GetFullUri(remoteDirectory, remoteFile), destinationFilePath);
                }
                catch (WebException ex)
                {
                    Error.SetErrorMessage(ex.Message);
                }

                client.DownloadFileCompleted -= Completed;
                client.DownloadProgressChanged -= DownloadProgress;
            }

            ProgressChanged(100);
            return !HasErrors;
        }

        public async Task<string> DownloadFileToStringAsync(string remoteDirectory, string remoteFile)
        {
            Error.ClearErrorMessage();

            mCancelled = false;
            mCompleted = false;

            mProgress = 0;

            var tDataString = string.Empty;
            using (var client = new WebClient())
            {
                if (mRequiresAuthentication) client.Credentials = new NetworkCredential(mUser, mPass);

                try
                {
                    var data = await client.OpenReadTaskAsync(GetFullUri(remoteDirectory, remoteFile));
                    tDataString = new StreamReader(data).ReadToEnd();
                    mCompleted = true;
                    ProgressChanged(100);
                    return tDataString;
                }
                catch (Exception ex)
                {
                    Error.SetErrorMessage(ex.Message);
                    mCompleted = false;
                    ProgressChanged(100);
                    return null;
                }
            }
        }

        public string DownloadFileToString(string remoteDirectory, string remoteFile)
        {
            Error.ClearErrorMessage();

            mCancelled = false;
            mCompleted = false;

            mProgress = 0;

            var tDataString = string.Empty;
            using (var client = new WebClient())
            {
                if (mRequiresAuthentication) client.Credentials = new NetworkCredential(mUser, mPass);

                try
                {
                    var data = client.OpenRead(GetFullUri(remoteDirectory, remoteFile));
                    tDataString = new StreamReader(data).ReadToEnd();
                    mCompleted = true;
                    ProgressChanged(100);
                    return tDataString;
                }
                catch (Exception ex)
                {
                    Error.SetErrorMessage(ex.Message);
                    mCompleted = false;
                    ProgressChanged(100);
                    return null;
                }
            }
        }

        #endregion Methods

        #region Private Methods

        private void DownloadProgress(object sender, DownloadProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage <= mProgress) return;

            mProgress = e.ProgressPercentage;
            ProgressChanged(mProgress);
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            mCancelled = e.Cancelled;
            mCompleted = true;
        }

        private Uri GetFullUri(string remoteDirectory, string remoteFile)
        {
            var tUri = mHost;

            if (!string.IsNullOrEmpty(remoteDirectory)) tUri = tUri.AddUriSegment(remoteDirectory);
            if (!string.IsNullOrEmpty(remoteFile)) tUri = tUri.AddUriParameter(remoteFile);

            return tUri.FixURLFileLink();
        }

        #endregion Private Methods
    }
}