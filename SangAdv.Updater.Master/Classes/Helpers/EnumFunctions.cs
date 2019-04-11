using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SangAdv.Updater.Master
{
    public class EnumFunctions
    {
        public class KeyValuePair
        {
            public string Key { get; set; }

            public string Name { get; set; }

            public int Value { get; set; }
        }

        public static List<KeyValuePair> ListFrom<T>()
        {
            var array = (T[])(Enum.GetValues(typeof(T)).Cast<T>());
            return array
              .Select(a => new KeyValuePair
              {
                  Key = a.ToString(),
                  Name = SplitCapitalizedWords(a.ToString()),
                  Value = Convert.ToInt32(a)
              })
                .OrderBy(kvp => kvp.Name)
               .ToList();
        }

        public static string SplitCapitalizedWords(string source)
        {
            if (String.IsNullOrEmpty(source)) return String.Empty;
            var newText = new StringBuilder(source.Length * 2);
            newText.Append(source[0]);
            for (int i = 1; i < source.Length; i++)
            {
                if (char.IsUpper(source[i])) newText.Append(' ');
                newText.Append(source[i]);
            }
            return newText.ToString();
        }
    }
}