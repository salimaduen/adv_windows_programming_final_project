using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project
{
    public partial class frmStores : Form
    {
        public frmStores()
        {
            InitializeComponent();
            this.Load += FrmStores_Load; // Load event to populate the list on form load
        }

        private void FrmStores_Load(object sender, EventArgs e)
        {
            // Populate the store list on form load
            PopulateStoreList(string.Empty);
        }

        private void txtSearchBar_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearchBar.Text.Trim().ToLower();
            PopulateStoreList(searchText);
        }

        private void PopulateStoreList(string searchText)
        {
            lstStores.Items.Clear();

            using (BookStoreEntities context = new BookStoreEntities())
            {
                try
                {
                    var stores = string.IsNullOrEmpty(searchText)
                        ? context.stores
                            .Select(s => new { s.stor_id, s.stor_name, s.city, s.state })
                            .ToList()
                        : context.stores
                            .Where(s => s.stor_name.ToLower().Contains(searchText) || s.city.ToLower().Contains(searchText))
                            .Select(s => new { s.stor_id, s.stor_name, s.city, s.state })
                            .ToList();

                    if (stores.Any())
                    {
                        foreach (var store in stores)
                        {
                            lstStores.Items.Add($"{store.stor_id} {store.stor_name} - {store.city}, {store.state}");
                        }
                    }
                    else
                    {
                        lstStores.Items.Add("No stores found");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving stores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Get values from the textboxes
                string id = txtStoreId.Text.Trim();
                string name = txtStoreName.Text.Trim();
                string address = txtStoreAddress.Text.Trim();
                string city = txtCity.Text.Trim();
                string state = txtState.Text.Trim();
                string zip = txtZip.Text.Trim();

                if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("Store ID and Name are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate state
                if (state.Length != 2)
                {
                    MessageBox.Show("State must be a valid 2-letter abbreviation.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate ZIP code
                if (zip.Length != 5 || !zip.All(char.IsDigit))
                {
                    MessageBox.Show("ZIP code must be a 5-digit number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Create a new store record
                var newStore = new store
                {
                    stor_id = id,
                    stor_name = name,
                    stor_address = string.IsNullOrEmpty(address) ? null : address,
                    city = string.IsNullOrEmpty(city) ? null : city,
                    state = state.ToUpper(),
                    zip = zip
                };

                // Add the store to the database
                using (BookStoreEntities context = new BookStoreEntities())
                {
                    if (context.stores.Any(s => s.stor_id == id))
                    {
                        MessageBox.Show("Store ID already exists. Please use a unique ID.", "Duplicate Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    context.stores.Add(newStore);
                    context.SaveChanges();
                }

                // Refresh the store list
                PopulateStoreList(string.Empty);

                // Show success message
                MessageBox.Show("Store added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear input fields
                ClearInputFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding the store:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                string id = txtStoreId.Text.Trim();

                if (string.IsNullOrEmpty(id))
                {
                    MessageBox.Show("Please enter a valid Store ID to remove.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (BookStoreEntities context = new BookStoreEntities())
                {
                    var storeToRemove = context.stores.SingleOrDefault(s => s.stor_id == id);

                    if (storeToRemove == null)
                    {
                        MessageBox.Show("Store not found!", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    context.stores.Remove(storeToRemove);
                    context.SaveChanges();
                }

                // Refresh the store list
                PopulateStoreList(string.Empty);

                // Show success message
                MessageBox.Show("Store removed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear input fields
                ClearInputFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while removing the store:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        private void ClearInputFields()
        {
            txtStoreId.Text = "";
            txtStoreName.Text = "";
            txtStoreAddress.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtZip.Text = "";
        }

        private void lstStores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstStores.SelectedIndex == -1)
                return;

            string selected = lstStores.Items[lstStores.SelectedIndex].ToString();
            string[] parts = selected.Split(' ');
            string selectedId = parts[0];

            if (!string.IsNullOrEmpty(selectedId))
            {
                try
                {
                    using (BookStoreEntities context = new BookStoreEntities())
                    {
                        var store = context.stores
                            .Where(s => s.stor_id == selectedId)
                            .FirstOrDefault();

                        if (store != null)
                        {
                            txtStoreId.Text = store.stor_id;
                            txtStoreName.Text = store.stor_name;
                            txtStoreAddress.Text = store.stor_address;
                            txtCity.Text = store.city;
                            txtState.Text = store.state;
                            txtZip.Text = store.zip;
                        }
                        else
                        {
                            MessageBox.Show("No store found with the selected ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error occurred while fetching the store:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
