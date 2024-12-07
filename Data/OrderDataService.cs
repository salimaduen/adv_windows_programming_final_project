using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project.Data
{
    internal class OrderDataService
    {
        public void AddSales(string storeId, string ordNum, DateTime orderDate, string payTerms, Dictionary<string, (int Quantity, decimal? Price)> items)
        {
            using (var context = new BookStoreEntities())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (var item in items)
                        {
                            string titleId = item.Key;
                            short quantity = (short)item.Value.Quantity;

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
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public List<(string TitleId, string Title, int Quantity, decimal Price)> GetOrderedItems(
            Dictionary<string, (int Quantity, decimal? Price)> items)
        {
            using (var context = new BookStoreEntities())
            {
                return items.Select(item =>
                {
                    string titleId = item.Key;
                    string title = context.titles.FirstOrDefault(t => t.title_id == titleId)?.title1;
                    decimal price = item.Value.Price ?? 0;

                    return (TitleId: titleId, Title: title, Quantity: item.Value.Quantity, Price: price);
                }).ToList();
            }
        }

        public string GenerateUniqueOrderNumber()
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

        public List<title> SearchTitles(string searchText)
        {
            using (var context = new BookStoreEntities())
            {
                return context.titles
                    .Where(t => t.title1.ToLower().Contains(searchText.ToLower()))
                    .ToList();
            }
        }

        public List<string> GetStoreIds()
        {
            using (var context = new BookStoreEntities())
            {
                return context.stores.Select(s => s.stor_id).ToList();
            }
        }
    }
}
