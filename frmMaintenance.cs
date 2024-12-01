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
    public partial class frmMaintenance : Form
    {
        public frmMaintenance()
        {
            InitializeComponent();
        }

        private void btnAuthors_Click(object sender, EventArgs e)
        {
            using (frmAuthors frmAuthors = new frmAuthors())
            {
                frmAuthors.ShowDialog();
            }
        }

        private void btnStores_Click(object sender, EventArgs e)
        {
            using (frmStores frmStores = new frmStores())
            {
                frmStores.ShowDialog();
            }
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            using (frmEmployees frmEmployees = new frmEmployees())
            {
                frmEmployees.ShowDialog();
            }
        }

        private void btnPublisher_Click(object sender, EventArgs e)
        {
            using (frmPublisher frmPublisher = new frmPublisher())
            {
                frmPublisher.ShowDialog();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
