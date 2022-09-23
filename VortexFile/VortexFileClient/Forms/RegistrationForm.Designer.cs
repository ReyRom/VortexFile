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
            this.EmailTextBox = new System.Windows.Forms.TextBox();
            this.ConfirmTextBox = new System.Windows.Forms.TextBox();
            this.UsernameTextBox = new System.Windows.Forms.TextBox();
            this.PhoneTextBox = new System.Windows.Forms.TextBox();
            this.LoginTextBox = new System.Windows.Forms.TextBox();
            this.CaptchaTextBox = new System.Windows.Forms.TextBox();
            this.RenewCaptchaButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.GoBackLinkLabel = new System.Windows.Forms.LinkLabel();
            this.Captcha = new VortexFileClient.Extensions.Captcha();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // EnterButton
            // 
            this.EnterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(210)))));
            this.EnterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EnterButton.ForeColor = System.Drawing.Color.White;
            this.EnterButton.Location = new System.Drawing.Point(30, 485);
            this.EnterButton.Margin = new System.Windows.Forms.Padding(4);
            this.EnterButton.Name = "EnterButton";
            this.EnterButton.Size = new System.Drawing.Size(345, 42);
            this.EnterButton.TabIndex = 4;
            this.EnterButton.Text = "Зарегистрироваться";
            this.EnterButton.UseVisualStyleBackColor = false;
            this.EnterButton.Click += new System.EventHandler(this.EnterButton_Click);
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(252)))));
            this.PasswordTextBox.Location = new System.Drawing.Point(30, 152);
            this.PasswordTextBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PlaceholderText = "Пароль";
            this.PasswordTextBox.Size = new System.Drawing.Size(345, 26);
            this.PasswordTextBox.TabIndex = 2;
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(252)))));
            this.EmailTextBox.Location = new System.Drawing.Point(30, 113);
            this.EmailTextBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.PlaceholderText = "Email";
            this.EmailTextBox.Size = new System.Drawing.Size(345, 26);
            this.EmailTextBox.TabIndex = 3;
            // 
            // ConfirmTextBox
            // 
            this.ConfirmTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(252)))));
            this.ConfirmTextBox.Location = new System.Drawing.Point(30, 191);
            this.ConfirmTextBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.ConfirmTextBox.Name = "ConfirmTextBox";
            this.ConfirmTextBox.PlaceholderText = "Подтверждение пароля";
            this.ConfirmTextBox.Size = new System.Drawing.Size(345, 26);
            this.ConfirmTextBox.TabIndex = 5;
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(252)))));
            this.UsernameTextBox.Location = new System.Drawing.Point(30, 231);
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.PlaceholderText = "Имя пользователя";
            this.UsernameTextBox.Size = new System.Drawing.Size(345, 26);
            this.UsernameTextBox.TabIndex = 6;
            // 
            // PhoneTextBox
            // 
            this.PhoneTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(252)))));
            this.PhoneTextBox.Location = new System.Drawing.Point(30, 270);
            this.PhoneTextBox.Name = "PhoneTextBox";
            this.PhoneTextBox.PlaceholderText = "Номер телефона";
            this.PhoneTextBox.Size = new System.Drawing.Size(345, 26);
            this.PhoneTextBox.TabIndex = 7;
            // 
            // LoginTextBox
            // 
            this.LoginTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(252)))));
            this.LoginTextBox.Location = new System.Drawing.Point(30, 74);
            this.LoginTextBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.LoginTextBox.Name = "LoginTextBox";
            this.LoginTextBox.PlaceholderText = "Логин";
            this.LoginTextBox.Size = new System.Drawing.Size(345, 26);
            this.LoginTextBox.TabIndex = 8;
            // 
            // CaptchaTextBox
            // 
            this.CaptchaTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(252)))));
            this.CaptchaTextBox.Location = new System.Drawing.Point(30, 445);
            this.CaptchaTextBox.Name = "CaptchaTextBox";
            this.CaptchaTextBox.Size = new System.Drawing.Size(315, 26);
            this.CaptchaTextBox.TabIndex = 10;
            // 
            // RenewCaptchaButton
            // 
            this.RenewCaptchaButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RenewCaptchaButton.FlatAppearance.BorderSize = 0;
            this.RenewCaptchaButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RenewCaptchaButton.Image = global::VortexFileClient.Properties.Resources.Refresh;
            this.RenewCaptchaButton.Location = new System.Drawing.Point(351, 445);
            this.RenewCaptchaButton.Name = "RenewCaptchaButton";
            this.RenewCaptchaButton.Size = new System.Drawing.Size(24, 24);
            this.RenewCaptchaButton.TabIndex = 11;
            this.RenewCaptchaButton.UseVisualStyleBackColor = true;
            this.RenewCaptchaButton.Click += new System.EventHandler(this.RenewCaptchaButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(210)))));
            this.label1.Location = new System.Drawing.Point(30, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 37);
            this.label1.TabIndex = 14;
            this.label1.Text = "Регистрация";
            // 
            // GoBackLinkLabel
            // 
            this.GoBackLinkLabel.AutoSize = true;
            this.GoBackLinkLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(210)))));
            this.GoBackLinkLabel.Location = new System.Drawing.Point(133, 536);
            this.GoBackLinkLabel.Name = "GoBackLinkLabel";
            this.GoBackLinkLabel.Size = new System.Drawing.Size(137, 22);
            this.GoBackLinkLabel.TabIndex = 15;
            this.GoBackLinkLabel.TabStop = true;
            this.GoBackLinkLabel.Text = "Уже есть аккаунт";
            this.GoBackLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.GoBackLinkLabel_LinkClicked);
            // 
            // Captcha
            // 
            this.Captcha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Captcha.Location = new System.Drawing.Point(30, 337);
            this.Captcha.Margin = new System.Windows.Forms.Padding(4);
            this.Captcha.Name = "Captcha";
            this.Captcha.Size = new System.Drawing.Size(345, 91);
            this.Captcha.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(377, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 22);
            this.label2.TabIndex = 17;
            this.label2.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(377, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 22);
            this.label3.TabIndex = 18;
            this.label3.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(377, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 22);
            this.label4.TabIndex = 19;
            this.label4.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(377, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 22);
            this.label5.TabIndex = 20;
            this.label5.Text = "*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 309);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(287, 22);
            this.label6.TabIndex = 21;
            this.label6.Text = "Введите код с картинки в поле ниже:";
            // 
            // RegistrationForm
            // 
            this.AcceptButton = this.EnterButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.GoBackLinkLabel;
            this.ClientSize = new System.Drawing.Size(405, 572);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Captcha);
            this.Controls.Add(this.GoBackLinkLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RenewCaptchaButton);
            this.Controls.Add(this.CaptchaTextBox);
            this.Controls.Add(this.LoginTextBox);
            this.Controls.Add(this.PhoneTextBox);
            this.Controls.Add(this.UsernameTextBox);
            this.Controls.Add(this.ConfirmTextBox);
            this.Controls.Add(this.EnterButton);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.EmailTextBox);
            this.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RegistrationForm";
            this.Load += new System.EventHandler(this.RegistrationForm_Load);
            this.Shown += new System.EventHandler(this.RegistrationForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button EnterButton;
        private TextBox PasswordTextBox;
        private TextBox EmailTextBox;
        private TextBox ConfirmTextBox;
        private TextBox UsernameTextBox;
        private TextBox PhoneTextBox;
        private TextBox LoginTextBox;
        private TextBox CaptchaTextBox;
        private Button RenewCaptchaButton;
        private Label label1;
        private LinkLabel GoBackLinkLabel;
        private Extensions.Captcha Captcha;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}