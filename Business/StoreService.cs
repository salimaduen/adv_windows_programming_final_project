using Final_Project.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Final_Project.Business
{
    internal class StoreService
    {
        private readonly StoreDataService _dataService;

        public StoreService()
        {
            _dataService = new StoreDataService();
        }

        public List<store> SearchStores(string searchText)
        {
            return _dataService.GetStores(searchText);
        }

        public store GetStoreDetails(string storeId)
        {
            return _dataService.GetStoreById(storeId);
        }

        public void CreateStore(store newStore)
        {
            ValidateStore(newStore);
            _dataService.AddStore(newStore);
        }

        public void DeleteStore(string storeId)
        {
            _dataService.RemoveStore(storeId);
        }

        private void ValidateStore(store store)
        {
            if (string.IsNullOrEmpty(store.stor_id) || string.IsNullOrEmpty(store.stor_name))
            {
                throw new ArgumentException("Store ID and Name are required.");
            }

            if (store.state.Length != 2 || !Regex.IsMatch(store.state, "^[A-Za-z]+$"))
            {
                throw new ArgumentException("State must be a valid 2-letter abbreviation.");
            }

            if (store.zip.Length != 5 || !store.zip.All(char.IsDigit))
            {
                throw new ArgumentException("ZIP code must be a 5-digit number.");
            }
        }
    }

}
