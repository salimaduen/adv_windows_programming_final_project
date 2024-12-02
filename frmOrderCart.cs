﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project
{
    public partial class frmOrderCart : Form
    {
        private DataTable cartTable;
        public frmOrderCart()
        {
            InitializeComponent();
            txtSearchBar.GotFocus += RemovePlaceholderText;

            cartTable = new DataTable();
            cartTable.Columns.Add("Id", typeof(string));
            cartTable.Columns.Add("Title", typeof(string));
            cartTable.Columns.Add("Price", typeof(decimal));

            dgvCartList.DataSource = cartTable;
            dgvCartList.Columns["Price"].DefaultCellStyle.Format = "C";

            fillStoreCombo();
        }

        private void RemovePlaceholderText(object sender, EventArgs e)
        {
            if (txtSearchBar.Text == "Search title name...")
            {
                txtSearchBar.Text = string.Empty;
                txtSearchBar.ForeColor = Color.Black;
            }
        }

        private void fillStoreCombo()
        {
            using (BookStoreEntities context = new BookStoreEntities())
            {
                var stores = context.stores
                    .Select(s => s.stor_id)
                    .ToList();
                stores.Insert(0, "");
                this.cmbStores.DataSource = stores;
            }
        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            Dictionary<string, ValueTuple<int, decimal?>> items = new Dictionary<string, ValueTuple<int, decimal?>>();

            foreach (DataRow row in this.cartTable.Rows)
            {
                string title_id = row["Id"].ToString();
                decimal? price = row["Price"] as decimal?;

                if (!items.ContainsKey(title_id))
                {
                    items.Add(title_id, (1, price));
                }
                else
                {
                    var current = items[title_id];
                    items[title_id] = (current.Item1 + 1, current.Item2);
                }
            }

            string storeId = this.cmbStores.SelectedItem.ToString();
            string ordNum = GenerateUniqueOrderNumber();
            DateTime orderDate = DateTime.Now;

            if (items.Count <= 0)
            {
                MessageBox.Show("You must add at least one item before proceeding with purchase.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (storeId.Equals(""))
            {
                MessageBox.Show("You must select a store before proceeding with purchase.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            foreach (String key in items.Keys)
            {
                Console.WriteLine(key + ": " + items[key]);
            }
            MessageBox.Show("Purchase was successfull!");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearchBar_TextChanged(object sender, EventArgs e)
        {
            using (BookStoreEntities context = new BookStoreEntities())
            {
                // Get the search text from the search bar
                string searchText = this.txtSearchBar.Text.ToLower();

                // Query the titles table, excluding NULL prices
                var titles = context.titles
                    .Where(t => t.price != null && t.title1.ToLower().Contains(searchText)) // Skip NULL prices
                    .Select(t => new { t.title_id, t.title1, t.price })
                    .ToList();

                // Clear the DataGridView
                dgvTitleList.DataSource = null;

                if (titles.Count > 0)
                {
                    // Bind the queried titles to the DataGridView
                    dgvTitleList.DataSource = titles;

                    // Format columns (optional)
                    dgvTitleList.Columns["title_id"].HeaderText = "Title ID";
                    dgvTitleList.Columns["title1"].HeaderText = "Title";
                    dgvTitleList.Columns["price"].HeaderText = "Price";
                    dgvTitleList.Columns["price"].DefaultCellStyle.Format = "C";
                }
                else
                {
                    // If no results are found, display a message
                    dgvTitleList.DataSource = new[]
                    {
                new { title = "No titles found", price = (decimal?)null }
            };

                    dgvTitleList.Columns["title"].HeaderText = "Title";
                    dgvTitleList.Columns["price"].HeaderText = "Price";
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.dgvTitleList.SelectedRows.Count <= 0 )
            {
                MessageBox.Show("Must select a title first before adding!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = this.dgvTitleList.SelectedRows[0];

            string id = selectedRow.Cells["title_id"].Value?.ToString();
            string title = selectedRow.Cells["title1"].Value?.ToString();
            decimal? price = selectedRow.Cells["price"].Value as decimal?;

            if (id == null || price == null || price == null)
            {
                return;
            }

            cartTable.Rows.Add(id, title, price.Value);
            UpdateCost();

        }
        
        private void UpdateCost()
        {
            decimal subTotal = 0.0m;
            foreach (DataRow row in this.cartTable.Rows)
            {
                if (row["price"] != DBNull.Value)
                {
                    subTotal += Convert.ToDecimal(row["price"]);
                }
            }
            this.txtSubtotal.Text = Math.Round(subTotal, 2).ToString("C");
            this.txtTax.Text = Math.Round(subTotal * 0.07m, 2).ToString("C");
            this.txtTotal.Text = Math.Round(subTotal * 1.07m, 2).ToString("C");
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (this.dgvCartList.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Must select a title first before removing!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = this.dgvCartList.SelectedRows[0];
            this.dgvCartList.Rows.Remove(selectedRow);
            UpdateCost();
        }

        private string GenerateUniqueOrderNumber()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();

            using (BookStoreEntities context = new BookStoreEntities())
            {
                string ordNum;

                do
                {
                    // Generate a random length between 5 and 8 characters
                    int length = random.Next(5, 9);

                    // Generate the random alphanumeric string
                    ordNum = new string(Enumerable.Repeat(chars, length)
                                                  .Select(s => s[random.Next(s.Length)]).ToArray());

                } while (context.sales.Any(s => s.ord_num == ordNum)); // Check uniqueness in the database

                return ordNum;
            }
        }
    }
}