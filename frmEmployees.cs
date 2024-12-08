using Final_Project.Business;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

            if (!ValidateAddEmployeeInputs())
            {
                return; 
            }

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

        private bool ValidateAddEmployeeInputs()
        {
            
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Employee ID is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!Regex.IsMatch(txtId.Text.Trim(), @"^[A-Z]{3}[1-9][0-9]{4}[FM]$|^[A-Z]-[A-Z][1-9][0-9]{4}[FM]$"))
            {
                MessageBox.Show("Employee ID must follow the specified format (e.g., ABC1234F or A-B1234M).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            
            if (string.IsNullOrWhiteSpace(txtFName.Text) || txtFName.Text.Length > 20)
            {
                MessageBox.Show("First name is required and cannot exceed 20 characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            
            if (string.IsNullOrWhiteSpace(txtLName.Text) || txtLName.Text.Length > 30)
            {
                MessageBox.Show("Last name is required and cannot exceed 30 characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            if (!short.TryParse(txtJobId.Text, out short jobId))
            {
                MessageBox.Show("Job ID must be a valid number. {1-14}", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            var _context = new BookStoreEntities();
            var job = _context.jobs.SingleOrDefault(j => j.job_id == jobId);
            if (job == null)
            {
                MessageBox.Show("Job ID does not exist. Please enter a valid Job ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtJobLevel.Text) && byte.TryParse(txtJobLevel.Text, out byte jobLevel))
            {
               
                if (jobId == 1 && jobLevel != 10)
                {
                    MessageBox.Show("Job ID 1 expects the default level of 10.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

               
                if (jobId != 1 && (jobLevel < job.min_lvl || jobLevel > job.max_lvl))
                {
                    MessageBox.Show($"The level for Job ID {jobId} must be between {job.min_lvl} and {job.max_lvl}.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Job Level must be a valid number (1-255).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPubId.Text) || txtPubId.Text.Length != 4)
            {
                MessageBox.Show("Publisher ID must be one of the following: 1756, 1622, 0877, 0736, 1389, or match the format 99XX (e.g. 9952).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!DateTime.TryParse(txtHireDate.Text, out DateTime hireDate))
            {
                MessageBox.Show("Hire Date must be a valid date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (hireDate > DateTime.Now)
            {
                MessageBox.Show("Hire Date cannot be in the future.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true; 
        }

    }
}
