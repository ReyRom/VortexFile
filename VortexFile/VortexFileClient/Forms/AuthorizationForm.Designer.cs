namespace VortexFileClient.Forms
{
    partial class AuthorizationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthorizationForm));
            this.LoginTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.EnterButton = new System.Windows.Forms.Button();
            this.OnOffImageList = new System.Windows.Forms.ImageList(this.components);
            this.RegistrationLinkLabel = new System.Windows.Forms.LinkLabel();
            this.ResetPasswordLinkLabel = new System.Windows.Forms.LinkLabel();
            this.RememberCheckBox = new VortexFileClient.Extensions.SliderCheckBox();
            this.OfflineCheckBox = new VortexFileClient.Extensions.SliderCheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PasswordCheckBox = new VortexFileClient.Extensions.PasswordCheckBox();
            this.SuspendLayout();
            // 
            // LoginTextBox
            // 
            this.LoginTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(252)))));
            this.LoginTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LoginTextBox.Location = new System.Drawing.Point(30, 57);
            this.LoginTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.LoginTextBox.Name = "LoginTextBox";
            this.LoginTextBox.PlaceholderText = "Логин/Email";
            this.LoginTextBox.Size = new System.Drawing.Size(345, 26);
            this.LoginTextBox.TabIndex = 0;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(252)))));
            this.PasswordTextBox.Location = new System.Drawing.Point(30, 91);
            this.PasswordTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PlaceholderText = "Пароль";
            this.PasswordTextBox.Size = new System.Drawing.Size(304, 26);
            this.PasswordTextBox.TabIndex = 0;
            this.PasswordTextBox.UseSystemPasswordChar = true;
            // 
            // EnterButton
            // 
            this.EnterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(210)))));
            this.EnterButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.EnterButton.ForeColor = System.Drawing.Color.White;
            this.EnterButton.Location = new System.Drawing.Point(30, 164);
            this.EnterButton.Name = "EnterButton";
            this.EnterButton.Size = new System.Drawing.Size(345, 40);
            this.EnterButton.TabIndex = 1;
            this.EnterButton.Text = "Войти";
            this.EnterButton.UseVisualStyleBackColor = false;
            this.EnterButton.Click += new System.EventHandler(this.EnterButton_Click);
            // 
            // OnOffImageList
            // 
            this.OnOffImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.OnOffImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("OnOffImageList.ImageStream")));
            this.OnOffImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.OnOffImageList.Images.SetKeyName(0, "OFF1.png");
            this.OnOffImageList.Images.SetKeyName(1, "ON1.png");
            // 
            // RegistrationLinkLabel
            // 
            this.RegistrationLinkLabel.AutoSize = true;
            this.RegistrationLinkLabel.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RegistrationLinkLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(210)))));
            this.RegistrationLinkLabel.Location = new System.Drawing.Point(123, 214);
            this.RegistrationLinkLabel.Name = "RegistrationLinkLabel";
            this.RegistrationLinkLabel.Size = new System.Drawing.Size(158, 22);
            this.RegistrationLinkLabel.TabIndex = 4;
            this.RegistrationLinkLabel.TabStop = true;
            this.RegistrationLinkLabel.Text = "Зарегистрироваться";
            this.RegistrationLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.RegistrationLinkLabel_LinkClicked);
            // 
            // ResetPasswordLinkLabel
            // 
            this.ResetPasswordLinkLabel.AutoSize = true;
            this.ResetPasswordLinkLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(210)))));
            this.ResetPasswordLinkLabel.Location = new System.Drawing.Point(143, 243);
            this.ResetPasswordLinkLabel.Name = "ResetPasswordLinkLabel";
            this.ResetPasswordLinkLabel.Size = new System.Drawing.Size(120, 22);
            this.ResetPasswordLinkLabel.TabIndex = 5;
            this.ResetPasswordLinkLabel.TabStop = true;
            this.ResetPasswordLinkLabel.Text = "Забыли пароль";
            this.ResetPasswordLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ResetPasswordLinkLabel_LinkClicked);
            // 
            // RememberCheckBox
            // 
            this.RememberCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.RememberCheckBox.AutoSize = true;
            this.RememberCheckBox.FlatAppearance.BorderSize = 0;
            this.RememberCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.RememberCheckBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.RememberCheckBox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.RememberCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RememberCheckBox.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RememberCheckBox.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RememberCheckBox.ImageIndex = 0;
            this.RememberCheckBox.Location = new System.Drawing.Point(30, 124);
            this.RememberCheckBox.Name = "RememberCheckBox";
            this.RememberCheckBox.Size = new System.Drawing.Size(169, 32);
            this.RememberCheckBox.TabIndex = 6;
            this.RememberCheckBox.Text = "Запомнить меня";
            this.RememberCheckBox.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.RememberCheckBox.UseVisualStyleBackColor = true;
            // 
            // OfflineCheckBox
            // 
            this.OfflineCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.OfflineCheckBox.AutoSize = true;
            this.OfflineCheckBox.FlatAppearance.BorderSize = 0;
            this.OfflineCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.OfflineCheckBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.OfflineCheckBox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.OfflineCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OfflineCheckBox.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OfflineCheckBox.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OfflineCheckBox.ImageIndex = 0;
            this.OfflineCheckBox.Location = new System.Drawing.Point(194, 124);
            this.OfflineCheckBox.Name = "OfflineCheckBox";
            this.OfflineCheckBox.Size = new System.Drawing.Size(181, 32);
            this.OfflineCheckBox.TabIndex = 7;
            this.OfflineCheckBox.Text = "Автономный вход";
            this.OfflineCheckBox.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.OfflineCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(210)))));
            this.label1.Location = new System.Drawing.Point(163, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 37);
            this.label1.TabIndex = 8;
            this.label1.Text = "Вход";
            // 
            // PasswordCheckBox
            // 
            this.PasswordCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.PasswordCheckBox.AutoSize = true;
            this.PasswordCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.PasswordCheckBox.FlatAppearance.BorderSize = 0;
            this.PasswordCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.PasswordCheckBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.PasswordCheckBox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.PasswordCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PasswordCheckBox.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PasswordCheckBox.ImageIndex = 0;
            this.PasswordCheckBox.Location = new System.Drawing.Point(337, 86);
            this.PasswordCheckBox.Name = "PasswordCheckBox";
            this.PasswordCheckBox.Size = new System.Drawing.Size(38, 38);
            this.PasswordCheckBox.TabIndex = 9;
            this.PasswordCheckBox.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.PasswordCheckBox.UseVisualStyleBackColor = false;
            this.PasswordCheckBox.CheckedChanged += new System.EventHandler(this.PasswordCheckBox_CheckedChanged);
            // 
            // AuthorizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 279);
            this.Controls.Add(this.PasswordCheckBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OfflineCheckBox);
            this.Controls.Add(this.RememberCheckBox);
            this.Controls.Add(this.ResetPasswordLinkLabel);
            this.Controls.Add(this.RegistrationLinkLabel);
            this.Controls.Add(this.EnterButton);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.LoginTextBox);
            this.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "AuthorizationForm";
            this.Text = "Авторизация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox LoginTextBox;
        private TextBox PasswordTextBox;
        private Button EnterButton;
        private LinkLabel RegistrationLinkLabel;
        private LinkLabel ResetPasswordLinkLabel;
        private ImageList OnOffImageList;
        private Extensions.SliderCheckBox RememberCheckBox;
        private Extensions.SliderCheckBox OfflineCheckBox;
        private Label label1;
        private Extensions.PasswordCheckBox PasswordCheckBox;
    }
}