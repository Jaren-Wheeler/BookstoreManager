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
    /// Interaction logic for AddBookPopup.xaml
    /// </summary>
    public partial class AddBookPopup : Window
    {
        private BookViewModel bookViewModel;
        public AddBookPopup()
        {
            InitializeComponent();
            bookViewModel = new BookViewModel();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            InventoryWindow inventoryWindow = new InventoryWindow();
            inventoryWindow.Show();
            this.Close();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            bookViewModel.Title = TitleTextBox.Text;
            bookViewModel.Author = AuthorTextBox.Text;
            decimal price;

            if (decimal.TryParse(PriceTextBox.Text, out price))
            {
                bookViewModel.Price = price;
            } else
            {
                MessageBox.Show("Please enter a valid price", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (bookViewModel.ValidateBook() == null)
            {
                bookViewModel.AddBookToSystem();
                MessageBox.Show(TitleTextBox.Text + " has been successfully added");
            } else
            {
                MessageBox.Show(bookViewModel.ValidateBook());
            }
        }
    }
}
