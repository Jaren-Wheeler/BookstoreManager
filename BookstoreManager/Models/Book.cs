using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreManager.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        public decimal Price { get; set; }

        string dbPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BookstoreDB.sqlite");
        public void AddBook(string title, string author, decimal price)
        {
            using (var connection = new SQLiteConnection($"Data Source={dbPath}"))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Book (title, author, price) VALUES (@title, @author, @price)";
                command.Parameters.AddWithValue("@title", title);
                command.Parameters.AddWithValue("@author", author);
                command.Parameters.AddWithValue("@price", price);
                command.ExecuteNonQuery();
            }
        }
    }
}
