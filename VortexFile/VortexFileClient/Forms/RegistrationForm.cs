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
    public partial class RegistrationForm : Form
    {
        bool isCaptchaConfirmed = false;
        bool IsCaptchaConfirmed
        {
            set
            {
                EnterButton.Enabled = value;
            }
        }
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void RenewCaptchaButton_Click(object sender, EventArgs e)
        {
            Captcha.Renew();
        }

        private void GoBackButton_Click(object sender, EventArgs e)
        {
            Program.MainForm.GoBack();
        }

        private void ConfirmCaptchaButton_Click(object sender, EventArgs e)
        {
            if (Captcha.CheckText(CaptchaTextBox.Text))
            {
                IsCaptchaConfirmed = true;
            }
            else
            {
                Extensions.Feedback.WarningMessage("Неверно, попробуйте снова");
                Captcha.Renew();
            }
        }

        private void GoBackLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Program.MainForm.GoBack();
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            Captcha.Renew();
        }
    }
}
