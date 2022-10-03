using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VortexFileClient.Models;

namespace VortexFileClient.Data
{
    public class LocalStorage
    {
        private string initialCatalog = Path.Combine(Properties.Settings.Default.Path, "VortexFile.zip");

        private string userCatalog = Session.CurrentUser.Login + ".zip";

        private string zipPassword = Properties.Settings.Default.ZipPassword;

        private string password = Session.CurrentUser.Password;

        public LocalStorage()
        {
            if (!Directory.Exists(Properties.Settings.Default.Path))
            {
                Directory.CreateDirectory(Properties.Settings.Default.Path);
            }
            if (!File.Exists(initialCatalog))
            {
                ZipHelper.CreateZip(initialCatalog);
            }
            if (!GetCatalog().Any(z=>z.FileName == userCatalog))
            {
                string tempPath = Path.Combine(Properties.Settings.Default.Path, userCatalog);
                ZipHelper.AppendFilesToZipWithPassword(initialCatalog, new List<string> { ZipHelper.CreateZip(tempPath) }, zipPassword);
                File.Delete(tempPath);
            }
            DAL.OnUserDelete += DAL_OnUserDelete;
        }

        private void DAL_OnUserDelete(object? sender, EventArgs e)
        {
            using(ZipFile zip = ZipHelper.ReadZip(initialCatalog))
            {
                var zipEntry = GetCatalog().SingleOrDefault(z => z.FileName == (string)sender+".zip");
                if (zipEntry == null) return;
                zip.RemoveEntry(zipEntry);
                zip.Save();
            }
        }

        public void DeleteFiles(List<string> fileNames)
        {
            using (ZipFile zip = ZipHelper.ReadSubZipWithPassword(initialCatalog,userCatalog, zipPassword))
            {
                foreach (var fileName in fileNames)
                {
                    var zipEntry = GetUserCatalog(password).SingleOrDefault(z => z.FileName == fileName);
                    zip.RemoveEntry(zipEntry);
                }
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    zip.Save(memoryStream);
                    memoryStream.Position = 0;
                    using (var outerZip = ZipHelper.ReadZip(initialCatalog))
                    {
                        outerZip.UpdateEntry(userCatalog, memoryStream);
                        outerZip.Save();
                    }
                }
            }
        }

        public void DownloadFiles(List<string> fileNames, string outFolder)
        {
            foreach (var fileName in fileNames)
            {
                var zipEntry = GetUserCatalog(password).SingleOrDefault(z => z.FileName == fileName);
                using (MemoryStream memoryStream = zipEntry.ExtractToMemoryStreamWithPassword(password))
                {
                    File.WriteAllBytes(Path.Combine(outFolder, fileName), memoryStream.ToArray());
                }
            }
        }

        public void UploadFiles(List<string> filesName)
        {
            using (ZipFile zip = ZipHelper.ReadSubZipWithPassword(initialCatalog, userCatalog, zipPassword))
            {
                zip.CompressionLevel = Ionic.Zlib.CompressionLevel.Default;
                zip.Password = password;
                foreach (var item in filesName)
                {
                    try
                    {
                        zip.AddFile(item, "");
                    }
                    catch (ArgumentException)
                    {
                        if (Extensions.Feedback.QuestionMessage($"Файл с именем {Path.GetFileName(item)} уже есть в каталоге. Заменить?"))
                        {
                            zip.UpdateFile(item, "");
                        }
                    }
                }
                using (MemoryStream memoryStream = new MemoryStream())
                { 
                    zip.Save(memoryStream);
                    memoryStream.Position = 0;
                    using (var outerZip = ZipHelper.ReadZip(initialCatalog))
                    {
                        outerZip.UpdateEntry(userCatalog, memoryStream);
                        outerZip.Save();
                    }
                }
            }
        }

        public List<ZipEntry> GetUserCatalog(string password)
        {
            return ZipHelper.ReadSubZipWithPassword(initialCatalog, userCatalog, password).Entries.ToList();
        }

        public List<ZipEntry> GetCatalog()
        {
            return ZipHelper.ReadZip(initialCatalog).Entries.ToList();
        }
    }
}
