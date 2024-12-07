using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project.Business
{
    internal class EmployeeService
    {
        private readonly BookStoreEntities _context;

        public EmployeeService()
        {
            _context = new BookStoreEntities();
        }

        public List<employee> GetAllEmployees(string searchText = null)
        {
            if (string.IsNullOrEmpty(searchText))
            {
                return _context.employees.ToList();
            }

            searchText = searchText.ToLower();
            return _context.employees
                .Where(emp => emp.fname.ToLower().StartsWith(searchText) || emp.lname.ToLower().StartsWith(searchText))
                .ToList();
        }

        public employee GetEmployeeById(string id)
        {
            return _context.employees.SingleOrDefault(emp => emp.emp_id == id);
        }

        public void AddEmployee(employee newEmployee)
        {
            if (_context.employees.Any(emp => emp.emp_id == newEmployee.emp_id))
            {
                throw new InvalidOperationException("Employee already exists.");
            }

            _context.employees.Add(newEmployee);
            _context.SaveChanges();
        }

        public void RemoveEmployee(string id)
        {
            var employeeToRemove = _context.employees.SingleOrDefault(emp => emp.emp_id == id);
            if (employeeToRemove == null)
            {
                throw new InvalidOperationException("Employee not found.");
            }

            _context.employees.Remove(employeeToRemove);
            _context.SaveChanges();
        }
    }


}
