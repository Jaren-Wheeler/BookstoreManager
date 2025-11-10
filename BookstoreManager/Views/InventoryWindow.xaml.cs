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
using BookstoreManager.ViewModels;

namespace BookstoreManager.Views
{
    /// <summary>
    /// Interaction logic for InventoryWindow.xaml
    /// </summary>
    public partial class InventoryWindow : Window
    {
        private BookViewModel bookViewModel;
        private string currentFilter = "";

        public InventoryWindow()
        {
            InitializeComponent();
            bookViewModel = new BookViewModel();
            this.DataContext = bookViewModel;

            bookViewModel.DisplayBooks(null); // display all books
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainDashboard mainDashboard = new MainDashboard();
            mainDashboard.Show();
            this.Close();
        }

        private void btnAddBooks_Click(object sender, RoutedEventArgs e)
        {
            AddBookPopup addBookWindow = new AddBookPopup();
            addBookWindow.Show();
            this.Close();
        }

        private void filterByCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (bookViewModel == null) return;

            ComboBox comboBox = sender as ComboBox;
            if (comboBox == null || comboBox.SelectedItem == null) return;

            // grab the text of the combobox item to be used in DisplayBooks method
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            string selectedText = selectedItem.Content.ToString();

            currentFilter = selectedText;

            ApplyFilter();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

            ApplyFilter();
        }

        private void ApplyFilter()
        {
            // Make sure ViewModel is initialized
            if (bookViewModel == null) return;

            // Try to parse txtSearch.Text to int safely
            int id = 0;
            int.TryParse(txtSearch.Text, out id);

            // Pass the filter type and input to the ViewModel
            bookViewModel.DisplayBooks(currentFilter, id, txtSearch.Text, txtSearch.Text);
        }
    }
}
