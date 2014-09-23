using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SessionCart.Models
{
    public class Tax
    {
        public double Rate { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public decimal Amount { get; set; }
    
    }
}
