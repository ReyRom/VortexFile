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
            this.Waiting = new VortexFileClient.Extensions.Waiting();
            this.AddButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.UsersDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // UsersDataGridView
            // 
            this.UsersDataGridView.AllowUserToAddRows = false;
            this.UsersDataGridView.AllowUserToDeleteRows = false;
            this.UsersDataGridView.AllowUserToResizeRows = false;
            this.UsersDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UsersDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.UsersDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(252)))));
            this.UsersDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UsersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UsersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LoginColumn,
            this.EmailColumn,
            this.UsernameColumn,
            this.PhoneColumn,
            this.DeleteColumn});
            this.UsersDataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(101)))), ((int)(((byte)(215)))));
            this.UsersDataGridView.Location = new System.Drawing.Point(15, 18);
            this.UsersDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.UsersDataGridView.MultiSelect = false;
            this.UsersDataGridView.Name = "UsersDataGridView";
            this.UsersDataGridView.RowHeadersVisible = false;
            this.UsersDataGridView.RowTemplate.Height = 25;
            this.UsersDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.UsersDataGridView.Size = new System.Drawing.Size(646, 361);
            this.UsersDataGridView.TabIndex = 0;
            this.UsersDataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.UsersDataGridView_CellBeginEdit);
            this.UsersDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.UsersDataGridView_CellContentClick);
            this.UsersDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.UsersDataGridView_CellEndEdit);
            // 
            // LoginColumn
            // 
            this.LoginColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LoginColumn.DataPropertyName = "Login";
            this.LoginColumn.HeaderText = "Логин";
            this.LoginColumn.MinimumWidth = 100;
            this.LoginColumn.Name = "LoginColumn";
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
            this.UsernameColumn.HeaderText = "Имя";
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
            this.DeleteColumn.FillWeight = 50F;
            this.DeleteColumn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteColumn.HeaderText = "";
            this.DeleteColumn.Name = "DeleteColumn";
            this.DeleteColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DeleteColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DeleteColumn.Text = "Удалить";
            this.DeleteColumn.UseColumnTextForButtonValue = true;
            // 
            // Waiting
            // 
            this.Waiting.Location = new System.Drawing.Point(160, 91);
            this.Waiting.Margin = new System.Windows.Forms.Padding(4);
            this.Waiting.Name = "Waiting";
            this.Waiting.Size = new System.Drawing.Size(340, 253);
            this.Waiting.TabIndex = 1;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(15, 386);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(216, 30);
            this.AddButton.TabIndex = 2;
            this.AddButton.Text = "Добавить пользователя";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // AdministrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(676, 420);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.Waiting);
            this.Controls.Add(this.UsersDataGridView);
            this.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private Extensions.Waiting Waiting;
        private Button AddButton;
    }
}