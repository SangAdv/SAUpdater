using System;
using System.Collections.Generic;

namespace SangAdv.Updater.Master
{
    public class Enum<TEnum> where TEnum : struct
    {
        public static IEnumerable<TEnum> GetAllValues()
        {
            return (TEnum[])Enum.GetValues(typeof(TEnum));
        }
    }
}