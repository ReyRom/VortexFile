using System.Text;
using System.Text.RegularExpressions;
using VortexFileClient.Data;
using VortexFileClient.Data.Models;
using VortexFileClient.Extensions;

namespace VortexFileClient.Forms
{
    public partial class AdministrationForm : Form, IStackableForm
    {
        private string? tempVar = null;
        private string? email = null;

        public event EventHandler<LoadFormEventArgs> LoadForm;
        public event EventHandler GoBack;

        public AdministrationForm()
        {
            InitializeComponent();
        }

        private async void AdministrationForm_LoadAsync(object sender, EventArgs e)
        {
            UsersDataGridView.AutoGenerateColumns = false;
            await RenewAsync();
        }

        private async Task RenewAsync()
        {
            UsersDataGridView.Visible = false;
            Waiting.Visible = true;
            try
            {
                UsersDataGridView.DataSource = await DAL.GetUsersAsync();
                Waiting.Visible = false;
                UsersDataGridView.Visible = true;
            }
            catch (Exception ex)
            {
                Feedback.ErrorMessage(ex);
            }
        }

        private void UsersDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            User user = UsersDataGridView.Rows[e.RowIndex].DataBoundItem as User;
            StringBuilder errors = new StringBuilder();
            User tmp = null;
            try
            {
                tmp = DAL.GetUserByEmail(user.Email);
            }
            catch (Exception ex)
            {
                Feedback.ErrorMessage(ex);
            }
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
                Feedback.WarningMessage(errors.ToString());
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
            try
            {
                DAL.UpdateUser(user);
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
                Feedback.ErrorMessage(ex);
            }
        }

        private void UsersDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            tempVar = UsersDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString() ?? String.Empty;
            email = (UsersDataGridView.Rows[e.RowIndex].DataBoundItem as User).Email;
        }

        private async void UsersDataGridView_CellContentClickAsync(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DeleteColumn.Index)
            {
                if (Feedback.QuestionMessage("Вы уверены, что хотите удалить эту учетную запись?"))
                {
                    var user = UsersDataGridView.Rows[e.RowIndex].DataBoundItem as User;
                    email = user.Email;
                    try
                    {
                        CloudStorage cloud = new CloudStorage();
                        LocalStorage local = new LocalStorage();
                        DAL.DeleteUser(user);
                    }
                    catch (Exception ex)
                    {
                        Feedback.ErrorMessage(ex);
                        return;
                    }
                    await RenewAsync();
                    try
                    {
                        EmailMessanger emailMessanger = new EmailMessanger("vortexfile-email-confirm@yandex.ru", "Vortex File", "zbhicmvhztojxnar");
                        string body = "Ваша учетная запись удалена";
                        await emailMessanger.SendEmailAsync(email, "Ограничение доступа", body);
                    }
                    catch (Exception ex)
                    {
                        Feedback.ErrorMessage(ex);
                    }
                }
            }
        }

        private async void AddButton_ClickAsync(object sender, EventArgs e)
        {
            LoadForm.Invoke(this, new LoadFormEventArgs(new RegistrationForm()));
            await RenewAsync();
        }

        private void ChangeAdminPasswordLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadForm.Invoke(this, new LoadFormEventArgs(new ChangeAdminPasswordForm()));
        }
    }
}
