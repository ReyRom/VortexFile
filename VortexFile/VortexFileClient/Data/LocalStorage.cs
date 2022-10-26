using Ionic.Zip;
using Org.BouncyCastle.Asn1.Pkcs;
using System.Text.RegularExpressions;
using VortexFileClient.Data.Models;
using VortexFileClient.Extensions;

namespace VortexFileClient.Data
{
    public class LocalStorage
    {
        User user;
        private string InitialCatalog { get => Path.Combine(Properties.Settings.Default.Path, "VortexFile.zip"); }

        private string UserCatalog { get => user.Login + ".zip"; }

        private string ZipPassword { get => Properties.Settings.Default.ZipPassword; }

        private string Password { get => user.Login.EncryptString(); }

        public string currentDirectory = "";

        public LocalStorage()
        {
            if (!Directory.Exists(Properties.Settings.Default.Path))
            {
                Directory.CreateDirectory(Properties.Settings.Default.Path);
            }
            if (!File.Exists(InitialCatalog))
            {
                ZipHelper.CreateZip(InitialCatalog);
            }
            DAL.OnUserDelete += DAL_OnUserDelete;
        }

        public LocalStorage(User user)
        {
            this.user = user;
            if (!Directory.Exists(Properties.Settings.Default.Path))
            {
                Directory.CreateDirectory(Properties.Settings.Default.Path);
            }
            if (!File.Exists(InitialCatalog))
            {
                ZipHelper.CreateZip(InitialCatalog);
            }
            if (!GetCatalog().Any(z => z.FileName == UserCatalog))
            {
                string tempPath = Path.Combine(Properties.Settings.Default.Path, UserCatalog);
                ZipHelper.AppendFilesToZipWithPassword(InitialCatalog, new List<string> { ZipHelper.CreateZip(tempPath) }, ZipPassword);
                File.Delete(tempPath);
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
            using (ZipFile zip = ZipHelper.ReadSubZipWithPassword(InitialCatalog, UserCatalog, ZipPassword))
            {
                foreach (var fileName in fileNames)
                {
                    var zipEntry = GetUserCatalog(Password).SingleOrDefault(z => z.FileName == fileName);
                    zip.RemoveEntry(zipEntry);
                }
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    zip.Save(memoryStream);
                    memoryStream.Position = 0;
                    using (var outerZip = ZipHelper.ReadZip(InitialCatalog))
                    {
                        outerZip.UpdateEntry(UserCatalog, memoryStream);
                        outerZip.Save();
                    }
                }
            }
        }

        public void DownloadFiles(List<string> fileNames, string outFolder)
        {
            foreach (var fileName in fileNames)
            {
                var zipEntry = GetUserCatalog(Password).SingleOrDefault(z => z.FileName == currentDirectory + fileName);
                if (zipEntry.IsDirectory)
                {
                    ExtractDirectoryWithPassword(currentDirectory, fileName, outFolder);
                }
                else
                {
                    using (MemoryStream memoryStream = zipEntry.ExtractToMemoryStreamWithPassword(Password))
                    {
                        File.WriteAllBytes(Path.Combine(outFolder, fileName), memoryStream.ToArray());
                    }
                }
            }
        }

        public void UploadDirectory(string directoryName)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(directoryName);
            var directories = directoryInfo.GetDirectories("",SearchOption.AllDirectories);
            var files = directoryInfo.GetFiles("", SearchOption.AllDirectories);
            using (ZipFile zip = ZipHelper.ReadSubZipWithPassword(InitialCatalog, UserCatalog, ZipPassword))
            {
                zip.CompressionLevel = Ionic.Zlib.CompressionLevel.Default;
                zip.Password = Password;
                zip.AddDirectoryByName(Path.Combine(currentDirectory, directoryInfo.Name));
                foreach (var item in directories)
                {
                    zip.AddDirectoryByName(Path.Combine(currentDirectory, item.FullName.Remove(0, directoryInfo.Parent.FullName.Length)));
                }
                foreach (var item in files)
                {
                    if (item.Length > Extensions.Tools.GigaByte * 2)
                    {
                        throw new Exception("Размер загружаемого файла больше 2ГБ.");
                    }
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
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    zip.Save(memoryStream);
                    memoryStream.Position = 0;
                    using (var outerZip = ZipHelper.ReadZip(InitialCatalog))
                    {
                        outerZip.UpdateEntry(UserCatalog, memoryStream);
                        outerZip.Save();
                    }
                }
            }
        }

        public void UploadFiles(List<string> filesName)
        {
            using (ZipFile zip = ZipHelper.ReadSubZipWithPassword(InitialCatalog, UserCatalog, ZipPassword))
            {
                zip.CompressionLevel = Ionic.Zlib.CompressionLevel.Default;
                zip.Password = Password;
                foreach (var item in filesName)
                {
                    if (new FileInfo(item).Length > Extensions.Tools.GigaByte * 2)
                    {
                        throw new Exception("Размер загружаемого файла больше 2ГБ.");
                    }
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
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    zip.Save(memoryStream);
                    memoryStream.Position = 0;
                    using (var outerZip = ZipHelper.ReadZip(InitialCatalog))
                    {
                        outerZip.UpdateEntry(UserCatalog, memoryStream);
                        outerZip.Save();
                    }
                }
            }
        }

        public void CreateDirectory(string directoryName)
        {
            using (ZipFile zip = ZipHelper.ReadSubZipWithPassword(InitialCatalog, UserCatalog, ZipPassword))
            {
                zip.CompressionLevel = Ionic.Zlib.CompressionLevel.Default;
                zip.Password = Password;
                zip.AddDirectoryByName(directoryName);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    zip.Save(memoryStream);
                    memoryStream.Position = 0;
                    using (var outerZip = ZipHelper.ReadZip(InitialCatalog))
                    {
                        outerZip.UpdateEntry(UserCatalog, memoryStream);
                        outerZip.Save();
                    }
                }
            }
        }

        public static List<string> GetLevel(string initialCatalog, List<ZipEntry> items)
        {
            var dirCont = items.Where(x => x.FileName.StartsWith(initialCatalog)).Select(x=>x.FileName.Remove(0,initialCatalog.Length)).ToList();
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
            using (var zip = ZipHelper.ReadSubZipWithPassword(InitialCatalog, UserCatalog, Password))
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
            return ZipHelper.ReadSubZipWithPassword(InitialCatalog, UserCatalog, password);
        }

        public ZipFile GetCatalog()
        {
            return ZipHelper.ReadZip(InitialCatalog);
        }
    }
}
