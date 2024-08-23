namespace SupplyTracker.Views
{
    partial class CustomerForm
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
            btnExit = new Button();
            btnClear = new Button();
            btnDelete = new Button();
            btnAdd = new Button();
            txtDepartmentCode = new TextBox();
            lblDepartmentCode = new Label();
            lblCaption = new Label();
            txtLastName = new TextBox();
            lblLastName = new Label();
            txtFirstName = new TextBox();
            lblFirstName = new Label();
            lstCustomer = new ListView();
            cboPosition = new ComboBox();
            txtPhoneNumber = new TextBox();
            lblPhoneNumber = new Label();
            lblPosition = new Label();
            SuspendLayout();
            // 
            // btnExit
            // 
            btnExit.Location = new Point(568, 408);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 23);
            btnExit.TabIndex = 41;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(427, 408);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 40;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(282, 408);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 39;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(139, 408);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 38;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtDepartmentCode
            // 
            txtDepartmentCode.Location = new Point(171, 224);
            txtDepartmentCode.Name = "txtDepartmentCode";
            txtDepartmentCode.Size = new Size(145, 23);
            txtDepartmentCode.TabIndex = 34;
            // 
            // lblDepartmentCode
            // 
            lblDepartmentCode.AutoSize = true;
            lblDepartmentCode.Location = new Point(37, 224);
            lblDepartmentCode.Name = "lblDepartmentCode";
            lblDepartmentCode.Size = new Size(101, 15);
            lblDepartmentCode.TabIndex = 31;
            lblDepartmentCode.Text = "Department Code";
            // 
            // lblCaption
            // 
            lblCaption.AutoSize = true;
            lblCaption.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblCaption.Location = new Point(282, 34);
            lblCaption.Name = "lblCaption";
            lblCaption.Size = new Size(233, 28);
            lblCaption.TabIndex = 30;
            lblCaption.Text = "Customer Management";
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(168, 179);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(145, 23);
            txtLastName.TabIndex = 43;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Location = new Point(37, 179);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(63, 15);
            lblLastName.TabIndex = 42;
            lblLastName.Text = "Last Name";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(168, 134);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(145, 23);
            txtFirstName.TabIndex = 45;
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Location = new Point(37, 134);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(64, 15);
            lblFirstName.TabIndex = 44;
            lblFirstName.Text = "First Name";
            // 
            // lstCustomer
            // 
            lstCustomer.FullRowSelect = true;
            lstCustomer.GridLines = true;
            lstCustomer.Location = new Point(388, 113);
            lstCustomer.Name = "lstCustomer";
            lstCustomer.Size = new Size(375, 245);
            lstCustomer.TabIndex = 46;
            lstCustomer.UseCompatibleStateImageBehavior = false;
            lstCustomer.View = View.Details;
            lstCustomer.SelectedIndexChanged += lstCustomer_SelectedIndexChanged;
            // 
            // cboPosition
            // 
            cboPosition.FormattingEnabled = true;
            cboPosition.Items.AddRange(new object[] { "Doctor", "Nurse" });
            cboPosition.Location = new Point(171, 324);
            cboPosition.Name = "cboPosition";
            cboPosition.Size = new Size(109, 23);
            cboPosition.TabIndex = 47;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(171, 276);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(145, 23);
            txtPhoneNumber.TabIndex = 48;
            // 
            // lblPhoneNumber
            // 
            lblPhoneNumber.AutoSize = true;
            lblPhoneNumber.Location = new Point(37, 276);
            lblPhoneNumber.Name = "lblPhoneNumber";
            lblPhoneNumber.Size = new Size(88, 15);
            lblPhoneNumber.TabIndex = 49;
            lblPhoneNumber.Text = "Phone Number";
            // 
            // lblPosition
            // 
            lblPosition.AutoSize = true;
            lblPosition.Location = new Point(37, 324);
            lblPosition.Name = "lblPosition";
            lblPosition.Size = new Size(50, 15);
            lblPosition.TabIndex = 50;
            lblPosition.Text = "Position";
            // 
            // CustomerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblPosition);
            Controls.Add(lblPhoneNumber);
            Controls.Add(txtPhoneNumber);
            Controls.Add(cboPosition);
            Controls.Add(lstCustomer);
            Controls.Add(txtFirstName);
            Controls.Add(lblFirstName);
            Controls.Add(txtLastName);
            Controls.Add(lblLastName);
            Controls.Add(btnExit);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(txtDepartmentCode);
            Controls.Add(lblDepartmentCode);
            Controls.Add(lblCaption);
            Name = "CustomerForm";
            Text = "CustomerForm";
            Load += CustomerForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnExit;
        private Button btnClear;
        private Button btnDelete;
        private Button btnAdd;
        private TextBox txtDepartmentCode;
        private Label lblDepartmentCode;
        private Label lblCaption;
        private TextBox txtLastName;
        private Label lblLastName;
        private TextBox txtFirstName;
        private Label lblFirstName;
        private ListView lstCustomer;
        private ComboBox cboPosition;
        private TextBox txtPhoneNumber;
        private Label lblPhoneNumber;
        private Label lblPosition;
    }
}