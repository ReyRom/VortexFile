using VortexFileClient.Data.Models;
using VortexFileClient.Extensions;

namespace VortexFileClient.Data
{
    internal class CloudStorage
    {
        private string ServerAddress { get => Properties.Settings.Default.FtpAddress; }
        private string login = string.Empty;
        private string password = string.Empty;

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

        public void DeleteFiles(List<string> fileNames)
        {
            foreach (var fileName in fileNames)
            {
                var status = FtpHelper.DeleteFile(ServerAddress + fileName, login, password);
            }
        }

        public void DeleteFiles(List<string> fileNames, User user)
        {
            foreach (var fileName in fileNames)
            {
                var status = FtpHelper.DeleteFile(ServerAddress + fileName, user.Login, user.Password);
            }
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
