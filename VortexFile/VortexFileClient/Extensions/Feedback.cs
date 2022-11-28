using MySql.Data.MySqlClient;
using System.Data;
using System.Net;

namespace VortexFileClient.Extensions
{
    public static class Feedback
    {
        public static void ErrorMessage(Exception ex = null)
        {
            if (ex == null)
            {
                MessageBox.Show("Возникла непредвиденная ошибка.\nПопробуйте еще раз или обратитетсь к системному администратору.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ex is DataException)
            {
                MessageBox.Show("При работе с данными возникла непредвиденная ошибка." +
                    "\nПопробуйте еще раз или обратитетсь к системному администратору.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ex is WebException web)
            {
                
                MessageBox.Show(GetMessage(((FtpWebResponse)web.Response).StatusCode) +
                    "\nПопробуйте еще раз или обратитетсь к системному администратору.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ex.InnerException is MySqlException)
            {
                MessageBox.Show("Отсутствует подключение к серверу базы данных." +
                    "\nПопробуйте еще раз или обратитетсь к системному администратору.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static string GetMessage(FtpStatusCode status)
        {
            switch (status)
            {
                case FtpStatusCode.AccountNeeded:
                    return "Непредоставлена учетная запись пользователя. Код ошибки - 532";
                case FtpStatusCode.ActionAbortedLocalProcessingError:
                    return "Возникло препятствие завершению запрошенной операции. Код ошибки - 451";
                case FtpStatusCode.ActionAbortedUnknownPageType:
                    return "Запрошенное действие не может быть выполнено, потому что неизвестен указанный тип страницы. Код ошибки - 551";
                case FtpStatusCode.ActionNotTakenFilenameNotAllowed:
                    return "Запрошенное действие не может быть выполнено с указанным файлом. Код ошибки - 553";
                case FtpStatusCode.ActionNotTakenFileUnavailable:
                    return "Запрошенное действие не может быть выполнено с указанным файлом, потому что файл недоступен. Код ошибки - 550";
                case FtpStatusCode.ArgumentSyntaxError:
                    return "Один или несколько аргументов команды содержат синтаксическую ошибку. Код ошибки - 501";
                case FtpStatusCode.BadCommandSequence:
                    return "Запрошенное действие не может быть выполнено с указанным файлом, потому что файл недоступен. Код ошибки - 503";
                case FtpStatusCode.CantOpenData:
                    return "Подключение к данным не может быть открыто. Код ошибки - 425";
                case FtpStatusCode.CommandNotImplemented:
                    return "Команда не реализована на FTP-сервере. Код ошибки - 502";
                case FtpStatusCode.CommandSyntaxError:
                    return "Команда содержит синтаксическую ошибку или не является командой, распознаваемой сервером. Код ошибки - 500";
                case FtpStatusCode.ConnectionClosed:
                    return "Подключение уже было закрыто. Код ошибки - 426";
                case FtpStatusCode.FileActionAborted:
                    return "Запрошенное действие выполнить невозможно. Код ошибки - 552";
                case FtpStatusCode.NotLoggedIn:
                    return "Сведения для входа на сервер должны быть предоставлены серверу. Код ошибки - 530";
                case FtpStatusCode.ServiceNotAvailable:
                    return "Служба недоступна. Код ошибки - 421";
                default:
                    return "При работе с FTP-сервером возникла непредвиденная ошибка или отсутствует подключение к FTP-серверу.";
            }
        }
        public static void InformationMessage(string message)
        {
            MessageBox.Show(message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void WarningMessage(string message)
        {
            MessageBox.Show(message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static bool QuestionMessage(string message)
        {
            return MessageBox.Show(message, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }
    }
}
