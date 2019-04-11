using System.Collections.Generic;

namespace SangAdv.Updater.Common
{
    public class SAUpdaterFileList
    {
        #region Properties

        public List<SAUpdaterFileItem> List { get; private set; } = new List<SAUpdaterFileItem>();

        public int Count => List.Count;

        public override string ToString()
        {
            return List.SAUpdaterSerialise();
        }

        internal void FromString(string data)
        {
            List = data.SAUpdaterDeserialise<List<SAUpdaterFileItem>>();
        }

        #endregion Properties

        #region Internal Methods

        public void Reset()
        {
            List.Clear();
        }

        public void Add(SAUpdaterFileItem updateItem)
        {
            List.Add(updateItem);
        }

        #endregion Internal Methods
    }
}