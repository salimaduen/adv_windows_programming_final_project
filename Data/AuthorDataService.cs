using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.Business
{
    internal class AuthorDataService
    {
        public List<author> GetAllAuthors()
        {
            using (var context = new BookStoreEntities())
            {
                return context.authors.ToList();
            }
        }

        public List<author> SearchAuthors(string searchText)
        {
            using (var context = new BookStoreEntities())
            {
                return context.authors
                    .Where(a => a.au_fname.StartsWith(searchText) || a.au_lname.StartsWith(searchText))
                    .ToList();
            }
        }

        public author GetAuthorById(string authorId)
        {
            using (var context = new BookStoreEntities())
            {
                return context.authors.SingleOrDefault(a => a.au_id == authorId);
            }
        }

        public void AddAuthor(author newAuthor)
        {
            using (var context = new BookStoreEntities())
            {
                if (context.authors.Any(a => a.au_id == newAuthor.au_id))
                {
                    throw new Exception("Author with the same ID already exists.");
                }

                context.authors.Add(newAuthor);
                context.SaveChanges();
            }
        }

        public void RemoveAuthor(string authorId)
        {
            using (var context = new BookStoreEntities())
            {
                var authorToRemove = context.authors.SingleOrDefault(a => a.au_id == authorId);

                if (authorToRemove == null)
                {
                    throw new Exception("Author not found.");
                }

                var relatedRecords = context.titleauthors.Where(ta => ta.au_id == authorId).ToList();
                context.titleauthors.RemoveRange(relatedRecords);
                context.authors.Remove(authorToRemove);

                context.SaveChanges();
            }
        }
    }

}
