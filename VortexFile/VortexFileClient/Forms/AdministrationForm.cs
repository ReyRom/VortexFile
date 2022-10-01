using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using VortexFileClient.Data;
using VortexFileClient.Models;

namespace VortexFileClient.Forms
{
    public partial class AdministrationForm : Form
    {
        private string tempVar;
        private string email;
        public AdministrationForm()
        {
            InitializeComponent();
        }

        private void AdministrationForm_Load(object sender, EventArgs e)
        {
            UsersDataGridView.AutoGenerateColumns = false;
            Renew();
        }

        private void Renew() {
            UsersDataGridView.DataSource = DAL.GetUsers();
        }

        private void UsersDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            User user = UsersDataGridView.Rows[e.RowIndex].DataBoundItem as User;
            StringBuilder errors = new StringBuilder();
            User tmp = DAL.GetUserByEmail(user.Email);
            if (tmp != null && tmp.IdUser != user.IdUser)
            {
                errors.AppendLine("Почта занята другим пользователем.");
            }
            if (!Regex.IsMatch(user.Email, @"^([A-Za-z0-9]+[.-_])*[A-Za-z0-9]+@[A-Za-z0-9-]+(\.[A-Z|a-z]{2,})+$"))
            {
                errors.AppendLine("Введен некорректный почтовый адрес.");
            }
            if (!String.IsNullOrWhiteSpace(user.Phone) && !Regex.IsMatch(user.Phone, @"^7|8+[0-9]{10}$"))
            {
                errors.AppendLine("Введен некорректный номер телефона.");
            }
            if (errors.Length > 0)
            {
                Extensions.Feedback.WarningMessage(errors.ToString());
                UsersDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = tempVar;
                return;
            }
            else
            {
                if (String.IsNullOrWhiteSpace(user.Phone))
                {
                    user.Phone = null;
                }
                if (String.IsNullOrWhiteSpace(user.Username))
                {
                    user.Username = null;
                }
            }
            DAL.UpdateUser(user);
            try
            {
                EmailMessanger emailMessanger = new EmailMessanger("vortexfile-email-confirm@yandex.ru", "Vortex File", "zbhicmvhztojxnar");
                string body = "Данные вашей учётной записи изменены.";
                if (email != user.Email)
                {
                    body += $" Указан новый почтовый адрес: {user.Email}";
                }
                Task.Run(() => emailMessanger.SendEmailAsync(email, "Редактирование учётной записи", body));
            }
            catch (Exception ex)
            {
                Extensions.Feedback.ErrorMessage(ex);
            }
        }

        private void UsersDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            tempVar = UsersDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString() ?? String.Empty;
            email = (UsersDataGridView.Rows[e.RowIndex].DataBoundItem as User).Email;
        }

        private void UsersDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DeleteColumn.Index)
            {
                if (Extensions.Feedback.QuestionMessage("Вы уверены, что хотите удалить эту учетную запись"))
                {
                    var user = UsersDataGridView.Rows[e.RowIndex].DataBoundItem as User;
                    email = user.Email;
                    DAL.DeleteUser(user);
                    Renew();
                    try
                    {
                        EmailMessanger emailMessanger = new EmailMessanger("vortexfile-email-confirm@yandex.ru", "Vortex File", "zbhicmvhztojxnar");
                        string body = "Ваша учетная запись удалена";
                        Task.Run(() => emailMessanger.SendEmailAsync(email, "Ограничение доступа", body));
                    }
                    catch (Exception ex)
                    {
                        Extensions.Feedback.ErrorMessage(ex);
                    }
                }
            }
        }
    }
}
