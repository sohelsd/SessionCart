using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SessionCart.Models
{
    public class Shipping
    {
        public string Carrier { get; set; }
        public string TrackingNumber { get; set; }
        public DateTime ShippedDate { get; set; }
        public string TrackingUrl { get; set; }
        public decimal Amount { get; set; }
        public string ShipVia { get; set; }
    }
}
