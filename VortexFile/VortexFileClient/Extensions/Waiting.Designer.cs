namespace VortexFileClient.Extensions
{
    partial class Waiting
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
            this.WaitingPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.WaitingPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // WaitingPictureBox
            // 
            this.WaitingPictureBox.BackColor = System.Drawing.Color.White;
            this.WaitingPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WaitingPictureBox.Image = global::VortexFileClient.Properties.Resources.Loading;
            this.WaitingPictureBox.Location = new System.Drawing.Point(0, 0);
            this.WaitingPictureBox.Name = "WaitingPictureBox";
            this.WaitingPictureBox.Size = new System.Drawing.Size(313, 253);
            this.WaitingPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.WaitingPictureBox.TabIndex = 0;
            this.WaitingPictureBox.TabStop = false;
            // 
            // Waiting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.WaitingPictureBox);
            this.Name = "Waiting";
            this.Size = new System.Drawing.Size(313, 253);
            ((System.ComponentModel.ISupportInitialize)(this.WaitingPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox WaitingPictureBox;
    }
}
