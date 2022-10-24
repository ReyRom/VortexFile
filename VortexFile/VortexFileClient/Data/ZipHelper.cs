using Ionic.Zip;
using Ionic.Zlib;
using System.Text;

namespace VortexFileClient.Data
{
    public static class ZipHelper
    {
        private static Encoding encoding = Encoding.UTF8;

        public static void AppendFilesToZipWithPassword(string fileName,
            List<string> appendFiles, string password,
            CompressionLevel compressionLevel = CompressionLevel.Default)
        {
            using (var zipFile = ZipFile.Read(fileName))
            {
                zipFile.Password = password;
                zipFile.CompressionLevel = compressionLevel;
                zipFile.AddFiles(appendFiles, "\\");
                zipFile.Save();
            }
        }

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
            using (var zip = ZipFile.Read(fileName))
            {
                return zip;
            }
        }

        public static ZipFile ReadSubZipWithPassword(string fileName, string subFileName, string password)
        {
            ReadOptions readOptions = new ReadOptions();
            readOptions.Encoding = encoding;
            using (var zip = ZipFile.Read(fileName, readOptions))
            {

                zip.AlternateEncodingUsage = ZipOption.Always;
                zip.AlternateEncoding = encoding;
                ZipEntry entry = zip[subFileName];
                using (var subZip = ZipFile.Read(entry.ExtractToMemoryStreamWithPassword(password), readOptions))
                {
                    subZip.AlternateEncodingUsage = ZipOption.Always;
                    subZip.AlternateEncoding = encoding;
                    return subZip;
                }
            }
        }

        public static MemoryStream ExtractToMemoryStreamWithPassword(this ZipEntry zipEntry, string password)
        {
            var mstream = new MemoryStream();
            zipEntry.ExtractWithPassword(mstream, password);
            mstream.Position = 0;
            return mstream;
        }
    }
}