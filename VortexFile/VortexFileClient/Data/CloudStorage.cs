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

        public void DownloadFiles(List<string> fileNames, string outFolder)
        {
            foreach (var fileName in fileNames)
            {
                if(fileName.Last() == '/')
                {
                    var dir = Directory.CreateDirectory(Path.Combine(outFolder, fileName));
                    DownloadDirectory(GetAllLevels(currentDirectory + fileName), dir.FullName);
                }
                else
                {
                    FtpHelper.DownloadFile(Path.Combine(outFolder, fileName), ServerAddress + currentDirectory + fileName, login, password);
                }
            }
        }
        public void DownloadDirectory(List<string> fileNames, string outFolder)
        {
            foreach (var fileName in fileNames)
            {
                if (fileName.Last() == '/')
                {
                    Directory.CreateDirectory(Path.Combine(outFolder, Path.GetFileName(fileName)));
                }
                else
                {
                    FtpHelper.DownloadFile(Path.Combine(outFolder, Path.GetFileName(fileName)), ServerAddress + fileName, login, password);
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
                    if (!Feedback.QuestionMessage($"Файл с именем {name} уже есть в облачном хранилище. Заменить?"))
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
            var parentPathLength = directoryInfo.Parent.FullName.Length;
            var directories = directoryInfo.GetDirectories("", SearchOption.AllDirectories);
            var files = directoryInfo.GetFiles("", SearchOption.AllDirectories);
            var cloudFiles = GetLevel(currentDirectory);
            if (cloudFiles.Contains(directoryInfo.Name + "/"))
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
                var path = directory.FullName.Remove(0, parentPathLength).Replace('\\', '/').Replace("//", "/") + "/";
                if (cloudFiles.Count < 0 || !cloudFiles.Contains(path))
                {
                    var address = ServerAddress + directory.FullName.Remove(0, directoryInfo.Parent.FullName.Length + 1).Replace('\\', '/');
                    FtpHelper.CreateDirectory(address, login, password);
                }
            }
            foreach (var file in files)
            {
                var match = cloudFiles.FirstOrDefault(f => f == file.FullName.Remove(0, parentPathLength).Replace('\\', '/'));
                if (cloudFiles.Count < 0 || match != null)
                {
                    if (!Feedback.QuestionMessage($"Файл с именем {match} уже есть в облачном хранилище. Заменить?"))
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
            List<string> allFiles = new List<string>();
            foreach (var file in files)
            {
                var level = (initialCatalog + "/" + file).Replace("//", "/");
                allFiles.Add(level);
                if (file.Last() == '/')
                {
                    allFiles.AddRange(GetAllLevels(level));
                }
            }
            return allFiles;
        }

        public void CreateDirectory(string directoryName)
        {
            FtpHelper.CreateDirectory(ServerAddress + currentDirectory + directoryName, login, password);
        }

        public List<string> GetUserCatalog(User user)
        {
            return FtpHelper.GetFilesList(ServerAddress, user.Login + "." + Properties.Settings.Default.Hash, user.Password);
        }
    }
}
