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

        private bool enableNav = true;

        private Stack<FilesChangedEventArgs> filesChanged = new Stack<FilesChangedEventArgs>();

        public FileManagerForm(bool onlineMode = true)
        {
            InitializeComponent();
            OnlineMode = onlineMode;
            FilesChange += FileManagerForm_FilesChangeAsync;
        }

        private void FileManagerForm_Load(object sender, EventArgs e)
        {
            CloudSliderCheckBox.Enabled = CloudSliderCheckBox.Checked = RemoteContextMenuStrip.Enabled = OnlineMode;
            FilesChange?.Invoke(this, new FilesChangedEventArgs());
        }

        private void FileManagerListView_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void SliderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CreateDirectoryButton.Enabled = UploadButton.Enabled = UploadDirectoryButton.Enabled = CloudSliderCheckBox.Checked || LocalSliderCheckBox.Checked;
        }

        private void LocalListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            RemoteListView.SelectedItems.Clear();
        }

        private void RemoteListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            LocalListView.SelectedItems.Clear();
        }

        private void RemoteContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            LocalListView.SelectedItems.Clear();
        }

        private void LocalContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            RemoteListView.SelectedItems.Clear();
        }

        #region LoadData
        private async void FileManagerForm_FilesChangeAsync(object? sender, FilesChangedEventArgs e)
        {
            if (e.ChangedRemote && e.ChangedLocal)
            {
                RemoteWaiting.Visible = LocalWaiting.Visible = true;               
                await LoadLocalDataAsync();
                await LoadRemoteDataAsync();
                RemoteWaiting.Visible = LocalWaiting.Visible = false;
                return;
            }
            if (e.ChangedRemote)
            {
                RemoteWaiting.Visible = true;
                await LoadRemoteDataAsync();
                RemoteWaiting.Visible = false;
            }
            if (e.ChangedLocal)
            {
                LocalWaiting.Visible = true;
                await LoadLocalDataAsync();
                LocalWaiting.Visible = false;
            }
        }

        private async Task LoadLocalDataAsync()
        {
            try
            {

                LocalListView.Items.Clear();
                using (ZipFile localFiles = await Task.Run(() => localStorage.GetUserCatalog()))
                {
                    foreach (var item in LocalStorage.GetLevel(localStorage.currentDirectory, localFiles.Entries.ToList()))
                    {
                        ListViewItem viewItem = new ListViewItem(item, Tools.GetIndex(item), LocalListView.Groups["localGroup"]);
                        LocalListView.Items.Add(viewItem);
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
                RemoteListView.Items.Clear();
               
                if (OnlineMode)
                {
                    if (cloudStorage.currentDirectory != "")
                    {
                        ListViewItem viewItem = new ListViewItem("", Tools.GetIndex(""), RemoteListView.Groups["cloudGroup"]);
                        RemoteListView.Items.Add(viewItem);
                    }
                    List<string> data = await Task.Run(List<string>() => 
                    {
                        try
                        {
                            return cloudStorage.GetLevel(cloudStorage.currentDirectory);
                        }
                        catch (Exception ex)
                        {
                            Feedback.ErrorMessage(ex);
                        }
                        return new List<string>();
                    });
                    foreach (var item in data)
                    {
                        ListViewItem viewItem = new ListViewItem(item, Tools.GetIndex(item), RemoteListView.Groups["cloudGroup"]);
                        RemoteListView.Items.Add(viewItem);
                    }
                }
            }
            catch (Exception ex)
            {
                Feedback.ErrorMessage(ex);
            }
        }
        #endregion

        #region Upload

        private void UploadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (CloudSliderCheckBox.Checked)
                {
                    UploadFtp(openFileDialog.FileNames.ToList());
                }
                if (LocalSliderCheckBox.Checked)
                {
                    UploadLocal(openFileDialog.FileNames.ToList());
                }
            }
        }
        private void UploadDirectoryButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                if (CloudSliderCheckBox.Checked)
                {
                    UploadFtp(folderBrowserDialog.SelectedPath);
                }
                if (LocalSliderCheckBox.Checked)
                {
                    UploadLocal(folderBrowserDialog.SelectedPath);
                }
            }
        }

        private void CreateDirectoryButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Введите название новой папки", out string folderName) == DialogResult.OK)
            {
                if(string.IsNullOrWhiteSpace(folderName))
                {
                    Feedback.WarningMessage("Имя папки не может быть пустым");
                    return;
                }
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

        private void CreateDirectoryRemoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Введите название новой папки", out string folderName) == DialogResult.OK)
            {
                CreateDirectoryFtp(folderName);
            }
        }

        private void CreateDirectoryLocalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Введите название новой папки", out string folderName) == DialogResult.OK)
            {
                CreateDirectoryLocal(folderName);
            }
        }

        private void UploadLocalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                UploadLocal(openFileDialog.FileNames.ToList());
            }
        }

        private void UploadRemoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                UploadFtp(openFileDialog.FileNames.ToList());
            }
        }

        private void UploadDirectoryLocalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                UploadLocal(folderBrowserDialog.SelectedPath);
            }
        }

        private void UploadDirectoryRemoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                UploadFtp(folderBrowserDialog.SelectedPath);
            }
        }

        private void CreateDirectoryLocal(string directoryName)
        {
            try
            {
                RunProgress(() => localStorage.CreateDirectory(directoryName), new FilesChangedEventArgs(remote: false));
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
                RunProgress(() => cloudStorage.CreateDirectory(directoryName), new FilesChangedEventArgs(local: false));
            }
            catch (Exception ex)
            {
                Feedback.ErrorMessage(ex);
            }
        }


        private void LocalListView_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                RunProgress(() => localStorage.Upload(((string[])e.Data.GetData(DataFormats.FileDrop)).ToList()), new FilesChangedEventArgs(remote: false));
            }
            catch (Exception ex)
            {
                Feedback.ErrorMessage(ex);
            }
        }

        private void RemoteListView_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                RunProgress(() => cloudStorage.Upload(((string[])e.Data.GetData(DataFormats.FileDrop)).ToList()), new FilesChangedEventArgs(local: false));
            }
            catch (Exception ex)
            {
                Feedback.ErrorMessage(ex);
            }
        }

        private void UploadFtp(List<string> fileNames)
        {
            try
            {
                RunProgress(() => cloudStorage.UploadFiles(fileNames), new FilesChangedEventArgs(local: false));
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
                RunProgress(() => localStorage.UploadFiles(fileNames), new FilesChangedEventArgs(remote: false));
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
                RunProgress(() => cloudStorage.UploadFiles(directoryName), new FilesChangedEventArgs(local: false));
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
                RunProgress(() => localStorage.UploadDirectory(directoryName), new FilesChangedEventArgs(remote: false));
            }
            catch (Exception ex)
            {
                Feedback.ErrorMessage(ex);
            }
        }
        #endregion

        #region Delete
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (LocalListView.SelectedItems.Count > 0 || RemoteListView.SelectedItems.Count > 0)
            {
                Delete();
            }
            else
            {
                Feedback.WarningMessage("Выберите файлы для удаления");
            }
        }

        private void Delete()
        {
            try
            {
                List<string> localFilesName = new List<string>();
                List<string> cloudFilesName = new List<string>();
                foreach (ListViewItem item in LocalListView.SelectedItems)
                {
                    localFilesName.Add(item.Text);
                }
                foreach (ListViewItem item in RemoteListView.SelectedItems)
                {
                    cloudFilesName.Add(item.Text);
                }
                if (localFilesName.Count > 0)
                {
                    RunProgress(() => localStorage.DeleteFiles(localFilesName), new FilesChangedEventArgs(remote: false));
                }
                if (cloudFilesName.Count > 0)
                {
                    RunProgress(() => cloudStorage.DeleteFiles(cloudFilesName), new FilesChangedEventArgs(local: false));
                }
            }
            catch (Exception ex)
            {
                Feedback.ErrorMessage(ex);
            }
        }
        #endregion

        #region Download
        private void DownloadButton_Click(object sender, EventArgs e)
        {
            if (LocalListView.SelectedItems.Count > 0 || RemoteListView.SelectedItems.Count > 0)
            {
                Download();
            }
            else
            {
                Feedback.WarningMessage("Выберите файлы для загрузки");
            }
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
                    foreach (ListViewItem item in LocalListView.SelectedItems)
                    {
                        localFilesName.Add(item.Text);
                    }
                    foreach (ListViewItem item in RemoteListView.SelectedItems)
                    {
                        cloudFilesName.Add(item.Text);
                    }
                    if (localFilesName.Count > 0)
                    {
                        RunProgress(() => localStorage.DownloadFiles(localFilesName, folderBrowserDialog.SelectedPath));
                    }
                    if (cloudFilesName.Count > 0)
                    {
                        RunProgress(() => cloudStorage.DownloadFiles(cloudFilesName, folderBrowserDialog.SelectedPath));
                    }
                }
            }
            catch (Exception ex)
            {
                Feedback.ErrorMessage(ex);
            }
        }
        #endregion

        #region BackgroundWorker
        private bool IsProgress
        {
            set
            {
                UploadButton.Enabled =
                    DownloadButton.Enabled =
                    DeleteButton.Enabled =
                    LocalSliderCheckBox.Enabled =
                    CloudSliderCheckBox.Enabled =
                    UploadDirectoryButton.Enabled =
                    CreateDirectoryButton.Enabled =
                    LocalContextMenuStrip.Enabled =
                    RemoteContextMenuStrip.Enabled =
                    enableNav = !value;

                progressBar.Visible = ProgressTimer.Enabled = value;
                progressBar.Value = 0;
                progressBar.Style = ProgressBarStyle.Blocks;
                progressBar.Style = ProgressBarStyle.Marquee;
            }
        }

        private void ProgressTimer_Tick(object sender, EventArgs e)
        {
            progressBar.Value += 2;
        }

        private void RunProgress(Action action, FilesChangedEventArgs filesChangedEventArgs = null)
        {
            filesChanged.Push(filesChangedEventArgs);
            fileMethods.Add(action);
            if (!BackgroundWorker.IsBusy)
            {
                IsProgress = true;
                BackgroundWorker.RunWorkerAsync();
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
            FilesChangedEventArgs filesChangedEventArgs = new FilesChangedEventArgs(local: false, remote: false);
            while (filesChanged.Count > 0)
            {
                var filesChanged = this.filesChanged.Pop();
                if (filesChanged != null)
                {
                    if (filesChanged.ChangedLocal)
                    {
                        filesChangedEventArgs.ChangedLocal = filesChanged.ChangedLocal;
                    }
                    if (filesChanged.ChangedRemote)
                    {
                        filesChangedEventArgs.ChangedRemote = filesChanged.ChangedRemote;
                    }
                }
            }
            FilesChange?.Invoke(this, filesChangedEventArgs);
            if (fileMethods.Count > 0)
            {
                BackgroundWorker.RunWorkerAsync();
            }
            else
            {
                IsProgress = false;
            }
        }
        #endregion

        #region FolderNavigation
        private void LocalListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!enableNav)
            {
                return;
            }
            ListViewHitTestInfo info = LocalListView.HitTest(e.X, e.Y);
            ListViewItem item = info.Item;
            if (item.Text == "")
            {
                localStorage.currentDirectory = Regex.Match(localStorage.currentDirectory, @"(?<back>([\w\s_]+/)*)[\w\s_]+/").Groups["back"].Value;
                FilesChange?.Invoke(this, new FilesChangedEventArgs(true, false));
            }
            else if (item.Text.Contains('/'))
            {
                localStorage.currentDirectory += item.Text;
                FilesChange?.Invoke(this, new FilesChangedEventArgs(true, false));
            }
            if (String.IsNullOrWhiteSpace(localStorage.currentDirectory))
            {
                LocalListView.Groups[0].Header = "Локальное хранилище";
            }
            else
            {
                LocalListView.Groups[0].Header = "Локальное хранилище/" + localStorage.currentDirectory;
            }
        }

        private void RemoteListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!enableNav)
            {
                return;
            }
            ListViewHitTestInfo info = RemoteListView.HitTest(e.X, e.Y);
            ListViewItem item = info.Item;
            if (item.Text == "")
            {
                cloudStorage.currentDirectory = Regex.Match(cloudStorage.currentDirectory, @"(?<back>(.+/)*)[\w\s_]+/").Groups["back"].Value;
                FilesChange?.Invoke(this, new FilesChangedEventArgs(false, true));
            }
            else if (item.Text.Contains('/'))
            {
                cloudStorage.currentDirectory += item.Text + "/";
                FilesChange?.Invoke(this, new FilesChangedEventArgs(false, true));
            }
            if (String.IsNullOrWhiteSpace(cloudStorage.currentDirectory))
            {
                RemoteListView.Groups[1].Header = "Облачное хранилище";
            }
            else
            {
                RemoteListView.Groups[1].Header = "Облачное хранилище/" + cloudStorage.currentDirectory.Replace("//", "/");
            }
        }
        #endregion
    }
}