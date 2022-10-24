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
            if (ex is WebException)
            {
                MessageBox.Show("Отсутствует подключение к серверу." +
                    "\nПопробуйте еще раз или обратитетсь к системному администратору.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void InformationMessage(string message)
        {
            System.Windows.Forms.MessageBox.Show(message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void WarningMessage(string message)
        {
            System.Windows.Forms.MessageBox.Show(message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static bool QuestionMessage(string message)
        {
            return System.Windows.Forms.MessageBox.Show(message, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }
    }
}
