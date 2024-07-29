using SupplyTracker.Data;
using SupplyTracker.Databases;
using SupplyTracker.Models;
using SupplyTracker.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SupplyTracker.Databases.ProductDB;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SupplyTracker.Views
{
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
            this.AcceptButton = btnSubmit;
            // Load all data needed for the form
            LoadData();
            SetupListView();
        }


        /// <summary>
        /// Setup the list view to show the product information
        /// </summary>
        private void SetupListView()
        {
            lstProduct.View = View.Details;
            lstProduct.Columns.Add("Product ID", 50);
            lstProduct.Columns.Add("Product Name", 100);
            lstProduct.Columns.Add("Lot Number", 100);
            lstProduct.Columns.Add("Price", 100);
            lstProduct.Columns.Add("Production's Date", 100);
            lstProduct.Columns.Add("Expiration's Date", 150);
            lstProduct.Columns.Add("Category", 100);
            lstProduct.Columns.Add("Vendor", 100);
        }

        /// <summary>
        /// This method will load all product to the list view product
        /// </summary>
        private void LoadProductList()
        {
            var products = ProductDB.GetAllProducts();

            lstProduct.Items.Clear();

            foreach (var product in products)
            {
                var listViewItem = new ListViewItem(product.ProductID.ToString());
                listViewItem.SubItems.Add(product.ProductName);
                listViewItem.SubItems.Add(product.LotNumber);
                listViewItem.SubItems.Add(product.Price.ToString());
                listViewItem.SubItems.Add(product.ProductionDate.ToString());
                listViewItem.SubItems.Add(product.ExpirationDate.ToString());
                listViewItem.SubItems.Add(product.CategoryName);
                listViewItem.SubItems.Add(product.VendorName);
                listViewItem.Tag = product;
                lstProduct.Items.Add(listViewItem);
            }
        }

        /// <summary>
        /// This function to load the supply units to the cbxUnitOfSupply
        /// </summary>
        private void LoadSupplyUnits()
        {
            List<string> supplyUnits = new List<string>
            {
                "Bottle",
                "Pack",
                "Each",
                "Box",
                "Carton",
                "Case",
                "Dozen",
                "Gram",
                "Kilogram",
                "Liter",
                "Milliliter",
                "Piece",
                "Roll",
                "Set",
                "Tube",
                "Bag",
                "Can",
                "Jar",
                "Bundle"
            };

            cbxUnitOfSupply.DataSource = supplyUnits;
            // Make the combobox read only
            cbxUnitOfSupply.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary>
        /// This method to load all vendor to cbxVendor
        /// </summary>
        private void LoadVendorList()
        {
            List<Vendor> lstVendors = VendorDB.GetAllVendors();
            cbxVendor.DataSource = lstVendors;
            // Set the display member by vendor's name
            cbxVendor.DisplayMember = "VendorName";
            // This value member is representing the vendor name and used to save to database
            cbxVendor.ValueMember = "VendorCode";
            // Make the combobox read only
            cbxVendor.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary>
        /// This method to load all product categories to cbxProductCategories
        /// </summary>
        private void LoadProductCategories()
        {
            List<ProductCategory> lstProductCategories = ProductCategoryDB.GetAllProductCategories();
            cbxProductCategories.DataSource = lstProductCategories;
            // Set the display member by category name
            cbxProductCategories.DisplayMember = "CategoryName";
            // This value member is representing the product category name and used to save to database
            cbxProductCategories.ValueMember = "ProductCategoryCode";
            // Make the combobox read only
            cbxProductCategories.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary>
        /// This method to load all data needed for the form
        /// </summary>
        private void LoadData()
        {
            LoadSupplyUnits();
            LoadVendorList();
            LoadProductCategories();
            LoadProductList();
        }

        /// <summary>
        /// This method to reset the form when needed
        /// </summary>
        private void ResetForm()
        {
            txtProductName.Text = "";
            txtLotNumber.Text = "";
            txtPrice.Text = "";
            cbxUnitOfSupply.SelectedIndex = 0;
            dtpProductionData.Value = DateTime.Now;
            dtpExpirationDate.Value = DateTime.Now;
            cbxProductCategories.SelectedIndex = 0;
            cbxVendor.SelectedIndex = 0;
            btnSubmit.Text = "Add";
            lstProduct.SelectedItems.Clear();
        }

        /// <summary>
        /// This method to add data to database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (IsValidAllData())
            {
                
                Product product = new Product
                {
                    ProductId = lstProduct.SelectedItems.Count > 0 ? ((ProductDTO)lstProduct.SelectedItems[0].Tag).ProductID : 0,
                    ProductName = txtProductName.Text,
                    Price = decimal.Parse(txtPrice.Text),
                    LotNumber = txtLotNumber.Text,
                    UnitOfSupply = cbxUnitOfSupply.SelectedValue.ToString(),
                    DateOfProduct = DateOnly.FromDateTime(DateTime.Parse(dtpProductionData.Text)),
                    DateOfExpire = DateOnly.FromDateTime(DateTime.Parse(dtpExpirationDate.Text)),
                    ProductCategoryCode = int.Parse(cbxProductCategories.SelectedValue.ToString()),
                    VendorCode = int.Parse(cbxVendor.SelectedValue.ToString())
                };
                if (btnSubmit.Text.Equals("Add"))
                {
                    ProductDB.AddProduct(product);
                    
                }
                else 
                {
                    ProductDB.UpdateProduct(product);
                }
                // Load the list of product and reset the form
                LoadProductList();
                ResetForm();
            }

        }
        /// <summary>
        /// This method to check all data is valid or not
        /// </summary>
        /// <returns>Return true if all data is valid, otherwise return false</returns>
        private Boolean IsValidAllData()
        {
            if (txtProductName.Text.Equals(String.Empty))
            {
                txtProductName.Focus();
                MessageBox.Show("Input the product's name", "Error");
                return false;
            }
            if (txtLotNumber.Text.Equals(String.Empty))
            {
                txtLotNumber.Focus();
                MessageBox.Show("Input the lot number", "Error");
                return false;
            }
            if (txtPrice.Text.Equals(String.Empty))
            {
                txtPrice.Focus();
                MessageBox.Show("Input the price", "Error");
                return false;
            }

            if (!Utils.IsValidRangeDate(dtpProductionData.Text, dtpExpirationDate.Text))
            {
                MessageBox.Show("The expiration date must be greater than the production date", "Error");
                return false;
            }

            if (!Utils.IsPositiveNumber(txtPrice.Text))
            {
                MessageBox.Show("The price must be a positive number", "Error");
                return false;
            }
            return true;
        }

        /// <summary>
        /// This method to update information to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetForm();
            
        }

        /// <summary>
        /// This method to delete the selected product from database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstProduct.SelectedItems.Count > 0)
            {
                Product product = new Product
                {
                    ProductId = ((ProductDTO)lstProduct.SelectedItems[0].Tag).ProductID
                };
                ProductDB.DeleteProduct(product);
                LoadProductList();
                ResetForm();
            }
            else
            {
                MessageBox.Show("Select the item that you want to delete.","Error");
            }
        }

        /// <summary>
        /// This method to close the currently form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// This method will load data from listview to form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstProduct.SelectedItems.Count > 0)
            {
                btnSubmit.Text = "Update";
                // Get the selected item
                ListViewItem selectedItem = lstProduct.SelectedItems[0];

                // Retrieve the product object from the Tag property
                var product = selectedItem.Tag as ProductDTO;

                if (product != null)
                {
                    txtProductName.Text = product.ProductName;
                    txtLotNumber.Text = product.LotNumber;
                    txtPrice.Text = product.Price.ToString();
                    cbxUnitOfSupply.SelectedItem = product.UnitOfSupply;
                    dtpProductionData.Text = product.ProductionDate.ToString();
                    dtpExpirationDate.Text = product.ExpirationDate.ToString();
                    cbxProductCategories.SelectedIndex = cbxProductCategories.FindString(product.CategoryName);
                    cbxVendor.SelectedIndex = cbxVendor.FindString(product.VendorName);
                }
            }
        }
    }
}
