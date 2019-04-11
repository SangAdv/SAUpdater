using System;
using System.Collections.Generic;

namespace SangAdv.Updater.Master
{
    internal class ComboBoxItems
    {
        #region properties

        public List<ComboBoxItem> Items { get; } = new List<ComboBoxItem>();

        #endregion properties

        #region Methods

        internal void Add(string description, string value)
        {
            Items.Add(new ComboBoxItem(description, value));
        }

        internal void Add<T>() where T : struct
        {
            foreach (var item in Enum<T>.GetAllValues()) Add(item.ToString(), Convert.ToInt32(item).ToString());
        }

        #endregion Methods
    }

    internal class ComboBoxItem
    {
        public string Description { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;

        internal ComboBoxItem(string description, string value)
        {
            Description = description;
            Value = value;
        }
    }
}