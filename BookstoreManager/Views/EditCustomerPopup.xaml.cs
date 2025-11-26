using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BookstoreManager.Models;
using BookstoreManager.ViewModels;

namespace BookstoreManager.Views
{
    /// <summary>
    /// Interaction logic for EditCustomerPopup.xaml
    /// </summary>
    public partial class EditCustomerPopup : Window
    {
        public Customer _customer;
        private CustomerViewModel customerViewModel;
        public EditCustomerPopup(Customer customer)
        {
            InitializeComponent();
            _customer = customer;

            firstNameTextBox.Text = _customer.First_name;
            lastNameTextBox.Text = _customer.Last_name;
            emailTextBox.Text = _customer.Email;
            phoneTextBox.Text = _customer.Phone_num;
            pointsTextBox.Text = _customer.Points.ToString();
          

            customerViewModel = new CustomerViewModel();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
