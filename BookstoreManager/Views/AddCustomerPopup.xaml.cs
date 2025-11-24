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
using System.Windows.Shapes;
using BookstoreManager.ViewModels;
namespace BookstoreManager.Views
{
    /// <summary>
    /// Interaction logic for AddCustomerPopup.xaml
    /// </summary>
    public partial class AddCustomerPopup : Window
    {
        private CustomerViewModel customerViewModel;
        public AddCustomerPopup()
        {
            InitializeComponent();
            customerViewModel = new CustomerViewModel();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            CustomerWindow customerWindow = new CustomerWindow();
            customerWindow.Show();
            this.Close();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            customerViewModel.First_name = FirstNameTextBox.Text;
            customerViewModel.Last_name = LastNameTextBox.Text;
            customerViewModel.Email = EmailTextBox.Text;
            customerViewModel.Phone_num = PhoneNumberTextBox.Text;
            int points;

            if (int.TryParse(PointsTextBox.Text, out points))
            {
                customerViewModel.Points = points;
            }
            else
            {
                MessageBox.Show("Please enter a valid price", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (customerViewModel.ValidateBook() == null)
            {
                customerViewModel.AddCustomerToSystem();
                MessageBox.Show(FirstNameTextBox.Text + " " + LastNameTextBox.Text + " has been successfully added");
            }
            else
            {
                MessageBox.Show(customerViewModel.ValidateBook());
            }
        }
    }
}
