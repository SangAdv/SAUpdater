using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace SangAdv.Updater.Common
{
    [Browsable(false)]
    public sealed class SAUpdaterFile
    {
        public static bool Delete(string filename)
        {
            ErrorMessage = string.Empty;
            if (!File.Exists(filename)) return true;

            try
            {
                var objFile = new FileInfo(filename) { Attributes = FileAttributes.Normal };
                objFile.Delete();
                objFile = null;

                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }
        }

        public static bool Copy(string originFilename, string destinationFilename)
        {
            ErrorMessage = string.Empty;
            try
            {
                if (!Delete(destinationFilename)) throw new Exception(ErrorMessage);
                File.Copy(originFilename, destinationFilename);
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }
        }

        public static bool Move(string originFilename, string destinationFilename)
        {
            ErrorMessage = string.Empty;
            try
            {
                if (!Delete(destinationFilename)) throw new Exception(ErrorMessage);
                File.Move(originFilename, destinationFilename);
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }
        }

        public static bool Write(string filename, string item, bool deflate = false)
        {
            try
            {
                using (var writer = new StreamWriter(filename))
                {
                    writer.WriteLine(deflate ? item.DeflateString() : item);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool Write(string filename, List<string> data, bool deflate = false)
        {
            try
            {
                using (var writer = new StreamWriter(filename))
                {
                    foreach (var item in data) writer.WriteLine(deflate ? item.DeflateString() : item);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<string> Read(string filename, bool isDeflated = false)
        {
            var tList = new List<string>();
            using (var reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    var item = reader.ReadLine();
                    tList.Add(isDeflated ? item.InflateString() : item);
                }
            }

            return tList;
        }

        public static string ErrorMessage;

        [StructLayout(LayoutKind.Sequential)]
        private struct RM_UNIQUE_PROCESS
        {
            public int dwProcessId;
            private System.Runtime.InteropServices.ComTypes.FILETIME ProcessStartTime;
        }

        private const int RmRebootReasonNone = 0;
        private const int CCH_RM_MAX_APP_NAME = 255;
        private const int CCH_RM_MAX_SVC_NAME = 63;

        private enum RM_APP_TYPE
        {
            RmUnknownApp = 0,
            RmMainWindow = 1,
            RmOtherWindow = 2,
            RmService = 3,
            RmExplorer = 4,
            RmConsole = 5,
            RmCritical = 1000
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct RM_PROCESS_INFO
        {
            public RM_UNIQUE_PROCESS Process;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SAUpdaterFile.CCH_RM_MAX_APP_NAME + 1)]
            public string strAppName;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SAUpdaterFile.CCH_RM_MAX_SVC_NAME + 1)]
            public string strServiceShortName;

            public RM_APP_TYPE ApplicationType;
            public uint AppStatus;
            public uint TSSessionId;

            [MarshalAs(UnmanagedType.Bool)]
            public bool bRestartable;
        }

        [DllImport("rstrtmgr.dll", CharSet = CharSet.Unicode)]
        private static extern int RmRegisterResources(uint pSessionHandle, UInt32 nFiles, string[] rgsFilenames, UInt32 nApplications, [In()]RM_UNIQUE_PROCESS[] rgApplications, UInt32 nServices, string[] rgsServiceNames);

        [DllImport("rstrtmgr.dll", CharSet = CharSet.Auto)]
        private static extern int RmStartSession(ref uint pSessionHandle, int dwSessionFlags, string strSessionKey);

        [DllImport("rstrtmgr.dll")]
        private static extern int RmEndSession(uint pSessionHandle);

        [DllImport("rstrtmgr.dll")]
        private static extern int RmGetList(uint dwSessionHandle, ref uint pnProcInfoNeeded, ref uint pnProcInfo, [In(), Out()]RM_PROCESS_INFO[] rgAffectedApps, ref uint lpdwRebootReasons);

        /// <summary>
        /// Find out what process(es) have a lock on the specified file.
        /// </summary>
        /// <param name="path">Path of the file.</param>
        /// <returns>Processes locking the file</returns>
        /// <remarks>See also:
        /// http://msdn.microsoft.com/en-us/library/windows/desktop/aa373661(v=vs.85).aspx
        /// http://wyupdate.googlecode.com/svn-history/r401/trunk/frmFilesInUse.cs (no copyright in code at time of viewing)
        ///
        /// </remarks>
        public static List<Process> WhoIsLocking(string path)
        {
            uint handle = 0;
            string key = Guid.NewGuid().ToString();
            List<Process> processes = new List<Process>();

            int res = RmStartSession(ref handle, 0, key);
            if (res != 0)
            {
                throw new Exception("Could not begin restart session.  Unable to determine file locker.");
            }

            try
            {
                const int ERROR_MORE_DATA = 234;
                uint pnProcInfoNeeded = 0;
                uint pnProcInfo = 0;
                uint lpdwRebootReasons = RmRebootReasonNone;

                string[] resources = new string[] { path };
                // Just checking on one resource.
                res = RmRegisterResources(handle, Convert.ToUInt32(resources.Length), resources, 0, null, 0, null);

                if (res != 0)
                {
                    throw new Exception("Could not register resource.");
                }

                //Note: there's a race condition here -- the first call to RmGetList() returns
                //      the total number of process. However, when we call RmGetList() again to get
                //      the actual processes this number may have increased.
                res = RmGetList(handle, ref pnProcInfoNeeded, ref pnProcInfo, null, ref lpdwRebootReasons);

                if (res == ERROR_MORE_DATA)
                {
                    // Create an array to store the process results
                    RM_PROCESS_INFO[] processInfo = new RM_PROCESS_INFO[pnProcInfoNeeded];
                    pnProcInfo = pnProcInfoNeeded;

                    // Get the list
                    res = RmGetList(handle, ref pnProcInfoNeeded, ref pnProcInfo, processInfo, ref lpdwRebootReasons);
                    if (res == 0)
                    {
                        processes = new List<Process>(Convert.ToInt32(pnProcInfo));

                        // Enumerate all of the results and add them to the
                        // list to be returned
                        for (int i = 0; i <= pnProcInfo - 1; i++)
                        {
                            try
                            {
                                processes.Add(Process.GetProcessById(processInfo[i].Process.dwProcessId));
                                // catch the error -- in case the process is no longer running
                            }
                            catch
                            {
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("Could not list processes locking resource.");
                    }
                }
                else if (res != 0)
                {
                    throw new Exception("Could not list processes locking resource. Failed to get size of result.");
                }
            }
            finally
            {
                RmEndSession(handle);
            }

            return processes;
        }

        public static bool IsFileLocked(string filename)
        {
            // If the file can be opened for exclusive access it means that the file
            // is no longer locked by the FTP server program and has completed uploading.
            try
            {
                FileInfo objFile = new FileInfo(filename);
                // also check for readonly
                if (objFile.Attributes.ToString().Contains(FileAttributes.Temporary.ToString()) || objFile.Attributes.ToString().Contains(FileAttributes.ReadOnly.ToString()) || objFile.Attributes.ToString().Contains(FileAttributes.System.ToString()))
                {
                    return true;
                }
                // attempt to open the file
                using (FileStream inputStream = objFile.Open(FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    return false;
                }
            }
            catch
            {
                return true;
            }
        }
    }
}