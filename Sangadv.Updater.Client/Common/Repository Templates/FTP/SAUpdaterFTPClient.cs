using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace SangAdv.Updater.Common
{
    public class SAUpdaterFTPClient : SAUpdaterErrorBase
    {
        #region Events

        public event UpdaterIntegerDelegate UploadProgressChanged = i => { };

        #endregion Events

        #region Variables

        private readonly Uri host;
        private readonly string user;
        private readonly string pass;
        private FtpWebRequest ftpRequest;
        private FtpWebResponse ftpResponse;
        private Stream ftpStream;

        private volatile int mFilestreamSize;
        private volatile int mPercentage = 0;

        #endregion Variables

        #region Constructor

        public SAUpdaterFTPClient(Uri hostUri, string userName, string password)
        {
            host = hostUri.FixURLDirectoryLink();
            user = userName;
            pass = password;

            //CheckFTPUri();
        }

        #endregion Constructor

        #region Methods

        public void DeleteFile(string remoteDirectory, string deleteFile)
        {
            Error.ClearErrorMessage();
            try
            {
                ftpRequest = GetRequest(remoteDirectory, deleteFile);
                ftpRequest.Method = WebRequestMethods.Ftp.DeleteFile;

                using (ftpResponse = (FtpWebResponse)ftpRequest.GetResponse())
                {
                }
            }
            catch (WebException ex)
            {
                Error.SetErrorMessage(ex.Message);
            }
            ftpRequest = null;
        }

        public void RenameFile(string remoteDirectory, string currentFileName, string newFileName)
        {
            Error.ClearErrorMessage();
            try
            {
                ftpRequest = GetRequest(remoteDirectory, currentFileName);
                ftpRequest.Method = WebRequestMethods.Ftp.Rename;
                ftpRequest.RenameTo = newFileName;

                using (ftpResponse = (FtpWebResponse)ftpRequest.GetResponse())
                {
                }
            }
            catch (WebException ex)
            {
                Error.SetErrorMessage(ex.Message);
            }
            ftpRequest = null;
        }

        public bool DirectoryExists(string checkDirectory)
        {
            Error.ClearErrorMessage();
            var tResult = false;
            try
            {
                ftpRequest = GetRequest(checkDirectory);
                ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;

                using (ftpResponse = (FtpWebResponse)ftpRequest.GetResponse())
                {
                }

                tResult = true;
            }
            catch (WebException ex)
            {
                var response = (FtpWebResponse)ex.Response;
                if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable) return false;
                Error.SetErrorMessage(ex.Message);
            }
            ftpRequest = null;
            return tResult;
        }

        public void CreateDirectory(string newDirectory)
        {
            Error.ClearErrorMessage();
            try
            {
                var tString = string.Empty;
                var tUri = host.AddUriSegment(newDirectory);

                // Split into path components
                var steps = tUri.ToString().Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                // Build list of full paths to each path component
                var paths = new List<string>();
                for (var i = 2; i <= steps.Length - 1; i++)
                {
                    tString = $"{tString}/{steps[i]}";
                    paths.Add(tString);
                }

                // Find first path component that needs creating
                int createIndex;
                for (createIndex = paths.Count; createIndex > 0; createIndex--)
                    if (DirectoryExists(paths[createIndex - 1]))
                        break;

                // Created needed paths
                for (; createIndex < paths.Count; createIndex++)
                {
                    ftpRequest = GetRequest(paths[createIndex]);
                    ftpRequest.Method = WebRequestMethods.Ftp.MakeDirectory;
                    using (ftpResponse = (FtpWebResponse)ftpRequest.GetResponse())
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                Error.SetErrorMessage(ex.Message);
            }
            ftpRequest = null;
        }

        public bool RemoveDirectory(string deleteDirectory)
        {
            Error.ClearErrorMessage();

            var fileList = DirectoryListSimple(deleteDirectory);
            foreach (var file in fileList)
                if (!string.IsNullOrEmpty(file))
                    DeleteFile(deleteDirectory, file);

            var tResult = false;
            try
            {
                ftpRequest = GetRequest(deleteDirectory);
                ftpRequest.Method = WebRequestMethods.Ftp.RemoveDirectory;

                using (ftpResponse = (FtpWebResponse)ftpRequest.GetResponse())
                {
                }

                tResult = true;
            }
            catch (WebException ex)
            {
                var response = (FtpWebResponse)ex.Response;
                if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable) return false;
                Error.SetErrorMessage(ex.Message);
            }
            ftpRequest = null;
            return tResult;
        }

        public string GetFileCreatedDateTime(string remoteDirectory, string fileName)
        {
            var tFileInfo = string.Empty;
            Error.ClearErrorMessage();
            try
            {
                ftpRequest = GetRequest(remoteDirectory, fileName);
                ftpRequest.Method = WebRequestMethods.Ftp.GetDateTimestamp;

                using (ftpResponse = (FtpWebResponse)ftpRequest.GetResponse())
                using (ftpStream = ftpResponse.GetResponseStream())
                using (var ftpReader = new StreamReader(ftpStream))
                    tFileInfo = ftpReader.ReadToEnd();
            }
            catch (WebException ex)
            {
                Error.SetErrorMessage(ex.Message);
            }
            ftpRequest = null;
            return "";
        }

        public bool FileExists(string remoteDirectory, string fileName)
        {
            Error.ClearErrorMessage();
            var tResult = false;
            try
            {
                ftpRequest = GetRequest(remoteDirectory, fileName);
                ftpRequest.Method = WebRequestMethods.Ftp.GetFileSize;
                using (ftpResponse = (FtpWebResponse)ftpRequest.GetResponse())
                {
                }

                tResult = true;
            }
            catch (WebException ex)
            {
                var response = (FtpWebResponse)ex.Response;
                if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable) return false;
                Error.SetErrorMessage(ex.Message);
            }
            ftpRequest = null;
            return tResult;
        }

        public long GetFileSize(string remoteDirectory, string fileName)
        {
            Error.ClearErrorMessage();
            long tFileSize = 0;
            try
            {
                ftpRequest = GetRequest(remoteDirectory, fileName);
                ftpRequest.Method = WebRequestMethods.Ftp.GetFileSize;

                using (ftpResponse = (FtpWebResponse)ftpRequest.GetResponse())
                    tFileSize = ftpResponse.ContentLength;
            }
            catch (WebException ex)
            {
                Error.SetErrorMessage(ex.Message);
            }

            ftpRequest = null;
            return tFileSize;
        }

        public bool UploadFile(string originFilePath, string remoteDirectory, string remoteFile, int kbPacketSize = 64)
        {
            mPercentage = 0;
            Error.ClearErrorMessage();
            try
            {
                var ftpRequest = GetRequest(remoteDirectory, remoteFile, false, 60000 * 2);
                ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;

                using (var fileStream = File.OpenRead(originFilePath))
                using (var ftpStream = ftpRequest.GetRequestStream())
                {
                    mFilestreamSize = (int)fileStream.Length;

                    ftpRequest.ContentLength = mFilestreamSize;

                    var buffLength = kbPacketSize * 1024;
                    var buffer = new byte[buffLength];
                    int read;
                    while ((read = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        ftpStream.Write(buffer, 0, read);
                        UpdateUploadProgress((int)fileStream.Position);
                    }
                }
                UpdateUploadProgress(mFilestreamSize);
                return true;
            }
            catch (WebException ex)
            {
                Error.SetErrorMessage(ex.Message);
                return false;
            }
        }

        public string[] DirectoryListSimple(string directory)
        {
            string directoryRaw = null;
            var directoryList = new[] { "" };
            try
            {
                ftpRequest = GetRequest(directory);
                ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;

                using (ftpResponse = (FtpWebResponse)ftpRequest.GetResponse())
                using (ftpStream = ftpResponse.GetResponseStream())
                {
                    using (var ftpReader = new StreamReader(ftpStream))
                    {
                        while (ftpReader.Peek() != -1) directoryRaw += ftpReader.ReadLine() + "|";
                        ftpReader.Close();
                    }

                    ftpStream.Close();
                }
                ftpResponse.Close();

                directoryList = directoryRaw.Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            }
            catch
            {
                directoryList = new[] { "" };
            }
            ftpRequest = null;
            return directoryList;
        }

        public string[] DirectoryListDetailed(string directory)
        {
            try
            {
                /* Create an FTP Request */
                var tUri = host.AddUriSegment(directory);
                ftpRequest = WebRequest.Create(tUri) as FtpWebRequest;
                /* Log in to the FTP Server with the User Name and Password Provided */
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                /* When in doubt, use these options */
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                ftpRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                /* Establish Return Communication with the FTP Server */
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                /* Establish Return Communication with the FTP Server */
                ftpStream = ftpResponse.GetResponseStream();
                /* Get the FTP Server's Response Stream */
                var ftpReader = new StreamReader(ftpStream);
                /* Store the Raw Response */
                string directoryRaw = null;
                /* Read Each Line of the Response and Append a Pipe to Each Line for Easy Parsing */
                try
                {
                    while (ftpReader.Peek() != -1) directoryRaw += ftpReader.ReadLine() + "|";
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                /* Resource Cleanup */
                ftpReader.Close();
                ftpStream.Close();
                ftpResponse.Close();
                ftpRequest = null;
                /* Return the Directory Listing as a string Array by Parsing 'directoryRaw' with the Delimiter you Append (I use | in This Example) */
                try
                {
                    var directoryList = directoryRaw.Split("|".ToCharArray());
                    return directoryList;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            /* Return an Empty string Array if an Exception Occurs */
            return new[] { "" };
        }

        private FtpWebRequest GetRequest(string remoteDirectory, string fileName = "", bool keepAlive = true, int timeout = 0)
        {
            var tUri = host.AddUriSegment(remoteDirectory);
            if (!string.IsNullOrEmpty(fileName.Trim())) tUri = tUri.AddUriParameter(fileName);
            ftpRequest = WebRequest.Create(tUri) as FtpWebRequest;
            ftpRequest.Credentials = new NetworkCredential(user, pass);
            ftpRequest.UseBinary = true;
            ftpRequest.UsePassive = true;
            ftpRequest.KeepAlive = keepAlive;
            if (timeout != 0) ftpRequest.Timeout = timeout;
            return ftpRequest;
        }

        private void UpdateUploadProgress(int progress)
        {
            var tPercentage = (((float)progress / (float)mFilestreamSize) * 100).Value<int>();
            if (tPercentage != mPercentage)
            {
                UploadProgressChanged(tPercentage);
                mPercentage = tPercentage;
            }
        }

        #endregion Methods
    }
}