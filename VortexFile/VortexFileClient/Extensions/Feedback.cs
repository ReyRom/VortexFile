using System.Data;

namespace VortexFileClient.Extensions
{
    public static class Feedback
    {
        public static void ErrorMessage(Exception ex = null)
        {
            if (ex == null)
            {
                System.Windows.Forms.MessageBox.Show("Возникла непредвиденная ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ex is DataException)
            {
                System.Windows.Forms.MessageBox.Show("При работе с данными возникла ошибка, попробуйте снова. " +
                    "Если ошибка не исчезнет, обратитесь к администратору приложения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            System.Windows.Forms.MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
