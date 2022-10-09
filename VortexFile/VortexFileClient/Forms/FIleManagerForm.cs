using System.ComponentModel;
using VortexFileClient.Data;
using VortexFileClient.Extensions;

namespace VortexFileClient.Forms
{
    public partial class FileManagerForm : Form, IStackableForm
    {
        private LocalStorage localStorage = new LocalStorage();
        private CloudStorage cloudStorage = new CloudStorage(Session.CurrentUser.Login, Session.CurrentUser.Password);

        public event EventHandler<LoadFormEventArgs> LoadForm;
        public event EventHandler GoBack;

        private bool OnlineMode { get; set; }

        private bool IsFileChange { get; set; }

        private bool IsProgress
        {
            set
            {
                progressBar.Visible = ProgressTimer.Enabled = value;
                progressBar.Value = 0;
                progressBar.Style = ProgressBarStyle.Blocks;
                progressBar.Style = ProgressBarStyle.Marquee;
            }
        }

        public FileManagerForm(bool onlineMode = true)
        {
            InitializeComponent();
            fileChanged += FileManagerForm_fileChanged;
            OnlineMode = onlineMode;
        }

        private void FileManagerForm_fileChanged(object? sender, EventArgs e)
        {
            LoadData();
        }

        private void FIleManagerForm_Load(object sender, EventArgs e)
        {
            label2.Text = Session.CurrentUser.Login;
            LoadData();
        }

        private void LoadData()
        {
            FileManagerListView.Items.Clear();
            foreach (var item in localStorage.GetUserCatalog(Properties.Settings.Default.ZipPassword))
            {
                ListViewItem viewItem = new ListViewItem(item.FileName, GetIndex(Path.GetExtension(item.FileName)), FileManagerListView.Groups["localGroup"]);
                FileManagerListView.Items.Add(viewItem);
            }
            foreach (var item in cloudStorage.GetUserCatalog())
            {
                ListViewItem viewItem = new ListViewItem(item, GetIndex(Path.GetExtension(item)), FileManagerListView.Groups["cloudGroup"]);
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

        Action fileMethod;
        event EventHandler fileChanged;

        private void RunProgress(Action action, bool updateData = true)
        {
            IsFileChange = updateData;
            fileMethod = action;
            IsProgress = true;
            BackgroundWorker.RunWorkerAsync();
        }

        private void UploadLocalButton_Click(object sender, EventArgs e)
        {
            UploadLocal();
        }

        private void UploadLocal()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                RunProgress(() => localStorage.UploadFiles(openFileDialog.FileNames.ToList()));
            }
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            Download();
        }

        private void Download()
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                List<string> localFilesName = new List<string>();
                List<string> cloudFilesName = new List<string>();
                foreach (ListViewItem item in FileManagerListView.SelectedItems)
                {
                    if (item.Group == FileManagerListView.Groups["localGroup"])
                    {
                        localFilesName.Add(item.Text);
                    }
                    else
                    {
                        cloudFilesName.Add(item.Text);
                    }
                }
                if (localFilesName.Count > 0)
                {
                    RunProgress(() => localStorage.DownloadFiles(localFilesName, folderBrowserDialog.SelectedPath), false);
                }
                if (cloudFilesName.Count > 0)
                {
                    RunProgress(() => cloudStorage.DownloadFiles(cloudFilesName, folderBrowserDialog.SelectedPath), false);
                }
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void Delete()
        {
            List<string> localFilesName = new List<string>();
            List<string> cloudFilesName = new List<string>();
            foreach (ListViewItem item in FileManagerListView.SelectedItems)
            {
                if (item.Group == FileManagerListView.Groups["localGroup"])
                {
                    localFilesName.Add(item.Text);
                }
                else
                {
                    cloudFilesName.Add(item.Text);
                }
            }
            if (localFilesName.Count > 0)
            {
                RunProgress(() => localStorage.DeleteFiles(localFilesName));
            }
            if (cloudFilesName.Count > 0)
            {
                RunProgress(() => cloudStorage.DeleteFiles(cloudFilesName));
            }
        }

        private void UploadFtpButton_Click(object sender, EventArgs e)
        {
            UploadFtp();
        }

        private void UploadFtp()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                RunProgress(() => cloudStorage.UploadFiles(openFileDialog.FileNames.ToList()));
            }
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            fileMethod.Invoke();
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (IsFileChange)
            {
                fileChanged.Invoke(this, EventArgs.Empty);
            }
            IsProgress = false;
        }

        private void ProgressTimer_Tick(object sender, EventArgs e)
        {
            if (progressBar.Value == 600)
            {
                progressBar.Value = 0;
            }
            else
            {
                progressBar.Value++;
            }
        }
    }
}
