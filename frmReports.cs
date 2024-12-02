using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project
{
    public partial class frmReports : Form
    {
        public frmReports()
        {
            InitializeComponent();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fromDate = dtpFrom.Value.Date;
                DateTime toDate = dtpTo.Value.Date;

                if (fromDate > toDate)
                {
                    MessageBox.Show("Start date cannot be later than the end date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (BookStoreEntities context = new BookStoreEntities())
                {
                    var reportData = (from sale in context.sales
                                      join title in context.titles
                                      on sale.title_id equals title.title_id
                                      where DbFunctions.TruncateTime(sale.ord_date) >= fromDate &&
                                            DbFunctions.TruncateTime(sale.ord_date) <= toDate
                                      orderby sale.ord_date
                                      select new
                                      {
                                          OrderNumber = sale.ord_num,
                                          TitleId = sale.title_id,
                                          Title = title.title1,
                                          Quantity = sale.qty,
                                          OrderDate = sale.ord_date,
                                          TotalValue = sale.qty * (title.price ?? 0) 
                                      }).ToList();

                    if (!reportData.Any())
                    {
                        MessageBox.Show("No records found for the selected date range.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    dgvReport.DataSource = reportData;

                    // currency format)
                    dgvReport.Columns["TotalValue"].DefaultCellStyle.Format = "C";

                    MessageBox.Show("Report data displayed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                MessageBox.Show($"An error occurred while generating the report:\n{innerException}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





    }
}
