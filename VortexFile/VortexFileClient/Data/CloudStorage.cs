namespace VortexFileClient.Data
{
    internal class CloudStorage
    {
        public event Action FilesChangeEvent;
        private string serverAddress = "ftp://91.122.211.144:50021/";
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
                if (new FileInfo(fileName).Length > Extensions.Constants.GigaByte * 2)
                {
                    throw new Exception("Размер загружаемого файла больше 2ГБ.");
                }
                var status = FtpHelper.UploadFile(fileName, serverAddress + Path.GetFileName(fileName), login, password);
            }
            FilesChangeEvent?.Invoke();
        }

        public void DeleteFiles(List<string> fileNames)
        {
            foreach (var fileName in fileNames)
            {
                var status = FtpHelper.DeleteFile(serverAddress + fileName, login, password);
            }
            FilesChangeEvent?.Invoke();
        }

        public List<string> GetUserCatalog()
        {
            return FtpHelper.GetFilesList(serverAddress, login, password);
        }
    }
}
