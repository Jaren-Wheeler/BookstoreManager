using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreManager.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        string dbPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BookstoreDB.sqlite");

        // Queries the database to insert a user into the database when an account is created
        public void CreateUser(string username, string password)
        {
            using (var connection = new SQLiteConnection($"Data Source={dbPath}"))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO User (username, password) VALUES (@username, @password)";

                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password); // hash the plain text password

                // insert the values into the database. Store the password as a hashed password.
                command.Parameters.AddWithValue("@username", username); 
                command.Parameters.AddWithValue("@password", hashedPassword);
                command.ExecuteNonQuery();
            }
        }

        // Queries the database to pull info from User table when a person is logging in. Returns the user if a match exists, otherwise null.
        public User LoginUser(string username, string password)
        {
            using (var connection = new SQLiteConnection($"Data Source={dbPath}"))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "Select * FROM User WHERE username = @username";
                command.Parameters.AddWithValue("@username", username);
            
                
                using (var reader = command.ExecuteReader()) {
                    if (reader.Read())
                    {

                        // stored hashed password
                        string storedHash = reader["password"].ToString();

                        // use Bcrypt library to check if the password matches the stored hashed password
                        bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, storedHash);

                        if (isPasswordValid)
                        {
                            return new User
                            {
                                UserID = Convert.ToInt32(reader["UserID"]),
                                Username = reader["username"].ToString(),
                                Password = storedHash
                            };
                        }
                       
                    }
                }
            }
            return null;
        }
    }
    
};
