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

        private string ZipName { get => Path.Combine(InitialCatalog, UserCatalog); }

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
            if (!File.Exists(ZipName))
            {
                ZipHelper.CreateZip(ZipName);
            }
            DAL.OnUserDelete += DAL_OnUserDelete;
        }

        private void DAL_OnUserDelete(object? sender, UserDeleteEventArgs e)
        {
            var path = Path.Combine(InitialCatalog, e.User.Login + ".zip");
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public void DeleteFiles(List<string> fileNames)
        {
            ZipHelper.DeleteFilesFromZip(ZipName, currentDirectory, fileNames);
        }

        public void DownloadFiles(List<string> fileNames, string outFolder)
        {
            ZipHelper.DownloadFiles(ZipName, currentDirectory, fileNames, outFolder, Password);
        }

        public void UploadDirectory(string directoryName)
        {
            ZipHelper.UploadDirectory(ZipName, currentDirectory, directoryName, Password);
        }

        public void UploadFiles(List<string> filesNames)
        {
            ZipHelper.UploadFiles(ZipName, currentDirectory, filesNames, Password);
        }

        public void Upload(List<string> uploadList)
        {
            List<string> files = new List<string>();
            List<string> directories = new List<string>();
            foreach (var item in uploadList)
            {
                if (Directory.Exists(item))
                {
                    directories.Add(item);
                }
                else
                {
                    files.Add(item);
                }
            }
            foreach (var item in directories)
            {
                ZipHelper.UploadDirectory(ZipName, currentDirectory, item, Password);
            }
            ZipHelper.UploadFiles(ZipName, currentDirectory, files, Password);
        }

        public void CreateDirectory(string directoryName)
        {
            ZipHelper.CreateDirectory(ZipName, directoryName, Password);
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
