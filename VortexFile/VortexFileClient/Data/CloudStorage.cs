using System.IO;
using VortexFileClient.Extensions;
using User = VortexFileClient.Data.Models.User;

namespace VortexFileClient.Data
{
    internal class CloudStorage
    {
        private string ServerAddress { get => Properties.Settings.Default.FtpAddress; }
        private string login = string.Empty;
        private string password = string.Empty;
        public string currentDirectory = "";

        public CloudStorage()
        {
            DAL.OnUserDelete += DAL_OnUserDelete;
        }

        public CloudStorage(User user)
        {
            this.login = user.Login;
            this.password = user.Password;
            DAL.OnUserDelete += DAL_OnUserDelete;
        }

        private void DAL_OnUserDelete(object? sender, UserDeleteEventArgs e)
        {
            DeleteFiles(GetUserCatalog(e.User), e.User);
        }

        public void DownloadFiles(List<string> fileNames, string outFolder)
        {
            foreach (var fileName in fileNames)
            {
                var status = FtpHelper.DownloadFile(Path.Combine(outFolder, fileName), ServerAddress + fileName, login, password);
            }
        }

        public void UploadFiles(List<string> fileNames)
        {
            foreach (var fileName in fileNames)
            {
                if (new FileInfo(fileName).Length > Extensions.Tools.GigaByte * 2)
                {
                    throw new Exception("Размер загружаемого файла больше 2ГБ.");
                }
                var status = FtpHelper.UploadFile(fileName, ServerAddress + Path.GetFileName(fileName), login, password);
            }
        }
        public void UploadFiles(string directoryName)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(directoryName);
            var directories = directoryInfo.GetDirectories("", SearchOption.AllDirectories);
            var files = directoryInfo.GetFiles("", SearchOption.AllDirectories);
            {
                var status = FtpHelper.CreateDirectory(ServerAddress + directoryInfo.Name, login, password);
            }
            foreach (var directory in directories)
            {
                var address = ServerAddress + directory.FullName.Remove(0, directoryInfo.Parent.FullName.Length+1).Replace('\\','/');
                var status = FtpHelper.CreateDirectory(address, login, password);
            }
            foreach (var file in files)
            {
                if (file.Length > Extensions.Tools.GigaByte * 2)
                {
                    throw new Exception("Размер загружаемого файла больше 2ГБ.");
                }
                var status = FtpHelper.UploadFile(file.FullName, ServerAddress + file.FullName.Remove(0, directoryInfo.Parent.FullName.Length + 1).Replace('\\', '/'), login, password);
            }
        }

        public void DeleteFiles(List<string> fileNames)
        {
            foreach (var fileName in fileNames)
            {
                if (!Path.HasExtension(fileName))
                {
                    var status = FtpHelper.DeleteDirectory(ServerAddress + fileName, login, password);
                }
                else
                {
                    var status = FtpHelper.DeleteFile(ServerAddress + fileName, login, password);
                }
            }
        }

        public void DeleteFiles(List<string> fileNames, User user)
        {
            foreach (var fileName in fileNames)
            {
                var status = FtpHelper.DeleteFile(ServerAddress + fileName, user.Login, user.Password);
            }
        }

        public List<string> GetLevel(string initialCatalog)
        {
            return FtpHelper.GetFilesList(ServerAddress + initialCatalog + "/", login, password); ;
        }

        public void CreateDirectory(string directoryName)
        {
            FtpHelper.CreateDirectory(ServerAddress + directoryName, login, password);
        }

        public List<string> GetUserCatalog()
        {
            return FtpHelper.GetFilesList(ServerAddress, login, password);
        }

        public List<string> GetUserCatalog(User user)
        {
            return FtpHelper.GetFilesList(ServerAddress, user.Login, user.Password);
        }
    }
}
