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

namespace SupplyTracker
{
    public partial class LoginForm : Form
    {
        public User LoggedInUser { get; private set; } // Store the logged-in user

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Initialize and show the login form
            LoginForm loginForm = new LoginForm();

            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                Form1 mainForm = new Form1();
                this.Hide(); 
                mainForm.ShowDialog(); // Show the main form
            }
            else
            {
                // Handle the case where login was not successful
                this.Close();
            }
        }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            UserDB UserDB = new UserDB();
            User loggedInUser = UserDB.VerifyLogin(username, password); // Store the user object

            if (loggedInUser != null)
            {
                MessageBox.Show("Login successful", "Success");
                Form1.LoggedInUser = loggedInUser; // Set the current user in Form1
                DialogResult = DialogResult.OK;

                // Hide the login form
                this.Hide();
            }
            else
            {
                DialogResult result = MessageBox.Show("Login failed. Please check your username and password and try again.", "Error", MessageBoxButtons.RetryCancel);
                if (result == DialogResult.Cancel)
                {
                    DialogResult = DialogResult.Cancel;
                }
                else
                {
                    DialogResult = DialogResult.Retry;
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
