using Ionic.Zip;
using Ionic.Zlib;
using System.Text;

namespace VortexFileClient.Data
{
    public static class ZipHelper
    {
        private static Encoding encoding = Encoding.UTF8;

        //public static void AppendFilesToZipWithPassword(string fileName,
        //    List<string> appendFiles, string password,
        //    CompressionLevel compressionLevel = CompressionLevel.Default)
        //{
        //    using (var zipFile = ZipFile.Read(fileName))
        //    {
        //        zipFile.Password = password;
        //        zipFile.CompressionLevel = compressionLevel;
        //        zipFile.AddFiles(appendFiles, "\\");
        //        zipFile.Save();
        //    }
        //}

        public static void AppendDirectoryToZipWithPassword(string fileName,
        string sourceDirectory, string password,
        CompressionLevel compressionLevel = CompressionLevel.Default)
        {
            using (var zipFile = new ZipFile(fileName))
            {
                zipFile.Password = password;
                zipFile.CompressionLevel = compressionLevel;
                zipFile.AddDirectory(sourceDirectory, "\\");
                zipFile.Save();
            }
        }

        public static string CreateZip(string fileName)
        {
            using (var zip = new ZipFile())
            {
                zip.CompressionLevel = CompressionLevel.Default;
                zip.Save(fileName);
            }
            return fileName;
        }

        public static ZipFile ReadZip(string fileName)
        {
            ReadOptions readOptions = new ReadOptions();
            readOptions.Encoding = encoding;
            using (var zip = ZipFile.Read(fileName, readOptions))
            {
                zip.AlternateEncodingUsage = ZipOption.Always;
                zip.AlternateEncoding = encoding;
                return zip;
            }
        }

        public static void DeleteFilesFromZip(string fileName, List<string> fileNames, string pathInArchive)
        {
            using (ZipFile zip = ReadZip(fileName))
            {
                zip.UseZip64WhenSaving = Zip64Option.AsNecessary;
                foreach (var file in fileNames)
                {
                    var zipEntry = zip.Entries.SingleOrDefault(z => z.FileName == Path.Combine(pathInArchive,file));
                    zip.RemoveEntry(zipEntry);
                }
                zip.Save();
            }
        }
    }
}