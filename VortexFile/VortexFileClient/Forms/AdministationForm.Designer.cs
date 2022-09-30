namespace VortexFileClient.Forms
{
    partial class AdministationForm
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
            this.UsersDataGridView = new System.Windows.Forms.DataGridView();
            this.LoginColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmailColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsernameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhoneColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.UsersDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // UsersDataGridView
            // 
            this.UsersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UsersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LoginColumn,
            this.EmailColumn,
            this.UsernameColumn,
            this.PhoneColumn});
            this.UsersDataGridView.Location = new System.Drawing.Point(12, 12);
            this.UsersDataGridView.Name = "UsersDataGridView";
            this.UsersDataGridView.RowTemplate.Height = 25;
            this.UsersDataGridView.Size = new System.Drawing.Size(599, 373);
            this.UsersDataGridView.TabIndex = 0;
            // 
            // LoginColumn
            // 
            this.LoginColumn.HeaderText = "Логин";
            this.LoginColumn.Name = "LoginColumn";
            // 
            // EmailColumn
            // 
            this.EmailColumn.HeaderText = "Email";
            this.EmailColumn.Name = "EmailColumn";
            // 
            // UsernameColumn
            // 
            this.UsernameColumn.HeaderText = "Имя пользователя";
            this.UsernameColumn.Name = "UsernameColumn";
            // 
            // PhoneColumn
            // 
            this.PhoneColumn.HeaderText = "Номер телефона";
            this.PhoneColumn.Name = "PhoneColumn";
            // 
            // AdministationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 397);
            this.Controls.Add(this.UsersDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdministationForm";
            this.Text = "AdministationForm";
            this.Load += new System.EventHandler(this.AdministationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UsersDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsersBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView UsersDataGridView;
        private DataGridViewTextBoxColumn LoginColumn;
        private DataGridViewTextBoxColumn EmailColumn;
        private DataGridViewTextBoxColumn UsernameColumn;
        private DataGridViewTextBoxColumn PhoneColumn;
        private BindingSource UsersBindingSource;
    }
}