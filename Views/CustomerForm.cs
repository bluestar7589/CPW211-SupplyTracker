using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SupplyTracker.Models;
using SupplyTracker.Databases;

namespace SupplyTracker.Views
{
    public partial class CustomerForm : Form
    {

        private User _currentUser; // Holds the currently logged-in user
        public CustomerForm()
        {
            InitializeComponent();
            _currentUser = Form1.LoggedInUser; // Get the logged-in user
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            // Add columns to the list view
            if (lstCustomer.Columns.Count == 0)
            {
                lstCustomer.Columns.Add("CustomerID", 100);
                lstCustomer.Columns.Add("FirstName", 150);
                lstCustomer.Columns.Add("LastName", 150);
                lstCustomer.Columns.Add("DepartmentCode", 50);
                lstCustomer.Columns.Add("PhoneNumber", 200);
                lstCustomer.Columns.Add("Position", 100);
            }

            LoadCustomerList(); // Load the customer data into the ListView
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (IsValidAllData())
            {
                Customer customer = new Customer()
                {
                    // CustomerID is left out as it is generated automatically by the database
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    DepartmentCode = int.Parse(txtDepartmentCode.Text),
                    PhoneNumber = txtPhoneNumber.Text,
                    Position = cboPosition.Text
                };
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Finds and loads the list of current customers
        /// </summary>
        public void LoadCustomerList()
        {
            lstCustomer.Items.Clear(); // Clear existing items in the list view

            var customers = CustomerDB.GetAllCustomers();

            if (customers == null || customers.Count == 0)
            {
                MessageBox.Show("No customers found to display.");
                return;
            }

            foreach (var customer in customers)
            {
                if (customer == null)
                {
                    MessageBox.Show("Found a null customer object."); // Debugging message
                    continue;
                }

                var listViewItem = new ListViewItem(customer.CustomerID.ToString());

                listViewItem.SubItems.Add(customer.FirstName);
                listViewItem.SubItems.Add(customer.LastName);
                listViewItem.SubItems.Add(customer.DepartmentCode.ToString());
                listViewItem.SubItems.Add(customer.PhoneNumber);
                listViewItem.SubItems.Add(customer.Position);

                // Tag the customer as a Customer

                listViewItem.Tag = customer;

                lstCustomer.Items.Add(listViewItem);
            }

            lstCustomer.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        /// <summary>
        /// A method to call when clearing the form's inputs
        /// </summary>
        private void ResetForm()
        {
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtDepartmentCode.Text = string.Empty;
            txtPhoneNumber.Text = string.Empty;
            cboPosition.Text = string.Empty;
        }

        /// <summary>
        /// Validates all inputs have been correctly entered
        /// </summary>
        /// <returns>Returns true if all inputs are valid, otherwise false</returns>
        private Boolean IsValidAllData()
        {
            if (string.IsNullOrEmpty(txtFirstName.Text))
            {
                txtFirstName.Focus();
                MessageBox.Show("Input customer's first name", "Error");
                return false;
            }

            if (string.IsNullOrEmpty(txtLastName.Text))
            {
                txtLastName.Focus();
                MessageBox.Show("Input customer's last name", "Error");
                return false;
            }

            if (string.IsNullOrEmpty(txtDepartmentCode.Text))
            {
                txtDepartmentCode.Focus();
                MessageBox.Show("Input customer's department code", "Error");
                return false;
            }

            if (string.IsNullOrEmpty(txtPhoneNumber.Text))
            {
                txtPhoneNumber.Focus();
                MessageBox.Show("Input customer's phone number", "Error");
                return false;
            }


            if (cboPosition.SelectedIndex == -1)
            {
                cboPosition.Focus();
                MessageBox.Show("Select a positon for the customer", "Error");
                return false;
            }

            return true;
        }

        private void lstCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstCustomer.SelectedItems.Count > 0)
            {
                btnAdd.Text = "Update";
                // Get the selected customer
                ListViewItem selectedCustomer = lstCustomer.SelectedItems[0];

                var customer = selectedCustomer.Tag as Customer;

                if (customer != null)
                {
                    txtFirstName.Text = customer.FirstName;
                    txtLastName.Text = customer.LastName;
                    txtPhoneNumber.Text = customer.PhoneNumber;
                    txtDepartmentCode.Text = customer.DepartmentCode.ToString();
                    cboPosition.Text = customer.Position;
                }
            }
            else
            {
                btnAdd.Text = "Add";
                ResetForm();
            }
        }

    }
}
