using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Final_Project.Business
{
    internal class AuthorService
    {
        private readonly AuthorDataService _dataService;

        public AuthorService()
        {
            _dataService = new AuthorDataService();
        }

        public List<author> GetAuthors(string searchText = null)
        {
            return string.IsNullOrEmpty(searchText)
                ? _dataService.GetAllAuthors()
                : _dataService.SearchAuthors(searchText);
        }

        public author GetAuthorDetails(string authorId)
        {
            return _dataService.GetAuthorById(authorId);
        }

        public void CreateAuthor(author newAuthor)
        {
            ValidateAuthor(newAuthor);
            _dataService.AddAuthor(newAuthor);
        }

        public void DeleteAuthor(string authorId)
        {
            _dataService.RemoveAuthor(authorId);
        }

        private void ValidateAuthor(author author)
        {
            if (string.IsNullOrWhiteSpace(author.au_id))
            {
                throw new ArgumentException("Author ID cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(author.au_fname) || string.IsNullOrWhiteSpace(author.au_lname))
            {
                throw new ArgumentException("First and Last Name are required.");
            }

            if (!Regex.IsMatch(author.zip, "^[0-9]{5}$"))
            {
                throw new ArgumentException("ZIP code must be a 5-digit number.");
            }

            if (!Regex.IsMatch(author.state, "^[A-Za-z]{2}$"))
            {
                throw new ArgumentException("State must be a valid 2-letter abbreviation.");
            }
        }
    }

}
