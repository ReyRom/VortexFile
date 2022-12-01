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
                var entry = zipFile.AddDirectory(sourceDirectory, "\\");
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

        public static void DeleteFilesFromZip(string zipName, string pathInArchive, List<string> fileNames)
        {
            using (ZipFile zip = ReadZip(zipName))
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

        public static void DownloadFiles(string zipName, string pathInArchive, List<string> fileNames, string outFolder, string password)
        {
            using (ZipFile zip = ZipHelper.ReadZip(zipName))
            {
                //zip.Encryption = EncryptionAlgorithm.WinZipAes128;
                foreach (var fileName in fileNames)
                {
                    var zipEntry = zip.SingleOrDefault(z => z.FileName == Path.Combine(pathInArchive, fileName));
                    if (zipEntry.IsDirectory)
                    {
                        ExtractDirectoryWithPassword(zipName, pathInArchive, fileName, outFolder, password);
                    }
                    else
                    {
                        zipEntry.ExtractWithPassword(outFolder, password);
                    }
                }
            }
        }

        public static void ExtractDirectoryWithPassword(string zipName, string pathInArchive, string directoryName, string outerFolder, string password)
        {
            using (var zip = ZipHelper.ReadZip(zipName))
            {
                var data = zip.Entries.Where(x => x.FileName.StartsWith(pathInArchive + directoryName)).ToList();
                foreach (var e in data)
                {
                    if (e.IsDirectory)
                    {
                        ExtractDirectoryWithPassword(zipName, pathInArchive + directoryName, e.FileName.Remove(0, (pathInArchive + directoryName).Length), outerFolder, password);
                    }
                    else
                    {
                        e.ExtractWithPassword(outerFolder, password);
                    }
                }
            }
        }

        public static void UploadDirectory(string zipName, string pathInArchive, string directoryName, string password)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(directoryName);
            var directories = directoryInfo.GetDirectories("", SearchOption.AllDirectories);
            var files = directoryInfo.GetFiles("", SearchOption.AllDirectories);
            using (ZipFile zip = ZipHelper.ReadZip(zipName))
            {
                zip.CompressionLevel = Ionic.Zlib.CompressionLevel.Default;
                zip.Password = password;
                //zip.Encryption = EncryptionAlgorithm.WinZipAes128;

                zip.UseZip64WhenSaving = Zip64Option.AsNecessary;
                try
                {
                    zip.AddDirectoryByName(Path.Combine(pathInArchive, directoryInfo.Name));
                }
                catch (Exception) { }
                foreach (var item in directories)
                {
                    try
                    {
                        zip.AddDirectoryByName(Path.Combine(pathInArchive, item.FullName.Remove(0, directoryInfo.Parent.FullName.Length)));
                    }
                    catch (Exception) { }
                }
                foreach (var item in files)
                {
                    try
                    {
                        zip.AddFile(item.FullName, pathInArchive + item.DirectoryName.Remove(0, directoryInfo.Parent.FullName.Length));
                    }
                    catch (ArgumentException)
                    {
                        if (Extensions.Feedback.QuestionMessage($"Файл с именем {Path.GetFileName(item.Name)} уже есть в каталоге. Заменить?"))
                        {
                            zip.UpdateFile(item.FullName, pathInArchive + item.DirectoryName.Remove(0, directoryInfo.Parent.FullName.Length));
                        }
                    }
                }
                zip.Save();
            }
        }

        public static void UploadFiles(string zipName, string pathInArchive, List<string> filesName, string password)
        {
            using (ZipFile zip = ZipHelper.ReadZip(zipName))
            {
                zip.CompressionLevel = Ionic.Zlib.CompressionLevel.Default;
                zip.Password = password;
                //zip.Encryption = EncryptionAlgorithm.WinZipAes128;
                zip.UseZip64WhenSaving = Zip64Option.AsNecessary;
                foreach (var item in filesName)
                {
                    try
                    {
                        zip.AddFile(item, pathInArchive);
                    }
                    catch (ArgumentException)
                    {
                        if (Extensions.Feedback.QuestionMessage($"Файл с именем {Path.GetFileName(item)} уже есть в каталоге. Заменить?"))
                        {
                            zip.UpdateFile(item, pathInArchive);
                        }
                    }
                }
                zip.Save();
            }
        }

        public static void CreateDirectory(string zipName, string directoryName, string password)
        {
            using (ZipFile zip = ZipHelper.ReadZip(zipName))
            {
                try
                {
                    zip.CompressionLevel = Ionic.Zlib.CompressionLevel.Default;
                    zip.Password = password;
                    //zip.Encryption = EncryptionAlgorithm.WinZipAes128;
                    zip.AddDirectoryByName(directoryName);
                    zip.UseZip64WhenSaving = Zip64Option.AsNecessary;
                    zip.Save();
                }
                catch (ArgumentException)
                {
                    Extensions.Feedback.WarningMessage($"Папка с именем {directoryName} уже есть в каталоге.");
                }
            }
        }
    }
}