using Final_Project.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Final_Project
{
    public partial class frmOrderCart : Form
    {
        private readonly OrderService _orderService;
        private readonly DataTable _cartTable;

        public frmOrderCart()
        {
            InitializeComponent();
            _orderService = new OrderService();
            _cartTable = CreateCartTable();
            dgvCartList.DataSource = _cartTable;

            dgvCartList.Columns["Price"].DefaultCellStyle.Format = "C";
            FillStoreCombo();
            FillPayCombo();
            txtSearchBar.GotFocus += RemovePlaceholderText;
        }

        private void RemovePlaceholderText(object sender, EventArgs e)
        {
            if (txtSearchBar.Text == "Search title name...")
            {
                txtSearchBar.Text = string.Empty;
                txtSearchBar.ForeColor = Color.Black;
            }
        }

        private DataTable CreateCartTable()
        {
            var table = new DataTable();
            table.Columns.Add("Id", typeof(string));
            table.Columns.Add("Title", typeof(string));
            table.Columns.Add("Price", typeof(decimal));
            return table;
        }

        private void FillStoreCombo()
        {
            var stores = _orderService.GetStoreIds();
            stores.Insert(0, string.Empty); // Add empty option
            cmbStores.DataSource = stores;
        }

        private void FillPayCombo()
        {
            List<int> lst = new List<int>();
            lst.AddRange(Enumerable.Range(1, 12));
            this.cmbPayTerm.DataSource = lst;
        }

        private void txtSearchBar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtSearchBar.Text.Trim();
                var titles = _orderService.SearchTitles(searchText);

                dgvTitleList.DataSource = titles;
                dgvTitleList.Columns["title_id"].HeaderText = "Title ID";
                dgvTitleList.Columns["title1"].HeaderText = "Title";
                dgvTitleList.Columns["price"].HeaderText = "Price";
                dgvTitleList.Columns["price"].DefaultCellStyle.Format = "C";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching titles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dgvTitleList.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a title first.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dgvTitleList.SelectedRows[0];
            string id = selectedRow.Cells["title_id"].Value.ToString();
            string title = selectedRow.Cells["title1"].Value.ToString();
            decimal price = (decimal)selectedRow.Cells["price"].Value;

            _cartTable.Rows.Add(id, title, price);
            UpdateCost();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvCartList.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select an item to remove.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _cartTable.Rows.RemoveAt(dgvCartList.SelectedRows[0].Index);
            UpdateCost();
        }

        private void UpdateCost()
        {
            decimal subTotal = _cartTable.AsEnumerable().Sum(row => Convert.ToDecimal(row["Price"]));
            txtSubtotal.Text = subTotal.ToString("C");
            txtTax.Text = (subTotal * 0.07m).ToString("C");
            txtTotal.Text = (subTotal * 1.07m).ToString("C");
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            try
            {
                
                string storeId = cmbStores.SelectedItem?.ToString();
                string payTerms = cmbPayTerm.SelectedItem?.ToString();
                string ordNum = _orderService.GenerateUniqueOrderNumber();
      
                DateTime orderDate = DateTime.Now.Date;
                
                _orderService.ProcessOrder(storeId, payTerms, _cartTable, orderDate, ordNum);

                MessageBox.Show("Purchase was successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                var orderedItems = _orderService.GetOrderedItems(_cartTable);

                frmSummary summary = new frmSummary(
                    ordNum,
                    orderedItems,
                    txtSubtotal.Text,
                    txtTax.Text,
                    txtTotal.Text);
                summary.Show();

                Close();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while processing the purchase:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
