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

            // Bind the Load event
            this.Load += FrmEmployees_Load;
        }

        private void FrmEmployees_Load(object sender, EventArgs e)
        {
            // Populate the listbox when the form loads
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
            lstEmployees.Items.Clear();

            using (BookStoreEntities context = new BookStoreEntities())
            {
                try
                {
                    var employees = string.IsNullOrEmpty(searchText)
                        ? context.employees
                            .Select(emp => new { emp.fname, emp.minit, emp.lname, emp.emp_id })
                            .ToList()
                        : context.employees
                            .Where(emp => emp.fname.ToLower().StartsWith(searchText) || emp.lname.ToLower().StartsWith(searchText))
                            .Select(emp => new { emp.fname, emp.minit, emp.lname, emp.emp_id })
                            .ToList();

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
                    MessageBox.Show($"Error retrieving employees: {ex.Message}");
                }
            }
        }

        

        private void lstEmployees_SelectedIndexChanged(object sender, EventArgs eventArgs)
        {
            if (lstEmployees.SelectedIndex == -1)
                return;

            string selected = lstEmployees.Items[lstEmployees.SelectedIndex].ToString();
            string[] selectedId = selected.Split(' ');
            selected = selectedId[0];

            if (!string.IsNullOrEmpty(selected))
            {
                try
                {
                    using (BookStoreEntities context = new BookStoreEntities())
                    {
                        var employee = context.employees
                            .Where(emp => emp.emp_id.Equals(selected))
                            .FirstOrDefault();

                        if (employee != null)
                        {
                            txtId.Text = employee.emp_id;
                            txtFName.Text = employee.fname;
                            txtMInitial.Text = employee.minit;
                            txtLName.Text = employee.lname;
                            txtJobId.Text = employee.job_id.ToString();
                            txtJobLevel.Text = employee.job_lvl.ToString();
                            txtPubId.Text = employee.pub_id;
                            txtHireDate.Text = employee.hire_date.ToString("yyyy-MM-dd");
                        }
                        else
                        {
                            MessageBox.Show("No employee found with the selected ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error occurred while fetching the employee:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            txtHireDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void btnAdd_Click(object sender, EventArgs eventArgs)
        {
            string id = txtId.Text.Trim();
            string fName = txtFName.Text.Trim();
            string mInitial = txtMInitial.Text.Trim();
            string lName = txtLName.Text.Trim();
            string jobId = txtJobId.Text.Trim();
            int jobLevel = int.TryParse(txtJobLevel.Text.Trim(), out int level) ? level : 0;
            string pubId = txtPubId.Text.Trim();
            DateTime hireDate = DateTime.TryParse(txtHireDate.Text.Trim(), out DateTime parsedDate) ? parsedDate : DateTime.Now;

            using (BookStoreEntities context = new BookStoreEntities())
            {
                try
                {
                    bool employeeExists = context.employees.Any(emp => emp.emp_id == id);

                    if (employeeExists)
                    {
                        MessageBox.Show("Employee already exists!", "Duplicate Record", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var newEmployee = new employee
                    {
                        emp_id = id,
                        fname = fName,
                        minit = string.IsNullOrEmpty(mInitial) ? null : mInitial,
                        lname = lName,
                        job_id = short.TryParse(jobId, out short parsedJobId) ? parsedJobId : throw new ArgumentException("Invalid job ID."),
                        job_lvl = jobLevel >= 0 && jobLevel <= byte.MaxValue ? (byte?)jobLevel : throw new ArgumentException("Invalid job level."),
                        pub_id = string.IsNullOrEmpty(pubId) ? null : pubId,
                        hire_date = hireDate
                    };

                    context.employees.Add(newEmployee);
                    context.SaveChanges();

                    txtSearchBar_TextChanged(sender, eventArgs);
                    MessageBox.Show("Employee added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    var innerException = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                    MessageBox.Show($"An error occurred while adding the employee:\n{innerException}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs eventArgs)
        {
            string id = txtId.Text.Trim();

            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Please enter a valid ID to remove.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (BookStoreEntities context = new BookStoreEntities())
            {
                try
                {
                    var employeeToRemove = context.employees.SingleOrDefault(emp => emp.emp_id == id);

                    if (employeeToRemove == null)
                    {
                        MessageBox.Show("Employee not found!", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    context.employees.Remove(employeeToRemove);
                    context.SaveChanges();

                    MessageBox.Show("Employee record removed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearInputFields();
                    txtSearchBar_TextChanged(sender, eventArgs);
                }
                catch (Exception ex)
                {
                    var innerException = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                    MessageBox.Show($"Error occurred while removing the employee:\n{innerException}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
