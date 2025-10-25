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
using BookstoreManager.Views;

namespace BookstoreManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            CreateDB createDB = new CreateDB(); // create the database tables
        }

        private void btnCreateAccountAction(object sender, RoutedEventArgs e)
        {
            CreateAccount createAccountWindow = new CreateAccount();
            createAccountWindow.Show();
            this.Close();
        }
    }
}
