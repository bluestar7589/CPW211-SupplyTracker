namespace SupplyTracker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
                else {
                    MessageBox.Show("Username or password is not correct!!! Please try again !!!","Error");
                }
            }
        }
    }
}
