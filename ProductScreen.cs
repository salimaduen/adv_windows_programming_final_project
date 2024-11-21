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
    public partial class ProductScreen : Form
    {
        public ProductScreen()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Book Successfuly Added");
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Book Successfuly Removed");
        }
    }
}
