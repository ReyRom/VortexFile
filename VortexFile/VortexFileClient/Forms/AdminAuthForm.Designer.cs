namespace VortexFileClient.Forms
{
    partial class AdminAuthForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminAuthForm));
            this.PasswordCheckBox = new VortexFileClient.Extensions.PasswordCheckBox();
            this.EnterButton = new System.Windows.Forms.Button();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.OnOffImageList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // PasswordCheckBox
            // 
            this.PasswordCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.PasswordCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(252)))));
            this.PasswordCheckBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PasswordCheckBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PasswordCheckBox.FlatAppearance.BorderSize = 0;
            this.PasswordCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(252)))));
            this.PasswordCheckBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(252)))));
            this.PasswordCheckBox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(252)))));
            this.PasswordCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PasswordCheckBox.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PasswordCheckBox.ImageIndex = 0;
            this.PasswordCheckBox.Location = new System.Drawing.Point(339, 50);
            this.PasswordCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.PasswordCheckBox.Name = "PasswordCheckBox";
            this.PasswordCheckBox.Size = new System.Drawing.Size(35, 23);
            this.PasswordCheckBox.TabIndex = 12;
            this.PasswordCheckBox.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.PasswordCheckBox.UseVisualStyleBackColor = false;
            this.PasswordCheckBox.CheckedChanged += new System.EventHandler(this.PasswordCheckBox_CheckedChanged);
            // 
            // EnterButton
            // 
            this.EnterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(210)))));
            this.EnterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EnterButton.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.EnterButton.ForeColor = System.Drawing.Color.White;
            this.EnterButton.Location = new System.Drawing.Point(30, 93);
            this.EnterButton.Margin = new System.Windows.Forms.Padding(4);
            this.EnterButton.Name = "EnterButton";
            this.EnterButton.Size = new System.Drawing.Size(345, 40);
            this.EnterButton.TabIndex = 11;
            this.EnterButton.Text = "Войти";
            this.EnterButton.UseVisualStyleBackColor = false;
            this.EnterButton.Click += new System.EventHandler(this.EnterButton_Click);
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(252)))));
            this.PasswordTextBox.Location = new System.Drawing.Point(30, 49);
            this.PasswordTextBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.PasswordTextBox.MaxLength = 20;
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PlaceholderText = "Пароль";
            this.PasswordTextBox.Size = new System.Drawing.Size(345, 26);
            this.PasswordTextBox.TabIndex = 10;
            this.PasswordTextBox.UseSystemPasswordChar = true;
            // 
            // OnOffImageList
            // 
            this.OnOffImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.OnOffImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("OnOffImageList.ImageStream")));
            this.OnOffImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.OnOffImageList.Images.SetKeyName(0, "OFF1.png");
            this.OnOffImageList.Images.SetKeyName(1, "ON1.png");
            // 
            // AdminAuthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(406, 164);
            this.Controls.Add(this.PasswordCheckBox);
            this.Controls.Add(this.EnterButton);
            this.Controls.Add(this.PasswordTextBox);
            this.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AdminAuthForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Extensions.PasswordCheckBox PasswordCheckBox;
        private Button EnterButton;
        private TextBox PasswordTextBox;
        private ImageList OnOffImageList;
    }
}