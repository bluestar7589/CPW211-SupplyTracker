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

namespace SupplyTracker
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            User user = new User();
            if (user.VerifyLogin(username, password))
            {
                MessageBox.Show("Login successful");
                
                // Hide the login form
                this.Hide();
                // Grab the main form
                Form1 mainForm = new Form1();
                // Display the main form
                mainForm.Show();
            } else
            {
                MessageBox.Show("Login failed. Please check your username and password and try again.");
            }
        }
    }
}
