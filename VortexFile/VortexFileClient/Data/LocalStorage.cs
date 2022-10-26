using Ionic.Zip;
using System.Text.RegularExpressions;
using VortexFileClient.Data.Models;
using VortexFileClient.Extensions;

namespace VortexFileClient.Data
{
    public class LocalStorage
    {
        User user;
        private string InitialCatalog { get => Path.Combine(Properties.Settings.Default.Path, "VortexFileLocalStorage"); }

        private string UserCatalog { get => user.Login + ".zip"; }

        private string ZipPassword { get => Properties.Settings.Default.ZipPassword; }

        private string Password { get => user.Login.EncryptString(); }

        public string currentDirectory = "";

        public LocalStorage()
        {
            if (!Directory.Exists(InitialCatalog))
            {
                Directory.CreateDirectory(InitialCatalog);
            }
            DAL.OnUserDelete += DAL_OnUserDelete;
        }

        public LocalStorage(User user)
        {
            this.user = user;
            if (!Directory.Exists(InitialCatalog))
            {
                Directory.CreateDirectory(InitialCatalog);
            }
            if (!File.Exists(Path.Combine(InitialCatalog, UserCatalog)))
            {
                ZipHelper.CreateZip(Path.Combine(InitialCatalog, UserCatalog));
            }
            DAL.OnUserDelete += DAL_OnUserDelete;
        }

        private void DAL_OnUserDelete(object? sender, UserDeleteEventArgs e)
        {
            using (ZipFile zip = ZipHelper.ReadZip(InitialCatalog))
            {
                var zipEntry = GetCatalog().SingleOrDefault(z => z.FileName == e.User.Login + ".zip");
                if (zipEntry == null) return;
                zip.RemoveEntry(zipEntry);
                zip.Save();
            }
        }

        public void DeleteFiles(List<string> fileNames)
        {
            using (ZipFile zip = ZipHelper.ReadZip(Path.Combine(InitialCatalog, UserCatalog)))
            {

                zip.UseZip64WhenSaving = Zip64Option.AsNecessary;
                foreach (var fileName in fileNames)
                {
                    var zipEntry = zip.Entries.SingleOrDefault(z => z.FileName == currentDirectory + fileName);
                    zip.RemoveEntry(zipEntry);
                }
                zip.Save();
            }
        }

        public void DownloadFiles(List<string> fileNames, string outFolder)
        {
            using (ZipFile zip = ZipHelper.ReadZip(Path.Combine(InitialCatalog, UserCatalog)))
            {
                //zip.Encryption = EncryptionAlgorithm.WinZipAes128;
                foreach (var fileName in fileNames)
                {
                    var zipEntry = zip.SingleOrDefault(z => z.FileName == currentDirectory + fileName);
                    if (zipEntry.IsDirectory)
                    {
                        ExtractDirectoryWithPassword(currentDirectory, fileName, outFolder);
                    }
                    else
                    {
                        zipEntry.ExtractWithPassword(outFolder, Password);
                    }
                }
            }
        }

        public void UploadDirectory(string directoryName)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(directoryName);
            var directories = directoryInfo.GetDirectories("", SearchOption.AllDirectories);
            var files = directoryInfo.GetFiles("", SearchOption.AllDirectories);
            using (ZipFile zip = ZipHelper.ReadZip(Path.Combine(InitialCatalog, UserCatalog)))
            {
                zip.CompressionLevel = Ionic.Zlib.CompressionLevel.Default;
                zip.Password = Password;
                //zip.Encryption = EncryptionAlgorithm.WinZipAes128;

                zip.UseZip64WhenSaving = Zip64Option.AsNecessary;
                zip.AddDirectoryByName(Path.Combine(currentDirectory, directoryInfo.Name));
                foreach (var item in directories)
                {
                    zip.AddDirectoryByName(Path.Combine(currentDirectory, item.FullName.Remove(0, directoryInfo.Parent.FullName.Length)));
                }
                foreach (var item in files)
                {
                    try
                    {
                        zip.AddFile(item.FullName, currentDirectory + item.DirectoryName.Remove(0, directoryInfo.Parent.FullName.Length));
                    }
                    catch (ArgumentException)
                    {
                        if (Extensions.Feedback.QuestionMessage($"Файл с именем {Path.GetFileName(item.Name)} уже есть в каталоге. Заменить?"))
                        {
                            zip.UpdateFile(item.FullName, currentDirectory + item.DirectoryName.Remove(0, directoryInfo.Parent.FullName.Length));
                        }
                    }
                }
                zip.Save();

            }
        }

        public void UploadFiles(List<string> filesName)
        {
            using (ZipFile zip = ZipHelper.ReadZip(Path.Combine(InitialCatalog, UserCatalog)))
            {
                zip.CompressionLevel = Ionic.Zlib.CompressionLevel.Default;
                zip.Password = Password;
                //zip.Encryption = EncryptionAlgorithm.WinZipAes128;
                zip.UseZip64WhenSaving = Zip64Option.AsNecessary;
                foreach (var item in filesName)
                {
                    try
                    {
                        zip.AddFile(item, currentDirectory);
                    }
                    catch (ArgumentException)
                    {
                        if (Extensions.Feedback.QuestionMessage($"Файл с именем {Path.GetFileName(item)} уже есть в каталоге. Заменить?"))
                        {
                            zip.UpdateFile(item, currentDirectory);
                        }
                    }
                }
                zip.Save();
            }
        }

        public void CreateDirectory(string directoryName)
        {
            using (ZipFile zip = ZipHelper.ReadZip(Path.Combine(InitialCatalog, UserCatalog)))
            {
                zip.CompressionLevel = Ionic.Zlib.CompressionLevel.Default;
                zip.Password = Password;
                //zip.Encryption = EncryptionAlgorithm.WinZipAes128;
                zip.AddDirectoryByName(directoryName);
                zip.UseZip64WhenSaving = Zip64Option.AsNecessary;
                zip.Save();
            }
        }

        public static List<string> GetLevel(string initialCatalog, List<ZipEntry> items)
        {
            var dirCont = items.Where(x => x.FileName.StartsWith(initialCatalog)).Select(x => x.FileName.Remove(0, initialCatalog.Length)).ToList();
            List<string> result = new List<string>();
            foreach (var item in dirCont)
            {
                if (!Regex.IsMatch(item, @"[//]\w"))
                {
                    result.Add(item);
                }
            }
            return result;
        }
        public void ExtractDirectoryWithPassword(string path, string directoryName, string outerFolder)
        {
            using (var zip = ZipHelper.ReadZip(Path.Combine(InitialCatalog, UserCatalog)))
            {
                var data = zip.Entries.Where(x => x.FileName.StartsWith(path + directoryName)).ToList();
                foreach (var e in data)
                {
                    if (e.IsDirectory)
                    {
                        ExtractDirectoryWithPassword(path + directoryName, e.FileName.Remove(0, (path + directoryName).Length), outerFolder);
                    }
                    else
                    {
                        e.ExtractWithPassword(outerFolder, Password);
                    }
                }
            }
        }

        public ZipFile GetUserCatalog(string password)
        {
            return ZipHelper.ReadZip(Path.Combine(InitialCatalog,UserCatalog));
        }

        public ZipFile GetCatalog()
        {
            return ZipHelper.ReadZip(InitialCatalog);
        }
    }
}
