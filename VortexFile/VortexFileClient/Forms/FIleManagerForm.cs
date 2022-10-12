using Ionic.Zip;
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
            fileChanged += FileManagerForm_fileChangedAsync;
            OnlineMode = onlineMode;
        }

        private async void FileManagerForm_fileChangedAsync(object? sender, EventArgs e)
        {
            waiting.Visible = true;
            await LoadDataAsync();
            waiting.Visible = false;
        }

        private void FileManagerForm_Load(object sender, EventArgs e)
        {
            label2.Text = Session.CurrentUser.Login;
            UploadFtpButton.Enabled = OnlineMode;
            fileChanged.Invoke(null, EventArgs.Empty);
        }

        private async Task LoadDataAsync()
        {
            try
            {
                FileManagerListView.Items.Clear();
                foreach (var item in await Task.Run(()=>localStorage.GetUserCatalog(Properties.Settings.Default.ZipPassword)))
                {
                    ListViewItem viewItem = new ListViewItem(item.FileName, GetIndex(Path.GetExtension(item.FileName)), FileManagerListView.Groups["localGroup"]);
                    FileManagerListView.Items.Add(viewItem);
                }
                if (OnlineMode)
                {
                    foreach (var item in await Task.Run(() => cloudStorage.GetUserCatalog()))
                    {
                        ListViewItem viewItem = new ListViewItem(item, GetIndex(Path.GetExtension(item)), FileManagerListView.Groups["cloudGroup"]);
                        FileManagerListView.Items.Add(viewItem);
                    }
                }
            }
            catch (Exception ex)
            {
                Feedback.ErrorMessage(ex);
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
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    RunProgress(() => localStorage.UploadFiles(openFileDialog.FileNames.ToList()));
                }
            }
            catch (Exception ex)
            {
                Feedback.ErrorMessage(ex);
            }
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            Download();
        }

        private void Download()
        {
            try
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
            catch (Exception ex)
            {
                Feedback.ErrorMessage(ex);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void Delete()
        {
            try
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
            catch (Exception ex)
            {
                Feedback.ErrorMessage(ex);
            }
        }

        private void UploadFtpButton_Click(object sender, EventArgs e)
        {
            UploadFtp();
        }

        private void UploadFtp()
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    RunProgress(() => cloudStorage.UploadFiles(openFileDialog.FileNames.ToList()));
                }
            }
            catch (Exception ex)
            {
                Feedback.ErrorMessage(ex);
            }
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                fileMethod.Invoke();
            }
            catch (Exception ex)
            {
                Feedback.ErrorMessage(ex);
            }
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
            progressBar.Value +=2;
        }
    }
}
