using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SessionCart.Models;

namespace SessionCart
{
    public static class ShoppingCart
    {
        #region Session Keys

        private const string CartStore = "scCartStore";
        private const string CartBillTo = "scCartBillTo";
        private const string CartShipTo = "scCartShipTo";
        private const string CartFreight = "scCartFreight";
        private const string CartTax = "scCartTax";
        private const string CartCreditCard = "scCartCreditCard";
        private const string CartUser = "scCartUser";
        private const string CartPo = "scCartPo";

        #endregion

        #region Freight

        private static Shipping _freight;

        public static Shipping Freight
        {
            get
            {
                return Get(CartFreight, ()=> Update(CartFreight, new Shipping {Amount = 0.0M, ShipVia = "Ground"}));
            }
            set
            {
                _freight = value;
                Update(CartFreight, _freight);
            }
        }

        
        
        #endregion

        #region User

        private static User _user;

        public static User User
        {
            get
            {
                return Get(CartUser, () => Update(CartUser, Update(CartUser, new User())));
            }
            set
            {
                _user = value;
                Update(CartUser, _user);
            }
        }

        #endregion

        #region Tax

        private static Tax _tax;

        public static Tax Tax
        {
            get { return Get(CartTax, () => Update(CartTax, new Tax {Amount = 0.0M})); }
            set
            {
                _tax = value;
                Update(CartTax, _tax);
            }
        }

        #endregion

        #region CreditCard

        private static CreditCard _card;

        public static CreditCard CreditCard
        {
            get { return Get(CartCreditCard, () => Update(CartCreditCard, new CreditCard())); }
            set
            {
                _card = value;
                Update(CartCreditCard, _card);
            }
        }

        #endregion

        #region Bill Ship Addresses

        private static Address _billAddress;

        public static Address BillTo
        {
            get { return Get(CartBillTo, () => Update(CartBillTo, new Address())); }
            set
            {
                _billAddress = value;
                Update(CartBillTo, _billAddress);
            }
        }

        private static Address _shipAddress;

        public static Address ShipTo
        {
            get { return Get(CartShipTo, ()=> Update(CartShipTo, new Address())); }
            set
            {
                _shipAddress = value;
                Update(CartShipTo, _shipAddress);
            }
        }

        #endregion

        #region CartItems

        public static List<Product> Items
        {
            get { return GetCart(); }
        }

        public static void Add(Product model, int count = 1)
        {
            if (CartExists())
            {
                if (GetCart().Any(i => i.ItemNumber == model.ItemNumber))
                {
                    UpdateCartItems(CartStore, model, GetCart().First(i => i.ModelGuid == model.ModelGuid).Count + count);
                }
                else
                {
                    UpdateCartItems(CartStore, model, count);
                }
            }
            else
            {
                UpdateCartItems(CartStore, model, count);
            }

        }

        public static void Remove(Product model)
        {
            UpdateCartItems(CartStore, model, 0);
        }

        public static void Update(Product model)
        {
            if (CartExists())
            {
                if (GetCart().Any(i => i.ModelGuid == model.ModelGuid))
                {
                    UpdateCartItems(CartStore, model, model.Count);
                }
            }
        }

        public static int ItemsCount
        {
            get { return GetCart().Sum(i => i.Count); }
        }

        public static decimal Total
        {
            get { return CalculateSubTotal(); }
        }

        public static decimal GrandTotal
        {
            get { return Total + Tax.Amount + Freight.Amount; }
        }

        public static decimal TotalWeight
        {
            get { return CalculateWeight(); }
        }

        private static decimal CalculateSubTotal()
        {
            decimal total = 0.0M;
            foreach (var model in GetCart())
            {
                total = total + (decimal) (model.Price*(model.Count > 0 ? model.Count : 1));
            }
            return total;
        }

        private static decimal CalculateWeight()
        {
            decimal total = 0.0M;
            foreach (var model in GetCart())
            {
                total = total + (model.Weight*((model.Count > 0) ? model.Count : 1));
            }
            return total;
        }

        public static bool Contains(Product model)
        {
            if (CartExists())
            {
                foreach (var item in GetCart())
                {
                    if (item.ModelGuid == model.ModelGuid)
                        return true;
                }
            }
            return false;
        }

        public static Product LastItem()
        {
            return GetCart().LastOrDefault();
        }

        private static bool CartExists()
        {
            return System.Web.HttpContext.Current.Session[CartStore] != null;
        }


        private static List<Product> GetCart()
        {
            if (CartExists())
                return HttpContext.Current.Session[CartStore] as List<Product>;
            return new List<Product>();
        }

        private static void UpdateCartItems(string sessionVariable, Product value, int count)
        {
            var updatedCart = new List<Product>();
            value.Count = count;
            if (HttpContext.Current.Session[sessionVariable] != null)
            {
                var modelsInCart = HttpContext.Current.Session[sessionVariable] as List<Product> ??
                                   new List<Product>();
                if (count > 0)
                {
                    updatedCart = modelsInCart;
                    if (updatedCart.Any(i => i.ModelGuid == value.ModelGuid))
                    {
                        updatedCart.First(i => i.ModelGuid == value.ModelGuid).Count = count;
                    }
                    else
                        updatedCart.Add(value);
                }
                else
                {
                    foreach (var model in modelsInCart)
                    {
                        if (model.ModelGuid != value.ModelGuid)
                            updatedCart.Add(model);
                    }
                }
                HttpContext.Current.Session[sessionVariable] = updatedCart;
            }
            else
            {
                updatedCart.Add(value);
                HttpContext.Current.Session.Add(sessionVariable, updatedCart);
            }
        }

        #endregion

        #region PONumber

        private static string _po;

        public static string PO
        {
            get { return Get(CartPo, ()=>Update(CartPo, string.Empty)); }
            set
            {
                _po = value;
                Update(CartPo,_po);
            }
        }

        #endregion

        #region Order

        public static Order CurrentOrder
        {
            get { return GetOrder(); }
        }

        private static Order GetOrder()
        {
            var order = new Order
            {
                ProductsOrdered = Items,
                ShipTo = ShipTo,
                BillTo = BillTo,
                ShippingMethod = Freight.ShipVia,
                TaxTotal = Tax.Amount,
                ShippingTotal = Freight.Amount,
                GrandTotal = GrandTotal,
                OrderTotal = GrandTotal,
                SubTotal = Total,
                PoNumber = PO,
                UseBillTo = ShipTo.Address1 == BillTo.Address1
            };
            return order;
        }

        #endregion

        #region Session Manager
        private static T Get<T>(string key, Func<T> callback) where T : class
        {
            if (Exists(key))
            {
                return HttpContext.Current.Session[key] as T;
            }
            return callback();
        }

        private static T Update<T>(string key, T value) where T : class
        {
            if (Exists(key))
            {
                HttpContext.Current.Session[key] = value;
            }
            else
            {
                HttpContext.Current.Session.Add(key, value);
            }
            return Get(key, () => Update(key, value));
        }

        private static bool Exists(string key)
        {
            return HttpContext.Current.Session[key] != null;
        }

        #endregion
    }
}
