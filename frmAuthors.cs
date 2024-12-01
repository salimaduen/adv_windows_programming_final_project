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
        public frmAuthors()
        {
            InitializeComponent();
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
            if (this.txtSearchBar.Text.Length == 0)
            {
                {
                    this.lstAuthors.Items.Clear();

                    using (BookStoreEntities context = new BookStoreEntities())
                    {
                        var authors = context.authors
                            .Select(a => new {a.au_fname, a.au_lname, a.au_id})
                            .ToList();

                        foreach (var auth in authors)
                        {
                            this.lstAuthors.Items.Add($"{auth.au_fname} {auth.au_lname} {auth.au_id}");
                        }
                    }
                }
            } else
            {
                this.lstAuthors.Items.Clear();

                using (BookStoreEntities context = new BookStoreEntities())
                {
                    string searchText = this.txtSearchBar.Text.ToLower();

                    var authors = context.authors
                        .Where(a => a.au_fname.ToLower().StartsWith(searchText) || a.au_lname.ToLower().StartsWith(searchText))
                        .Select(a => new { a.au_fname, a.au_lname, a.au_id})
                        .ToList();

                    if (authors.Count > 0)
                    {
                        foreach (var auth in authors)
                        {
                            this.lstAuthors.Items.Add($"{auth.au_fname} {auth.au_lname} {auth.au_id}");
                        }
                    } else
                    {
                        this.lstAuthors.Items.Add("No authors found");
                    }
                    
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string id = txtId.Text.Trim();
            string fName = txtFname.Text.Trim();
            string lName = txtLName.Text.Trim();
            string phone = Regex.Replace(txtPhone.Text.Trim(), @"[()\\s]", "");
            string address = txtAddress.Text.Trim();
            string city = txtCity.Text.Trim();
            string state = txtState.Text.Trim().ToUpper();
            string zip = txtZip.Text.Trim();
            string contractText = cmbContract.Text.Trim();


            using (BookStoreEntities context = new BookStoreEntities())
            {
                try
                {
   
                    bool authorExists = context.authors.Any(a => a.au_id == id);

                    if (authorExists)
                    {
                        MessageBox.Show("Author already exists!", "Duplicate Record", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    
                    var newAuthor = new author
                    {
                        au_id = id,
                        au_fname = fName,
                        au_lname = lName,
                        phone = phone,
                        address = string.IsNullOrEmpty(address) ? null : address,
                        city = string.IsNullOrEmpty(city) ? null : city,
                        state = string.IsNullOrEmpty(state) ? null : state,
                        zip = zip,
                        contract = Boolean.Parse(contractText)
                    };
                    
                    context.authors.Add(newAuthor);
                    context.SaveChanges();
                    txtSearchBar_TextChanged(sender, e);
                    MessageBox.Show("Author added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    var innerException = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                    MessageBox.Show($"An error occurred while adding the author:\n{innerException}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void lstAuthors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstAuthors.SelectedIndex == -1)
                return;

            string selected = lstAuthors.Items[lstAuthors.SelectedIndex].ToString();
            string[] selectedId = selected.Split(' ');
            selected = selectedId[selectedId.Length - 1];

            if (!string.IsNullOrEmpty(selected))
            {
                try
                {
                    using (BookStoreEntities context = new BookStoreEntities())
                    {
                        var author = context.authors
                            .Where(a => a.au_id.Equals(selected))
                            .FirstOrDefault();

                        if (author != null)
                        {
                            txtId.Text = author.au_id;
                            txtFname.Text = author.au_fname;
                            txtLName.Text = author.au_lname;
                            txtPhone.Text = author.phone.Replace(" ", "").Replace("-", "");
                            txtAddress.Text = author.address;
                            txtCity.Text = author.city;
                            txtState.Text = author.state;
                            txtZip.Text = author.zip;
                            cmbContract.Text = author.contract.ToString();
                        }
                        else
                        {
                            MessageBox.Show("No author found with the selected ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error occurred while fetching the author:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
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
                    var authorToRemove = context.authors.SingleOrDefault(a => a.au_id == id);

                    if (authorToRemove == null)
                    {
                        MessageBox.Show("Author not found!", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var relatedRecords = context.titleauthors.Where(ta => ta.au_id == id).ToList();
                    if (relatedRecords.Any())
                    {
                        context.titleauthors.RemoveRange(relatedRecords);
                    }

                    context.authors.Remove(authorToRemove);

                    context.SaveChanges();

                    MessageBox.Show("Author record removed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearInputFields();
                    txtSearchBar_TextChanged(sender, e);
                }
                catch (Exception ex)
                {
                    var innerException = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                    MessageBox.Show($"Error occurred while removing the author:\n{innerException}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void ClearInputFields()
        {
            txtId.Text = "";
            txtFname.Text = "";
            txtLName.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtZip.Text = "";
            cmbContract.SelectedIndex = -1;
        }

    }
}
