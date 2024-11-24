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
    public partial class Maintenance : Form
    {
        public Maintenance()
        {
            InitializeComponent();
        }

        private void btnTitles_Click(object sender, EventArgs e)
        {
            ProductScreen productScreen = new ProductScreen();
            productScreen.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();

            this.Close();
        }

        private void btnAuthors_Click(object sender, EventArgs e)
        {
            Author authorsForm = new Author();
            authorsForm.Show(); 
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            Employees employeesForm = new Employees();
            employeesForm.Show();
        }

        private void btnStores_Click(object sender, EventArgs e)
        {
            Stores storesForm = new Stores();
            storesForm.Show();
        }

        private void btnPublisher_Click(object sender, EventArgs e)
        {
            Publishers publisherForm = new Publishers();
            publisherForm.Show();
        }
    }
}
