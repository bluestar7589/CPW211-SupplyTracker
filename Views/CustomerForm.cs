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
                listViewItem.Tag = customer;

                lstCustomer.Items.Add(listViewItem);
            }

            lstCustomer.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }
    }
}
