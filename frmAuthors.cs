using Final_Project.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project
{
    public partial class frmAuthors : Form
    {
        private readonly AuthorService _authorService;

        public frmAuthors()
        {
            InitializeComponent();
            _authorService = new AuthorService();
            txtSearchBar.GotFocus += RemovePlaceholderText;
        }

        private void RemovePlaceholderText(object sender, EventArgs e)
        {
            if (txtSearchBar.Text == "Search author name...")
            {
                txtSearchBar.Text = string.Empty;
                txtSearchBar.ForeColor = Color.Black;
            }
        }

        private void txtSearchBar_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearchBar.Text.Trim();
            PopulateAuthorList(searchText);
        }

        private void PopulateAuthorList(string searchText)
        {
            lstAuthors.Items.Clear();

            try
            {
                var authors = _authorService.GetAuthors(searchText);

                if (authors.Any())
                {
                    foreach (var author in authors)
                    {
                        lstAuthors.Items.Add($"{author.au_fname} {author.au_lname} ({author.au_id})");
                    }
                }
                else
                {
                    lstAuthors.Items.Add("No authors found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching authors:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string auId = txtId.Text.Trim();
                if (!Regex.IsMatch(auId, @"^\d{3}-\d{2}-\d{4}$"))
                {
                    MessageBox.Show("Author ID must be in the format XXX-XX-XXXX and consist only of digits.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string auFname = txtFname.Text.Trim();
                if (string.IsNullOrEmpty(auFname) || auFname.Length > 20)
                {
                    MessageBox.Show("First name cannot be empty and must not exceed 20 characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string auLname = txtLName.Text.Trim();
                if (string.IsNullOrEmpty(auLname) || auLname.Length > 40)
                {
                    MessageBox.Show("Last name cannot be empty and must not exceed 40 characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string zip = txtZip.Text.Trim();
                if (!string.IsNullOrWhiteSpace(zip) && !Regex.IsMatch(zip, @"^\d{5}$"))
                {
                    MessageBox.Show("ZIP code must consist of exactly 5 digits.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool contract = false;
                if (!bool.TryParse(cmbContract.Text.Trim(), out contract))
                {
                    MessageBox.Show("Contract must be either 'True' or 'False'.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var newAuthor = new author
                {
                    au_id = auId,
                    au_fname = auFname,
                    au_lname = auLname,
                    phone = Regex.Replace(txtPhone.Text.Trim(), @"[()\s-]", ""), 
                    address = string.IsNullOrWhiteSpace(txtAddress.Text) ? null : txtAddress.Text.Trim(),
                    city = string.IsNullOrWhiteSpace(txtCity.Text) ? null : txtCity.Text.Trim(),
                    state = txtState.Text.Trim().ToUpper(),
                    zip = zip,
                    contract = contract
                };

                _authorService.CreateAuthor(newAuthor);
                MessageBox.Show("Author added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PopulateAuthorList(string.Empty);
                ClearInputFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding author:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lstAuthors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstAuthors.SelectedIndex == -1) return;

            string selected = lstAuthors.SelectedItem.ToString();
            string authorId = selected.Split(' ').Last().Trim(new char[] { '(', ')' });

            try
            {
                var author = _authorService.GetAuthorDetails(authorId);

                if (author != null)
                {
                    txtId.Text = author.au_id;
                    txtFname.Text = author.au_fname;
                    txtLName.Text = author.au_lname;
                    txtPhone.Text = author.phone;
                    txtAddress.Text = author.address;
                    txtCity.Text = author.city;
                    txtState.Text = author.state;
                    txtZip.Text = author.zip;
                    cmbContract.Text = author.contract.ToString();
                }
                else
                {
                    MessageBox.Show("Author not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching author details:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string authorId = txtId.Text.Trim();

            if (string.IsNullOrEmpty(authorId))
            {
                MessageBox.Show("Please enter a valid Author ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _authorService.DeleteAuthor(authorId);
                MessageBox.Show("Author removed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PopulateAuthorList(string.Empty);
                ClearInputFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error removing author:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputFields()
        {
            txtId.Clear();
            txtFname.Clear();
            txtLName.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            txtCity.Clear();
            txtState.Clear();
            txtZip.Clear();
            cmbContract.SelectedIndex = -1;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
