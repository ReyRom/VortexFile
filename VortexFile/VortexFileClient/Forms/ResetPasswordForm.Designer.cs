namespace VortexFileClient.Forms
{
    partial class ResetPasswordForm
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
            this.SendCodeButton = new System.Windows.Forms.Button();
            this.CodeTextBox = new System.Windows.Forms.TextBox();
            this.ConfirmCodeButton = new System.Windows.Forms.Button();
            this.ConfirmTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LoginTextBox
            // 
            this.LoginTextBox.Location = new System.Drawing.Point(83, 68);
            this.LoginTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.LoginTextBox.Name = "LoginTextBox";
            this.LoginTextBox.PlaceholderText = "Логин/Email";
            this.LoginTextBox.Size = new System.Drawing.Size(127, 29);
            this.LoginTextBox.TabIndex = 1;
            // 
            // SendCodeButton
            // 
            this.SendCodeButton.Location = new System.Drawing.Point(274, 67);
            this.SendCodeButton.Name = "SendCodeButton";
            this.SendCodeButton.Size = new System.Drawing.Size(159, 29);
            this.SendCodeButton.TabIndex = 2;
            this.SendCodeButton.Text = "Отправить код";
            this.SendCodeButton.UseVisualStyleBackColor = true;
            // 
            // CodeTextBox
            // 
            this.CodeTextBox.Location = new System.Drawing.Point(84, 110);
            this.CodeTextBox.Name = "CodeTextBox";
            this.CodeTextBox.PlaceholderText = "Код подтверждения";
            this.CodeTextBox.Size = new System.Drawing.Size(161, 29);
            this.CodeTextBox.TabIndex = 3;
            // 
            // ConfirmCodeButton
            // 
            this.ConfirmCodeButton.Location = new System.Drawing.Point(274, 109);
            this.ConfirmCodeButton.Name = "ConfirmCodeButton";
            this.ConfirmCodeButton.Size = new System.Drawing.Size(159, 30);
            this.ConfirmCodeButton.TabIndex = 4;
            this.ConfirmCodeButton.Text = "Подтвердить";
            this.ConfirmCodeButton.UseVisualStyleBackColor = true;
            // 
            // ConfirmTextBox
            // 
            this.ConfirmTextBox.Location = new System.Drawing.Point(84, 200);
            this.ConfirmTextBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.ConfirmTextBox.Name = "ConfirmTextBox";
            this.ConfirmTextBox.PlaceholderText = "Подтверждение пароля";
            this.ConfirmTextBox.Size = new System.Drawing.Size(225, 29);
            this.ConfirmTextBox.TabIndex = 7;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(84, 159);
            this.PasswordTextBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PlaceholderText = "Новый пароль";
            this.PasswordTextBox.Size = new System.Drawing.Size(225, 29);
            this.PasswordTextBox.TabIndex = 6;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(321, 172);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(112, 44);
            this.SaveButton.TabIndex = 8;
            this.SaveButton.Text = "Сохранить";
            this.SaveButton.UseVisualStyleBackColor = true;
            // 
            // ResetPasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 312);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.ConfirmTextBox);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.ConfirmCodeButton);
            this.Controls.Add(this.CodeTextBox);
            this.Controls.Add(this.SendCodeButton);
            this.Controls.Add(this.LoginTextBox);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ResetPasswordForm";
            this.Text = "Восстановление пароля";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox LoginTextBox;
        private Button SendCodeButton;
        private TextBox CodeTextBox;
        private Button ConfirmCodeButton;
        private TextBox ConfirmTextBox;
        private TextBox PasswordTextBox;
        private Button SaveButton;
    }
}