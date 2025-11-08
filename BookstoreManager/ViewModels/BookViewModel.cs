using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreManager.Models;

namespace BookstoreManager.ViewModels
{
    internal class BookViewModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }

        public Book book = new Book();

        // Call the method from the Book model to add a book to the database
        public void AddBookToSystem()
        {
            book.AddBook(Title, Author, Price);
        }

        public string ValidateBook()
        {
            string message;

            if (Author.Any(char.IsDigit))
            {
                message = "Author name must only contain letters";
                return message;
            }
           
            return null;
        }
    }
    
}
