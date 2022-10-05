using Ionic.Zip;
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
    public partial class FileManagerForm : Form, IStackableForm
    {
        private LocalStorage localStorage = new LocalStorage();

        public event EventHandler<LoadFormEventArgs> LoadForm;
        public event EventHandler GoBack;

        public FileManagerForm()
        {
            InitializeComponent();
        }

        private void FIleManagerForm_Load(object sender, EventArgs e)
        {
            label2.Text = Data.Session.CurrentUser.Login;
            LoadData();
        }

        private void LoadData()
        {
            FileManagerListView.Items.Clear();
            foreach (var item in localStorage.GetUserCatalog(Properties.Settings.Default.ZipPassword))
            {
                ListViewItem viewItem = new ListViewItem(item.FileName, GetIndex(Path.GetExtension(item.FileName)));
                FileManagerListView.Items.Add(viewItem);
            }
        }

        private int GetIndex(string extension)
        {
            switch (extension.ToLower())
            {
                case ".zip":
                case ".rar":
                case ".7z":
                    return 0;
                case ".jpg":
                case ".png":
                case ".bmp":
                case ".jpeg":
                case ".gif":
                    return 2;
                case ".mp3":
                case ".wav":
                    return 3;
                case ".mp4":
                case ".avi":
                case ".mkv":
                    return 4;
                default:
                    return 1;
            }
        }

        private void UploadLocalButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                localStorage.UploadFiles(openFileDialog.FileNames.ToList());
            }
            LoadData();
        }

        private void DownloadLocalButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                List<string> filesName = new List<string>();
                foreach (ListViewItem item in FileManagerListView.SelectedItems)
                {
                    filesName.Add(item.Text);
                }
                localStorage.DownloadFiles(filesName, folderBrowserDialog.SelectedPath);
            }
            LoadData();
        }

        private void DeleteLocalButton_Click(object sender, EventArgs e)
        {
            List<string> filesName = new List<string>();
            foreach (ListViewItem item in FileManagerListView.SelectedItems)
            {
                filesName.Add(item.Text);
            }
            localStorage.DeleteFiles(filesName);
            LoadData();
        }
    }
}
