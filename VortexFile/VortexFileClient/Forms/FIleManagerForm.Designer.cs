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
            this.FileManagerListView = new System.Windows.Forms.ListView();
            this.ExtensionImageList = new System.Windows.Forms.ImageList(this.components);
            this.UploadButton = new System.Windows.Forms.Button();
            this.BackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.ProgressTimer = new System.Windows.Forms.Timer(this.components);
            this.waiting = new VortexFileClient.Extensions.Waiting();
            this.LocalSliderCheckBox = new VortexFileClient.Extensions.SliderCheckBox();
            this.CloudSliderCheckBox = new VortexFileClient.Extensions.SliderCheckBox();
            this.progressBar = new VortexFileClient.Extensions.ColorProgressBar();
            this.DownloadButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FileManagerListView
            // 
            this.FileManagerListView.AllowDrop = true;
            this.FileManagerListView.GridLines = true;
            listViewGroup1.Header = "Локальное хранилище";
            listViewGroup1.Name = "localGroup";
            listViewGroup2.Header = "Облачное хранилище";
            listViewGroup2.Name = "cloudGroup";
            this.FileManagerListView.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.FileManagerListView.LargeImageList = this.ExtensionImageList;
            this.FileManagerListView.Location = new System.Drawing.Point(26, 14);
            this.FileManagerListView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FileManagerListView.Name = "FileManagerListView";
            this.FileManagerListView.Size = new System.Drawing.Size(1009, 518);
            this.FileManagerListView.SmallImageList = this.ExtensionImageList;
            this.FileManagerListView.TabIndex = 2;
            this.FileManagerListView.UseCompatibleStateImageBehavior = false;
            this.FileManagerListView.View = System.Windows.Forms.View.Tile;
            this.FileManagerListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.FileManagerListView_DragDrop);
            this.FileManagerListView.DragEnter += new System.Windows.Forms.DragEventHandler(this.FileManagerListView_DragEnter);
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
            // UploadButton
            // 
            this.UploadButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(210)))));
            this.UploadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UploadButton.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.UploadButton.ForeColor = System.Drawing.Color.White;
            this.UploadButton.Location = new System.Drawing.Point(26, 581);
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
            // waiting
            // 
            this.waiting.ImageSize = new System.Drawing.Size(224, 192);
            this.waiting.Location = new System.Drawing.Point(26, 14);
            this.waiting.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.waiting.Name = "waiting";
            this.waiting.Size = new System.Drawing.Size(1009, 518);
            this.waiting.TabIndex = 8;
            this.waiting.Visible = false;
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
            // FileManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1065, 664);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.DownloadButton);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.CloudSliderCheckBox);
            this.Controls.Add(this.LocalSliderCheckBox);
            this.Controls.Add(this.waiting);
            this.Controls.Add(this.UploadButton);
            this.Controls.Add(this.FileManagerListView);
            this.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FileManagerForm";
            this.Text = "FIleManagerForm";
            this.Load += new System.EventHandler(this.FileManagerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ListView FileManagerListView;
        private ImageList ExtensionImageList;
        private Button UploadButton;
        private System.ComponentModel.BackgroundWorker BackgroundWorker;
        private System.Windows.Forms.Timer ProgressTimer;
        private Extensions.Waiting waiting;
        private Extensions.SliderCheckBox LocalSliderCheckBox;
        private Extensions.SliderCheckBox CloudSliderCheckBox;
        private Extensions.ColorProgressBar progressBar;
        private Button DownloadButton;
        private Button DeleteButton;
    }
}