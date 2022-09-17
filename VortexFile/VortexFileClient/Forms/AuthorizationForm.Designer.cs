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
            this.SuspendLayout();
            // 
            // LoginTextBox
            // 
            this.LoginTextBox.Location = new System.Drawing.Point(59, 82);
            this.LoginTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.LoginTextBox.Name = "LoginTextBox";
            this.LoginTextBox.PlaceholderText = "Логин/Email";
            this.LoginTextBox.Size = new System.Drawing.Size(273, 29);
            this.LoginTextBox.TabIndex = 0;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(59, 119);
            this.PasswordTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PlaceholderText = "Пароль";
            this.PasswordTextBox.Size = new System.Drawing.Size(273, 29);
            this.PasswordTextBox.TabIndex = 0;
            // 
            // EnterButton
            // 
            this.EnterButton.Location = new System.Drawing.Point(358, 87);
            this.EnterButton.Name = "EnterButton";
            this.EnterButton.Size = new System.Drawing.Size(137, 48);
            this.EnterButton.TabIndex = 1;
            this.EnterButton.Text = "Войти";
            this.EnterButton.UseVisualStyleBackColor = true;
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
            this.RegistrationLinkLabel.Location = new System.Drawing.Point(12, 275);
            this.RegistrationLinkLabel.Name = "RegistrationLinkLabel";
            this.RegistrationLinkLabel.Size = new System.Drawing.Size(155, 21);
            this.RegistrationLinkLabel.TabIndex = 4;
            this.RegistrationLinkLabel.TabStop = true;
            this.RegistrationLinkLabel.Text = "Зарегистрироваться";
            this.RegistrationLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.RegistrationLinkLabel_LinkClicked);
            // 
            // ResetPasswordLinkLabel
            // 
            this.ResetPasswordLinkLabel.AutoSize = true;
            this.ResetPasswordLinkLabel.Location = new System.Drawing.Point(424, 275);
            this.ResetPasswordLinkLabel.Name = "ResetPasswordLinkLabel";
            this.ResetPasswordLinkLabel.Size = new System.Drawing.Size(119, 21);
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
            this.RememberCheckBox.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RememberCheckBox.ImageIndex = 0;
            this.RememberCheckBox.Location = new System.Drawing.Point(59, 155);
            this.RememberCheckBox.Name = "RememberCheckBox";
            this.RememberCheckBox.Size = new System.Drawing.Size(171, 31);
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
            this.OfflineCheckBox.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OfflineCheckBox.ImageIndex = 0;
            this.OfflineCheckBox.Location = new System.Drawing.Point(59, 192);
            this.OfflineCheckBox.Name = "OfflineCheckBox";
            this.OfflineCheckBox.Size = new System.Drawing.Size(181, 31);
            this.OfflineCheckBox.TabIndex = 7;
            this.OfflineCheckBox.Text = "Автономный вход";
            this.OfflineCheckBox.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.OfflineCheckBox.UseVisualStyleBackColor = true;
            // 
            // AuthorizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 305);
            this.Controls.Add(this.OfflineCheckBox);
            this.Controls.Add(this.RememberCheckBox);
            this.Controls.Add(this.ResetPasswordLinkLabel);
            this.Controls.Add(this.RegistrationLinkLabel);
            this.Controls.Add(this.EnterButton);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.LoginTextBox);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
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
    }
}