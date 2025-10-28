using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreManager.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Email { get; set; }
        public string Phone_num { get; set; }
        public int Points { get; set; }
        public int UserID { get; set; }

    }
}
