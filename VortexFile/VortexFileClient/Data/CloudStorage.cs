using System.Net;

namespace VortexFileClient.Data
{
    internal class CloudStorage
    {
        private string serverAddress = "ftp://25.36.141.142/";
        private string login = string.Empty;
        private string password = string.Empty;

        public CloudStorage(string login, string password)
        {
            this.login = login;
            this.password = password;
        }

        public void DownloadFiles(List<string> fileNames, string outFolder)
        {
            foreach (var fileName in fileNames)
            {
                var status = FtpHelper.DownloadFile(Path.Combine(outFolder, fileName), serverAddress + fileName, login, password);
                
            }
        }

        public void UploadFiles(List<string> fileNames)
        {
            foreach (var fileName in fileNames)
            {
                var status = FtpHelper.UploadFile(fileName, serverAddress+ Path.GetFileName(fileName), login, password);
                
            }
        }

        public void DeleteFiles(List<string> fileNames)
        {
            foreach (var fileName in fileNames)
            {
                var status = FtpHelper.DeleteFile(serverAddress + fileName, login, password);
                
            }
        }

        public List<string> GetUserCatalog()
        {
            return FtpHelper.GetFilesList(serverAddress, login, password);
        }
    }
}
