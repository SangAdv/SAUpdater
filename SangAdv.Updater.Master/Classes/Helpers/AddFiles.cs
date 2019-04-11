using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SangAdv.Updater.Master
{
    internal class AddFiles
    {
        #region Properties

        public string Filename { get; set; }
        public int FileId { get; set; }
        public string UniqueName { get; set; }
        public bool ShortCut { get; set; }
        public List<AddFiles> Files { get; private set; } = new List<AddFiles>();

        #endregion Properties

        #region Methods

        public void Add(FileInfo fileInfo)
        {
            var tFileId = 0;
            string tUniqueFilename = null;

            var tShortCut = (fileInfo.Extension.ToUpper().Trim() == ".EXE") ? true : false;

            var tNewFile = fileInfo.Name.ToUpper().Trim();
            var a = Files.Where(x => new FileInfo(x.Filename).Name.ToUpper().Trim() == tNewFile);
            if (a.Any())
            {
                tFileId = a.First().FileId;
                tUniqueFilename = a.First().UniqueName;
            }

            if (tFileId == 0) tUniqueFilename = GetUniqueFileName(8);

            Files.Add(new AddFiles { FileId = 0, Filename = fileInfo.Name, ShortCut = tShortCut, UniqueName = tUniqueFilename });
        }

        private string GetUniqueFileName(int length)
        {
            const string s = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var unique = false;
            string tName;

            do
            {
                var sb = new StringBuilder();
                var r = new Random();
                unique = true;
                for (var i = 1; i <= length; i++)
                {
                    var idx = r.Next(0, 35);
                    sb.Append(s.Substring(idx, 1));
                }
                tName = sb.ToString();

                unique = true;

                var a = Files.Where(x => x.UniqueName.ToUpper().Trim() == tName.ToUpper().Trim());
                if (a.Any()) unique = false;
            } while (!unique);
            return tName;
        }

        #endregion Methods
    }
}