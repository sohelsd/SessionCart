SessionCart
===========

A super simple asp.net shopping cart using sessions.

The single class SessionCart.ShoppingCart.cs powers all of necessary shopping cart functionality. It exposes wrapper objects to Order, Product, Tax, and Shipping. During the checkout experience, we manage data in user session. A brief run-down of the APIs and their purpose:

-	ShoppingCart.Add()
o	Pass a Product to add it to existing shopping cart.
o	Pass quantity optionally.
o	If product already exists, it will only increase the count.
-	ShoppingCart.Remove()
o	Completely removes product from cart.
-	ShoppingCart.Update()
o	Updates product quantity in cart.
-	ShoppingCart.Contains()
o	Returns true if the specified Product exists in cart.
-	ShoppingCart.Items
o	Returns a list of Products in cart.
-	ShoppingCart.LastItem
o	Returns last product added to cart.
-	ShoppingCart.ItemCount
o	Returns total no. of products.
-	ShoppingCart.Total
o	Returns sub-total of all products in cart.
-	ShoppingCart.GrandTotal
o	Returns sub-total + Tax + Shipping Cost
-	ShoppingCart.TotalWeight
o	Returns total weight specified in all Products in cart
-	ShoppingCart.Freight
o	Get/Set SessionCart.Models.Shipping object
-	ShoppingCart.Tax
o	Get/Set SessionCart.Models.Tax object
-	ShoppingCart.ShipTo
o	Get/Set SessionCart.Models.Address object
-	ShoppingCart.BillTo
o	Get/Set SessionCart.Models.Address object
-	ShoppingCart.User
o	Get/Set SessionCart.Models.User object
-	ShoppingCart.CreditCard
o	Get/Set SessionCart.Models.CreditCard object
-	ShoppingCart.PONumber
o	Get/Set string value of Purchase Order
-	ShoppingCart.CurrentOrder
o	Returns an SessionCar.Models.Order object with all the above values from session.
