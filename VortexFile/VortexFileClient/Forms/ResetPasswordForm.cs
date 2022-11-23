using System.Text.RegularExpressions;
using VortexFileClient.Data;
using VortexFileClient.Data.Models;
using VortexFileClient.Extensions;

namespace VortexFileClient.Forms
{
    public partial class ResetPasswordForm : Form, IStackableForm
    {
        EmailMessanger? emailMessanger;
        User? user;

        int timeout;

        public event EventHandler<LoadFormEventArgs> LoadForm;
        public event EventHandler GoBack;

        public ResetPasswordForm()
        {
            InitializeComponent();
        }

        private void SendCode()
        {
            user = DAL.GetUser(LoginTextBox.Text);
            if (user != null)
            {
                emailMessanger = new EmailMessanger("vortexfile-email-confirm@yandex.ru", "Vortex File", "zbhicmvhztojxnar");
                Task.Run(() => emailMessanger.SendEmailCodeAsync(user.Email, "Код восстановления пароля"));
                tabControl.SelectedTab = CodeTabPage;
            }
        }

        private void SendCodeButton_Click(object sender, EventArgs e)
        {
            SendCode();
        }

        private void SendCodeLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SendCode();
            timeout = 60;
            SendCodeLinkLabel.Enabled = false;
            timer.Start();
        }

        private void CodeTextBox_TextChanged(object sender, EventArgs e)
        {
            if (CodeTextBox.Text.Length == 5)
            {
                if (emailMessanger.CheckCode(CodeTextBox.Text))
                {
                    tabControl.SelectedTab = PasswordTabPage;
                }
                else
                {
                    CodeTextBox.BackColor = Color.FromArgb(235, 192, 192);
                }
            }
            else
            {
                CodeTextBox.BackColor = Color.FromArgb(235, 237, 252);
            }
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (PasswordTextBox.Text != ConfirmTextBox.Text)
            {
                Feedback.WarningMessage("Пароли не совпадают");
                return;
            }
            if (!Regex.IsMatch(PasswordTextBox.Text, @"^[a-zA-ZА-Яа-яЁё0-9]{8,20}$") || user.Password.Contains(" "))
            {
                Feedback.WarningMessage("Введен некорректный пароль. Пароль должен состоять из 8 - 20 символов, которые могут быть цифрами, строчными и прописными буквами.");
                return;
            }
            try
            {
                DAL.ChangeUserPassword(user, PasswordTextBox.Text);
                Feedback.InformationMessage("Пароль успешно изменен");
                GoBack.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                Feedback.ErrorMessage(ex);
            }
        }

        private void ResetPasswordForm_Load(object sender, EventArgs e)
        {
            tabControl.ItemSize = new Size(0, 1);
            tabControl.SizeMode = TabSizeMode.Fixed;
        }

        private void PasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PasswordTextBox.UseSystemPasswordChar = ConfirmTextBox.UseSystemPasswordChar = !PasswordCheckBox.Checked;
        }

        private void CodeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timeout--;
            SendCodeLinkLabel.Text = $"Подождите {timeout} секунд для повторной отправки";
            if (timeout==0)
            {
                SendCodeLinkLabel.Enabled = true;
                timer.Stop();
            }
        }
    }
}
