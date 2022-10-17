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
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Локальное хранилище", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Облачное хранилище", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileManagerForm));
            this.label2 = new System.Windows.Forms.Label();
            this.FileManagerListView = new System.Windows.Forms.ListView();
            this.ExtensionImageList = new System.Windows.Forms.ImageList(this.components);
            this.UploadButton = new System.Windows.Forms.Button();
            this.DownloadButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.BackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.ProgressTimer = new System.Windows.Forms.Timer(this.components);
            this.waiting = new VortexFileClient.Extensions.Waiting();
            this.progressBar = new VortexFileClient.Extensions.ColorProgressBar();
            this.LocalSliderCheckBox = new VortexFileClient.Extensions.SliderCheckBox();
            this.CloudSliderCheckBox = new VortexFileClient.Extensions.SliderCheckBox();
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
            this.FileManagerListView.AllowDrop = true;
            this.FileManagerListView.GridLines = true;
            listViewGroup3.Header = "Локальное хранилище";
            listViewGroup3.Name = "localGroup";
            listViewGroup4.Header = "Облачное хранилище";
            listViewGroup4.Name = "cloudGroup";
            this.FileManagerListView.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup3,
            listViewGroup4});
            this.FileManagerListView.LargeImageList = this.ExtensionImageList;
            this.FileManagerListView.Location = new System.Drawing.Point(273, 12);
            this.FileManagerListView.Name = "FileManagerListView";
            this.FileManagerListView.Size = new System.Drawing.Size(471, 381);
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
            this.UploadButton.Location = new System.Drawing.Point(40, 38);
            this.UploadButton.Name = "UploadButton";
            this.UploadButton.Size = new System.Drawing.Size(128, 23);
            this.UploadButton.TabIndex = 3;
            this.UploadButton.Text = "Загрузить";
            this.UploadButton.UseVisualStyleBackColor = true;
            this.UploadButton.Click += new System.EventHandler(this.UploadButton_Click);
            // 
            // DownloadButton
            // 
            this.DownloadButton.Location = new System.Drawing.Point(40, 126);
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.Size = new System.Drawing.Size(75, 23);
            this.DownloadButton.TabIndex = 4;
            this.DownloadButton.Text = "Скачать";
            this.DownloadButton.UseVisualStyleBackColor = true;
            this.DownloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(40, 155);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteButton.TabIndex = 5;
            this.DeleteButton.Text = "Удалить";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
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
            this.waiting.Location = new System.Drawing.Point(273, 12);
            this.waiting.Name = "waiting";
            this.waiting.Size = new System.Drawing.Size(471, 381);
            this.waiting.TabIndex = 8;
            this.waiting.Visible = false;
            // 
            // progressBar
            // 
            this.progressBar.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.progressBar.LineWidth = 200;
            this.progressBar.Location = new System.Drawing.Point(12, 399);
            this.progressBar.Maximum = 600;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(732, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 9;
            this.progressBar.Visible = false;
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
            this.LocalSliderCheckBox.Location = new System.Drawing.Point(40, 67);
            this.LocalSliderCheckBox.Name = "LocalSliderCheckBox";
            this.LocalSliderCheckBox.Size = new System.Drawing.Size(176, 25);
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
            this.CloudSliderCheckBox.Location = new System.Drawing.Point(40, 95);
            this.CloudSliderCheckBox.Name = "CloudSliderCheckBox";
            this.CloudSliderCheckBox.Size = new System.Drawing.Size(172, 25);
            this.CloudSliderCheckBox.TabIndex = 11;
            this.CloudSliderCheckBox.Text = "Облачное хранилище";
            this.CloudSliderCheckBox.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CloudSliderCheckBox.UseVisualStyleBackColor = true;
            this.CloudSliderCheckBox.CheckedChanged += new System.EventHandler(this.SliderCheckBox_CheckedChanged);
            // 
            // FileManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 429);
            this.Controls.Add(this.CloudSliderCheckBox);
            this.Controls.Add(this.LocalSliderCheckBox);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.waiting);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.DownloadButton);
            this.Controls.Add(this.UploadButton);
            this.Controls.Add(this.FileManagerListView);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FileManagerForm";
            this.Text = "FIleManagerForm";
            this.Load += new System.EventHandler(this.FileManagerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label2;
        private ListView FileManagerListView;
        private ImageList ExtensionImageList;
        private Button UploadButton;
        private Button DownloadButton;
        private Button DeleteButton;
        private System.ComponentModel.BackgroundWorker BackgroundWorker;
        private System.Windows.Forms.Timer ProgressTimer;
        private Extensions.Waiting waiting;
        private Extensions.ColorProgressBar progressBar;
        private Extensions.SliderCheckBox LocalSliderCheckBox;
        private Extensions.SliderCheckBox CloudSliderCheckBox;
    }
}