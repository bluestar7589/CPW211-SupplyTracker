﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SupplyTracker.Data;
using SupplyTracker.Models;
using SupplyTracker.Databases;

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
            UserDB UserDB = new();

            string username = txtUsername.Text;
            string password = txtPassword.Text;



            if (UserDB.VerifyLogin(username, password))
            {
                MessageBox.Show("Login successful", "Success");
                DialogResult = DialogResult.OK;

                // Hide the login form
                this.Hide();
            }
            else
            {
                DialogResult result = MessageBox.Show("Login failed. Please check your username and password and try again.", "Error");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
