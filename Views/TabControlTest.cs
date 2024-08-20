using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SupplyTracker.Views
{
    public partial class TabControlTest : Form
    {
        public TabControlTest()
        {
            InitializeComponent();
            // Initialize and add the TabControl to the form
            tabControl.Dock = DockStyle.Fill;
            tabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl.DrawItem += new DrawItemEventHandler(tabControl_DrawItem);
            tabControl.MouseDown += new MouseEventHandler(tabControl_MouseDown);
        }

        /// <summary>
        /// This method to open the product form in a new tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void productManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open the product form in a new tab
            AddFormToTab<ProductForm>("Product Management");
            // Create a new instance of the form
            //ProductForm form = new ProductForm(tabControl);
            //form.TopLevel = false;
            //form.FormBorderStyle = FormBorderStyle.None;
            //form.Dock = DockStyle.Fill;

            //// Create a new TabPage and add the form to it
            //TabPage tabPage = new TabPage("Product Management");
            //tabPage.Controls.Add(form);
            //tabControl.TabPages.Add(tabPage);

            //// Show the form
            //form.Show();
        }

        /// <summary>
        /// This method to open the user form in a new tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void userManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open the product form in a new tab
            AddFormToTab<UserForm>("User Management");
        }

        /// <summary>
        /// Adds a form to a new tab in the TabControl
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tabTitle"></param>
        private void AddFormToTab<T>(string tabTitle) where T : Form, new()
        {
            // Check if the form is already open in a tab
            foreach (TabPage tp in tabControl.TabPages)
            {
                if (tp.Controls.OfType<T>().Any())
                {
                    // If the form is already open, activate the tab and return
                    tabControl.SelectedTab = tp;
                    return;
                }
            }
            // Create a new instance of the form
            T form = new T();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            // Create a new TabPage and add the form to it
            TabPage tabPage = new TabPage(tabTitle);
            tabPage.Controls.Add(form);
            tabControl.TabPages.Add(tabPage);
            tabControl.SelectedTab = tabPage;

            // Show the form
            form.Show();
        }

        /// <summary>
        /// This method to create the close button for the tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            // Draw the tab text
            e.Graphics.DrawString(tabControl.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + 10, e.Bounds.Top + 4);

            // Draw the close button
            int closeButtonSize = 16;
            int padding = 5;
            Rectangle closeButton = new Rectangle(e.Bounds.Right - closeButtonSize - padding, e.Bounds.Top + 4, closeButtonSize, closeButtonSize);

            // Draw the close button background
            e.Graphics.FillRectangle(Brushes.LightGray, closeButton);

            // Draw the close button border
            e.Graphics.DrawRectangle(Pens.Black, closeButton);

            // Draw the "x" inside the close button
            e.Graphics.DrawString("x", e.Font, Brushes.Black, closeButton.Left + 3, closeButton.Top + 1);
        }

        /// <summary>
        /// This method to close the tab when the close button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                Rectangle tabRect = tabControl.GetTabRect(i);
                Rectangle closeButton = new Rectangle(tabRect.Right - 20, tabRect.Top + 4, 16, 16);

                if (closeButton.Contains(e.Location))
                {
                    tabControl.TabPages.RemoveAt(i);
                    break;
                }
            }
        }
    }
}
