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
    /// Interaction logic for CreateAccountView.xaml
    /// </summary>
    public partial class CreateAccount : Window
    {
        private UserViewModel userViewModel;
        public CreateAccount()
        {
            InitializeComponent();
            userViewModel = new UserViewModel();
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {

            // connect the model definitons with the user inputs
            userViewModel.Username = txtCreateUsername.Text;
            userViewModel.Password = pwdCreatePassword.Password;

            string confirmPassword = pwdConfirmPassword.Password; // define confirm password input value (not in model)

            string validationMessage = userViewModel.ValidateUsers();

            // if the validation message is not null, then print the appropriate message

            if (pwdCreatePassword.Password != confirmPassword)
            {
                lblMessages.Text = "Passwords must match";
            } else
            {
                if (validationMessage != null)
                {

                    lblMessages.Text = validationMessage;
                }
                else
                {
                    MessageBox.Show("Account Created Successfully", "Success", MessageBoxButton.OK); // popup success message
                    userViewModel.CreateAccount(); // insert information into the User table.
                }
            }
            
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow loginPage = new MainWindow();
            loginPage.Show();
            this.Close();
        }
    }
}
