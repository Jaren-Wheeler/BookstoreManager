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

namespace BookstoreManager.Views
{
    /// <summary>
    /// Interaction logic for EditBookPopup.xaml
    /// </summary>
    public partial class EditBookPopup : Window
    {
        public EditBookPopup()
        {
            InitializeComponent();
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

        }
    }
}
