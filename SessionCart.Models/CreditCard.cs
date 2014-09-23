using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SessionCart.Models
{
    public class CreditCard
    {
        public string Name { get; set; }
        public string CardId { get; set; }
        public string PaymentTerms { get; set; }
        public string CardType { get; set; }
        public string CardNumber { get; set; }
        public string SecurityCode { get; set; }
        public string ExpirationMonth { get; set; }
        public string ExpirationYear { get; set; }
        public bool Authorized { get; set; }
        public CreditCardType Type { get; set; }
        public Address Address { get; set; }
        public string LastFourDigits { get { return string.IsNullOrEmpty(CardNumber)?string.Empty:CardNumber.Substring(CardNumber.Length - 4, 4); } }
        public enum CreditCardType
        {
            MasterCard,
            Visa,
            Discover,
            AmericanExpress
        }
       
    }
}
