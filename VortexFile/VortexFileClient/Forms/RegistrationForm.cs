using VortexFileClient.Data;
using VortexFileClient.Data.Models;
using VortexFileClient.Extensions;

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
                Feedback.WarningMessage("Пароли не совпадают");
                return;
            }
            if (!Captcha.CheckText(CaptchaTextBox.Text))
            {
                Feedback.WarningMessage("Неправильно указан текст с картинки");
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
                Feedback.InformationMessage("Вы успешно зарегистрировались");
                try
                {
                    EmailMessanger emailMessanger = new EmailMessanger("vortexfile-email-confirm@yandex.ru", "Vortex File", "zbhicmvhztojxnar");
                    string body = "Вы зарегистрированы в системе  VortexFile";
                    Task.Run(() => emailMessanger.SendEmailAsync(newUser.Email, "Регистрация", body));
                }
                catch (Exception ex)
                {
                    Feedback.ErrorMessage(ex);
                }
                GoBack.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                Feedback.ErrorMessage(ex);
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

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            passwordStrengthIndicator.Password = PasswordTextBox.Text;
        }
    }
}
