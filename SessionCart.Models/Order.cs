using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace SessionCart.Models
{
    
    public class Order
    {
        public string OrderId { get; set; }
        public string OrderNumber { get; set; }
        public Address ShipTo { get; set; }
        public Address BillTo { get; set; }
        public bool UseBillTo { get; set; }
        public User User { get; set; }
        public string ShippingMethod { get; set; }
        public CreditCard CreditCard { get; set; }
        public string PoNumber { get; set; }
        public List<Product> ProductsOrdered { get; set; }
        public string OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderTotal { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal SubTotal { get; set; }
        public decimal ShippingTotal { get; set; }
        public decimal TaxTotal { get; set; }

    }
}
