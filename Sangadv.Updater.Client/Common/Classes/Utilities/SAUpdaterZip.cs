using System.IO;
using System.IO.Compression;

namespace SangAdv.Updater
{
    public static class SAUpdaterZip
    {
        public static void Add(string fullZipArchiveFilename, string fullFilenameToAdd)
        {
            using (ZipArchive zip = ZipFile.Open(fullZipArchiveFilename, ZipArchiveMode.Create))
            {
                zip.CreateEntryFromFile(fullFilenameToAdd, Path.GetFileName(fullFilenameToAdd), CompressionLevel.Optimal);
            }
        }

        public static void Extract(string fullZipArchiveFilename, string extractFolder)
        {
            using (ZipArchive zip = ZipFile.Open(fullZipArchiveFilename, ZipArchiveMode.Read))
            {
                zip.ExtractToDirectory(extractFolder);
            }
        }
    }
}