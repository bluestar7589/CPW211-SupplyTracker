namespace SupplyTracker.Views
{
    partial class ProductForm
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
            txtProductName = new TextBox();
            dtpProductionData = new DateTimePicker();
            cbxUnitOfSupply = new ComboBox();
            lblProductName = new Label();
            lblLotNumber = new Label();
            lblUnitOfSupply = new Label();
            lblPrice = new Label();
            lblExpirationDate = new Label();
            lblProductionDate = new Label();
            lblVendor = new Label();
            lblProductCategory = new Label();
            txtLotNumber = new TextBox();
            txtPrice = new TextBox();
            dtpExpirationDate = new DateTimePicker();
            cbxProductCategories = new ComboBox();
            cbxVendor = new ComboBox();
            btnSubmit = new Button();
            btnDelete = new Button();
            btnExit = new Button();
            lstProduct = new ListView();
            btnUpdate = new Button();
            SuspendLayout();
            // 
            // lblCaption
            // 
            lblCaption.AutoSize = true;
            lblCaption.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblCaption.Location = new Point(306, 9);
            lblCaption.Name = "lblCaption";
            lblCaption.Size = new Size(217, 28);
            lblCaption.TabIndex = 0;
            lblCaption.Text = "Product Management";
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(132, 56);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(200, 23);
            txtProductName.TabIndex = 1;
            // 
            // dtpProductionData
            // 
            dtpProductionData.Location = new Point(132, 178);
            dtpProductionData.Name = "dtpProductionData";
            dtpProductionData.Size = new Size(200, 23);
            dtpProductionData.TabIndex = 9;
            // 
            // cbxUnitOfSupply
            // 
            cbxUnitOfSupply.FormattingEnabled = true;
            cbxUnitOfSupply.Location = new Point(132, 145);
            cbxUnitOfSupply.Name = "cbxUnitOfSupply";
            cbxUnitOfSupply.Size = new Size(88, 23);
            cbxUnitOfSupply.TabIndex = 7;
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Location = new Point(12, 59);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(84, 15);
            lblProductName.TabIndex = 0;
            lblProductName.Text = "Product Name";
            // 
            // lblLotNumber
            // 
            lblLotNumber.AutoSize = true;
            lblLotNumber.Location = new Point(12, 89);
            lblLotNumber.Name = "lblLotNumber";
            lblLotNumber.Size = new Size(71, 15);
            lblLotNumber.TabIndex = 2;
            lblLotNumber.Text = "Lot Number";
            // 
            // lblUnitOfSupply
            // 
            lblUnitOfSupply.AutoSize = true;
            lblUnitOfSupply.Location = new Point(12, 148);
            lblUnitOfSupply.Name = "lblUnitOfSupply";
            lblUnitOfSupply.Size = new Size(82, 15);
            lblUnitOfSupply.TabIndex = 6;
            lblUnitOfSupply.Text = "Unit of Supply";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(12, 118);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(33, 15);
            lblPrice.TabIndex = 4;
            lblPrice.Text = "Price";
            // 
            // lblExpirationDate
            // 
            lblExpirationDate.AutoSize = true;
            lblExpirationDate.Location = new Point(12, 213);
            lblExpirationDate.Name = "lblExpirationDate";
            lblExpirationDate.Size = new Size(95, 15);
            lblExpirationDate.TabIndex = 10;
            lblExpirationDate.Text = "Expiration's Date";
            // 
            // lblProductionDate
            // 
            lblProductionDate.AutoSize = true;
            lblProductionDate.Location = new Point(12, 178);
            lblProductionDate.Name = "lblProductionDate";
            lblProductionDate.Size = new Size(101, 15);
            lblProductionDate.TabIndex = 8;
            lblProductionDate.Text = "Production's Date";
            // 
            // lblVendor
            // 
            lblVendor.AutoSize = true;
            lblVendor.Location = new Point(12, 275);
            lblVendor.Name = "lblVendor";
            lblVendor.Size = new Size(44, 15);
            lblVendor.TabIndex = 14;
            lblVendor.Text = "Vendor";
            // 
            // lblProductCategory
            // 
            lblProductCategory.AutoSize = true;
            lblProductCategory.Location = new Point(12, 243);
            lblProductCategory.Name = "lblProductCategory";
            lblProductCategory.Size = new Size(100, 15);
            lblProductCategory.TabIndex = 12;
            lblProductCategory.Text = "Product Category";
            // 
            // txtLotNumber
            // 
            txtLotNumber.Location = new Point(132, 86);
            txtLotNumber.Name = "txtLotNumber";
            txtLotNumber.Size = new Size(200, 23);
            txtLotNumber.TabIndex = 3;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(132, 115);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(200, 23);
            txtPrice.TabIndex = 5;
            // 
            // dtpExpirationDate
            // 
            dtpExpirationDate.Location = new Point(132, 207);
            dtpExpirationDate.Name = "dtpExpirationDate";
            dtpExpirationDate.Size = new Size(200, 23);
            dtpExpirationDate.TabIndex = 11;
            // 
            // cbxProductCategories
            // 
            cbxProductCategories.FormattingEnabled = true;
            cbxProductCategories.Location = new Point(132, 243);
            cbxProductCategories.Name = "cbxProductCategories";
            cbxProductCategories.Size = new Size(200, 23);
            cbxProductCategories.TabIndex = 13;
            // 
            // cbxVendor
            // 
            cbxVendor.FormattingEnabled = true;
            cbxVendor.Location = new Point(132, 272);
            cbxVendor.Name = "cbxVendor";
            cbxVendor.Size = new Size(200, 23);
            cbxVendor.TabIndex = 15;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(148, 342);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(75, 23);
            btnSubmit.TabIndex = 17;
            btnSubmit.Text = "Add";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(296, 342);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 19;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(565, 342);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 23);
            btnExit.TabIndex = 20;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // lstProduct
            // 
            lstProduct.FullRowSelect = true;
            lstProduct.Location = new Point(356, 59);
            lstProduct.Name = "lstProduct";
            lstProduct.Size = new Size(432, 236);
            lstProduct.TabIndex = 22;
            lstProduct.UseCompatibleStateImageBehavior = false;
            lstProduct.SelectedIndexChanged += lstProduct_SelectedIndexChanged;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(432, 342);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 18;
            btnUpdate.Text = "Clear";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnClear_Click;
            // 
            // ProductForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 383);
            Controls.Add(lstProduct);
            Controls.Add(btnExit);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnSubmit);
            Controls.Add(cbxVendor);
            Controls.Add(cbxProductCategories);
            Controls.Add(dtpExpirationDate);
            Controls.Add(txtPrice);
            Controls.Add(txtLotNumber);
            Controls.Add(lblVendor);
            Controls.Add(lblProductCategory);
            Controls.Add(lblExpirationDate);
            Controls.Add(lblProductionDate);
            Controls.Add(lblUnitOfSupply);
            Controls.Add(lblPrice);
            Controls.Add(lblLotNumber);
            Controls.Add(lblProductName);
            Controls.Add(cbxUnitOfSupply);
            Controls.Add(dtpProductionData);
            Controls.Add(txtProductName);
            Controls.Add(lblCaption);
            Name = "ProductForm";
            Text = "Product Management";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCaption;
        private TextBox txtProductName;
        private DateTimePicker dtpProductionData;
        private ComboBox cbxUnitOfSupply;
        private Label lblProductName;
        private Label lblLotNumber;
        private Label lblUnitOfSupply;
        private Label lblPrice;
        private Label lblExpirationDate;
        private Label lblProductionDate;
        private Label lblVendor;
        private Label lblProductCategory;
        private TextBox txtLotNumber;
        private TextBox txtPrice;
        private DateTimePicker dtpExpirationDate;
        private ComboBox cbxProductCategories;
        private ComboBox cbxVendor;
        private Button btnSubmit;
        private Button btnDelete;
        private Button btnExit;
        private ListView lstProduct;
        private Button btnUpdate;
    }
}