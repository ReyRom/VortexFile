namespace VortexFileClient.Forms
{
    partial class FileManagerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Локальное хранилище", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Облачное хранилище", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileManagerForm));
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Локальное хранилище", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Облачное хранилище", System.Windows.Forms.HorizontalAlignment.Left);
            this.LocalListView = new System.Windows.Forms.ListView();
            this.LocalContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.downloadLocalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteLocalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadLocalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadDirectoryLocalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createDirectoryLocalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExtensionImageList = new System.Windows.Forms.ImageList(this.components);
            this.UploadButton = new System.Windows.Forms.Button();
            this.BackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.ProgressTimer = new System.Windows.Forms.Timer(this.components);
            this.LocalSliderCheckBox = new VortexFileClient.Extensions.SliderCheckBox();
            this.CloudSliderCheckBox = new VortexFileClient.Extensions.SliderCheckBox();
            this.progressBar = new VortexFileClient.Extensions.ColorProgressBar();
            this.DownloadButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.UploadDirectoryButton = new System.Windows.Forms.Button();
            this.CreateDirectoryButton = new System.Windows.Forms.Button();
            this.RemoteListView = new System.Windows.Forms.ListView();
            this.RemoteContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.downloadRemoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteRemoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadRemoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadDirectoryRemoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createDirectoryRemoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LocalWaiting = new VortexFileClient.Extensions.Waiting();
            this.RemoteWaiting = new VortexFileClient.Extensions.Waiting();
            this.LocalContextMenuStrip.SuspendLayout();
            this.RemoteContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // LocalListView
            // 
            this.LocalListView.AllowDrop = true;
            this.LocalListView.ContextMenuStrip = this.LocalContextMenuStrip;
            this.LocalListView.GridLines = true;
            listViewGroup1.Header = "Локальное хранилище";
            listViewGroup1.Name = "localGroup";
            listViewGroup2.Header = "Облачное хранилище";
            listViewGroup2.Name = "cloudGroup";
            this.LocalListView.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.LocalListView.LargeImageList = this.ExtensionImageList;
            this.LocalListView.Location = new System.Drawing.Point(26, 14);
            this.LocalListView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LocalListView.Name = "LocalListView";
            this.LocalListView.Size = new System.Drawing.Size(499, 518);
            this.LocalListView.SmallImageList = this.ExtensionImageList;
            this.LocalListView.TabIndex = 2;
            this.LocalListView.UseCompatibleStateImageBehavior = false;
            this.LocalListView.View = System.Windows.Forms.View.Tile;
            this.LocalListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.LocalListView_ItemSelectionChanged);
            this.LocalListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.LocalListView_DragDrop);
            this.LocalListView.DragEnter += new System.Windows.Forms.DragEventHandler(this.FileManagerListView_DragEnter);
            this.LocalListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LocalListView_MouseDoubleClick);
            // 
            // LocalContextMenuStrip
            // 
            this.LocalContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.downloadLocalToolStripMenuItem,
            this.deleteLocalToolStripMenuItem,
            this.uploadLocalToolStripMenuItem,
            this.uploadDirectoryLocalToolStripMenuItem,
            this.createDirectoryLocalToolStripMenuItem});
            this.LocalContextMenuStrip.Name = "LocalContextMenuStrip";
            this.LocalContextMenuStrip.Size = new System.Drawing.Size(181, 136);
            this.LocalContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.LocalContextMenuStrip_Opening);
            // 
            // downloadLocalToolStripMenuItem
            // 
            this.downloadLocalToolStripMenuItem.Name = "downloadLocalToolStripMenuItem";
            this.downloadLocalToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.downloadLocalToolStripMenuItem.Text = "Скачать";
            this.downloadLocalToolStripMenuItem.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // deleteLocalToolStripMenuItem
            // 
            this.deleteLocalToolStripMenuItem.Name = "deleteLocalToolStripMenuItem";
            this.deleteLocalToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteLocalToolStripMenuItem.Text = "Удалить";
            this.deleteLocalToolStripMenuItem.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // uploadLocalToolStripMenuItem
            // 
            this.uploadLocalToolStripMenuItem.Name = "uploadLocalToolStripMenuItem";
            this.uploadLocalToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.uploadLocalToolStripMenuItem.Text = "Загрузить файл";
            this.uploadLocalToolStripMenuItem.Click += new System.EventHandler(this.UploadLocalToolStripMenuItem_Click);
            // 
            // uploadDirectoryLocalToolStripMenuItem
            // 
            this.uploadDirectoryLocalToolStripMenuItem.Name = "uploadDirectoryLocalToolStripMenuItem";
            this.uploadDirectoryLocalToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.uploadDirectoryLocalToolStripMenuItem.Text = "Загрузить папку";
            this.uploadDirectoryLocalToolStripMenuItem.Click += new System.EventHandler(this.UploadDirectoryLocalToolStripMenuItem_Click);
            // 
            // createDirectoryLocalToolStripMenuItem
            // 
            this.createDirectoryLocalToolStripMenuItem.Name = "createDirectoryLocalToolStripMenuItem";
            this.createDirectoryLocalToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.createDirectoryLocalToolStripMenuItem.Text = "Создать папку";
            this.createDirectoryLocalToolStripMenuItem.Click += new System.EventHandler(this.CreateDirectoryLocalToolStripMenuItem_Click);
            // 
            // ExtensionImageList
            // 
            this.ExtensionImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ExtensionImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ExtensionImageList.ImageStream")));
            this.ExtensionImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.ExtensionImageList.Images.SetKeyName(0, "icon_folder.png");
            this.ExtensionImageList.Images.SetKeyName(1, "icon_document.png");
            this.ExtensionImageList.Images.SetKeyName(2, "icon_image.png");
            this.ExtensionImageList.Images.SetKeyName(3, "icon_music.png");
            this.ExtensionImageList.Images.SetKeyName(4, "icon_film.png");
            this.ExtensionImageList.Images.SetKeyName(5, "icon_folder_up.png");
            this.ExtensionImageList.Images.SetKeyName(6, "icon_archive.png");
            // 
            // UploadButton
            // 
            this.UploadButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(210)))));
            this.UploadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UploadButton.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.UploadButton.ForeColor = System.Drawing.Color.White;
            this.UploadButton.Location = new System.Drawing.Point(26, 576);
            this.UploadButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UploadButton.Name = "UploadButton";
            this.UploadButton.Size = new System.Drawing.Size(194, 38);
            this.UploadButton.TabIndex = 3;
            this.UploadButton.Text = "Загрузить";
            this.UploadButton.UseVisualStyleBackColor = false;
            this.UploadButton.Click += new System.EventHandler(this.UploadButton_Click);
            // 
            // BackgroundWorker
            // 
            this.BackgroundWorker.WorkerReportsProgress = true;
            this.BackgroundWorker.WorkerSupportsCancellation = true;
            this.BackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker_DoWork);
            this.BackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker_RunWorkerCompleted);
            // 
            // ProgressTimer
            // 
            this.ProgressTimer.Interval = 25;
            this.ProgressTimer.Tick += new System.EventHandler(this.ProgressTimer_Tick);
            // 
            // LocalSliderCheckBox
            // 
            this.LocalSliderCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.LocalSliderCheckBox.AutoSize = true;
            this.LocalSliderCheckBox.Checked = true;
            this.LocalSliderCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.LocalSliderCheckBox.FlatAppearance.BorderSize = 0;
            this.LocalSliderCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.LocalSliderCheckBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.LocalSliderCheckBox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.LocalSliderCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LocalSliderCheckBox.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LocalSliderCheckBox.ImageIndex = 1;
            this.LocalSliderCheckBox.Location = new System.Drawing.Point(228, 570);
            this.LocalSliderCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LocalSliderCheckBox.Name = "LocalSliderCheckBox";
            this.LocalSliderCheckBox.Size = new System.Drawing.Size(217, 32);
            this.LocalSliderCheckBox.TabIndex = 10;
            this.LocalSliderCheckBox.Text = "Локальное хранилище";
            this.LocalSliderCheckBox.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.LocalSliderCheckBox.UseVisualStyleBackColor = true;
            this.LocalSliderCheckBox.CheckedChanged += new System.EventHandler(this.SliderCheckBox_CheckedChanged);
            // 
            // CloudSliderCheckBox
            // 
            this.CloudSliderCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.CloudSliderCheckBox.AutoSize = true;
            this.CloudSliderCheckBox.Checked = true;
            this.CloudSliderCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CloudSliderCheckBox.FlatAppearance.BorderSize = 0;
            this.CloudSliderCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.CloudSliderCheckBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.CloudSliderCheckBox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.CloudSliderCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloudSliderCheckBox.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CloudSliderCheckBox.ImageIndex = 1;
            this.CloudSliderCheckBox.Location = new System.Drawing.Point(228, 598);
            this.CloudSliderCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CloudSliderCheckBox.Name = "CloudSliderCheckBox";
            this.CloudSliderCheckBox.Size = new System.Drawing.Size(210, 32);
            this.CloudSliderCheckBox.TabIndex = 11;
            this.CloudSliderCheckBox.Text = "Облачное хранилище";
            this.CloudSliderCheckBox.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CloudSliderCheckBox.UseVisualStyleBackColor = true;
            this.CloudSliderCheckBox.CheckedChanged += new System.EventHandler(this.SliderCheckBox_CheckedChanged);
            // 
            // progressBar
            // 
            this.progressBar.Color = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(210)))));
            this.progressBar.LineWidth = 200;
            this.progressBar.Location = new System.Drawing.Point(26, 540);
            this.progressBar.Maximum = 600;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(1009, 27);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 16;
            this.progressBar.Visible = false;
            // 
            // DownloadButton
            // 
            this.DownloadButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(210)))));
            this.DownloadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DownloadButton.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DownloadButton.ForeColor = System.Drawing.Color.White;
            this.DownloadButton.Location = new System.Drawing.Point(755, 582);
            this.DownloadButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.Size = new System.Drawing.Size(137, 38);
            this.DownloadButton.TabIndex = 17;
            this.DownloadButton.Text = "Скачать";
            this.DownloadButton.UseVisualStyleBackColor = false;
            this.DownloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(210)))));
            this.DeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteButton.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DeleteButton.ForeColor = System.Drawing.Color.White;
            this.DeleteButton.Location = new System.Drawing.Point(900, 582);
            this.DeleteButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(135, 38);
            this.DeleteButton.TabIndex = 18;
            this.DeleteButton.Text = "Удалить";
            this.DeleteButton.UseVisualStyleBackColor = false;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // UploadDirectoryButton
            // 
            this.UploadDirectoryButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(210)))));
            this.UploadDirectoryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UploadDirectoryButton.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.UploadDirectoryButton.ForeColor = System.Drawing.Color.White;
            this.UploadDirectoryButton.Location = new System.Drawing.Point(26, 616);
            this.UploadDirectoryButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UploadDirectoryButton.Name = "UploadDirectoryButton";
            this.UploadDirectoryButton.Size = new System.Drawing.Size(194, 38);
            this.UploadDirectoryButton.TabIndex = 19;
            this.UploadDirectoryButton.Text = "Загрузить каталог";
            this.UploadDirectoryButton.UseVisualStyleBackColor = false;
            this.UploadDirectoryButton.Click += new System.EventHandler(this.UploadDirectoryButton_Click);
            // 
            // CreateDirectoryButton
            // 
            this.CreateDirectoryButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(210)))));
            this.CreateDirectoryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateDirectoryButton.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CreateDirectoryButton.ForeColor = System.Drawing.Color.White;
            this.CreateDirectoryButton.Location = new System.Drawing.Point(610, 582);
            this.CreateDirectoryButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CreateDirectoryButton.Name = "CreateDirectoryButton";
            this.CreateDirectoryButton.Size = new System.Drawing.Size(137, 38);
            this.CreateDirectoryButton.TabIndex = 20;
            this.CreateDirectoryButton.Text = "Создать папку";
            this.CreateDirectoryButton.UseVisualStyleBackColor = false;
            this.CreateDirectoryButton.Click += new System.EventHandler(this.CreateDirectoryButton_Click);
            // 
            // RemoteListView
            // 
            this.RemoteListView.AllowDrop = true;
            this.RemoteListView.ContextMenuStrip = this.RemoteContextMenuStrip;
            this.RemoteListView.GridLines = true;
            listViewGroup3.Header = "Локальное хранилище";
            listViewGroup3.Name = "localGroup";
            listViewGroup4.Header = "Облачное хранилище";
            listViewGroup4.Name = "cloudGroup";
            this.RemoteListView.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup3,
            listViewGroup4});
            this.RemoteListView.LargeImageList = this.ExtensionImageList;
            this.RemoteListView.Location = new System.Drawing.Point(536, 14);
            this.RemoteListView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RemoteListView.Name = "RemoteListView";
            this.RemoteListView.Size = new System.Drawing.Size(499, 518);
            this.RemoteListView.SmallImageList = this.ExtensionImageList;
            this.RemoteListView.TabIndex = 21;
            this.RemoteListView.UseCompatibleStateImageBehavior = false;
            this.RemoteListView.View = System.Windows.Forms.View.Tile;
            this.RemoteListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.RemoteListView_ItemSelectionChanged);
            this.RemoteListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.RemoteListView_DragDrop);
            this.RemoteListView.DragEnter += new System.Windows.Forms.DragEventHandler(this.FileManagerListView_DragEnter);
            this.RemoteListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.RemoteListView_MouseDoubleClick);
            // 
            // RemoteContextMenuStrip
            // 
            this.RemoteContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.downloadRemoteToolStripMenuItem,
            this.deleteRemoteToolStripMenuItem,
            this.uploadRemoteToolStripMenuItem,
            this.uploadDirectoryRemoteToolStripMenuItem,
            this.createDirectoryRemoteToolStripMenuItem});
            this.RemoteContextMenuStrip.Name = "LocalContextMenuStrip";
            this.RemoteContextMenuStrip.Size = new System.Drawing.Size(164, 114);
            this.RemoteContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.RemoteContextMenuStrip_Opening);
            // 
            // downloadRemoteToolStripMenuItem
            // 
            this.downloadRemoteToolStripMenuItem.Name = "downloadRemoteToolStripMenuItem";
            this.downloadRemoteToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.downloadRemoteToolStripMenuItem.Text = "Скачать";
            this.downloadRemoteToolStripMenuItem.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // deleteRemoteToolStripMenuItem
            // 
            this.deleteRemoteToolStripMenuItem.Name = "deleteRemoteToolStripMenuItem";
            this.deleteRemoteToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.deleteRemoteToolStripMenuItem.Text = "Удалить";
            this.deleteRemoteToolStripMenuItem.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // uploadRemoteToolStripMenuItem
            // 
            this.uploadRemoteToolStripMenuItem.Name = "uploadRemoteToolStripMenuItem";
            this.uploadRemoteToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.uploadRemoteToolStripMenuItem.Text = "Загрузить файл";
            this.uploadRemoteToolStripMenuItem.Click += new System.EventHandler(this.UploadRemoteToolStripMenuItem_Click);
            // 
            // uploadDirectoryRemoteToolStripMenuItem
            // 
            this.uploadDirectoryRemoteToolStripMenuItem.Name = "uploadDirectoryRemoteToolStripMenuItem";
            this.uploadDirectoryRemoteToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.uploadDirectoryRemoteToolStripMenuItem.Text = "Загрузить папку";
            this.uploadDirectoryRemoteToolStripMenuItem.Click += new System.EventHandler(this.UploadDirectoryRemoteToolStripMenuItem_Click);
            // 
            // createDirectoryRemoteToolStripMenuItem
            // 
            this.createDirectoryRemoteToolStripMenuItem.Name = "createDirectoryRemoteToolStripMenuItem";
            this.createDirectoryRemoteToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.createDirectoryRemoteToolStripMenuItem.Text = "Создать папку";
            this.createDirectoryRemoteToolStripMenuItem.Click += new System.EventHandler(this.CreateDirectoryRemoteToolStripMenuItem_Click);
            // 
            // LocalWaiting
            // 
            this.LocalWaiting.ImageSize = 50;
            this.LocalWaiting.Location = new System.Drawing.Point(26, 14);
            this.LocalWaiting.Margin = new System.Windows.Forms.Padding(4);
            this.LocalWaiting.Name = "LocalWaiting";
            this.LocalWaiting.Size = new System.Drawing.Size(499, 518);
            this.LocalWaiting.TabIndex = 22;
            this.LocalWaiting.Visible = false;
            // 
            // RemoteWaiting
            // 
            this.RemoteWaiting.ImageSize = 50;
            this.RemoteWaiting.Location = new System.Drawing.Point(536, 14);
            this.RemoteWaiting.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.RemoteWaiting.Name = "RemoteWaiting";
            this.RemoteWaiting.Size = new System.Drawing.Size(499, 518);
            this.RemoteWaiting.TabIndex = 23;
            this.RemoteWaiting.Visible = false;
            // 
            // FileManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1065, 664);
            this.Controls.Add(this.RemoteWaiting);
            this.Controls.Add(this.LocalWaiting);
            this.Controls.Add(this.RemoteListView);
            this.Controls.Add(this.CreateDirectoryButton);
            this.Controls.Add(this.UploadDirectoryButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.DownloadButton);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.CloudSliderCheckBox);
            this.Controls.Add(this.LocalSliderCheckBox);
            this.Controls.Add(this.UploadButton);
            this.Controls.Add(this.LocalListView);
            this.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FileManagerForm";
            this.Text = "FIleManagerForm";
            this.Load += new System.EventHandler(this.FileManagerForm_Load);
            this.LocalContextMenuStrip.ResumeLayout(false);
            this.RemoteContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ListView LocalListView;
        private ImageList ExtensionImageList;
        private Button UploadButton;
        private System.ComponentModel.BackgroundWorker BackgroundWorker;
        private System.Windows.Forms.Timer ProgressTimer;
        private Extensions.SliderCheckBox LocalSliderCheckBox;
        private Extensions.SliderCheckBox CloudSliderCheckBox;
        private Extensions.ColorProgressBar progressBar;
        private Button DownloadButton;
        private Button DeleteButton;
        private Button UploadDirectoryButton;
        private Button CreateDirectoryButton;
        private ListView RemoteListView;
        private Extensions.Waiting LocalWaiting;
        private Extensions.Waiting RemoteWaiting;
        private ContextMenuStrip LocalContextMenuStrip;
        private ToolStripMenuItem downloadLocalToolStripMenuItem;
        private ToolStripMenuItem deleteLocalToolStripMenuItem;
        private ToolStripMenuItem uploadLocalToolStripMenuItem;
        private ToolStripMenuItem uploadDirectoryLocalToolStripMenuItem;
        private ToolStripMenuItem createDirectoryLocalToolStripMenuItem;
        private ContextMenuStrip RemoteContextMenuStrip;
        private ToolStripMenuItem downloadRemoteToolStripMenuItem;
        private ToolStripMenuItem deleteRemoteToolStripMenuItem;
        private ToolStripMenuItem uploadRemoteToolStripMenuItem;
        private ToolStripMenuItem uploadDirectoryRemoteToolStripMenuItem;
        private ToolStripMenuItem createDirectoryRemoteToolStripMenuItem;
    }
}