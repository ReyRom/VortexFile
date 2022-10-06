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
                Path = folderBrowser.SelectedPath;
            }
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            PathTextBox.Text = Path;
        }

        private void AdminButton_Click(object sender, EventArgs e)
        {
            LoadForm.Invoke(this,new LoadFormEventArgs(new AdminAuthForm()));
        }
    }
}
