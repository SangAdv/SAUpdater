using System;

namespace SangAdv.Updater.Common
{
    public enum SAUpdaterResults : int
    {
        Success = 1,
        ServerNameMissing = 2,
        FilesFolderMissing = 3,
        NotConnected = 4,
        MissingVersionFile = 5,
        Undefined = 6,
        InValidOS = 7,
        InValidFramework = 8,
        FilesFolderCreateError = 9,
        ConversionError = 10,
        InstallerUpdateAvailable = 11,
        InstallerNotAvailable = 12,
        DownloadError = 13,
        FileFolderDeleteError = 14,
        NewUpdateNotAvailable = 15,
        GeneralError = 999
    }

    public class SAUpdaterEventArgs : EventArgs
    {
        #region Properties

        public SAUpdaterResults Result { get; private set; }
        public string Message { get; private set; }
        public bool HasError => Result != SAUpdaterResults.Success;
        public bool IsSuccess => Result == SAUpdaterResults.Success;

        #endregion Properties

        #region Constrctor

        public SAUpdaterEventArgs()
        {
            Message = string.Empty;
            Result = SAUpdaterResults.Success;
        }

        public SAUpdaterEventArgs(string eventMessage, SAUpdaterResults e)
        {
            Message = eventMessage;
            Result = e;
        }

        #endregion Constrctor

        #region Methods

        public void SetEventArgs(string EventMessage, SAUpdaterResults e)
        {
            Message = EventMessage;
            Result = e;
        }

        public void SetErrorMessage(string ErrorMessage)
        {
            Message = ErrorMessage;
            Result = SAUpdaterResults.GeneralError;
        }

        public void ClearErrorMessage()
        {
            Message = "";
            Result = SAUpdaterResults.Success;
        }

        #endregion Methods
    }
}