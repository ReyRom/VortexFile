using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VortexFileClient.Data
{
    public class LocalStorage
    {
        private string initialCatalog = Path.Combine(Properties.Settings.Default.Path, "VortexFile.zip");

        private string userCatalog = Session.CurrentUser.Login + ".zip";

        private BindingList<ZipEntry> bindingList = new BindingList<ZipEntry>();

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
                ZipHelper.AppendFilesToZip(initialCatalog, new List<string> { ZipHelper.CreateZip(tempPath) });
                File.Delete(tempPath);
            }
        }

        public void DeleteFiles(List<string> fileNames)
        {
            using (ZipFile zip = ZipHelper.ReadSubZip(initialCatalog,userCatalog))
            {
                foreach (var fileName in fileNames)
                {
                    var zipEntry = GetUserCatalog().SingleOrDefault(z => z.FileName == fileName);
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
                var zipEntry = GetUserCatalog().SingleOrDefault(z => z.FileName == fileName);
                using (MemoryStream memoryStream = zipEntry.ExtractToMemoryStream())
                {
                    File.WriteAllBytes(Path.Combine(outFolder, fileName), memoryStream.ToArray());
                }
            }
        }

        public void UploadFiles(List<string> filesName)
        {
            using (ZipFile zip = ZipHelper.ReadSubZip(initialCatalog, userCatalog))
            {
                zip.CompressionLevel = Ionic.Zlib.CompressionLevel.Default;
                foreach (var item in filesName)
                {
                    try
                    {
                        zip.AddFile(item, "");
                    }
                    catch (ArgumentException)
                    {
                        //обрати внимание
                        zip.UpdateFile(item, "");
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

        public List<ZipEntry> GetUserCatalog()
        {
            return ZipHelper.ReadSubZip(initialCatalog, userCatalog).Entries.ToList();
        }

        public List<ZipEntry> GetCatalog()
        {
            return ZipHelper.ReadZip(initialCatalog).Entries.ToList();
        }
    }
}
