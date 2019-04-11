using System;
using System.IO;

namespace SangAdv.Updater.Common
{
    internal class SAUpdaterLogger
    {
        #region Variables

        private string mLoggingFilename;

        #endregion Variables

        #region Constructor

        internal SAUpdaterLogger(string loggingFolder)
        {
            mLoggingFilename = Path.Combine(loggingFolder, $"UpdateLog-{DateTime.Now.ToDateTimeString()}.log");

            foreach (var item in Directory.GetFiles(loggingFolder)) SAUpdaterFile.Delete(item);
        }

        #endregion Constructor

        #region Methods

        internal void Add(string className, string methodName, string message)
        {
            using (var sw = File.AppendText(mLoggingFilename))
            {
                sw.WriteLine($"{DateTime.Now:HH:mm:ss} {message} - {className} [{methodName}]");
            }
        }

        #endregion Methods
    }
}