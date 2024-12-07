using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.Data
{
    internal class StoreDataService
    {
        public List<store> GetStores(string searchText = null)
        {
            using (var context = new BookStoreEntities())
            {
                if (string.IsNullOrEmpty(searchText))
                {
                    return context.stores.ToList();
                }

                return context.stores
                    .Where(s => s.stor_name.ToLower().Contains(searchText) || s.city.ToLower().Contains(searchText))
                    .ToList();
            }
        }

        public store GetStoreById(string storeId)
        {
            using (var context = new BookStoreEntities())
            {
                return context.stores.SingleOrDefault(s => s.stor_id == storeId);
            }
        }

        public void AddStore(store newStore)
        {
            using (var context = new BookStoreEntities())
            {
                if (context.stores.Any(s => s.stor_id == newStore.stor_id))
                {
                    throw new InvalidOperationException("Store ID already exists.");
                }

                context.stores.Add(newStore);
                context.SaveChanges();
            }
        }

        public void RemoveStore(string storeId)
        {
            using (var context = new BookStoreEntities())
            {
                var storeToRemove = context.stores.SingleOrDefault(s => s.stor_id == storeId);
                if (storeToRemove == null)
                {
                    throw new InvalidOperationException("Store not found.");
                }

                var relatedSales = context.sales.Where(s => s.stor_id == storeId).ToList();
                context.sales.RemoveRange(relatedSales);
                context.stores.Remove(storeToRemove);
                context.SaveChanges();
            }
        }
    }

}
