using System;

namespace SangAdv.Updater.Common
{
    public class SAUpdaterVersionNumber
    {
        #region Variables

        private readonly string[] FinalVersion = { "0", "0", "0", "0" };

        #endregion Variables

        #region Constructor

        public SAUpdaterVersionNumber(string versionNumber)
        {
            if (string.IsNullOrWhiteSpace(versionNumber)) return;

            versionNumber = versionNumber.FixVersionNumberFormat();

            if (!versionNumber.CheckVersionNumberFormat()) return;

            var Ver = versionNumber.Trim().Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);

            if (Ver.Length <= 0) return;
            for (var i = 0; i < 4; i++) FinalVersion[i] = i <= Ver.Length - 1 ? Ver[i] : "0";
        }

        #endregion Constructor

        #region Properties

        public string FullVersion => $"{FinalVersion[0]}.{FinalVersion[1]}.{FinalVersion[2]}.{FinalVersion[3]}";
        public int Major => Convert.ToInt32(FinalVersion[0]);
        public int Minor => Convert.ToInt32(FinalVersion[1]);
        public int Build => Convert.ToInt32(FinalVersion[2]);
        public int Revision => Convert.ToInt32(FinalVersion[3]);

        #endregion Properties
    }
}