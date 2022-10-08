using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VortexFileClient.Extensions;

namespace VortexFileClient.Forms
{
    public partial class ChangeAdminPasswordForm : Form, IStackableForm
    {
        public ChangeAdminPasswordForm()
        {
            InitializeComponent();
        }

        public event EventHandler<LoadFormEventArgs> LoadForm;
        public event EventHandler GoBack;

        private void EnterButton_Click(object sender, EventArgs e)
        {
            if (PasswordTextBox.Text == ConfirmTextBox.Text)
            {
                Properties.Settings.Default.AdminPassword = PasswordTextBox.Text;
                Properties.Settings.Default.Save();
                GoBack.Invoke(this, EventArgs.Empty);
            }
        }

        private void PasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PasswordTextBox.UseSystemPasswordChar = ConfirmTextBox.UseSystemPasswordChar = !PasswordCheckBox.Checked;
        }
    }
}
