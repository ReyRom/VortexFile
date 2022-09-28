using Ionic.Zip;
using Ionic.Zlib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace VortexFileClient.Data
{
    public static class ZipHelper
    {
        private static Encoding encoding = Encoding.GetEncoding(866);
        public static void CompressionDirectory(string fileName,
            string sourceDirectory,
            CompressionLevel compressionLevel = CompressionLevel.Default)
        {
            using (var zipFile = new ZipFile(fileName))
            {
                zipFile.CompressionLevel = compressionLevel;
                zipFile.AddDirectory(sourceDirectory, "\\");
                zipFile.Save();
            }
        }

        public static void AppendFilesToZip(string fileName,
            List<string> appendFiles,
            CompressionLevel compressionLevel = CompressionLevel.Default)
        {
            using (var zipFile = ZipFile.Read(fileName))
            {
                zipFile.CompressionLevel = compressionLevel;
                zipFile.AddFiles(appendFiles, "\\");
                zipFile.Save();
            }
        }

        public static void AppendFilesToZipFromArray(string fileName,
            List<byte[]> appendFiles,
            CompressionLevel compressionLevel = CompressionLevel.Default)
        {
            using (var zipFile = new ZipFile(fileName))
            {
                zipFile.CompressionLevel = compressionLevel;
                foreach (var file in appendFiles)
                {
                    var tempFileName = Guid.NewGuid().ToString();
                    zipFile.AddEntry(tempFileName, file);
                }

                zipFile.Save();
            }
        }

        public static void ExtractZip(string fileName, string outFolder)
        {
            using (var zip = ZipFile.Read(fileName))
            {
                foreach (var e in zip)
                {
                    e.Extract(outFolder, ExtractExistingFileAction.OverwriteSilently);
                }
            }
        }

        public static string CreateZip(string fileName)
        {
            using(var zip = new ZipFile())
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
        public static ZipFile ReadSubZip(string fileName, string subFileName)
        {
            ReadOptions readOptions = new ReadOptions();
            readOptions.Encoding = encoding;
            using (var zip = ZipFile.Read(fileName, readOptions))
            {
                
                zip.AlternateEncodingUsage = ZipOption.Always;
                zip.AlternateEncoding = encoding;
                ZipEntry entry = zip[subFileName];
                using (var subZip = ZipFile.Read(entry.ExtractToMemoryStream(), readOptions))
                {
                    subZip.AlternateEncodingUsage = ZipOption.Always;
                    subZip.AlternateEncoding = encoding;
                    return subZip;
                }
            }
        }
            public static MemoryStream ExtractToMemoryStream(this ZipEntry zipEntry)
            {
                var mstream = new MemoryStream();
                zipEntry.Extract(mstream);
                mstream.Position = 0;
                return mstream;
            }
    }
}