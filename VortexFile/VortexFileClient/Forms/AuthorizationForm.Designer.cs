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
            this.LoginTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.EnterButton = new System.Windows.Forms.Button();
            this.RememberCheckBox = new System.Windows.Forms.CheckBox();
            this.OfflineCheckBox = new System.Windows.Forms.CheckBox();
            this.RegistrationLinkLabel = new System.Windows.Forms.LinkLabel();
            this.ResetPasswordLinkLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // LoginTextBox
            // 
            this.LoginTextBox.Location = new System.Drawing.Point(161, 91);
            this.LoginTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.LoginTextBox.Name = "LoginTextBox";
            this.LoginTextBox.PlaceholderText = "Логин/Email";
            this.LoginTextBox.Size = new System.Drawing.Size(127, 29);
            this.LoginTextBox.TabIndex = 0;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(161, 128);
            this.PasswordTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PlaceholderText = "Пароль";
            this.PasswordTextBox.Size = new System.Drawing.Size(127, 29);
            this.PasswordTextBox.TabIndex = 0;
            // 
            // EnterButton
            // 
            this.EnterButton.Location = new System.Drawing.Point(274, 195);
            this.EnterButton.Name = "EnterButton";
            this.EnterButton.Size = new System.Drawing.Size(137, 48);
            this.EnterButton.TabIndex = 1;
            this.EnterButton.Text = "Войти";
            this.EnterButton.UseVisualStyleBackColor = true;
            this.EnterButton.Click += new System.EventHandler(this.EnterButton_Click);
            // 
            // RememberCheckBox
            // 
            this.RememberCheckBox.AutoSize = true;
            this.RememberCheckBox.Location = new System.Drawing.Point(232, 303);
            this.RememberCheckBox.Name = "RememberCheckBox";
            this.RememberCheckBox.Size = new System.Drawing.Size(148, 25);
            this.RememberCheckBox.TabIndex = 2;
            this.RememberCheckBox.Text = "Запомнить меня";
            this.RememberCheckBox.UseVisualStyleBackColor = true;
            // 
            // OfflineCheckBox
            // 
            this.OfflineCheckBox.AutoSize = true;
            this.OfflineCheckBox.Location = new System.Drawing.Point(252, 345);
            this.OfflineCheckBox.Name = "OfflineCheckBox";
            this.OfflineCheckBox.Size = new System.Drawing.Size(158, 25);
            this.OfflineCheckBox.TabIndex = 3;
            this.OfflineCheckBox.Text = "Автономный вход";
            this.OfflineCheckBox.UseVisualStyleBackColor = true;
            // 
            // RegistrationLinkLabel
            // 
            this.RegistrationLinkLabel.AutoSize = true;
            this.RegistrationLinkLabel.Location = new System.Drawing.Point(79, 459);
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
            this.ResetPasswordLinkLabel.Location = new System.Drawing.Point(544, 465);
            this.ResetPasswordLinkLabel.Name = "ResetPasswordLinkLabel";
            this.ResetPasswordLinkLabel.Size = new System.Drawing.Size(119, 21);
            this.ResetPasswordLinkLabel.TabIndex = 5;
            this.ResetPasswordLinkLabel.TabStop = true;
            this.ResetPasswordLinkLabel.Text = "Забыли пароль";
            // 
            // AuthorizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 525);
            this.Controls.Add(this.ResetPasswordLinkLabel);
            this.Controls.Add(this.RegistrationLinkLabel);
            this.Controls.Add(this.OfflineCheckBox);
            this.Controls.Add(this.RememberCheckBox);
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
        private CheckBox RememberCheckBox;
        private CheckBox OfflineCheckBox;
        private LinkLabel RegistrationLinkLabel;
        private LinkLabel ResetPasswordLinkLabel;
    }
}