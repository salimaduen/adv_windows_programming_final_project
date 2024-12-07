using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.Data
{
    internal class ReportDataService
    {
        public List<dynamic> GetSalesData(DateTime fromDate, DateTime toDate)
        {
            using (var context = new BookStoreEntities())
            {
                return (from sale in context.sales
                        join title in context.titles
                        on sale.title_id equals title.title_id
                        where sale.ord_date >= fromDate && sale.ord_date <= toDate
                        orderby sale.ord_date
                        select new
                        {
                            StoreId = sale.stor_id,
                            OrderNumber = sale.ord_num,
                            TitleId = sale.title_id,
                            Title = title.title1,
                            Quantity = sale.qty,
                            OrderDate = sale.ord_date,
                            TotalValue = sale.qty * (title.price ?? 0)
                        }).ToList<dynamic>();
            }
        }
    }

}
