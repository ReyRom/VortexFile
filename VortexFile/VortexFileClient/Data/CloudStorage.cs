using System.Net;
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

        private void ThrowException(FtpStatusCode status)
        {
            string exMessage = String.Empty;
            switch (status)
            {
                case FtpStatusCode.AccountNeeded:
                    exMessage = "Непредоставлена учетная запись пользователя. Код ошибки - 532";
                    break;
                case FtpStatusCode.ActionAbortedLocalProcessingError:
                    exMessage = "Возникло препятствие завершению запрошенной операции. Код ошибки - 451";
                    break;
                case FtpStatusCode.ActionAbortedUnknownPageType:
                    exMessage = "Запрошенное действие не может быть выполнено, потому что неизвестен указанный тип страницы. Код ошибки - 551";
                    break;
                case FtpStatusCode.ActionNotTakenFilenameNotAllowed:
                    exMessage = "Запрошенное действие не может быть выполнено с указанным файлом. Код ошибки - 553";
                    break;
                case FtpStatusCode.ActionNotTakenFileUnavailable:
                    exMessage = "Запрошенное действие не может быть выполнено с указанным файлом, потому что файл недоступен. Код ошибки - 550";
                    break;
                case FtpStatusCode.ArgumentSyntaxError:
                    exMessage = "Один или несколько аргументов команды содержат синтаксическую ошибку. Код ошибки - 501";
                    break;
                case FtpStatusCode.BadCommandSequence:
                    exMessage = "Запрошенное действие не может быть выполнено с указанным файлом, потому что файл недоступен. Код ошибки - 503";
                    break;
                case FtpStatusCode.CantOpenData:
                    exMessage = "Подключение к данным не может быть открыто. Код ошибки - 425";
                    break;
                case FtpStatusCode.CommandNotImplemented:
                    exMessage = "Команда не реализована на FTP-сервере. Код ошибки - 502";
                    break;
                case FtpStatusCode.CommandSyntaxError:
                    exMessage = "Команда содержит синтаксическую ошибку или не является командой, распознаваемой сервером. Код ошибки - 500";
                    break;
                case FtpStatusCode.ConnectionClosed:
                    exMessage = "Подключение уже было закрыто. Код ошибки - 426";
                    break;
                case FtpStatusCode.FileActionAborted:
                    exMessage = "Запрошенное действие выполнить невозможно. Код ошибки - 552";
                    break;
                case FtpStatusCode.NotLoggedIn:
                    exMessage = "Сведения для входа на сервер должны быть предоставлены серверу. Код ошибки - 530";
                    break;
                case FtpStatusCode.ServiceNotAvailable:
                    exMessage = "Служба недоступна. Код ошибки - 421";
                    break;
            }
            if (exMessage != String.Empty)
            {
                throw new Exception($"Возникла непредвиденная ошибка: \"{exMessage}\"." +
                    "\nВойди в свою учётную запись еще раз или обратитетсь к системному администратору.");
            }
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
                ThrowException(status);
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
                ThrowException(status);
            }
        }

        public void DeleteFiles(List<string> fileNames)
        {
            foreach (var fileName in fileNames)
            {
                var status = FtpHelper.DeleteFile(ServerAddress + fileName, login, password);
                ThrowException(status);
            }
        }

        public void DeleteFiles(List<string> fileNames, User user)
        {
            foreach (var fileName in fileNames)
            {
                var status = FtpHelper.DeleteFile(ServerAddress + fileName, user.Login, user.Password);
                ThrowException(status);
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
