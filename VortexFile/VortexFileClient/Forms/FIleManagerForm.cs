using Ionic.Zip;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using VortexFileClient.Data;
using VortexFileClient.Extensions;
using MessageBox = VortexFileClient.Extensions.MessageBox;

namespace VortexFileClient.Forms
{
    public partial class FileManagerForm : Form, IStackableForm
    {
        private LocalStorage localStorage = new LocalStorage(Session.CurrentUser);
        private CloudStorage cloudStorage = new CloudStorage(Session.CurrentUser);

        private List<Action> fileMethods = new List<Action>();
        private event EventHandler<FilesChangedEventArgs> FilesChange;

        public event EventHandler<LoadFormEventArgs> LoadForm;
        public event EventHandler GoBack;

        private bool OnlineMode { get; set; }

        private bool IsFileChange { get; set; }

        private bool IsProgress
        {
            set
            {
                UploadButton.Enabled = DownloadButton.Enabled = DeleteButton.Enabled = LocalSliderCheckBox.Enabled = CloudSliderCheckBox.Enabled = !value;
                progressBar.Visible = ProgressTimer.Enabled = value;
                progressBar.Value = 0;
                progressBar.Style = ProgressBarStyle.Blocks;
                progressBar.Style = ProgressBarStyle.Marquee;
            }
        }

        public FileManagerForm(bool onlineMode = true)
        {
            InitializeComponent();
            OnlineMode = onlineMode;
            FilesChange += FileManagerForm_FilesChangeAsync; ;
        }

        private async void FileManagerForm_FilesChangeAsync(object? sender, FilesChangedEventArgs e)
        {
            waiting.Visible = true;
            if(e.ChangedRemote)
                await LoadRemoteDataAsync();
            if (e.ChangedLocal)
                await LoadLocalDataAsync();
            waiting.Visible = false;
        }

        private void FileManagerForm_Load(object sender, EventArgs e)
        {
            this.Text = Session.CurrentUser.Login;
            CloudSliderCheckBox.Enabled = CloudSliderCheckBox.Checked = OnlineMode;
            FilesChange?.Invoke(this ,new FilesChangedEventArgs());
        }

        private async Task LoadLocalDataAsync()
        {
            try
            {
                List<ListViewItem> list = new List<ListViewItem>();
                foreach (ListViewItem item in FileManagerListView.Groups["localGroup"].Items)
                {
                    list.Add(item);
                }
                foreach (ListViewItem item in list)
                {
                    FileManagerListView.Items.Remove(item);
                }
                using (ZipFile localFiles = await Task.Run(() => localStorage.GetUserCatalog(Properties.Settings.Default.ZipPassword)))
                {
                    foreach (var item in LocalStorage.GetLevel(localStorage.currentDirectory, localFiles.Entries.ToList()))
                    {
                        ListViewItem viewItem = new ListViewItem(item, GetIndex(Path.GetExtension(item)), FileManagerListView.Groups["localGroup"]);
                        FileManagerListView.Items.Add(viewItem);
                    }
                }
            }
            catch (Exception ex)
            {
                Feedback.ErrorMessage(ex);
            }
        }

        private async Task LoadRemoteDataAsync()
        {
            try
            {
                List<ListViewItem> list = new List<ListViewItem>();
                foreach (ListViewItem item in FileManagerListView.Groups["cloudGroup"].Items)
                {
                    list.Add(item);
                }
                foreach (ListViewItem item in list)
                {
                    FileManagerListView.Items.Remove(item);
                }
               
                if (OnlineMode)
                {
                    if (cloudStorage.currentDirectory != "")
                    {
                        ListViewItem viewItem = new ListViewItem("", GetIndex(""), FileManagerListView.Groups["cloudGroup"]);
                        FileManagerListView.Items.Add(viewItem);
                    }
                    foreach (var item in await Task.Run(() => cloudStorage.GetLevel(cloudStorage.currentDirectory)))
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

        //private async Task LoadDataAsync()
        //{
        //    try
        //    {
        //        FileManagerListView.Items.Clear();
        //        var localFiles = await Task.Run(() => localStorage.GetUserCatalog(Properties.Settings.Default.ZipPassword));
        //        foreach (var item in LocalStorage.GetLevel(localStorage.currentDirectory,localFiles))
        //        {
        //            ListViewItem viewItem = new ListViewItem(item, GetIndex(Path.GetExtension(item)), FileManagerListView.Groups["localGroup"]);
        //            FileManagerListView.Items.Add(viewItem);
        //        }
        //        if (OnlineMode)
        //        {
        //            if (cloudStorage.currentDirectory != "")
        //            {
        //                ListViewItem viewItem = new ListViewItem("", GetIndex(""), FileManagerListView.Groups["cloudGroup"]);
        //                FileManagerListView.Items.Add(viewItem);
        //            }
        //            foreach (var item in await Task.Run(() => cloudStorage.GetLevel(cloudStorage.currentDirectory)))
        //            {
        //                ListViewItem viewItem = new ListViewItem(item, GetIndex(Path.GetExtension(item)), FileManagerListView.Groups["cloudGroup"]);
        //                FileManagerListView.Items.Add(viewItem);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Feedback.ErrorMessage(ex);
        //    }
        //}

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
                case "":
                    return 0;
                default:
                    return 1;
            }
        }

        private void RunProgress(Action action, bool updateData = true)
        {
            IsFileChange = updateData;
            fileMethods.Add(action);
            if (!BackgroundWorker.IsBusy)
            {
                IsProgress = true;
                BackgroundWorker.RunWorkerAsync();
            }
        }

        private void UploadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (LocalSliderCheckBox.Checked)
                {
                    UploadLocal(openFileDialog.FileNames.ToList());
                }
                if (CloudSliderCheckBox.Checked)
                {
                    UploadFtp(openFileDialog.FileNames.ToList());
                }
            }
        }

