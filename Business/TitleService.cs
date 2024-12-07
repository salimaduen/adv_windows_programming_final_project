using Final_Project.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.Business
{
    internal class TitleService
    {
        private readonly TitleDataService _dataService;

        public TitleService()
        {
            _dataService = new TitleDataService();
        }

        public List<title> SearchTitles(string searchText)
        {
            return _dataService.GetTitles(searchText);
        }

        public title GetTitleDetails(string titleId)
        {
            return _dataService.GetTitleById(titleId);
        }

        public bool CreateTitle(title newTitle)
        {
            return _dataService.AddTitle(newTitle);
        }

        public void RemoveTitle(string titleId)
        {
            _dataService.DeleteTitleById(titleId);
        }
    }


}
