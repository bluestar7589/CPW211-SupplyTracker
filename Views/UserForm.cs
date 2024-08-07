using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SupplyTracker.Databases;
using SupplyTracker.Models;

namespace SupplyTracker.Views
{
    public partial class UserForm : Form
    {
        private User _currentUser; // Holds the currently logged-in user

        public UserForm()
        {
            InitializeComponent();
            _currentUser = Form1.LoggedInUser; // Get the logged-in user
            this.Load += new EventHandler(UserForm_Load); // Ensure the Load event is connected
        }

        private void UserForm_Load(object sender, EventArgs e)
        {

            // Add columns to the list view
            if (lstUser.Columns.Count == 0)
            {
                lstUser.Columns.Add("UserID", 100);
                lstUser.Columns.Add("Username", 150);
                lstUser.Columns.Add("Password", 150);
                lstUser.Columns.Add("Role", 100);
                lstUser.Columns.Add("Last Date Login", 120);
            }

            LoadUserList(); // Load the user data into the ListView

            // If the current user is an admin,
            // let them change a user's Role
            cboRole.Enabled = _currentUser.Role == "Admin";
        }

        public void LoadUserList()
        {
            lstUser.Items.Clear(); // Clear existing items in the list view

            var users = UserDB.GetAllUsers();

            if (users == null || users.Count == 0)
            {
                MessageBox.Show("No users found to display.");
                return;
            }

            foreach (var user in users)
            {
                if (user == null)
                {
                    MessageBox.Show("Found a null user object."); // Debugging message
                    continue;
                }

                var listViewItem = new ListViewItem(user.UserID.ToString());

                listViewItem.SubItems.Add(user.Username);
                listViewItem.SubItems.Add(user.Password);
                listViewItem.SubItems.Add(user.Role);
                listViewItem.SubItems.Add(user.LastDateLogin?.ToString("MM/dd/yyyy"));
                listViewItem.Tag = user;

                lstUser.Items.Add(listViewItem);
            }

            lstUser.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (IsValidAllData())
            {
                User user = new User()
                {
                    UserID = lstUser.SelectedItems.Count > 0 ? ((User)lstUser.SelectedItems[0].Tag).UserID : 0,
                    Username = txtUsername.Text,
                    Password = txtPassword.Text,
                    Role = cboRole.Text,
                    LastDateLogin = DateTime.Now
                };
                if (btnAdd.Text.Equals("Add"))
                {
                    UserDB.AddUser(user);
                }
                else
                {
                    UserDB.UpdateUser(user);
                }

                // Load the list of users and reset the form
                LoadUserList();
                ResetForm();
            }
        }

        private void ResetForm()
        {
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            cboRole.SelectedIndex = -1;
        }

        private Boolean IsValidAllData()
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                txtUsername.Focus();
                MessageBox.Show("Input a unique username", "Error");
                return false;
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                txtPassword.Focus();
                MessageBox.Show("Input a password", "Error");
                return false;
            }

            if (cboRole.SelectedIndex == -1)
            {
                cboRole.Focus();
                MessageBox.Show("Select a role for the user", "Error");
                return false;
            }

            return true;
        }

        private void lstUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstUser.SelectedItems.Count > 0)
            {
                btnAdd.Text = "Update";
                // Get the selected item
                ListViewItem selectedItem = lstUser.SelectedItems[0];

                // Retrieve the user object from the Tag property
                var user = selectedItem.Tag as User;

                if (user != null)
                {
                    txtUserID.Text = user.UserID.ToString();
                    txtUsername.Text = user.Username;
                    txtPassword.Text = user.Password;
                    cboRole.Text = user.Role;
                }
            }
            else
            {
                btnAdd.Text = "Add";
                ResetForm();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstUser.SelectedItems.Count > 0)
            {
                var user = (User)lstUser.SelectedItems[0].Tag;

                if (user != null)
                {
                    UserDB.DeleteUser(user);
                }
                LoadUserList();
                ResetForm();
            }
            else
            {
                MessageBox.Show("Select the item that you want to delete.", "Error");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
    }
}
