using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.Data
{
    internal class TitleDataService
    {
        public List<title> GetTitles(string searchText = null)
        {
            using (var context = new BookStoreEntities())
            {
                var query = context.titles.AsQueryable();

                if (!string.IsNullOrEmpty(searchText))
                {
                    query = query.Where(t => t.title1.ToLower().Contains(searchText.ToLower()));
                }

                return query.ToList();
            }
        }

        public title GetTitleById(string titleId)
        {
            using (var context = new BookStoreEntities())
            {
                return context.titles.SingleOrDefault(t => t.title_id == titleId);
            }
        }

        public bool AddTitle(title newTitle)
        {
            using (var context = new BookStoreEntities())
            {
                if (context.titles.Any(t => t.title1 == newTitle.title1))
                    return false;

                context.titles.Add(newTitle);
                context.SaveChanges();
                return true;
            }
        }

        public void DeleteTitleById(string titleId)
        {
            using (var context = new BookStoreEntities())
            {
                var titleToDelete = context.titles.SingleOrDefault(t => t.title_id == titleId);
                if (titleToDelete != null)
                {
                    context.titles.Remove(titleToDelete);
                    context.SaveChanges();
                }
            }
        }
    }


}
