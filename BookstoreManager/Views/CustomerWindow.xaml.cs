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
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        private CustomerViewModel customerViewModel;
        private string currentFilter = "";
        public CustomerWindow()
        {
            InitializeComponent();
            customerViewModel = new CustomerViewModel();
            this.DataContext = customerViewModel;

            customerViewModel.DisplayCustomer(null); // display all customers
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainDashboard mainDashboard = new MainDashboard();
            mainDashboard.Show();
            this.Close();
        }

        private void btnClearFilters_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddCustomers_Click(object sender, RoutedEventArgs e)
        {
            AddCustomerPopup addCustomerPopup = new AddCustomerPopup();
            addCustomerPopup.Show();
            this.Close();
        }

        private void filterByCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CustomerName_Click(object sender, RoutedEventArgs e)
        {
            TextBlock tb = sender as TextBlock;
            Customer customer = tb.DataContext as Customer;

            if (customer == null) return;

            EditCustomerPopup editCustomerWindow = new EditCustomerPopup(customer);
            editCustomerWindow.Show();
            this.Close();
        }
    }
}
