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
            txtUserId = new TextBox();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            dtpLastLogin = new DateTimePicker();
            cboRole = new ComboBox();
            lstUser = new ListView();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
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
            // txtUserId
            // 
            txtUserId.Location = new Point(160, 98);
            txtUserId.Name = "txtUserId";
            txtUserId.Size = new Size(100, 23);
            txtUserId.TabIndex = 7;
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
            // 
            // button1
            // 
            button1.Location = new Point(139, 398);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 24;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(282, 398);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 25;
            button2.Text = "Delete";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(427, 398);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 26;
            button3.Text = "Clear";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(568, 398);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 27;
            button4.Text = "Exit";
            button4.UseVisualStyleBackColor = true;
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(lstUser);
            Controls.Add(cboRole);
            Controls.Add(dtpLastLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(txtUserId);
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
        private TextBox txtUserId;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private DateTimePicker dtpLastLogin;
        private ComboBox cboRole;
        private ListView lstUser;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
    }
}