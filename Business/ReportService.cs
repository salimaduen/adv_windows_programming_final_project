using Final_Project.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project.Business
{
    internal class ReportService
    {
        private readonly ReportDataService _dataService;

        public ReportService()
        {
            _dataService = new ReportDataService();
        }

        public List<dynamic> GetReportData(DateTime fromDate, DateTime toDate)
        {
            if (fromDate > toDate)
            {
                throw new ArgumentException("Start date cannot be later than the end date.");
            }

            return _dataService.GetSalesData(fromDate, toDate);
        }

        public void ExportToCsv(string filePath, DataGridView dgv)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("File path cannot be empty.");
            }

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    writer.Write(dgv.Columns[i].HeaderText);
                    if (i < dgv.Columns.Count - 1)
                        writer.Write(",");
                }
                writer.WriteLine();

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        writer.Write(row.Cells[i].Value?.ToString() ?? "");
                        if (i < dgv.Columns.Count - 1)
                            writer.Write(",");
                    }
                    writer.WriteLine();
                }
            }
        }
    }

}
