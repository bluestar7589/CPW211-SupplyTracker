namespace SupplyTracker.Views
{
    partial class UserForm
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
            lblCaption = new Label();
            lblUserID = new Label();
            lblUsername = new Label();
            lblPassword = new Label();
            lblRole = new Label();
            lblLastLogin = new Label();
            txtUserID = new TextBox();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            dtpLastLogin = new DateTimePicker();
            cboRole = new ComboBox();
            lstUser = new ListView();
            btnAdd = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            btnExit = new Button();
            SuspendLayout();
            // 
            // lblCaption
            // 
            lblCaption.AutoSize = true;
            lblCaption.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblCaption.Location = new Point(299, 9);
            lblCaption.Name = "lblCaption";
            lblCaption.Size = new Size(185, 28);
            lblCaption.TabIndex = 1;
            lblCaption.Text = "User Management";
            // 
            // lblUserID
            // 
            lblUserID.AutoSize = true;
            lblUserID.Location = new Point(40, 98);
            lblUserID.Name = "lblUserID";
            lblUserID.Size = new Size(41, 15);
            lblUserID.TabIndex = 2;
            lblUserID.Text = "UserID";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(40, 149);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(60, 15);
            lblUsername.TabIndex = 3;
            lblUsername.Text = "Username";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(40, 212);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(57, 15);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Password";
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Location = new Point(40, 269);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(30, 15);
            lblRole.TabIndex = 5;
            lblRole.Text = "Role";
            // 
            // lblLastLogin
            // 
            lblLastLogin.AutoSize = true;
            lblLastLogin.Location = new Point(40, 320);
            lblLastLogin.Name = "lblLastLogin";
            lblLastLogin.Size = new Size(88, 15);
            lblLastLogin.TabIndex = 6;
            lblLastLogin.Text = "Last Login Date";
            // 
            // txtUserID
            // 
            txtUserID.Location = new Point(160, 98);
            txtUserID.Name = "txtUserID";
            txtUserID.Size = new Size(100, 23);
            txtUserID.TabIndex = 7;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(160, 149);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(145, 23);
            txtUsername.TabIndex = 8;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(160, 212);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(145, 23);
            txtPassword.TabIndex = 9;
            // 
            // dtpLastLogin
            // 
            dtpLastLogin.Location = new Point(160, 320);
            dtpLastLogin.Name = "dtpLastLogin";
            dtpLastLogin.Size = new Size(200, 23);
            dtpLastLogin.TabIndex = 10;
            // 
            // cboRole
            // 
            cboRole.FormattingEnabled = true;
            cboRole.Location = new Point(160, 269);
            cboRole.Name = "cboRole";
            cboRole.Size = new Size(145, 23);
            cboRole.TabIndex = 11;
            // 
            // lstUser
            // 
            lstUser.FullRowSelect = true;
            lstUser.Location = new Point(385, 98);
            lstUser.Name = "lstUser";
            lstUser.Size = new Size(375, 245);
            lstUser.TabIndex = 23;
            lstUser.UseCompatibleStateImageBehavior = false;
            lstUser.SelectedIndexChanged += lstUser_SelectedIndexChanged;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(139, 398);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 24;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(282, 398);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 25;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(427, 398);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 26;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(568, 398);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 23);
            btnExit.TabIndex = 27;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnExit);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(lstUser);
            Controls.Add(cboRole);
            Controls.Add(dtpLastLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(txtUserID);
            Controls.Add(lblLastLogin);
            Controls.Add(lblRole);
            Controls.Add(lblPassword);
            Controls.Add(lblUsername);
            Controls.Add(lblUserID);
            Controls.Add(lblCaption);
            Name = "UserForm";
            Text = "UserForm";
            Load += UserForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCaption;
        private Label lblUserID;
        private Label lblUsername;
        private Label lblPassword;
        private Label lblRole;
        private Label lblLastLogin;
        private TextBox txtUserID;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private DateTimePicker dtpLastLogin;
        private ComboBox cboRole;
        private ListView lstUser;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnClear;
        private Button btnExit;
    }
}