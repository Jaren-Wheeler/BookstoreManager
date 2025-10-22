using System.Data.SQLite;
using System;
using System.IO;

namespace BookstoreManager.Models
{
    // Utility class to create the SQLite database and its schema
    internal class CreateDB
    {
        // Changed to use the new file name you specified: BookstoreDB.sqlite
        private const string DatabaseFile = "BookstoreDB.sqlite";

        // Using static readonly is best practice for C# versions before 10.0
        private static readonly string ConnectionString = $"Data Source={DatabaseFile};Version=3;";

        public CreateDB()
        {
            try
            {
                // Create the database file if it doesn't exist
                if (!File.Exists(DatabaseFile))
                {
                    SQLiteConnection.CreateFile(DatabaseFile);
                    Console.WriteLine($"Database file '{DatabaseFile}' created successfully.");
                }

                // Define all SQL commands in an array for sequential execution
                string[] createTableSql = new[]
                {
                    // Book Table
                    @"
                    CREATE TABLE IF NOT EXISTS Book (
                        BookID INTEGER PRIMARY KEY AUTOINCREMENT,
                        title TEXT NOT NULL,
                        author TEXT NOT NULL,
                        price REAL NOT NULL
                    );",

                    // User Table
                    @"
                    CREATE TABLE IF NOT EXISTS User (
                        UserID INTEGER PRIMARY KEY AUTOINCREMENT,
                        username TEXT NOT NULL UNIQUE,
                        -- In a real application, this should be a large TEXT field for a secure hash
                        password TEXT NOT NULL
                    );",
                    
                    // Customer Table
                    @"
                    CREATE TABLE IF NOT EXISTS Customer (
                        CustomerID INTEGER PRIMARY KEY AUTOINCREMENT,
                        first_name TEXT NOT NULL,
                        last_name TEXT NOT NULL,
                        email TEXT UNIQUE,
                        phone_num TEXT,
                        points REAL DEFAULT 0
                    );",
                    
                    // Sale Table (Note: Using REAL for float and TEXT for varchar/string)
                    @"
                    CREATE TABLE IF NOT EXISTS Sale (
                        SaleID INTEGER PRIMARY KEY AUTOINCREMENT,
                        sale_details TEXT, 
                        pointsAccrued INTEGER DEFAULT 0,
                        CustomerID INTEGER NOT NULL, 
                        
                        -- This foreign key assumes a simplified one-book-per-sale model
                        BookID INTEGER NOT NULL, 

                        FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID),
                        FOREIGN KEY (BookID) REFERENCES Book(BookID)
                    );"
                };

                // Open the connection and execute the commands 
                using (var dbConnection = new SQLiteConnection(ConnectionString))
                {
                    dbConnection.Open();
                    Console.WriteLine("Database connection opened.");

                    foreach (string sql in createTableSql)
                    {
                        using (var command = new SQLiteCommand(sql, dbConnection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                    Console.WriteLine("All tables created or confirmed to exist.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred during database creation:");
                Console.WriteLine(ex.Message);
            }
        }
    }
}