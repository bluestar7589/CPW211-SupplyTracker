using SupplyTracker.Views;
using SupplyTracker.Models;

namespace SupplyTracker
{
    public partial class Form1 : Form
    {
        public static User? LoggedInUser { get; set; } // Static property to hold the logged-in user


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            this.Enabled = false;
            // Keep showing the login form until success or cancel (exit) the program.
            while (LoggedInUser == null)
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    btnLoginLogout.Text = "Logout";
                    this.Enabled = true;
                    break;
                }
                else if (loginForm.ShowDialog() == DialogResult.Cancel)
                {
                    Application.Exit();// Exit the program
                }
            }
        }

        /// <summary>
        /// This method will open the product form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void productManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductForm productForm = new ProductForm();
            productForm.MdiParent = this;
            productForm.Show();
        }

        private void userManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserForm userForm = new UserForm();
            userForm.ShowDialog();
        }

        private void btnLoginLogout_Click(object sender, EventArgs e)
        {
            if (btnLoginLogout.Text == "Logout") 
            {
                LoggedInUser = null;
                btnLoginLogout.Text = "Login";
            }
            else 
            {
                // Restart the application
                Application.Restart();
                Environment.Exit(0); // Ensure the current instance exits
            }
        }


    }
}
