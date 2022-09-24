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
            this.components = new System.ComponentModel.Container();
            this.LoginTextBox = new System.Windows.Forms.TextBox();
            this.SendCodeButton = new System.Windows.Forms.Button();
            this.CodeTextBox = new System.Windows.Forms.TextBox();
            this.ConfirmTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.LoginTabPage = new System.Windows.Forms.TabPage();
            this.CodeTabPage = new System.Windows.Forms.TabPage();
            this.SendCodeLinkLabel = new System.Windows.Forms.LinkLabel();
            this.PasswordTabPage = new System.Windows.Forms.TabPage();
            this.PasswordCheckBox = new VortexFileClient.Extensions.PasswordCheckBox();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl.SuspendLayout();
            this.LoginTabPage.SuspendLayout();
            this.CodeTabPage.SuspendLayout();
            this.PasswordTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoginTextBox
            // 
            this.LoginTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(252)))));
            this.LoginTextBox.Location = new System.Drawing.Point(30, 41);
            this.LoginTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.LoginTextBox.Name = "LoginTextBox";
            this.LoginTextBox.PlaceholderText = "Логин/Email";
            this.LoginTextBox.Size = new System.Drawing.Size(345, 26);
            this.LoginTextBox.TabIndex = 1;
            // 
            // SendCodeButton
            // 
            this.SendCodeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(210)))));
            this.SendCodeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SendCodeButton.ForeColor = System.Drawing.Color.White;
            this.SendCodeButton.Location = new System.Drawing.Point(117, 81);
            this.SendCodeButton.Name = "SendCodeButton";
            this.SendCodeButton.Size = new System.Drawing.Size(149, 42);
            this.SendCodeButton.TabIndex = 2;
            this.SendCodeButton.Text = "Отправить код";
            this.SendCodeButton.UseVisualStyleBackColor = false;
            this.SendCodeButton.Click += new System.EventHandler(this.SendCodeButton_Click);
            // 
            // CodeTextBox
            // 
            this.CodeTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(252)))));
            this.CodeTextBox.Location = new System.Drawing.Point(85, 50);
            this.CodeTextBox.MaxLength = 5;
            this.CodeTextBox.Name = "CodeTextBox";
            this.CodeTextBox.PlaceholderText = "Код подтверждения";
            this.CodeTextBox.Size = new System.Drawing.Size(238, 26);
            this.CodeTextBox.TabIndex = 3;
            this.CodeTextBox.TextChanged += new System.EventHandler(this.CodeTextBox_TextChanged);
            this.CodeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CodeTextBox_KeyPress);
            // 
            // ConfirmTextBox
            // 
            this.ConfirmTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(252)))));
            this.ConfirmTextBox.Location = new System.Drawing.Point(30, 62);
            this.ConfirmTextBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.ConfirmTextBox.MaxLength = 20;
            this.ConfirmTextBox.Name = "ConfirmTextBox";
            this.ConfirmTextBox.PlaceholderText = "Подтверждение пароля";
            this.ConfirmTextBox.Size = new System.Drawing.Size(345, 26);
            this.ConfirmTextBox.TabIndex = 7;
            this.ConfirmTextBox.UseSystemPasswordChar = true;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(252)))));
            this.PasswordTextBox.Location = new System.Drawing.Point(30, 23);
            this.PasswordTextBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.PasswordTextBox.MaxLength = 20;
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PlaceholderText = "Новый пароль";
            this.PasswordTextBox.Size = new System.Drawing.Size(345, 26);
            this.PasswordTextBox.TabIndex = 6;
            this.PasswordTextBox.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(210)))));
            this.label1.Location = new System.Drawing.Point(30, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(336, 37);
            this.label1.TabIndex = 15;
            this.label1.Text = "Восстановление пароля";
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl.Controls.Add(this.LoginTabPage);
            this.tabControl.Controls.Add(this.CodeTabPage);
            this.tabControl.Controls.Add(this.PasswordTabPage);
            this.tabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl.ItemSize = new System.Drawing.Size(100, 16);
            this.tabControl.Location = new System.Drawing.Point(-5, 63);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(418, 189);
            this.tabControl.TabIndex = 16;
            this.tabControl.TabStop = false;
            // 
            // LoginTabPage
            // 
            this.LoginTabPage.BackColor = System.Drawing.Color.White;
            this.LoginTabPage.Controls.Add(this.LoginTextBox);
            this.LoginTabPage.Controls.Add(this.SendCodeButton);
            this.LoginTabPage.Location = new System.Drawing.Point(4, 20);
            this.LoginTabPage.Name = "LoginTabPage";
            this.LoginTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.LoginTabPage.Size = new System.Drawing.Size(410, 165);
            this.LoginTabPage.TabIndex = 0;
            this.LoginTabPage.Text = "LoginTabPage";
            // 
            // CodeTabPage
            // 
            this.CodeTabPage.Controls.Add(this.SendCodeLinkLabel);
            this.CodeTabPage.Controls.Add(this.CodeTextBox);
            this.CodeTabPage.Location = new System.Drawing.Point(4, 20);
            this.CodeTabPage.Name = "CodeTabPage";
            this.CodeTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.CodeTabPage.Size = new System.Drawing.Size(410, 165);
            this.CodeTabPage.TabIndex = 1;
            this.CodeTabPage.Text = "CodeTabPage";
            this.CodeTabPage.UseVisualStyleBackColor = true;
            // 
            // SendCodeLinkLabel
            // 
            this.SendCodeLinkLabel.AutoSize = true;
            this.SendCodeLinkLabel.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SendCodeLinkLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(210)))));
            this.SendCodeLinkLabel.Location = new System.Drawing.Point(107, 90);
            this.SendCodeLinkLabel.Name = "SendCodeLinkLabel";
            this.SendCodeLinkLabel.Size = new System.Drawing.Size(188, 22);
            this.SendCodeLinkLabel.TabIndex = 5;
            this.SendCodeLinkLabel.TabStop = true;
            this.SendCodeLinkLabel.Text = "Отправить код повторно";
            this.SendCodeLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SendCodeLinkLabel_LinkClicked);
            // 
            // PasswordTabPage
            // 
            this.PasswordTabPage.Controls.Add(this.PasswordCheckBox);
            this.PasswordTabPage.Controls.Add(this.ConfirmButton);
            this.PasswordTabPage.Controls.Add(this.ConfirmTextBox);
            this.PasswordTabPage.Controls.Add(this.PasswordTextBox);
            this.PasswordTabPage.Location = new System.Drawing.Point(4, 20);
            this.PasswordTabPage.Name = "PasswordTabPage";
            this.PasswordTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.PasswordTabPage.Size = new System.Drawing.Size(410, 165);
            this.PasswordTabPage.TabIndex = 2;
            this.PasswordTabPage.Text = "PasswordTabPage";
            this.PasswordTabPage.UseVisualStyleBackColor = true;
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
            this.PasswordCheckBox.Location = new System.Drawing.Point(339, 24);
            this.PasswordCheckBox.Name = "PasswordCheckBox";
            this.PasswordCheckBox.Size = new System.Drawing.Size(35, 24);
            this.PasswordCheckBox.TabIndex = 10;
            this.PasswordCheckBox.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.PasswordCheckBox.UseVisualStyleBackColor = false;
            this.PasswordCheckBox.CheckedChanged += new System.EventHandler(this.PasswordCheckBox_CheckedChanged);
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(210)))));
            this.ConfirmButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConfirmButton.ForeColor = System.Drawing.Color.White;
            this.ConfirmButton.Location = new System.Drawing.Point(30, 97);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(345, 42);
            this.ConfirmButton.TabIndex = 9;
            this.ConfirmButton.Text = "Подтвердить";
            this.ConfirmButton.UseVisualStyleBackColor = false;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(-4, 61);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(428, 34);
            this.panel1.TabIndex = 17;
            // 
            // ResetPasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(408, 246);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ResetPasswordForm";
            this.Load += new System.EventHandler(this.ResetPasswordForm_Load);
            this.tabControl.ResumeLayout(false);
            this.LoginTabPage.ResumeLayout(false);
            this.LoginTabPage.PerformLayout();
            this.CodeTabPage.ResumeLayout(false);
            this.CodeTabPage.PerformLayout();
            this.PasswordTabPage.ResumeLayout(false);
            this.PasswordTabPage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox LoginTextBox;
        private Button SendCodeButton;
        private TextBox CodeTextBox;
        private TextBox ConfirmTextBox;
        private TextBox PasswordTextBox;
        private Label label1;
        private TabControl tabControl;
        private TabPage LoginTabPage;
        private TabPage CodeTabPage;
        private TabPage PasswordTabPage;
        private LinkLabel SendCodeLinkLabel;
        private Button ConfirmButton;
        private Panel panel1;
        private Extensions.PasswordCheckBox PasswordCheckBox;
    }
}