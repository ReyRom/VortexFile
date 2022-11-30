using VortexFileClient.Data.Models;
using VortexFileClient.Extensions;
using MessageBox = VortexFileClient.Extensions.MessageBox;

namespace VortexFileClient.Forms
{
    public partial class AuthorizationForm : Form, IStackableForm
    {
        public AuthorizationForm()
        {
            InitializeComponent();
            LoginTextBox.Text = Data.Session.Login;
            PasswordTextBox.Text = Data.Session.Password;
            RememberCheckBox.Checked = LoginTextBox.Text != String.Empty;
        }

        public event EventHandler<LoadFormEventArgs> LoadForm;
        public event EventHandler GoBack;

        private void EnterButton_Click(object sender, EventArgs e)
        {
            if (OfflineCheckBox.Checked)
            {
                Data.Session.AuthorizeOffline();
                Feedback.InformationMessage("Вы успешно авторизованы");
                LoadForm.Invoke(this, new LoadFormEventArgs(new FileManagerForm(false)));
                return;
            }
            User user = null;
            try
            {
                user = Data.Session.Authorize(LoginTextBox.Text, PasswordTextBox.Text);
            }
            catch (Exception ex)
            {
                Feedback.ErrorMessage(ex);
                return;
            }
            if (user == null)
            {
                Feedback.WarningMessage("Неправильный логин/email или пароль");
            }
            else
            {
                if (RememberCheckBox.Checked)
                {
                    Data.Session.Login = LoginTextBox.Text;
                    Data.Session.Password = PasswordTextBox.Text;
                }
                else
                {
                    Data.Session.Login = Data.Session.Password = String.Empty;
                }
                Feedback.InformationMessage("Вы успешно авторизованы");
                LoadForm.Invoke(this, new LoadFormEventArgs(new FileManagerForm()));
            }
        }

        private void RegistrationLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadForm.Invoke(this, new LoadFormEventArgs(new RegistrationForm()));
        }

        private void ResetPasswordLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadForm.Invoke(this, new LoadFormEventArgs(new ResetPasswordForm()));
        }

        private void RememberCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            RememberCheckBox.ImageIndex = RememberCheckBox.Checked ? 1 : 0;
        }

        private void PasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PasswordTextBox.UseSystemPasswordChar = !PasswordCheckBox.Checked;
        }

        private void AuthorizationForm_Shown(object sender, EventArgs e)
        {
            LoginTextBox.Focus();
        }
    }
}
