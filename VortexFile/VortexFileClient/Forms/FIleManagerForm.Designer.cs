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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileManagerForm));
            this.label2 = new System.Windows.Forms.Label();
            this.FileManagerListView = new System.Windows.Forms.ListView();
            this.ExtensionImageList = new System.Windows.Forms.ImageList(this.components);
            this.UploadLocalButton = new System.Windows.Forms.Button();
            this.DownloadLocalButton = new System.Windows.Forms.Button();
            this.DeleteLocalButton = new System.Windows.Forms.Button();
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
            this.FileManagerListView.LargeImageList = this.ExtensionImageList;
            this.FileManagerListView.Location = new System.Drawing.Point(273, 12);
            this.FileManagerListView.Name = "FileManagerListView";
            this.FileManagerListView.Size = new System.Drawing.Size(471, 405);
            this.FileManagerListView.SmallImageList = this.ExtensionImageList;
            this.FileManagerListView.TabIndex = 2;
            this.FileManagerListView.UseCompatibleStateImageBehavior = false;
            this.FileManagerListView.View = System.Windows.Forms.View.List;
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
            this.UploadLocalButton.Size = new System.Drawing.Size(75, 23);
            this.UploadLocalButton.TabIndex = 3;
            this.UploadLocalButton.Text = "Загрузить";
            this.UploadLocalButton.UseVisualStyleBackColor = true;
            this.UploadLocalButton.Click += new System.EventHandler(this.UploadLocalButton_Click);
            // 
            // DownloadLocalButton
            // 
            this.DownloadLocalButton.Location = new System.Drawing.Point(40, 67);
            this.DownloadLocalButton.Name = "DownloadLocalButton";
            this.DownloadLocalButton.Size = new System.Drawing.Size(75, 23);
            this.DownloadLocalButton.TabIndex = 4;
            this.DownloadLocalButton.Text = "Скачать";
            this.DownloadLocalButton.UseVisualStyleBackColor = true;
            this.DownloadLocalButton.Click += new System.EventHandler(this.DownloadLocalButton_Click);
            // 
            // DeleteLocalButton
            // 
            this.DeleteLocalButton.Location = new System.Drawing.Point(40, 96);
            this.DeleteLocalButton.Name = "DeleteLocalButton";
            this.DeleteLocalButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteLocalButton.TabIndex = 5;
            this.DeleteLocalButton.Text = "Удалить";
            this.DeleteLocalButton.UseVisualStyleBackColor = true;
            this.DeleteLocalButton.Click += new System.EventHandler(this.DeleteLocalButton_Click);
            // 
            // FileManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 429);
            this.Controls.Add(this.DeleteLocalButton);
            this.Controls.Add(this.DownloadLocalButton);
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
        private Button DownloadLocalButton;
        private Button DeleteLocalButton;
    }
}