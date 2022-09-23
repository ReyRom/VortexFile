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

namespace VortexFileClient.Forms
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void RenewCaptchaButton_Click(object sender, EventArgs e)
        {
            Captcha.Renew();
        }

        private void GoBackLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Program.MainForm.GoBack();
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
                Program.MainForm.GoBack();
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
    }
}
