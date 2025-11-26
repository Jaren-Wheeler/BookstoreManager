using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Diagnostics;

namespace BookstoreManager.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Email { get; set; }
        public string Phone_num { get; set; }
        public int Points { get; set; }
        public int UserID { get; set; }

        string dbPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BookstoreDB.sqlite");

        // Inserts a book into the Book database table
        public void AddCustomer(string first_name, string last_name, string email, string phone_num, int points)
        {
            using (var connection = new SQLiteConnection($"Data Source={dbPath}"))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Customer (first_name, last_name, email, phone_num, points) VALUES (@first_name, @last_name, @email, @phone_num, @points)";
                command.Parameters.AddWithValue("@first_name", first_name);
                command.Parameters.AddWithValue("@last_name", last_name);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@phone_num", phone_num);
                command.Parameters.AddWithValue("@points", points);
                command.ExecuteNonQuery();
            }
        }

        // Fetches all the customers from the database
        public List<Customer> FetchCustomers()
        {
            var customers = new List<Customer>();

            using (var connection = new SQLiteConnection($"Data Source={dbPath}"))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT CustomerID, first_name, last_name, email, phone_num, points from Customer";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var customer = new Customer
                        {
                            CustomerID = Convert.ToInt32(reader["CustomerID"]),
                            First_name = reader["first_name"].ToString(),
                            Last_name = reader["last_name"].ToString(),
                            Email = reader["email"].ToString(),
                            Phone_num = reader["phone_num"].ToString(),
                            Points = Convert.ToInt32(reader["points"])
                        };
                        customers.Add(customer);
                    }
                }
            }

            return customers;
        }

        // filter customers by the given parameter depending on what the user chooses
        public List<Customer> FilterCustomers(int? id = null, string name = null, string email = null, string phone_num = null)
        {
            var customers = new List<Customer>();
            using (var connection = new SQLiteConnection($"Data Source={dbPath}"))
            {
                connection.Open();
                var command = connection.CreateCommand();
                var query = "SELECT CustomerId, first_name, last_name, email, phone_num, points from Customer WHERE 1=1"; // return all rows and can add filters onto it

                // Add to ther query depending on what the method signature is
                if (id != null)
                {
                    query += " AND CustomerId = @id"; // add to original query to filter by ID
                    command.Parameters.AddWithValue("@id", id.Value);
                }
                if (!string.IsNullOrEmpty(name))
                {
                    query += " AND (first_name || ' ' || last_name) LIKE @name"; // filters to names with similar words
                    command.Parameters.AddWithValue("@name", $"%{name}%");
                }
                if (!string.IsNullOrEmpty(email))
                {
                    query += " AND email LIKE @email"; // filters to authors with similar words
                    command.Parameters.AddWithValue("@email", $"%{email}%");
                }
                if (!string.IsNullOrEmpty(phone_num))
                {
                    query += " AND phone_num LIKE @phone_num"; // filters to authors with similar words
                    command.Parameters.AddWithValue("@phone_num", $"%{phone_num}%");
                }
                command.CommandText = query;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var customer = new Customer
                        {
                            CustomerID = Convert.ToInt32(reader["CustomerId"]),
                            First_name = reader["first_name"].ToString(),
                            Last_name = reader["last_name"].ToString(),
                            Email = reader["email"].ToString(),
                            Phone_num = reader["phone_num"].ToString(),
                            Points = Convert.ToInt32(Points)
                        };
                        customers.Add(customer);
                    }
                }
            }
            return customers;
        }

        // update an existing record in the book table
        public void UpdateCustomer(int id, String first_name, String last_name, String email, String phone_num, int points)
        {
            using (var connection = new SQLiteConnection($"Data Source={dbPath}"))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "UPDATE Customer SET first_name = @first_name, last_name = @last_name, email = @email, phone_num = @phone_num, @points = points WHERE CustomerId = @id";

                command.Parameters.AddWithValue("@first_name", first_name);
                command.Parameters.AddWithValue("@last_name", last_name);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@phone_num", phone_num);
                command.Parameters.AddWithValue("@points", points);
                command.ExecuteNonQuery();
            }
        }

        // delete a record in the book table
        public void DeleteCustomer(decimal id)
        {
            using (var connection = new SQLiteConnection($"Data Source={dbPath}"))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "DELETE FROM Customer WHERE CustomerID=@id";

                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }
    }
}
