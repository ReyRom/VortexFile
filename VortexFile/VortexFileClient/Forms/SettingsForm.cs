using VortexFileClient.Extensions;

namespace VortexFileClient.Forms
{
    public partial class SettingsForm : Form, IStackableForm
    {
        private string Path
        {
            get
            {
                return Properties.Settings.Default.Path;
            }
            set
            {
                Properties.Settings.Default.Path = value;
                Properties.Settings.Default.Save();
                PathTextBox.Text = value;
            }
        }
        public SettingsForm()
        {
            InitializeComponent();
        }

        public event EventHandler<LoadFormEventArgs> LoadForm;
        public event EventHandler GoBack;

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                PathTextBox.Text = folderBrowser.SelectedPath;
            }
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            PathTextBox.Text = Path;
        }

        private void AdministrationLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadForm.Invoke(this, new LoadFormEventArgs(new AdminAuthForm()));
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(PathTextBox.Text))
            {
                Directory.CreateDirectory(PathTextBox.Text);
                try
                {
                    File.Move(System.IO.Path.Combine(Properties.Settings.Default.Path, "VortexFile.zip"), System.IO.Path.Combine(PathTextBox.Text, "VortexFile.zip"));
                }
                catch (Exception){}
            }
            Path = PathTextBox.Text;
        }

    }
}
