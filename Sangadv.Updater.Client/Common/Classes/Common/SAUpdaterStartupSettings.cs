using System;
using System.Collections.Generic;
using System.IO;

namespace SangAdv.Updater.Common
{
    public class SAUpdaterStartupSettings : SAUpdaterErrorBase
    {
        #region Variables

        private string mFilename;
        private Dictionary<int, string> mData = new Dictionary<int, string>();
        private string mApplicationFolder;

        #endregion Variables

        #region Constructor

        public SAUpdaterStartupSettings(string applicationFolder)
        {
            if (string.IsNullOrEmpty(applicationFolder)) throw new ArgumentException(nameof(applicationFolder));

            mApplicationFolder = applicationFolder;
            Initialise();
            if (HasError) return;

            if (!File.Exists(mFilename)) Save();

            Error = Read();
            if (Error.Result == SAUpdaterResults.Success) return;

            Reset();
        }

        #endregion Constructor

        #region Methods

        public void Update<T>(int key, T value)
        {
            mData[key] = value.ToString();
        }

        public void Remove(int key)
        {
            mData.Remove(key);
        }

        public void Save()
        {
            if (string.IsNullOrEmpty(mFilename))
            {
                Initialise();
                if (HasError) return;
            }

            SAUpdaterFile.Write(mFilename, SetString());
        }

        public SAUpdaterEventArgs Read()
        {
            if (string.IsNullOrEmpty(mFilename))
            {
                Initialise();
                if (HasError) return new SAUpdaterEventArgs("Filename not defined", SAUpdaterResults.FilesFolderMissing);
            }

            var tData = SAUpdaterFile.Read(mFilename);
            FromString(tData.Count == 0 ? string.Empty : tData[0]);
            return new SAUpdaterEventArgs("", SAUpdaterResults.Success);
        }

        public string Get(int key)
        {
            return mData.ContainsKey(key) ? mData[key] : string.Empty;
        }

        public bool HasKey(int key) => mData.ContainsKey(key);

        public T Get<T>(int key)
        {
            return mData.ContainsKey(key) ? mData[key].Value<T>() : default(T);
        }

        public void Reset()
        {
            mData = new Dictionary<int, string>();
        }

        #endregion Methods

        #region Private Methods

        private void Initialise()
        {
            Error.ClearErrorMessage();
            try
            {
                if (string.IsNullOrEmpty(mApplicationFolder)) throw new Exception("Unspecified application folder");
                mFilename = Path.Combine(mApplicationFolder, SAUpdaterConstants.ClientStartupFileName);
            }
            catch (Exception ex)
            {
                Error.SetErrorMessage(ex.Message);
            }
        }

        private void FromString(string dataString)
        {
            Error.ClearErrorMessage();
            try
            {
                mData = dataString.InflateString().SAUpdaterDeserialise<Dictionary<int, string>>();
                if (mData == null) Reset();
            }
            catch (Exception ex)
            {
                Error = new SAUpdaterEventArgs(ex.Message, SAUpdaterResults.ConversionError);
                Reset();
            }
        }

        private string SetString()
        {
            if (mData == null) Reset();
            return mData.SAUpdaterSerialise().DeflateString();
        }

        #endregion Private Methods

        #region Class

        internal class SAUpdaterSettingsValue
        {
            #region Properties

            public string Value { get; }
            public bool ForceUpdate { get; }

            #endregion Properties

            #region Constructor

            public SAUpdaterSettingsValue(string value, bool forceUpdate = false)
            {
                Value = value;
                ForceUpdate = forceUpdate;
            }

            #endregion Constructor
        }

        #endregion Class
    }
}