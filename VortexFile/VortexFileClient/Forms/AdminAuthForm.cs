using VortexFileClient.Extensions;

namespace VortexFileClient.Forms
{
    public partial class AdminAuthForm : Form, IStackableForm
    {
        public AdminAuthForm()
        {
            InitializeComponent();
        }

        public event EventHandler<LoadFormEventArgs> LoadForm;
        public event EventHandler GoBack;

        private void EnterButton_Click(object sender, EventArgs e)
        {
            if (PasswordTextBox.Text == Properties.Settings.Default.AdminPassword)
            {
                PasswordTextBox.Text = String.Empty;
                LoadForm.Invoke(this, new LoadFormEventArgs(new AdministrationForm()));
            }
            else
            {
                Feedback.WarningMessage("Неверный пароль администратора");
            }
        }

        private void PasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PasswordTextBox.UseSystemPasswordChar = !PasswordCheckBox.Checked;
        }

        private void AdminAuthForm_Load(object sender, EventArgs e)
        {
            PasswordTextBox.Focus();
        }
    }
}
