using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VortexFileClient.Forms
{
    public partial class AuthorizationForm : Form
    {
        public AuthorizationForm()
        {
            InitializeComponent();
            LoginTextBox.Text = Data.Session.Login;
            PasswordTextBox.Text = Data.Session.Password;
            RememberCheckBox.Checked = LoginTextBox.Text != String.Empty;
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            if (Data.Session.Authorize(LoginTextBox.Text, PasswordTextBox.Text) == null)
            {
                Extensions.Feedback.WarningMessage("Неправильный логин/email или пароль.");
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
                Program.MainForm.LoadForm(new FIleManagerForm());
            }
        }

        private void RegistrationLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Program.MainForm.LoadForm(new RegistrationForm());
        }

        private void ResetPasswordLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Program.MainForm.LoadForm(new ResetPasswordForm());
        }

        private void RememberCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            RememberCheckBox.ImageIndex = RememberCheckBox.Checked ? 1 : 0;
        }
    }
}
