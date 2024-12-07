using Final_Project.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project.Business
{
    internal class OrderService
    {
        private readonly OrderDataService _dataService;

        public OrderService()
        {
            _dataService = new OrderDataService();
        }

        public void ProcessOrder(string storeId, string payTerms, DataTable cartTable, DateTime orderDate, string ordNum)
        {
            if (string.IsNullOrEmpty(storeId))
            {
                throw new ArgumentException("You must select a store before proceeding with purchase.");
            }

            var items = GetItemsFromCart(cartTable);

            if (items.Count == 0)
            {
                throw new ArgumentException("You must add at least one item before proceeding with purchase.");
            }

            _dataService.AddSales(storeId, ordNum, orderDate, payTerms, items);
        }

        public List<(string TitleId, string Title, int Quantity, decimal Price)> GetOrderedItems(
            DataTable cartTable)
        {
            var items = GetItemsFromCart(cartTable);
            return _dataService.GetOrderedItems(items);
        }

        public string GenerateUniqueOrderNumber()
        {
            return _dataService.GenerateUniqueOrderNumber();
        }

        private Dictionary<string, (int Quantity, decimal? Price)> GetItemsFromCart(DataTable cartTable)
        {
            var items = new Dictionary<string, (int Quantity, decimal? Price)>();

            foreach (DataRow row in cartTable.Rows)
            {
                string titleId = row["Id"].ToString();
                decimal? price = row["Price"] as decimal?;

                if (!items.ContainsKey(titleId))
                {
                    items[titleId] = (1, price);
                }
                else
                {
                    var current = items[titleId];
                    items[titleId] = (current.Quantity + 1, current.Price);
                }
            }

            return items;
        }

        public List<title> SearchTitles(string searchText)
        {
            return _dataService.SearchTitles(searchText);
        }

        public List<string> GetStoreIds()
        {
            return _dataService.GetStoreIds();
        }
    }

}
