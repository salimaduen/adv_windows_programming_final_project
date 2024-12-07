using Final_Project.Business;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Final_Project
{
    public partial class frmEmployees : Form
    {
        private EmployeeService _employeeService;

        public frmEmployees()
        {
            InitializeComponent();
            _employeeService = new EmployeeService();
            txtSearchBar.GotFocus += RemovePlaceholderText;
            this.Load += FrmEmployees_Load;
        }

        private void FrmEmployees_Load(object sender, EventArgs e)
        {
            PopulateEmployeeList(string.Empty);
        }

        private void RemovePlaceholderText(object sender, EventArgs e)
        {
            if (txtSearchBar.Text == "Search employee...")
            {
                txtSearchBar.Text = string.Empty;
                txtSearchBar.ForeColor = Color.Black;
            }
        }

        private void txtSearchBar_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearchBar.Text.Trim().ToLower();
            PopulateEmployeeList(searchText);
        }

        private void PopulateEmployeeList(string searchText)
        {
            try
            {
                lstEmployees.Items.Clear();
                var employees = _employeeService.GetAllEmployees(searchText);
                if (employees.Any())
                {
                    foreach (var emp in employees)
                    {
                        lstEmployees.Items.Add($"{emp.emp_id} {emp.fname} {emp.minit} {emp.lname}");
                    }
                }
                else
                {
                    lstEmployees.Items.Add("No employees found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving employees: {GetFullExceptionMessage(ex)}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lstEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstEmployees.SelectedIndex == -1) return;

            string selected = lstEmployees.Items[lstEmployees.SelectedIndex].ToString();
            string[] parts = selected.Split(' ');
            string empId = parts[0]; // Assume emp_id is the first part

            try
            {
                var employee = _employeeService.GetEmployeeById(empId);
                if (employee != null)
                {
                    txtId.Text = employee.emp_id;
                    txtFName.Text = employee.fname;
                    txtMInitial.Text = employee.minit;
                    txtLName.Text = employee.lname;
                    txtJobId.Text = employee.job_id.ToString();
                    txtJobLevel.Text = employee.job_lvl.ToString();
                    txtPubId.Text = employee.pub_id;
                    txtHireDate.Text = employee.hire_date.ToString("MM-dd-yyyy");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving employee details: {GetFullExceptionMessage(ex)}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var newEmployee = new employee
                {
                    emp_id = txtId.Text.Trim(),
                    fname = txtFName.Text.Trim(),
                    minit = txtMInitial.Text.Trim(),
                    lname = txtLName.Text.Trim(),
                    job_id = short.Parse(txtJobId.Text.Trim()),
                    job_lvl = byte.Parse(txtJobLevel.Text.Trim()),
                    pub_id = txtPubId.Text.Trim(),
                    hire_date = DateTime.Parse(txtHireDate.Text.Trim())
                };

                _employeeService.AddEmployee(newEmployee);
                PopulateEmployeeList(string.Empty);
                MessageBox.Show("Employee added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Duplicate Record", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding employee: {GetFullExceptionMessage(ex)}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                string id = txtId.Text.Trim();
                _employeeService.RemoveEmployee(id);
                PopulateEmployeeList(string.Empty);
                ClearInputFields();
                MessageBox.Show("Employee removed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error removing employee: {GetFullExceptionMessage(ex)}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputFields()
        {
            txtId.Text = "";
            txtFName.Text = "";
            txtMInitial.Text = "";
            txtLName.Text = "";
            txtJobId.Text = "";
            txtJobLevel.Text = "";
            txtPubId.Text = "";
            txtHireDate.Text = DateTime.Now.ToString("MM-dd-yyyy");
        }

        private string GetFullExceptionMessage(Exception ex)
        {
            var sb = new StringBuilder();
            while (ex != null)
            {
                sb.AppendLine(ex.Message);
                ex = ex.InnerException;
            }
            return sb.ToString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
