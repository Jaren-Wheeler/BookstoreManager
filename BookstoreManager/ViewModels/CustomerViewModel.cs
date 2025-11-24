using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreManager.Models;

namespace BookstoreManager.ViewModels
{
    internal class CustomerViewModel
    {
        public int Id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Email { get; set; }
        public string Phone_num { get; set; }
        public int Points { get; set; }

        public Customer customer = new Customer();

        public ObservableCollection<Customer> Customers { get; set; } = new ObservableCollection<Customer>(); // stores the list of customers fetched from the database

        // Call the method from the Customer model to add a customer to the database
        public void AddCustomerToSystem()
        {
            customer.AddCustomer(First_name, Last_name, Email, Phone_num, 0);
        }

        public string ValidateBook()
        {
            string message;

            if (First_name.Any(char.IsDigit) || Last_name.Any(char.IsDigit))
            {
                message = "Customer name must only contain letters";
                return message;
            }

            return null;
        }


        // Fetches all books from the database. Adds them to the ObservableCollection Books.
        public void DisplayCustomer(string filter, int? id = null, string name = null, string email = null, string phone_num = null)
        {
            Customers.Clear();
            List<Customer> customerList;

            if (filter == "Filter by ID")
            {
                customerList = customer.FilterCustomers(id);
            }
            else if (filter == "Filter by name")
            {
                customerList = customer.FilterCustomers(null, name);
            }
            else if (filter == "Filter by email")
            {
                customerList = customer.FilterCustomers(null, null, email);
            }
            else if (filter == "Filter by phone number")
            {
                customerList = customer.FilterCustomers(null, null, null, phone_num);
            }
            else      
            {
                customerList = customer.FetchCustomers();
            }

            foreach (var book in customerList)
            {
                Customers.Add(book);
            }
        }

        // Method to update an existing customer in the database
        public void EditCustomerInSystem()
        {
            customer.UpdateCustomer(Id, First_name, Last_name, Email, Phone_num, Points);
        }

        // Method to delete a customer from the database
        public void DeleteCustomerInSystem(int id)
        {
            customer.DeleteCustomer(id);
        }

    }
}
