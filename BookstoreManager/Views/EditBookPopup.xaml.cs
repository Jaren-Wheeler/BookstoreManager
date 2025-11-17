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
using BookstoreManager.Models;
using BookstoreManager.ViewModels;
namespace BookstoreManager.Views
{
    /// <summary>
    /// Interaction logic for EditBookPopup.xaml
    /// </summary>
    public partial class EditBookPopup : Window
    {
        public Book _book;
        private BookViewModel bookViewModel;
        public EditBookPopup(Book book)
        {
            InitializeComponent();
            _book = book;

            titleTextBlock.Text = book.Title;
            authorTextBlock.Text = book.Author;
            priceTextBlock.Text = book.Price.ToString();

            bookViewModel = new BookViewModel();
        }

        // event handler to go back to inventory page
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            InventoryWindow inventoryWindow = new InventoryWindow();
            inventoryWindow.Show();
            this.Close();
        }

        // event handler to delete the book from the system
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        // event handler to submit changes to the book
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string title = titleTextBlock.Text;
            string author = authorTextBlock.Text;

            if (!decimal.TryParse(priceTextBlock.Text, out decimal price))
            {
                MessageBox.Show("Please enter a valid price");
                return;
            }

            // validate using the SAME ViewModel as Add Book
           /*string validation = bookViewModel.ValidateBook();

            if (validation != null)
            {
                MessageBox.Show(validation, "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }*/

            // Update model if validation passed
            _book.Title = title;
            _book.Author = author;
            _book.Price = price;

            _book.UpdateBook(_book.BookID, title, author, price); // update the book in the datbaase

            MessageBox.Show("Book updated successfully!");

            // return to inventory window
            InventoryWindow inventoryWindow = new InventoryWindow();
            inventoryWindow.Show();
            this.Close();
        }

    }
}
