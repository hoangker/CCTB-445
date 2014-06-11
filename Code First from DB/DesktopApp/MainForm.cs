using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Close the program/form
        }

        private void regionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Open a form as a dialog box
            ViewRegions frm = new ViewRegions();

            frm.ShowDialog(); // Execution of this method will PAUSE here until the dialog box (ViewRegions) is closed
            // resume after the dialog box is closed

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Set the applications startup date/time in the status bar
            StartTimeStatus.Text = "App Started on " + DateTime.Now.ToString();
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void shippersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewShippers shippersfrm = new ViewShippers();
            shippersfrm.MdiParent = this;
            shippersfrm.WindowState = FormWindowState.Maximized;
            shippersfrm.Show(); // we do NOT pause here as we show the form..
            //MessageBox.Show("Here's the ViewShopper's Form");
        }

        private void customerOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void productSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void errorLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutThisAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO: 1) Open the AboutApp form as a dialog window.
            AboutApp aboutApp = new AboutApp();
            aboutApp.ShowDialog();
        }
    }
}
