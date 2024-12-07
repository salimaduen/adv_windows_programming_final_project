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
        private readonly PublisherService _publisherService;

        public frmPublisher()
        {
            InitializeComponent();
            _publisherService = new PublisherService();
            txtSearchBar.GotFocus += RemovePlaceholderText;
        }

        private void frmPublisher_Load(object sender, EventArgs e)
        {
            PopulatePublisherList(string.Empty);
        }

        private void RemovePlaceholderText(object sender, EventArgs e)
        {
            if (txtSearchBar.Text == "Search For Publisher")
            {
                txtSearchBar.Text = string.Empty;
                txtSearchBar.ForeColor = Color.Black;
            }
        }

        private void txtSearchBar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtSearchBar.Text.Trim();
                PopulatePublisherList(searchText);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching for publishers:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lstPublishers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPublishers.SelectedIndex == -1) return;

            string selected = lstPublishers.SelectedItem.ToString();
            string pubId = selected.Split('(').Last().Trim(')');

            try
            {
                var publishers = _publisherService.GetPublishers(pubId);
                if (publishers.Any())
                {
                    var publisher = publishers.First();
                    txtPubId.Text = publisher.pub_id;
                    txtPubName.Text = publisher.pub_name;
                    txtCity.Text = publisher.city;
                    txtState.Text = publisher.state;
                    txtCountry.Text = publisher.country;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading publisher details:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulatePublisherList(string searchText)
        {
            lstPublishers.Items.Clear();

            try
            {
                var publishers = _publisherService.GetPublishers(searchText);

                if (publishers.Any())
                {
                    foreach (var pub in publishers)
                    {
                        lstPublishers.Items.Add($"{pub.pub_name} ({pub.pub_id})");
                    }
                }
                else
                {
                    lstPublishers.Items.Add("No publishers found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading publishers:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var newPublisher = new publisher
                {
                    pub_id = txtPubId.Text.Trim(),
                    pub_name = txtPubName.Text.Trim(),
                    city = txtCity.Text.Trim(),
                    state = txtState.Text.Trim().ToUpper(),
                    country = txtCountry.Text.Trim()
                };

                _publisherService.AddPublisher(newPublisher);
                PopulatePublisherList(string.Empty);
                MessageBox.Show("Publisher added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Duplicate Record", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding publisher:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                string pubId = txtPubId.Text.Trim();

                if (string.IsNullOrEmpty(pubId))
                {
                    MessageBox.Show("Please enter a valid Publisher ID to remove.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _publisherService.RemovePublisher(pubId);
                PopulatePublisherList(string.Empty);
                MessageBox.Show("Publisher removed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error removing publisher:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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