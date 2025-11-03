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
    /// Interaction logic for MainDashboard.xaml
    /// </summary>
    public partial class MainDashboard : Window
    {
        public MainDashboard()
        {
            InitializeComponent();
        }

        private void dashboardNavBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            InventoryWindow bookInventory = new InventoryWindow();
            bookInventory.Show();
            this.Close();
        }

        private void customerNavBtn_Click(object sender, RoutedEventArgs e)
        {
            CustomerWindow customerPage = new CustomerWindow();
            customerPage.Show();
            this.Close();
        }

        private void salesNavBtn_Click(object sender, RoutedEventArgs e)
        {
            SaleWindow salesWindow = new SaleWindow();
            salesWindow.Show();
            this.Close();
        }

        private void logoutBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow loginPage = new MainWindow();
            loginPage.Show();
            this.Close();
        }

      
    }
}
