using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreManager.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }


        // Queries the database to insert a user into the database when an account is created
        public void CreateUser(string username, string password)
        {
            using (var connection = new SQLiteConnection("Data Source=Bookstore.db"))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO User (Username, Password) VALUES (@username, @password)";
                command.Parameters.AddWithValue("username", username); 
                command.Parameters.AddWithValue("password", password);
                command.ExecuteNonQuery();
            }
        }

        // Queries the database to pull info from User table when a person is logging in. Returns the user if a match exists, otherwise null.
        public User LoginUser(string username, string password)
        {
            using (var connection = new SQLiteConnection("Data Source=Bookstore.db"))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "Select * FROM User WHERE Username = @username AND Password = @password";
                command.Parameters.AddWithValue("username", username);
                command.Parameters.AddWithValue("password", password);
                
                using (var reader = command.ExecuteReader()) {
                    if (reader.Read())
                    {
                        return new User
                        {
                            UserID = Convert.ToInt32(reader["UserID"]),
                            Username = reader["Username"].ToString(),
                            Password = reader["Username"].ToString()
                        };
                    }
                }
            }
            return null;
        }
    }
    
};
