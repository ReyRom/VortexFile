using System.IO;
﻿using System.Net;
using VortexFileClient.Data.Models;
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
            this.login = user.Login +"."+ Properties.Settings.Default.Hash;
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
                FtpHelper.DownloadFile(Path.Combine(outFolder, fileName), ServerAddress + currentDirectory + fileName, login, password);
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
                FtpHelper.UploadFile(fileName, ServerAddress + currentDirectory + Path.GetFileName(fileName), login, password);
            }
        }
        public void UploadFiles(string directoryName)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(directoryName);
            var directories = directoryInfo.GetDirectories("", SearchOption.AllDirectories);
            var files = directoryInfo.GetFiles("", SearchOption.AllDirectories);
            {
                FtpHelper.CreateDirectory(ServerAddress + currentDirectory + directoryInfo.Name, login, password);
            }
            foreach (var directory in directories)
            {
                var address = ServerAddress + directory.FullName.Remove(0, directoryInfo.Parent.FullName.Length+1).Replace('\\','/');
                FtpHelper.CreateDirectory(address, login, password);
            }
            foreach (var file in files)
            {
                if (file.Length > Extensions.Tools.GigaByte * 2)
                {
                    throw new Exception("Размер загружаемого файла больше 2ГБ.");
                }
                FtpHelper.UploadFile(file.FullName, ServerAddress + currentDirectory + file.FullName.Remove(0, directoryInfo.Parent.FullName.Length + 1).Replace('\\', '/'), login, password);
            }
        }

        public void DeleteFiles(List<string> fileNames)
        {
            foreach (var fileName in fileNames)
            {
                if (!Path.HasExtension(fileName))
                {
                    FtpHelper.DeleteDirectory(ServerAddress + currentDirectory + fileName+"/", login, password);
                }
                else
                {
                    FtpHelper.DeleteFile(ServerAddress+ currentDirectory + fileName, login, password);
                }
            }
        }

        public void DeleteFiles(List<string> fileNames, User user)
        {
            foreach (var fileName in fileNames)
            {
                FtpHelper.DeleteFile(ServerAddress +currentDirectory + fileName, user.Login + "." + Properties.Settings.Default.Hash, user.Password);
            }
        }

        public List<string> GetLevel(string initialCatalog)
        {
            return FtpHelper.GetFilesList(ServerAddress + initialCatalog + "/", login, password); ;
        }

        public void CreateDirectory(string directoryName)
        {
            FtpHelper.CreateDirectory(ServerAddress + currentDirectory + directoryName, login, password);
        }

        public List<string> GetUserCatalog()
        {
            return FtpHelper.GetFilesList(ServerAddress, login, password);
        }

        public List<string> GetUserCatalog(User user)
        {
            return FtpHelper.GetFilesList(ServerAddress, user.Login + "." + Properties.Settings.Default.Hash, user.Password);
        }
    }
}
