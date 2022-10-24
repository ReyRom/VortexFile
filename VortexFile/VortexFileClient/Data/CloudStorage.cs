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
            switch (status)
            {
                case FtpStatusCode.AccountNeeded:
                    throw new Exception("Возникла непредвиденная ошибка: \"Непредоставлена учетная запись пользователя\"." +
                        "\nВойди в свою учётную запись еще раз или обратитетсь к системному администратору.");
                case FtpStatusCode.ActionAbortedLocalProcessingError:
                    throw new Exception("Возникла непредвиденная ошибка: \"Препятствующая завершению запрошенной операции\"." +
                        "\nПопробуйте еще раз или обратитетсь к системному администратору.");
                case FtpStatusCode.ActionAbortedUnknownPageType:
                    throw new Exception("Возникла непредвиденная ошибка:\"Запрошенное действие не может быть выполнено, потому что неизвестен указанный тип страницы\"." +
                        "\nПопробуйте еще раз или обратитетсь к системному администратору.");
                case FtpStatusCode.ActionNotTakenFilenameNotAllowed:
                    throw new Exception("Возникла непредвиденная ошибка:\"Запрошенное действие не может быть выполнено с указанным файлом\"." +
                        "\nПопробуйте еще раз или обратитетсь к системному администратору.");
                case FtpStatusCode.ActionNotTakenFileUnavailable:
                    throw new Exception("Возникла непредвиденная ошибка: \"Запрошенное действие не может быть выполнено с указанным файлом, потому что файл недоступен\"." +
                        "\nПопробуйте еще раз или обратитетсь к системному администратору.");
                case FtpStatusCode.ArgumentSyntaxError:
                    throw new Exception("Возникла непредвиденная ошибка: \"Один или несколько аргументов команды содержат синтаксическую ошибку\"." +
                        "\nПопробуйте еще раз или обратитетсь к системному администратору.");
                case FtpStatusCode.BadCommandSequence:
                    throw new Exception("Возникла непредвиденная ошибка: \"Запрошенное действие не может быть выполнено с указанным файлом, потому что файл недоступен\"." +
                        "\nПопробуйте еще раз или обратитетсь к системному администратору.");
                case FtpStatusCode.CantOpenData:
                    throw new Exception("Возникла непредвиденная ошибка: \"Подключение к данным не может быть открыто\"." +
                        "\nПопробуйте еще раз или обратитетсь к системному администратору.");
                case FtpStatusCode.CommandNotImplemented:
                    throw new Exception("Возникла непредвиденная ошибка: \"Команда не реализована на FTP-сервере\"." +
                        "\nПопробуйте еще раз или обратитетсь к системному администратору.");
                case FtpStatusCode.CommandSyntaxError:
                    throw new Exception("Возникла непредвиденная ошибка: \"Команда содержит синтаксическую ошибку или не является командой, распознаваемой сервером\"." +
                        "\nПопробуйте еще раз или обратитетсь к системному администратору.");
                case FtpStatusCode.ConnectionClosed:
                    throw new Exception("Возникла непредвиденная ошибка: \"Подключение уже было закрыто\"." +
                        "\nПопробуйте еще раз или обратитетсь к системному администратору.");
                case FtpStatusCode.FileActionAborted:
                    throw new Exception("Возникла непредвиденная ошибка: \"Запрошенное действие выполнить невозможно\"." +
                        "\nПопробуйте еще раз или обратитетсь к системному администратору.");
                case FtpStatusCode.NotLoggedIn:
                    throw new Exception("Возникла непредвиденная ошибка: \"Сведения для входа на сервер должны быть предоставлены серверу\"." +
                        "\nПопробуйте еще раз или обратитетсь к системному администратору.");
                case FtpStatusCode.ServiceNotAvailable:
                    throw new Exception("Возникла непредвиденная ошибка: \"Служба недоступна\"." +
                        "\nПопробуйте еще раз или обратитетсь к системному администратору.");
                default:
                    return;
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
