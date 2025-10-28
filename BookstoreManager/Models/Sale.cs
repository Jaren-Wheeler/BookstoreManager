using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Numerics;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreManager.Models
{
    public class Sale
    {
        public int SaleID { get; set; }
        public string Sale_details { get; set; }
        public int Points_accrued { get; set; }
        public int CustomerID { get; set; }
        public int BookID { get; set; }
    }
}