        private void UploadFtp(List<string> fileNames)
        {
            try
            {
                RunProgress(() => cloudStorage.UploadFiles(fileNames));
            }
            catch (Exception ex)
            {
                Feedback.ErrorMessage(ex);
            }
        }

        private void UploadLocal(List<string> fileNames)
        {
            try
            {
                RunProgress(() => localStorage.UploadFiles(fileNames));
            }
            catch (Exception ex)
            {
                Feedback.ErrorMessage(ex);
            }
        }

        private void UploadFtp(string directoryName)
        {
            try
            {
                RunProgress(() => cloudStorage.UploadFiles(directoryName));
            }
            catch (Exception ex)
            {
                Feedback.ErrorMessage(ex);
            }
        }

        private void UploadLocal(string directoryName)
        {
            try
            {
                RunProgress(() => localStorage.UploadDirectory(directoryName));
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

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                fileMethods.First().Invoke();
            }
            catch (Exception ex)
            {
                Feedback.ErrorMessage(ex);
            }
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            fileMethods.RemoveAt(0);
            if (IsFileChange)
            {
                FilesChange?.Invoke(this, new FilesChangedEventArgs());
            }
            if (fileMethods.Count > 0)
            {
                BackgroundWorker.RunWorkerAsync();
            }
            else
            {
                IsProgress = false;
            }
        }

        private void ProgressTimer_Tick(object sender, EventArgs e)
        {
            progressBar.Value += 2;
        }

        private void FileManagerListView_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void FileManagerListView_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (LocalSliderCheckBox.Checked)
                {
                    RunProgress(() => localStorage.UploadFiles(((string[])e.Data.GetData(DataFormats.FileDrop)).ToList()));
                }
                if (CloudSliderCheckBox.Checked)
                {
                    RunProgress(() => cloudStorage.UploadFiles(((string[])e.Data.GetData(DataFormats.FileDrop)).ToList()));
                }
            }
            catch (Exception ex)
            {
                Feedback.ErrorMessage(ex);
            }
        }

        private void SliderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UploadButton.Enabled = UploadDirectoryButton.Enabled = CloudSliderCheckBox.Checked || LocalSliderCheckBox.Checked;
        }

        private void FileManagerListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = FileManagerListView.HitTest(e.X, e.Y);
            ListViewItem item = info.Item;
            if (item.Group == FileManagerListView.Groups["localGroup"])
            {
                if (item.Text == "")
                {
                    localStorage.currentDirectory = Regex.Match(localStorage.currentDirectory, @"(?<back>([\w\s_]+/)*)[\w\s_]+/").Groups["back"].Value;
                    FilesChange?.Invoke(this, new FilesChangedEventArgs(true,false));
                }
                else if (item.Text.Contains('/'))
                {
                    localStorage.currentDirectory += item.Text;
                    FilesChange?.Invoke(this, new FilesChangedEventArgs(true, false));
                }
            }
            if (item.Group == FileManagerListView.Groups["cloudGroup"])
            {
                if (item.Text == "")
                {
                    cloudStorage.currentDirectory = Regex.Match(cloudStorage.currentDirectory, @"(?<back>([\w\s_]+/)*)[\w\s_]+/").Groups["back"].Value;
                    FilesChange?.Invoke(this, new FilesChangedEventArgs(false, true));
                }
                else if (!Path.HasExtension(item.Text))
                {
                    cloudStorage.currentDirectory += item.Text + "/";
                    FilesChange?.Invoke(this, new FilesChangedEventArgs(false, true));
                }
            }
        }

        private void UploadDirectoryButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                if (LocalSliderCheckBox.Checked)
                {
                    UploadLocal(folderBrowserDialog.SelectedPath);
                }
                if (CloudSliderCheckBox.Checked)
                {
                    UploadFtp(folderBrowserDialog.SelectedPath);
                }
            }
        }

        private void CreateDirectoryLocal(string directoryName)
        {
            try
            {
                RunProgress(() => localStorage.CreateDirectory(directoryName));
            }
            catch (Exception ex)
            {
                Feedback.ErrorMessage(ex);
            }
        }
        private void CreateDirectoryFtp(string directoryName)
        {
            try
            {
                RunProgress(() => cloudStorage.CreateDirectory(directoryName));
            }
            catch (Exception ex)
            {
                Feedback.ErrorMessage(ex);
            }
        }


        private void CreateDirectoryButton_Click(object sender, EventArgs e)
        {
            var folderName = "";
            if (MessageBox.Show("Введите название новой папки", out folderName) == DialogResult.OK)
            {
                if (LocalSliderCheckBox.Checked)
                {
                    CreateDirectoryLocal(folderName);
                }
                if (CloudSliderCheckBox.Checked)
                {
                    CreateDirectoryFtp(folderName);
                }
            }
        }
    }
}