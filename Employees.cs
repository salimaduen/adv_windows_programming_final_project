using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project
{
    public partial class Employees : Form
    {
        public Employees()
        {
            InitializeComponent();
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {

            string currentText = txtId.Text;
            char newChar = e.KeyChar;

            if (char.IsControl(newChar))
            {
                e.Handled = false;
                return;
            }

            string newText = currentText + newChar;

            string pattern = @"^[A-Z]{0,3}[1-9]?[0-9]{0,4}(FM?)?$|^[A-Z]-[A-Z][1-9]?[0-9]{0,4}(FM?)?$";

            if (!Regex.IsMatch(newText, pattern))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
    }
}
