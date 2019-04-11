using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace SangAdv.Updater.Common
{
    internal class SAUpdaterFileUpload
    {
        #region Constructor

        public SAUpdaterFileUpload(Uri hostUri, string userName, string password)
        {
            mHost = hostUri.FixURLDirectoryLink();
            mUser = userName;
            mPass = password;

            if (string.IsNullOrEmpty(mUser) && string.IsNullOrEmpty(mPass)) mRequiresAuthentication = false;
        }

        #endregion Constructor

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

        public SAUpdaterEventArgs Errors { get; } = new SAUpdaterEventArgs();
        public bool HasErrors => Errors.HasError;
        public bool HasCompleted => mCompleted;
        public bool WasCancelled => mCancelled;

        #endregion Properties

        #region Methods

        public async Task UploadFileAsync(string originFilePath, string remoteDirectory, string remoteFile)
        {
            mCompleted = false;
            mCancelled = false;

            var tUri = mHost.AddUriSegment(remoteDirectory).AddUriParameter(remoteFile);

            using (var client = new WebClient())
            {
                if (mRequiresAuthentication) client.Credentials = new NetworkCredential(mUser, mPass);
                client.UploadFileCompleted += Completed;
                client.UploadProgressChanged += UploadProgress;

                try
                {
                    await client.UploadFileTaskAsync(tUri, originFilePath);
                }
                catch (WebException ex)
                {
                    var s = ex.Message;
                }

                client.UploadFileCompleted -= Completed;
                client.UploadProgressChanged -= UploadProgress;
            }
        }

        public bool UploadFile(string originFilePath, string remoteDirectory, string remoteFile)
        {
            mCompleted = false;
            mCancelled = false;

            var tUri = mHost.AddUriSegment(remoteDirectory).AddUriParameter(remoteFile);

            try
            {
                var ftp = (FtpWebRequest)WebRequest.Create(tUri);
                ftp.Credentials = new NetworkCredential(mUser, mPass);

                ftp.KeepAlive = true;
                ftp.UseBinary = true;
                ftp.Method = WebRequestMethods.Ftp.UploadFile;

                var fs = File.OpenRead(originFilePath);
                var buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
                fs.Close();

                var ftpstream = ftp.GetRequestStream();
                ftpstream.Write(buffer, 0, buffer.Length);
                ftpstream.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void UploadProgress(object sender, UploadProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage > mProgress)
            {
                mProgress = e.ProgressPercentage;
                ProgressChanged(mProgress);
            }
        }

        private void Completed(object sender, UploadFileCompletedEventArgs e)
        {
            mCancelled = e.Cancelled;
            mCompleted = true;
        }

        #endregion Methods
    }
}