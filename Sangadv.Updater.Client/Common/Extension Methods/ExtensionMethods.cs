using Newtonsoft.Json;
using System;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace SangAdv.Updater.Common
{
    public static class ExtensionMethods
    {
        #region Strings

        public static string DeflateString(this string text)
        {
            using (var mstream = new MemoryStream())
            {
                using (var zstream = new DeflateStream(mstream, CompressionMode.Compress))
                using (var twriter = new StreamWriter(zstream, Encoding.UTF8))
                    twriter.Write(text);

                return mstream.ToArray().ToBase64String();
            }
        }

        public static string InflateString(this string base64)
        {
            try
            {
                using (var mstream = new MemoryStream(base64.ToByteArray()))
                using (var zstream = new DeflateStream(mstream, CompressionMode.Decompress))
                using (var treader = new StreamReader(zstream))
                    return treader.ReadToEnd();
            }
            catch
            {
                return string.Empty;
            }
        }

        internal static string ToBase64String(this byte[] byteArray) => Convert.ToBase64String(byteArray);

        internal static byte[] ToByteArray(this string base64String) => Convert.FromBase64String(base64String);

        internal static int ToInt32(this string integerValue)
        {
            try
            {
                return Convert.ToInt32(integerValue.Trim());
            }
            catch
            {
                return 0;
            }
        }

        internal static string Right(this string inString, int length)
        {
            if (string.IsNullOrEmpty(inString)) return string.Empty;
            inString = inString.Trim();
            return inString.Length < length ? inString : inString.Substring(inString.Length - length, length);
        }

        internal static string Left(this string inString, int length)
        {
            if (string.IsNullOrEmpty(inString)) return string.Empty;
            inString = inString.Trim();
            return inString.Length < length ? inString : inString.Substring(0, length);
        }

        public static string GenerateFileMD5(this string filepath)
        {
            try
            {
                using (var md5 = new MD5CryptoServiceProvider())
                {
                    using (var f = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.Read, 8192))
                        md5.ComputeHash(f);

                    var hash = md5.Hash;
                    var buff = new StringBuilder();

                    foreach (var hashByte in hash) buff.Append($"{hashByte:X2}");

                    return buff.ToString();
                }
            }
            catch
            {
                return string.Empty;
            }
        }

        #endregion Strings

        #region Folder

        public static string FixFolderText(this string directory)
        {
            var tString = directory.Trim();
            if (tString.Length == 0) tString += @"\";
            if (tString.Right(1) != @"\") tString += @"\";
            return tString;
        }

        #endregion Folder

        #region Json

        public static string SAUpdaterSerialise(this object data) => JsonConvert.SerializeObject(data, Formatting.None);

        internal static T SAUpdaterDeserialise<T>(this string stringData) => JsonConvert.DeserializeObject<T>(stringData);

        #endregion Json

        #region Object

        public static T Value<T>(this object value) => (T)Convert.ChangeType(value, typeof(T));

        #endregion Object

        #region DateTime

        public static string ToDateTimeString(this DateTime dateValue) => dateValue.ToString("yyyyMMddHHmm");

        public static DateTime ToDateTime(this string stringDateValue)
        {
            //Assume Instr is in the form YYYYMMDDHHmm
            if (stringDateValue == "") return DateTime.Now;
            if (stringDateValue.Length > 12) stringDateValue = stringDateValue.Left(12);
            try
            {
                return DateTime.ParseExact(stringDateValue, "yyyyMMddHHmm", CultureInfo.InvariantCulture);
            }
            catch
            {
                return DateTime.Now;
            }
        }

        #endregion DateTime

        #region Version

        public static bool IsNewerVersion(this string newVersion, string currentVersion)
        {
            if (string.IsNullOrWhiteSpace(newVersion)) return false;
            if (string.IsNullOrWhiteSpace(currentVersion)) currentVersion = "0.0.0.0";

            newVersion = newVersion.FixVersionNumberFormat();
            currentVersion = currentVersion.FixVersionNumberFormat();

            if (!newVersion.CheckVersionNumberFormat()) return false;
            if (!currentVersion.CheckVersionNumberFormat()) return false;

            var NVer = newVersion.Split('.');
            var CVer = currentVersion.Split('.');

            for (var i = 0; i < 4; i++)
            {
                if (NVer[i].ToInt32() > CVer[i].ToInt32()) return true;
                if (NVer[i].ToInt32() < CVer[i].ToInt32()) return false;
            }

            return false;
        }

        public static bool CheckVersionNumberFormat(this string versionNumber) => new Regex(@"^(?:0|[1-9][0-9]*)(?:\.(0|[1-9][0-9]*))*$").IsMatch(versionNumber);

        internal static string FixVersionNumberFormat(this string versionNumber)
        {
            string[] finalVersion = { "0", "0", "0", "0" };

            var Ver = versionNumber.Trim().Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);

            if (Ver.Length > 0) for (var i = 0; i < 4; i++) finalVersion[i] = i <= Ver.Length - 1 ? Ver[i] : "0";

            return $"{finalVersion[0]}.{finalVersion[1]}.{finalVersion[2]}.{finalVersion[3]}";
        }

        #endregion Version

        #region URL

        internal static string FixURLText(this string directoryName)
        {
            var tString = directoryName.Trim();
            if (tString.Substring(tString.Length - 1, 1) == "/") tString = tString.Substring(0, tString.Length - 1);
            if (tString.ToUpper().IndexOf("HTTP") + 1 == 0 && tString.ToUpper().IndexOf("FTP") + 1 == 0)
                if (tString.Substring(0, 1) != "/") tString = "/" + tString;
            return tString;
        }

        public static Uri AddUriSegment(this Uri urlLink, string urlSegment)
        {
            urlSegment = urlSegment.FixURLDirectoryLink();
            urlLink = urlLink.FixURLDirectoryLink();
            return new Uri(urlLink, urlSegment);
        }

        public static string FixURLDirectoryLink(this string urlLink)
        {
            if (string.IsNullOrEmpty(urlLink)) return string.Empty;
            return urlLink.EndsWith("/") ? urlLink : $"{urlLink}/";
        }

        internal static Uri FixURLDirectoryLink(this Uri urlLink)
        {
            if (!urlLink.IsWellFormedOriginalString()) throw new Exception($"{urlLink} is not well formed");
            var url = urlLink.ToString();
            return url.EndsWith("/") ? urlLink : new Uri($"{url}/");
        }

        internal static Uri AddUriParameter(this Uri urlLink, string urlParamater)
        {
            urlLink = urlLink.FixURLDirectoryLink();
            return new Uri(urlLink, urlParamater);
        }

        internal static Uri FixURLFileLink(this Uri urlLink)
        {
            var url = urlLink.ToString();
            while (url.EndsWith("/")) url = url.Left(url.Length - 1);
            return new Uri(url);
        }

        #endregion URL
    }
}