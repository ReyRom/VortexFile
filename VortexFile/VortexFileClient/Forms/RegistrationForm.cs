using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VortexFileClient.Data;
using VortexFileClient.Extensions;
using VortexFileClient.Models;

namespace VortexFileClient.Forms
{
    public partial class RegistrationForm : Form, IStackableForm
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        public event EventHandler<LoadFormEventArgs> LoadForm;
        public event EventHandler GoBack;

        private void RenewCaptchaButton_Click(object sender, EventArgs e)
        {
            Captcha.Renew();
        }

        private void GoBackLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GoBack.Invoke(this, EventArgs.Empty);
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            Captcha.Renew();
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            if (PasswordTextBox.Text != ConfirmTextBox.Text)
            {
                Feedback.WarningMessage("Пароли не совпадают.");
                return;
            }
            if (!Captcha.CheckText(CaptchaTextBox.Text))
            {
                Feedback.WarningMessage("Неправильно указан текст с картинки.");
                return;
            }
            User newUser = new User()
            {
                Login = LoginTextBox.Text,
                Email = EmailTextBox.Text,
                Password = PasswordTextBox.Text,
                Username = UsernameTextBox.Text,
                Phone = PhoneTextBox.Text
            };
            try
            {
                Session.Registration(newUser);
                Feedback.InformationMessage("Вы успешно зарегистрировались.");
                try
                {
                    EmailMessanger emailMessanger = new EmailMessanger("vortexfile-email-confirm@yandex.ru", "Vortex File", "zbhicmvhztojxnar");
                    string body = "Вы зарегистрированы в системе  VortexFile";
                    Task.Run(() => emailMessanger.SendEmailAsync(newUser.Email, "Ограничение доступа", body));
                }
                catch (Exception ex)
                {
                    Extensions.Feedback.ErrorMessage(ex);
                }
                GoBack.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                Feedback.WarningMessage(ex.Message);
            }
        }

        private void RegistrationForm_Shown(object sender, EventArgs e)
        {
            LoginTextBox.Focus();
        }
        private void PasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PasswordTextBox.UseSystemPasswordChar = ConfirmTextBox.UseSystemPasswordChar = !PasswordCheckBox.Checked;
        }

        private void CaptchaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }
    }
}
