using Final_Project.Business;
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
        private readonly StoreService _storeService;

        public frmStores()
        {
            InitializeComponent();
            _storeService = new StoreService();
            this.Load += FrmStores_Load;
            txtSearchBar.GotFocus += RemovePlaceholderText;
            txtSearchBar.TextChanged += txtSearchBar_TextChanged;
            lstStores.SelectedIndexChanged += lstStores_SelectedIndexChanged;
        }

        private void FrmStores_Load(object sender, EventArgs e)
        {
            PopulateStoreList(string.Empty);
        }

        private void RemovePlaceholderText(object sender, EventArgs e)
        {
            if (txtSearchBar.Text == "Search store name...")
            {
                txtSearchBar.Text = string.Empty;
                txtSearchBar.ForeColor = Color.Black;
            }
        }

        private void txtSearchBar_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearchBar.Text.Trim().ToLower();
            PopulateStoreList(searchText);
        }

        private void PopulateStoreList(string searchText)
        {
            lstStores.Items.Clear();

            try
            {
                var stores = _storeService.SearchStores(searchText);

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
                ShowExceptionDetails(ex);
            }
        }

        private void lstStores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstStores.SelectedIndex == -1) return;

            string selected = lstStores.Items[lstStores.SelectedIndex].ToString();
            string selectedId = selected.Split(' ')[0];

            try
            {
                var store = _storeService.GetStoreDetails(selectedId);

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
            catch (Exception ex)
            {
                ShowExceptionDetails(ex);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string storId = txtStoreId.Text.Trim();
                if (string.IsNullOrEmpty(storId) || storId.Length != 4)
                {
                    MessageBox.Show("Store ID must be exactly 4 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string state = txtState.Text.Trim().ToUpper();
                if (!string.IsNullOrEmpty(state) && state.Length != 2)
                {
                    MessageBox.Show("State must be exactly 2 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string zip = txtZip.Text.Trim();
                if (!string.IsNullOrEmpty(zip) && zip.Length != 5)
                {
                    MessageBox.Show("ZIP code must be exactly 5 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var newStore = new store
                {
                    stor_id = storId,
                    stor_name = txtStoreName.Text.Trim(),
                    stor_address = string.IsNullOrEmpty(txtStoreAddress.Text) ? null : txtStoreAddress.Text.Trim(),
                    city = string.IsNullOrEmpty(txtCity.Text) ? null : txtCity.Text.Trim(),
                    state = string.IsNullOrEmpty(state) ? null : state,
                    zip = string.IsNullOrEmpty(zip) ? null : zip
                };

                _storeService.CreateStore(newStore);
                PopulateStoreList(string.Empty);
                ClearInputFields();
                MessageBox.Show("Store added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ShowExceptionDetails(ex);
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

                _storeService.DeleteStore(id);
                PopulateStoreList(string.Empty);
                ClearInputFields();
                MessageBox.Show("Store removed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ShowExceptionDetails(ex);
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

        private void ShowExceptionDetails(Exception ex)
        {
            var innerException = ex.InnerException?.Message ?? ex.Message;
            MessageBox.Show($"An error occurred:\n{innerException}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
