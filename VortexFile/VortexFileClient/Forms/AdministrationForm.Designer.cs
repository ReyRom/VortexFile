namespace VortexFileClient.Forms
{
    partial class AdministrationForm
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
            this.DeleteColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.UsersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.UsersDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // UsersDataGridView
            // 
            this.UsersDataGridView.AllowUserToAddRows = false;
            this.UsersDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.UsersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UsersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LoginColumn,
            this.EmailColumn,
            this.UsernameColumn,
            this.PhoneColumn,
            this.DeleteColumn});
            this.UsersDataGridView.Location = new System.Drawing.Point(12, 12);
            this.UsersDataGridView.Name = "UsersDataGridView";
            this.UsersDataGridView.RowTemplate.Height = 25;
            this.UsersDataGridView.Size = new System.Drawing.Size(599, 373);
            this.UsersDataGridView.TabIndex = 0;
            this.UsersDataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.UsersDataGridView_CellBeginEdit);
            this.UsersDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.UsersDataGridView_CellContentClick);
            this.UsersDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.UsersDataGridView_CellEndEdit);
            // 
            // LoginColumn
            // 
            this.LoginColumn.DataPropertyName = "Login";
            this.LoginColumn.HeaderText = "Логин";
            this.LoginColumn.Name = "LoginColumn";
            this.LoginColumn.ReadOnly = true;
            // 
            // EmailColumn
            // 
            this.EmailColumn.DataPropertyName = "Email";
            this.EmailColumn.HeaderText = "Email";
            this.EmailColumn.Name = "EmailColumn";
            // 
            // UsernameColumn
            // 
            this.UsernameColumn.DataPropertyName = "Username";
            this.UsernameColumn.HeaderText = "Имя пользователя";
            this.UsernameColumn.Name = "UsernameColumn";
            // 
            // PhoneColumn
            // 
            this.PhoneColumn.DataPropertyName = "Phone";
            this.PhoneColumn.HeaderText = "Номер телефона";
            this.PhoneColumn.Name = "PhoneColumn";
            // 
            // DeleteColumn
            // 
            this.DeleteColumn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteColumn.HeaderText = "";
            this.DeleteColumn.Name = "DeleteColumn";
            this.DeleteColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DeleteColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DeleteColumn.Text = "Удалить";
            this.DeleteColumn.UseColumnTextForButtonValue = true;
            // 
            // AdministrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 397);
            this.Controls.Add(this.UsersDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdministrationForm";
            this.Text = "AdministationForm";
            this.Load += new System.EventHandler(this.AdministrationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UsersDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsersBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView UsersDataGridView;
        private BindingSource UsersBindingSource;
        private DataGridViewTextBoxColumn LoginColumn;
        private DataGridViewTextBoxColumn EmailColumn;
        private DataGridViewTextBoxColumn UsernameColumn;
        private DataGridViewTextBoxColumn PhoneColumn;
        private DataGridViewButtonColumn DeleteColumn;
    }
}