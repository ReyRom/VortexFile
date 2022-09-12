namespace Captcha
{
    partial class Captcha
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.CaptchaPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.CaptchaPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // CaptchaPictureBox
            // 
            this.CaptchaPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CaptchaPictureBox.Location = new System.Drawing.Point(0, 0);
            this.CaptchaPictureBox.Name = "CaptchaPictureBox";
            this.CaptchaPictureBox.Size = new System.Drawing.Size(279, 105);
            this.CaptchaPictureBox.TabIndex = 0;
            this.CaptchaPictureBox.TabStop = false;
            // 
            // Captcha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CaptchaPictureBox);
            this.Name = "Captcha";
            this.Size = new System.Drawing.Size(279, 105);
            ((System.ComponentModel.ISupportInitialize)(this.CaptchaPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox CaptchaPictureBox;
    }
}
