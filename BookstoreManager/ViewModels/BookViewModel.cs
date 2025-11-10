using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Packaging;
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

        public ObservableCollection<Book> Books { get; set; } = new ObservableCollection<Book>(); // stores the list of books fetched from the database

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


        // Fetches all books from the database. Adds them to the ObservableCollection Books.
        public void DisplayBooks(string filter, int? id = null, string title = null, string author = null)
        {
            Books.Clear();
            List<Book> bookList;

            if (filter == "Filter by ID")
            {
                bookList = book.FilterBooks(id);
            } 
            else if (filter == "Filter by Title") {
                bookList = book.FilterBooks(null, title);
            }
            else if (filter == "Filter by Author")
            {
                bookList = book.FilterBooks(null, null, author);
            }
            else
            {
                bookList = book.FetchBooks();
            }
            
            foreach (var book in bookList)
            {
                Books.Add(book);
            }
        }
    }
    
}
