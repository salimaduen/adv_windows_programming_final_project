using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Final_Project
{
    public partial class frmPublisher : Form
    {
        public frmPublisher()
        {
            InitializeComponent();
            txtSearchBar.GotFocus += RemovePlaceholderText;
        }

        private void RemovePlaceholderText(object sender, EventArgs e)
        {
            if (txtSearchBar.Text == "Search For Publisher")
            {
                txtSearchBar.Text = string.Empty;
                txtSearchBar.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtSearchBar_TextChanged(object sender, EventArgs e)
        {
            if (this.txtSearchBar.Text.Length == 0)
            {
                this.lstPublishers.Items.Clear();

                using (BookStoreEntities context = new BookStoreEntities())
                {
                    var publishers = context.publishers
                        .Select(p => new { p.pub_name, p.pub_id })
                        .ToList();

                    foreach (var pub in publishers)
                    {
                        this.lstPublishers.Items.Add($"{pub.pub_name} ({pub.pub_id})");
                        Console.WriteLine($"{pub.pub_name} ({pub.pub_id})");
                    }
                }
            }
            else
            {
                this.lstPublishers.Items.Clear();

                using (BookStoreEntities context = new BookStoreEntities())
                {
                    string searchText = this.txtSearchBar.Text.ToLower();

                    var publishers = context.publishers
                        .Where(p => p.pub_name.ToLower().StartsWith(searchText))
                        .Select(p => new { p.pub_name, p.pub_id })
                        .ToList();

                    if (publishers.Count > 0)
                    {
                        foreach (var pub in publishers)
                        {
                            this.lstPublishers.Items.Add($"{pub.pub_name} ({pub.pub_id})");
                        }
                    }
                    else
                    {
                        this.lstPublishers.Items.Add("No publishers found");
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string id = txtPubId.Text.Trim();
            string name = txtPubName.Text.Trim();
            string city = txtCity.Text.Trim();
            string state = txtState.Text.Trim().ToUpper();
            string country = txtCountry.Text.Trim();

            using (BookStoreEntities context = new BookStoreEntities())
            {
                try
                {
                    bool publisherExists = context.publishers.Any(p => p.pub_id == id);

                    if (publisherExists)
                    {
                        MessageBox.Show("Publisher already exists!", "Duplicate Record", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var newPublisher = new publisher
                    {
                        pub_id = id,
                        pub_name = name,
                        city = string.IsNullOrEmpty(city) ? null : city,
                        state = string.IsNullOrEmpty(state) ? null : state,
                        country = string.IsNullOrEmpty(country) ? null : country
                    };

                    context.publishers.Add(newPublisher);
                    context.SaveChanges();
                    txtSearchBar_TextChanged(sender, e);
                    MessageBox.Show("Publisher added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    var innerException = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                    MessageBox.Show($"An error occurred while adding the publisher:\n{innerException}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lstPublishers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPublishers.SelectedIndex == -1)
                return;

            string selected = lstPublishers.Items[lstPublishers.SelectedIndex].ToString();
            string[] selectedId = selected.Split('(');
            string id = selectedId[selectedId.Length - 1].Replace(")", "").Trim();

            using (BookStoreEntities context = new BookStoreEntities())
            {
                var publisher = context.publishers.FirstOrDefault(p => p.pub_id == id);

                if (publisher != null)
                {
                    txtPubId.Text = publisher.pub_id;
                    txtPubName.Text = publisher.pub_name;
                    txtCity.Text = publisher.city;
                    txtState.Text = publisher.state;
                    txtCountry.Text = publisher.country;
                }
                else
                {
                    MessageBox.Show("No publisher found with the selected ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string id = txtPubId.Text.Trim();

            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Please enter a valid ID to remove.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (BookStoreEntities context = new BookStoreEntities())
            {
                try
                {
                    // Check if the publisher exists
                    var publisherToRemove = context.publishers.SingleOrDefault(p => p.pub_id == id);
                    if (publisherToRemove == null)
                    {
                        MessageBox.Show("Publisher not found!", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Update pub_id for all titles referencing this publisher to the new ID (9952)
                    var relatedTitles = context.titles.Where(t => t.pub_id == id).ToList();
                    foreach (var title in relatedTitles)
                    {
                        title.pub_id = null; // Set pub_id to the new ID
                    }

                    // Update pub_id for employees referencing this publisher to the new ID (9952)
                    var relatedEmployees = context.employees.Where(es => es.pub_id == id).ToList();
                    foreach (var employee in relatedEmployees)
                    {
                        employee.pub_id = "9952"; // Set pub_id to the new ID
                    }

                    // Remove related records in pub_info
                    var relatedPubInfo = context.pub_info.SingleOrDefault(pi => pi.pub_id == id);
                    if (relatedPubInfo != null)
                    {
                        context.pub_info.Remove(relatedPubInfo);
                    }

                    // Finally, remove the publisher
                    context.publishers.Remove(publisherToRemove);
                    context.SaveChanges();

                    MessageBox.Show("Publisher record removed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearInputFields();
                    txtSearchBar_TextChanged(sender, e);
                }
                catch (Exception ex)
                {
                    var innerException = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                    MessageBox.Show($"Error occurred while removing the publisher:\n{innerException}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void ClearInputFields()
        {
            txtPubId.Text = "";
            txtPubName.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtCountry.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}