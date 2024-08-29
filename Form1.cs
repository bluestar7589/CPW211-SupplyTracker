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
            this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Disable all controls except the Login/Logout button
            SetControlsEnabled(false);

            LoginForm loginForm = new LoginForm();
            this.Enabled = false;
            // Keep showing the login form until success or cancel (exit) the program.
            while (LoggedInUser == null)
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    logOutToolStripMenuItem.Text = "Logout";
                    SetControlsEnabled(true); // Enable all features after login
                    this.Enabled = true;
                    break;
                }
                else if (loginForm.ShowDialog() == DialogResult.Cancel)
                {
                    Application.Exit(); // Exit the program
                }
            }
        }

        /// <summary>
        /// Allow or disallow users to use the form
        /// </summary>
        /// <param name="enabled"></param>
        private void SetControlsEnabled(bool enabled)
        {
            foreach (Control control in this.Controls)
            {
                if (control != logOutToolStripMenuItem)
                {
                    control.Enabled = enabled;
                }

                logOutToolStripMenuItem.Enabled = true; // Ensure the Logout button is always enabled
            }
        }

        /// <summary>
        /// This method will open the product form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void productManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open the product form using generic T structure
            openChildForm<ProductForm>();
        }

        /// <summary>
        /// This method will open the user form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void userManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open the user form using generic T structure
            openChildForm<UserForm>();
        }

        private void supplyManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm<SupplyForm>();
        }

        private void tabControlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabControlTest tabControl = new TabControlTest();
            tabControl.Show();
        }

        private void customerManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm<CustomerForm>();
        }

        private void logOutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (logOutToolStripMenuItem.Text == "Logout")
            {
                LoggedInUser = null;
                logOutToolStripMenuItem.Text = "Login";
                SetControlsEnabled(false);
            }
            else
            {
                // Restart the application
                Application.Restart();
                Environment.Exit(0); // Ensure the current instance exits
            }
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm<CustomerForm>();
        }

        /// <summary>
        /// This method to open the child form, as well as check if it is already open, it will not open another form
        /// </summary>
        /// <typeparam name="T"></typeparam>
        private void openChildForm<NewForm>() where NewForm : Form, new()
        {
            // Check if the form is already open
            foreach (Form form in this.MdiChildren)
            {
                if (form is NewForm)
                {
                    form.Activate();
                    return;
                }
            }

            // If not open, create and show the form
            NewForm childForm = new NewForm();
            childForm.MdiParent = this;
            childForm.Show();
        }
    }
}
