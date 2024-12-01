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
    public partial class frmMainMenu : Form
    {
        public frmMainMenu()
        {
            InitializeComponent();
        }

        private void btnMaintenance_Click(object sender, EventArgs e)
        {
            using (frmMaintenance frm = new frmMaintenance())
            {
                frm.ShowDialog();
            }
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            using (frmReports frm = new frmReports())
            {
                frm.ShowDialog();
            }
        }

        private void btnSearchTitles_Click(object sender, EventArgs e)
        {
            using (frmSearchTitles frm = new frmSearchTitles())
            {
                frm.ShowDialog();
            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            using (frmOrderCart frm = new frmOrderCart())
            {
                frm.ShowDialog();
            }
        }
    }
}
