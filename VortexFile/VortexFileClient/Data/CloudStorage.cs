using System.IO;
﻿using System.Net;
using System.Xml.Linq;
using VortexFileClient.Data.Models;
using VortexFileClient.Extensions;
using static System.Net.WebRequestMethods;
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

        private void DAL_OnUserDelete(object? sender, UserEventArgs e)
        {
            DeleteFiles(GetUserCatalog(e.User), e.User);
        }

        public void DownloadFiles(List<string> fileNames, string outFolder, string path="")
        {
            foreach (var fileName in fileNames)
            {
                if(fileName.Last() == '/')
                {
                    var newDir = Directory.CreateDirectory(Path.Combine(outFolder, fileName));
                    path += fileName;
                    DownloadFiles(GetLevel(currentDirectory + fileName), newDir.FullName, path);
                }
                else
                {
                    FtpHelper.DownloadFile(Path.Combine(outFolder, fileName), ServerAddress + currentDirectory + path + fileName, login, password);
                }
            }
        }

        public void UploadFiles(List<string> fileNames)
        {
            var files = GetLevel(currentDirectory);
            foreach (var fileName in fileNames)
            {
                var name = Path.GetFileName(fileName);
                if (files.Contains(name))
                {
                    if (!Feedback.QuestionMessage($"Файл с именем {name} уже есть в каталоге. Заменить?"))
                    {
                        continue;
                    }
                }
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
            var cloudFiles = GetLevel(currentDirectory);
            if (cloudFiles.Contains(directoryInfo.Name+"/"))
            {
                cloudFiles = GetAllLevels($"{currentDirectory}/{directoryInfo.Name}");
            }
            else
            {
                cloudFiles.Clear();
                FtpHelper.CreateDirectory(ServerAddress + currentDirectory + directoryInfo.Name, login, password);
            }
            foreach (var directory in directories)
            {
                var address = ServerAddress + directory.FullName.Remove(0, directoryInfo.Parent.FullName.Length + 1).Replace('\\', '/');
                if (cloudFiles.Count > 0 && !cloudFiles.Contains(directoryInfo.Name))
                {
                    FtpHelper.CreateDirectory(address, login, password);
                }
            }
            foreach (var file in files)
            {
                if (cloudFiles.Count > 0 && cloudFiles.Contains(file.Name))
                {
                    if (!Feedback.QuestionMessage($"Файл с именем {file.Name} уже есть в каталоге. Заменить?"))
                    {
                        continue;
                    }
                }
                if (file.Length > Extensions.Tools.GigaByte * 2)
                {
                    throw new Exception("Размер загружаемого файла больше 2ГБ.");
                }
                FtpHelper.UploadFile(file.FullName, ServerAddress + currentDirectory + file.FullName.Remove(0, directoryInfo.Parent.FullName.Length + 1).Replace('\\', '/'), login, password);
            }
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
                UploadFiles(item);
            }
            UploadFiles(files);
        }

        public void DeleteFiles(List<string> fileNames)
        {
            foreach (var fileName in fileNames)
            {
                if (!Path.HasExtension(fileName))
                {
                    FtpHelper.DeleteDirectory(ServerAddress + currentDirectory + fileName + "/", login, password);
                }
                else
                {
                    FtpHelper.DeleteFile(ServerAddress + currentDirectory + fileName, login, password);
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
            return FtpHelper.GetFilesList(ServerAddress + initialCatalog + "/", login, password);
        }

        public List<string> GetAllLevels(string initialCatalog)
        {
            List<string> files = FtpHelper.GetFilesList(ServerAddress + initialCatalog + "/", login, password);
            List<string> allFiles = files.ToList();
            foreach (var file in files)
            {
                if (file.Last() == '/')
                {
                    allFiles.AddRange(FtpHelper.GetFilesList(ServerAddress + initialCatalog + "/" + file, login, password));
                }
            }
            return allFiles;
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
