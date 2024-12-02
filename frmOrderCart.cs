using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

            FillStoreCombo();
            FillPayCombo();
        }

        private void RemovePlaceholderText(object sender, EventArgs e)
        {
            if (txtSearchBar.Text == "Search title name...")
            {
                txtSearchBar.Text = string.Empty;
                txtSearchBar.ForeColor = Color.Black;
            }
        }

        private void FillPayCombo()
        {
            List<int> lst = new List<int>();
            lst.AddRange(Enumerable.Range(1, 12));
            this.cmbPayTerm.DataSource = lst;
        }

        private void FillStoreCombo()
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
            string payTerms = this.cmbPayTerm.SelectedItem.ToString();
            DateTime orderDate = DateTime.Now.Date;

            if (items.Count <= 0)
            {
                MessageBox.Show("You must add at least one item before proceeding with purchase.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (String.IsNullOrEmpty(storeId))
            {
                MessageBox.Show("You must select a store before proceeding with purchase.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (BookStoreEntities context = new BookStoreEntities())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (var item in items)
                        {
                            string titleId = item.Key;
                            short quantity = (short)item.Value.Item1;

                        
                            context.sales.Add(new sale
                            {
                                stor_id = storeId,
                                ord_num = ordNum,
                                ord_date = orderDate,
                                qty = quantity,
                                payterms = payTerms,
                                title_id = titleId
                            });
                        }

                        context.SaveChanges();
                        transaction.Commit();

                        MessageBox.Show("Purchase was successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        var orderedItems = items.Select(item =>
                            new
                            {
                                TitleId = item.Key,
                                Title = context.titles.FirstOrDefault(t => t.title_id == item.Key)?.title1,
                                Quantity = item.Value.Item1,
                                Price = item.Value.Item2 ?? 0
                            }).Select(x => (x.TitleId, x.Title, x.Quantity, x.Price)).ToList();

                        frmSummary summary = new frmSummary(ordNum, orderedItems, this.txtSubtotal.Text, this.txtTax.Text, this.txtTotal.Text);
                        summary.Show();

                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"An error occurred while processing the purchase:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearchBar_TextChanged(object sender, EventArgs e)
        {
            using (BookStoreEntities context = new BookStoreEntities())
            {
   
                string searchText = this.txtSearchBar.Text.ToLower();

                var titles = context.titles
                    .Where(t => t.price != null && t.title1.ToLower().Contains(searchText))
                    .Select(t => new { t.title_id, t.title1, t.price })
                    .ToList();

 
                dgvTitleList.DataSource = null;

                if (titles.Count > 0)
                {
                    dgvTitleList.DataSource = titles;

                    dgvTitleList.Columns["title_id"].HeaderText = "Title ID";
                    dgvTitleList.Columns["title1"].HeaderText = "Title";
                    dgvTitleList.Columns["price"].HeaderText = "Price";
                    dgvTitleList.Columns["price"].DefaultCellStyle.Format = "C";
                }
                else
                {

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
                    int length = random.Next(5, 9);

                    ordNum = new string(Enumerable.Repeat(chars, length)
                                                  .Select(s => s[random.Next(s.Length)]).ToArray());

                } while (context.sales.Any(s => s.ord_num == ordNum)); // loop if num not unique

                return ordNum;
            }
        }
    }
}