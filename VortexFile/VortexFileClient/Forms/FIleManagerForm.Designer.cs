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
            this.label2 = new System.Windows.Forms.Label();
            this.FileManagerListView = new System.Windows.Forms.ListView();
            this.ExtensionImageList = new System.Windows.Forms.ImageList(this.components);
            this.UploadLocalButton = new System.Windows.Forms.Button();
            this.DownloadButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.UploadFtpButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.BackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.ProgressTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // FileManagerListView
            // 
            this.FileManagerListView.GridLines = true;
            listViewGroup1.Header = "Локальное хранилище";
            listViewGroup1.Name = "localGroup";
            listViewGroup2.Header = "Облачное хранилище";
            listViewGroup2.Name = "cloudGroup";
            this.FileManagerListView.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.FileManagerListView.LargeImageList = this.ExtensionImageList;
            this.FileManagerListView.Location = new System.Drawing.Point(273, 12);
            this.FileManagerListView.Name = "FileManagerListView";
            this.FileManagerListView.Size = new System.Drawing.Size(471, 381);
            this.FileManagerListView.SmallImageList = this.ExtensionImageList;
            this.FileManagerListView.TabIndex = 2;
            this.FileManagerListView.UseCompatibleStateImageBehavior = false;
            this.FileManagerListView.View = System.Windows.Forms.View.Tile;
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
            // 
            // UploadLocalButton
            // 
            this.UploadLocalButton.Location = new System.Drawing.Point(40, 38);
            this.UploadLocalButton.Name = "UploadLocalButton";
            this.UploadLocalButton.Size = new System.Drawing.Size(128, 23);
            this.UploadLocalButton.TabIndex = 3;
            this.UploadLocalButton.Text = "Загрузить локально";
            this.UploadLocalButton.UseVisualStyleBackColor = true;
            this.UploadLocalButton.Click += new System.EventHandler(this.UploadLocalButton_Click);
            // 
            // DownloadButton
            // 
            this.DownloadButton.Location = new System.Drawing.Point(40, 110);
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.Size = new System.Drawing.Size(75, 23);
            this.DownloadButton.TabIndex = 4;
            this.DownloadButton.Text = "Скачать";
            this.DownloadButton.UseVisualStyleBackColor = true;
            this.DownloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(40, 139);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteButton.TabIndex = 5;
            this.DeleteButton.Text = "Удалить";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // UploadFtpButton
            // 
            this.UploadFtpButton.Location = new System.Drawing.Point(40, 67);
            this.UploadFtpButton.Name = "UploadFtpButton";
            this.UploadFtpButton.Size = new System.Drawing.Size(128, 23);
            this.UploadFtpButton.TabIndex = 6;
            this.UploadFtpButton.Text = "Загрузить на FTP";
            this.UploadFtpButton.UseVisualStyleBackColor = true;
            this.UploadFtpButton.Click += new System.EventHandler(this.UploadFtpButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 399);
            this.progressBar.Maximum = 600;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(732, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 7;
            this.progressBar.Visible = false;
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
            this.ProgressTimer.Tick += new System.EventHandler(this.ProgressTimer_Tick);
            // 
            // FileManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 429);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.UploadFtpButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.DownloadButton);
            this.Controls.Add(this.UploadLocalButton);
            this.Controls.Add(this.FileManagerListView);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FileManagerForm";
            this.Text = "FIleManagerForm";
            this.Load += new System.EventHandler(this.FIleManagerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label2;
        private ListView FileManagerListView;
        private ImageList ExtensionImageList;
        private Button UploadLocalButton;
        private Button DownloadButton;
        private Button DeleteButton;
        private Button UploadFtpButton;
        private ProgressBar progressBar;
        private System.ComponentModel.BackgroundWorker BackgroundWorker;
        private System.Windows.Forms.Timer ProgressTimer;
    }
}