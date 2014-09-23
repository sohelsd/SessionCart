using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SessionCart.Models
{
    public class User
    {
        public string CustomerNumber { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public Address Address { get; set; }
    }
}
