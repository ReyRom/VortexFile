namespace VortexFileClient.Forms
{
    partial class RegistrationForm
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
            this.EnterButton = new System.Windows.Forms.Button();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.LoginTextBox = new System.Windows.Forms.TextBox();
            this.ConfirmTextBox = new System.Windows.Forms.TextBox();
            this.UsernameTextBox = new System.Windows.Forms.TextBox();
            this.PhoneTextBox = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Captcha = new VortexFileClient.Extensions.Captcha();
            this.CaptchaTextBox = new System.Windows.Forms.TextBox();
            this.RenewCaptchaButton = new System.Windows.Forms.Button();
            this.GoBackButton = new System.Windows.Forms.Button();
            this.ConfirmCaptchaButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EnterButton
            // 
            this.EnterButton.Location = new System.Drawing.Point(569, 372);
            this.EnterButton.Margin = new System.Windows.Forms.Padding(4);
            this.EnterButton.Name = "EnterButton";
            this.EnterButton.Size = new System.Drawing.Size(176, 67);
            this.EnterButton.TabIndex = 4;
            this.EnterButton.Text = "Зарегистрироваться";
            this.EnterButton.UseVisualStyleBackColor = true;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(88, 114);
            this.PasswordTextBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PlaceholderText = "Пароль";
            this.PasswordTextBox.Size = new System.Drawing.Size(225, 29);
            this.PasswordTextBox.TabIndex = 2;
            // 
            // LoginTextBox
            // 
            this.LoginTextBox.Location = new System.Drawing.Point(88, 73);
            this.LoginTextBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.LoginTextBox.Name = "LoginTextBox";
            this.LoginTextBox.PlaceholderText = "Email";
            this.LoginTextBox.Size = new System.Drawing.Size(225, 29);
            this.LoginTextBox.TabIndex = 3;
            // 
            // ConfirmTextBox
            // 
            this.ConfirmTextBox.Location = new System.Drawing.Point(88, 155);
            this.ConfirmTextBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.ConfirmTextBox.Name = "ConfirmTextBox";
            this.ConfirmTextBox.PlaceholderText = "Подтверждение пароля";
            this.ConfirmTextBox.Size = new System.Drawing.Size(225, 29);
            this.ConfirmTextBox.TabIndex = 5;
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.Location = new System.Drawing.Point(88, 193);
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.PlaceholderText = "Имя пользователя(необязательно)";
            this.UsernameTextBox.Size = new System.Drawing.Size(261, 29);
            this.UsernameTextBox.TabIndex = 6;
            // 
            // PhoneTextBox
            // 
            this.PhoneTextBox.Location = new System.Drawing.Point(88, 238);
            this.PhoneTextBox.Name = "PhoneTextBox";
            this.PhoneTextBox.PlaceholderText = "Номер телефона(необязательно)";
            this.PhoneTextBox.Size = new System.Drawing.Size(261, 29);
            this.PhoneTextBox.TabIndex = 7;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(88, 32);
            this.textBox1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.PlaceholderText = "Логин";
            this.textBox1.Size = new System.Drawing.Size(225, 29);
            this.textBox1.TabIndex = 8;
            // 
            // Captcha
            // 
            this.Captcha.Location = new System.Drawing.Point(422, 32);
            this.Captcha.Margin = new System.Windows.Forms.Padding(4);
            this.Captcha.Name = "Captcha";
            this.Captcha.Size = new System.Drawing.Size(278, 106);
            this.Captcha.TabIndex = 9;
            // 
            // CaptchaTextBox
            // 
            this.CaptchaTextBox.Location = new System.Drawing.Point(422, 145);
            this.CaptchaTextBox.Name = "CaptchaTextBox";
            this.CaptchaTextBox.Size = new System.Drawing.Size(151, 29);
            this.CaptchaTextBox.TabIndex = 10;
            // 
            // RenewCaptchaButton
            // 
            this.RenewCaptchaButton.Location = new System.Drawing.Point(707, 67);
            this.RenewCaptchaButton.Name = "RenewCaptchaButton";
            this.RenewCaptchaButton.Size = new System.Drawing.Size(118, 39);
            this.RenewCaptchaButton.TabIndex = 11;
            this.RenewCaptchaButton.Text = "Обновить";
            this.RenewCaptchaButton.UseVisualStyleBackColor = true;
            this.RenewCaptchaButton.Click += new System.EventHandler(this.RenewCaptchaButton_Click);
            // 
            // GoBackButton
            // 
            this.GoBackButton.Location = new System.Drawing.Point(84, 388);
            this.GoBackButton.Name = "GoBackButton";
            this.GoBackButton.Size = new System.Drawing.Size(146, 43);
            this.GoBackButton.TabIndex = 12;
            this.GoBackButton.Text = "button1";
            this.GoBackButton.UseVisualStyleBackColor = true;
            this.GoBackButton.Click += new System.EventHandler(this.GoBackButton_Click);
            // 
            // ConfirmCaptchaButton
            // 
            this.ConfirmCaptchaButton.Location = new System.Drawing.Point(588, 145);
            this.ConfirmCaptchaButton.Name = "ConfirmCaptchaButton";
            this.ConfirmCaptchaButton.Size = new System.Drawing.Size(112, 29);
            this.ConfirmCaptchaButton.TabIndex = 13;
            this.ConfirmCaptchaButton.Text = "Я не робот";
            this.ConfirmCaptchaButton.UseVisualStyleBackColor = true;
            this.ConfirmCaptchaButton.Click += new System.EventHandler(this.ConfirmCaptchaButton_Click);
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 511);
            this.Controls.Add(this.ConfirmCaptchaButton);
            this.Controls.Add(this.GoBackButton);
            this.Controls.Add(this.RenewCaptchaButton);
            this.Controls.Add(this.CaptchaTextBox);
            this.Controls.Add(this.Captcha);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.PhoneTextBox);
            this.Controls.Add(this.UsernameTextBox);
            this.Controls.Add(this.ConfirmTextBox);
            this.Controls.Add(this.EnterButton);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.LoginTextBox);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RegistrationForm";
            this.Text = "RegistrationForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button EnterButton;
        private TextBox PasswordTextBox;
        private TextBox LoginTextBox;
        private TextBox ConfirmTextBox;
        private TextBox UsernameTextBox;
        private TextBox PhoneTextBox;
        private TextBox textBox1;
        private Extensions.Captcha Captcha;
        private TextBox CaptchaTextBox;
        private Button RenewCaptchaButton;
        private Button GoBackButton;
        private Button ConfirmCaptchaButton;
    }
}