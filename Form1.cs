using SupplyTracker.Views;
using SupplyTracker.Models;

namespace SupplyTracker
{
    public partial class Form1 : Form
    {
        public static User LoggedInUser { get; set; } // Static property to hold the logged-in user


        public Form1()
        {
            InitializeComponent();
            this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            this.Enabled = false;
            // Keep showing the login form until success or cancel (exit) the program.
            while (true)
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    this.Enabled = true;
                    break;
                }
                else if (loginForm.ShowDialog() == DialogResult.Cancel)
                {
                    Application.Exit();// Exit the program
                }
                else
                {
                    MessageBox.Show("Username or password is not correct!!! Please try again !!!", "Error");
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
            // Check if the form is already open
            foreach (Form form in this.MdiChildren)
            {
                if (form is SupplyForm)
                {
                    form.Activate();
                    return;
                }
            }

            // If not open, create and show the form
            SupplyForm childForm = new SupplyForm();
            childForm.MdiParent = this;
            childForm.Show();
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
