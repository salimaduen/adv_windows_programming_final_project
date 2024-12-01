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
    public partial class frmEmployees : Form
    {
        public frmEmployees()
        {
            InitializeComponent();
            txtSearchBar.GotFocus += RemovePlaceholderText;
        }

        private void RemovePlaceholderText(object sender, EventArgs e)
        {
            if (txtSearchBar.Text == "Search employee...")
            {
                txtSearchBar.Text = string.Empty;
                txtSearchBar.ForeColor = Color.Black;
            }
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

            // Pattern needs improvement
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

        private void txtSearchBar_TextChanged(object sender, EventArgs e)
        {
            if (this.txtSearchBar.Text.Length == 0)
            {
                {
                    this.lstEmployees.Items.Clear();

                    using (BookStoreEntities context = new BookStoreEntities())
                    {
                        var employees = context.employees
                            .Select(a => new { a.fname, a.lname, a.emp_id })
                            .ToList();

                        foreach (var emp in employees)
                        {
                            this.lstEmployees.Items.Add($"{emp.emp_id} {emp.fname} {emp.lname}");
                        }
                    }
                }
            }
            else
            {
                this.lstEmployees.Items.Clear();

                using (BookStoreEntities context = new BookStoreEntities())
                {
                    string searchText = this.txtSearchBar.Text.ToLower();

                    var employees = context.employees
                        .Where(a => a.fname.ToLower().StartsWith(searchText) || a.lname.ToLower().StartsWith(searchText))
                        .Select(a => new { a.fname, a.lname, a.emp_id })
                        .ToList();

                    if (employees.Count > 0)
                    {
                        foreach (var emp in employees)
                        {
                            this.lstEmployees.Items.Add($"{emp.emp_id} {emp.fname} {emp.lname}");
                        }
                    }
                    else
                    {
                        this.lstEmployees.Items.Add("No employees found");
                    }

                }
            }
        }
    }
}