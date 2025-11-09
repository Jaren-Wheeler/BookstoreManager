using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreManager.Models;

namespace BookstoreManager.ViewModels
{
    internal class UserViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

        private User userModel = new User(); // bring the User from the model into the ViewModel.

        public bool Login()
        {
            var user = userModel.LoginUser(Username, Password);
            if (user != null)
            {
                return true;
            }
            return false;
           
        }

        public void CreateAccount()
        {
            userModel.CreateUser(Username, Password);
        }
        
   
        // Provides validation for the username and password inputted by the users when creating an account.
        public string ValidateUsers()
        {
            string message;
            if (Username.Length < 3 || Username.Length > 20)
            {
                message = "Username must be between 3 and 20 characters";
                return message;
            } else if (Password.Length < 8 || Password.Length > 64)
            {
                message = "Password must be between 8 and 64 characters";
                return message;
            } else if (!Password.Any(char.IsLower)) {
                message = "Password must contain at least one uppercase letter";
                return message;
            } else if (!Password.Any(char.IsUpper))
            {
                message = "Password must contain at least one lowercase letter";
                return message;
            } else if (!Password.Any(ch => "!@#$%^&*()_+-=[]{}|;:',.<>/?".Contains(ch)))
            {
                message = "Password must contain a special character.";
                return message;
            } else if (Username == "" || Password == "")
            {
                message = "Username and Password are both required fields";
                return message;
            }
            return null;
        }
    }
}
