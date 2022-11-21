namespace VortexFileClient.Extensions
{
    partial class MessageBox
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
            this.HeadPanel = new System.Windows.Forms.Panel();
            this.HeaderLabel = new System.Windows.Forms.Label();
            this.LogoPictureBox = new System.Windows.Forms.PictureBox();
            this.CloseButton = new System.Windows.Forms.Button();
            this.FooterPanel = new System.Windows.Forms.Panel();
            this.ButtonsFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.NoButton = new System.Windows.Forms.Button();
            this.YesButton = new System.Windows.Forms.Button();
            this.BodyPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.IconPictureBox = new System.Windows.Forms.PictureBox();
            this.BodyFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.TextLabel = new System.Windows.Forms.Label();
            this.InputTextBox = new System.Windows.Forms.TextBox();
            this.HeadPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).BeginInit();
            this.FooterPanel.SuspendLayout();
            this.ButtonsFlowLayoutPanel.SuspendLayout();
            this.BodyPanel.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IconPictureBox)).BeginInit();
            this.BodyFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // HeadPanel
            // 
            this.HeadPanel.BackColor = System.Drawing.Color.White;
            this.HeadPanel.Controls.Add(this.HeaderLabel);
            this.HeadPanel.Controls.Add(this.LogoPictureBox);
            this.HeadPanel.Controls.Add(this.CloseButton);
            this.HeadPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeadPanel.Location = new System.Drawing.Point(0, 0);
            this.HeadPanel.Margin = new System.Windows.Forms.Padding(4);
            this.HeadPanel.Name = "HeadPanel";
            this.HeadPanel.Size = new System.Drawing.Size(469, 30);
            this.HeadPanel.TabIndex = 1;
            // 
            // HeaderLabel
            // 
            this.HeaderLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HeaderLabel.Location = new System.Drawing.Point(40, 0);
            this.HeaderLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.HeaderLabel.Name = "HeaderLabel";
            this.HeaderLabel.Size = new System.Drawing.Size(369, 30);
            this.HeaderLabel.TabIndex = 3;
            this.HeaderLabel.Text = "Header";
            this.HeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.HeaderLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HeaderLabel_MouseDown);
            this.HeaderLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.HeaderLabel_MouseMove);
            // 
            // LogoPictureBox
            // 
            this.LogoPictureBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.LogoPictureBox.Image = global::VortexFileClient.Properties.Resources.Logo;
            this.LogoPictureBox.Location = new System.Drawing.Point(0, 0);
            this.LogoPictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.LogoPictureBox.Name = "LogoPictureBox";
            this.LogoPictureBox.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.LogoPictureBox.Size = new System.Drawing.Size(40, 30);
            this.LogoPictureBox.TabIndex = 3;
            this.LogoPictureBox.TabStop = false;
            // 
            // CloseButton
            // 
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.CloseButton.FlatAppearance.BorderSize = 0;
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.Location = new System.Drawing.Point(409, 0);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(4);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(60, 30);
            this.CloseButton.TabIndex = 0;
            this.CloseButton.Text = "X";
            this.CloseButton.UseVisualStyleBackColor = true;
            // 
            // FooterPanel
            // 
            this.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(252)))));
            this.FooterPanel.Controls.Add(this.ButtonsFlowLayoutPanel);
            this.FooterPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FooterPanel.Location = new System.Drawing.Point(0, 129);
            this.FooterPanel.Name = "FooterPanel";
            this.FooterPanel.Size = new System.Drawing.Size(469, 50);
            this.FooterPanel.TabIndex = 3;
            // 
            // ButtonsFlowLayoutPanel
            // 
            this.ButtonsFlowLayoutPanel.Controls.Add(this.CancelButton);
            this.ButtonsFlowLayoutPanel.Controls.Add(this.OkButton);
            this.ButtonsFlowLayoutPanel.Controls.Add(this.NoButton);
            this.ButtonsFlowLayoutPanel.Controls.Add(this.YesButton);
            this.ButtonsFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonsFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.ButtonsFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.ButtonsFlowLayoutPanel.Name = "ButtonsFlowLayoutPanel";
            this.ButtonsFlowLayoutPanel.Padding = new System.Windows.Forms.Padding(10);
            this.ButtonsFlowLayoutPanel.Size = new System.Drawing.Size(469, 50);
            this.ButtonsFlowLayoutPanel.TabIndex = 0;
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelButton.Location = new System.Drawing.Point(374, 10);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 30);
            this.CancelButton.TabIndex = 0;
            this.CancelButton.Text = "Отмена";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Visible = false;
            // 
            // OkButton
            // 
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OkButton.Location = new System.Drawing.Point(294, 10);
            this.OkButton.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 30);
            this.OkButton.TabIndex = 1;
            this.OkButton.Text = "ОК";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Visible = false;
            // 
            // NoButton
            // 
            this.NoButton.DialogResult = System.Windows.Forms.DialogResult.No;
            this.NoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NoButton.Location = new System.Drawing.Point(214, 10);
            this.NoButton.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.NoButton.Name = "NoButton";
            this.NoButton.Size = new System.Drawing.Size(75, 30);
            this.NoButton.TabIndex = 2;
            this.NoButton.Text = "Нет";
            this.NoButton.UseVisualStyleBackColor = true;
            this.NoButton.Visible = false;
            // 
            // YesButton
            // 
            this.YesButton.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.YesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.YesButton.Location = new System.Drawing.Point(134, 10);
            this.YesButton.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.YesButton.Name = "YesButton";
            this.YesButton.Size = new System.Drawing.Size(75, 30);
            this.YesButton.TabIndex = 3;
            this.YesButton.Text = "Да";
            this.YesButton.UseVisualStyleBackColor = true;
            this.YesButton.Visible = false;
            // 
            // BodyPanel
            // 
            this.BodyPanel.AutoSize = true;
            this.BodyPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BodyPanel.BackColor = System.Drawing.Color.White;
            this.BodyPanel.Controls.Add(this.tableLayoutPanel);
            this.BodyPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BodyPanel.Location = new System.Drawing.Point(0, 30);
            this.BodyPanel.Margin = new System.Windows.Forms.Padding(4);
            this.BodyPanel.Name = "BodyPanel";
            this.BodyPanel.Size = new System.Drawing.Size(469, 99);
            this.BodyPanel.TabIndex = 4;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.AutoSize = true;
            this.tableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.Controls.Add(this.IconPictureBox, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.BodyFlowLayoutPanel, 1, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(469, 99);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // IconPictureBox
            // 
            this.IconPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IconPictureBox.Location = new System.Drawing.Point(3, 3);
            this.IconPictureBox.Name = "IconPictureBox";
            this.IconPictureBox.Size = new System.Drawing.Size(91, 93);
            this.IconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.IconPictureBox.TabIndex = 1;
            this.IconPictureBox.TabStop = false;
            // 
            // BodyFlowLayoutPanel
            // 
            this.BodyFlowLayoutPanel.AutoSize = true;
            this.BodyFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BodyFlowLayoutPanel.Controls.Add(this.TextLabel);
            this.BodyFlowLayoutPanel.Controls.Add(this.InputTextBox);
            this.BodyFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BodyFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.BodyFlowLayoutPanel.Location = new System.Drawing.Point(100, 3);
            this.BodyFlowLayoutPanel.Name = "BodyFlowLayoutPanel";
            this.BodyFlowLayoutPanel.Padding = new System.Windows.Forms.Padding(10, 30, 10, 30);
            this.BodyFlowLayoutPanel.Size = new System.Drawing.Size(366, 93);
            this.BodyFlowLayoutPanel.TabIndex = 2;
            // 
            // TextLabel
            // 
            this.TextLabel.AutoEllipsis = true;
            this.TextLabel.AutoSize = true;
            this.TextLabel.Location = new System.Drawing.Point(13, 33);
            this.TextLabel.Margin = new System.Windows.Forms.Padding(3);
            this.TextLabel.MaximumSize = new System.Drawing.Size(330, 0);
            this.TextLabel.Name = "TextLabel";
            this.TextLabel.Padding = new System.Windows.Forms.Padding(3);
            this.TextLabel.Size = new System.Drawing.Size(58, 28);
            this.TextLabel.TabIndex = 0;
            this.TextLabel.Text = "label1";
            this.TextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // InputTextBox
            // 
            this.InputTextBox.Location = new System.Drawing.Point(84, 40);
            this.InputTextBox.Margin = new System.Windows.Forms.Padding(10);
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.Size = new System.Drawing.Size(323, 26);
            this.InputTextBox.TabIndex = 4;
            this.InputTextBox.Visible = false;
            // 
            // MessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(469, 179);
            this.Controls.Add(this.BodyPanel);
            this.Controls.Add(this.FooterPanel);
            this.Controls.Add(this.HeadPanel);
            this.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MessageBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MessageBox";
            this.HeadPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).EndInit();
            this.FooterPanel.ResumeLayout(false);
            this.ButtonsFlowLayoutPanel.ResumeLayout(false);
            this.BodyPanel.ResumeLayout(false);
            this.BodyPanel.PerformLayout();
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IconPictureBox)).EndInit();
            this.BodyFlowLayoutPanel.ResumeLayout(false);
            this.BodyFlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel HeadPanel;
        protected Label HeaderLabel;
        private PictureBox LogoPictureBox;
        private Button CloseButton;
        private Panel FooterPanel;
        protected Panel BodyPanel;
        private FlowLayoutPanel ButtonsFlowLayoutPanel;
        private Button CancelButton;
        private Button OkButton;
        private Button NoButton;
        private Button YesButton;
        private TableLayoutPanel tableLayoutPanel;
        private Label TextLabel;
        private PictureBox IconPictureBox;
        private FlowLayoutPanel BodyFlowLayoutPanel;
        private TextBox InputTextBox;
    }
}