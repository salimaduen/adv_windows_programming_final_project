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
    public partial class frmSummary : Form
    {
        private string orderNumber;
        private List<(string TitleId, string Title, int Quantity, decimal Price)> orderedItems;
        private string subTotal;
        private string tax;
        private string totalOrderCost;
        public frmSummary(
            string orderNumber,
            List<(string TitleId, string Title, int Quantity, decimal Price)> orderedItems,
            string subTotal,
            string tax,
            string totalOrderCost
            )
        {
            InitializeComponent();

            this.orderNumber = orderNumber;
            this.orderedItems = orderedItems;
            this.tax = tax;
            this.totalOrderCost = totalOrderCost;
            this.subTotal = subTotal;

            dgvOrderedItems.Columns.Add("TitleId", "Title ID");
            dgvOrderedItems.Columns.Add("Title", "Title");
            dgvOrderedItems.Columns.Add("Quantity", "Quantity");
            dgvOrderedItems.Columns.Add("Price", "Price");
            dgvOrderedItems.Columns.Add("Total", "Total");

            LoadSummary();
        }

        private void LoadSummary()
        {
            lblOrderNumber.Text = $"Order Number: {orderNumber}";
            txtTax.Text = this.tax;
            txtSubtotal.Text = this.subTotal;
            txtTotal.Text = this.totalOrderCost;

            foreach (var item in orderedItems)
            {
                decimal productTotal = item.Quantity * item.Price;
                dgvOrderedItems.Rows.Add(item.TitleId, item.Title, item.Quantity, item.Price.ToString("C"), productTotal.ToString("C"));
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
