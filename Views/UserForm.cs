using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SupplyTracker.Databases;
using SupplyTracker.Data;
using SupplyTracker.Models;
using static SupplyTracker.Databases.UserDB;
using static SupplyTracker.Databases.ProductDB;

namespace SupplyTracker.Views
{
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            using SupplyTrackerContext dbContext = new SupplyTrackerContext();
            UserDB UserDB = new UserDB();

            // LINQ method syntax
            List<User> userList = dbContext.Users.ToList();

            // Load the user list
            LoadUserList();


        }
        /// <summary>
        /// Creates a new user in the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (IsValidAllData())
            {
                User user = new User()
                {
                    UserID = lstUser.SelectedItems.Count > 0 ? ((UserDTO)lstUser.SelectedItems[0].Tag).UserID : 0,
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

        /// <summary>
        /// This method to load all users in the database on the list
        /// </summary>
        public void LoadUserList()
        {
            var users = UserDB.GetAllUsers();

            foreach (var user in users)
            {
                var ListViewItem = new ListViewItem(user.UserID.ToString());
                ListViewItem.SubItems.Add(user.Username);
                ListViewItem.SubItems.Add(user.Password);
                ListViewItem.SubItems.Add(user.Role);
                ListViewItem.SubItems.Add(user.LastDateLogin.ToString());
                ListViewItem.Tag = user;
                lstUser.Items.Add(ListViewItem);
            }
        }

        /// <summary>
        /// This method to clear the form when needed
        /// </summary>
        private void ResetForm()
        {
            txtUserID.Text = string.Empty;
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            dtpLastLogin.Text = string.Empty;
        }

        /// <summary>
        /// This method checks if the inputs are empty or not
        /// </summary>
        /// <returns>Returns true if all data is valid, otherwise returns false</returns>
        private Boolean IsValidAllData()
        {
            if (txtUsername.Text == string.Empty)
            {
                txtUsername.Focus();
                MessageBox.Show("Input a unique username", "Error");
                return false;
            }
            if (txtPassword.Text == string.Empty)
            {
                txtPassword.Focus();
                MessageBox.Show("Input a password", "Error");
                return false;
            }
            if (cboRole.SelectedIndex == 0)
            {
                cboRole.Focus();
                MessageBox.Show("Select a role for the user", "Error");
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

        private void lstUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstUser.SelectedItems.Count > 0)
            {
                btnAdd.Text = "Update";
                // Get the selected item
                ListViewItem selectedItem = lstUser.SelectedItems[0];

                // Retrieve the user object from the Tag property
                var user = selectedItem.Tag as UserDTO;

                if (user != null)
                {
                    txtUserID.Text = user.UserID.ToString();
                    txtUsername.Text = user.Username;
                    txtPassword.Text = user.Password;
                    cboRole.Text = user.Role;
                    dtpLastLogin.Text = user.LastDateLogin.ToString();
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
                User user = new User()
                {
                    UserID = ((UserDTO)lstUser.SelectedItems[0].Tag).UserID
                };
                UserDB.DeleteUser(user);
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
    }
}
