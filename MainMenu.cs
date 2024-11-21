using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            OrderCart cart = new OrderCart();
            cart.Show();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            Report report = new Report();   
            report.Show();
        }

        private void btnSearchTitles_Click(object sender, EventArgs e)
        {
            ProductScreen productScreen = new ProductScreen();    
            productScreen.Show();

        }

        private void btnMaintenance_Click(object sender, EventArgs e)
        {
            Maintenance maintenance = new Maintenance();
            maintenance.Show();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
