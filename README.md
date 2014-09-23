SessionCart
===========
A super simple asp.net shopping cart using sessions.

Either use the compilled DLLs or include the projects into your solution.

The class SessionCart.ShoppingCart.cs powers all of necessary shopping cart functionality. It exposes wrapper objects to Order, Product, Tax, and Shipping. During the checkout experience, we manage data in user session. A brief run-down of the APIs and their purpose:

- ShoppingCart.Add()
 * Pass a Product to add it to existing shopping cart.
 * Pass quantity optionally.
 * If product already exists, it will only increase the count.
- ShoppingCart.Remove()
 * Completely removes product from cart.
- ShoppingCart.Update()
 * Updates product quantity in cart.
- ShoppingCart.Contains()
 * Returns true if the specified Product exists in cart.
- ShoppingCart.Items
 *	Returns a list of Products in cart.
-	ShoppingCart.LastItem
 *	Returns last product added to cart.
-	ShoppingCart.ItemCount
 *	Returns total no. of products.
-	ShoppingCart.Total
 *	Returns sub-total of all products in cart.
-	ShoppingCart.GrandTotal
 *	Returns sub-total + Tax + Shipping Cost
-	ShoppingCart.TotalWeight
 *	Returns total weight specified in all Products in cart
-	ShoppingCart.Freight
 *	Get/Set SessionCart.Models.Shipping object
-	ShoppingCart.Tax
 *	Get/Set SessionCart.Models.Tax object
-	ShoppingCart.ShipTo
 *	Get/Set SessionCart.Models.Address object
-	ShoppingCart.BillTo
 *	Get/Set SessionCart.Models.Address object
-	ShoppingCart.User
 *	Get/Set SessionCart.Models.User object
-	ShoppingCart.CreditCard
 *	Get/Set SessionCart.Models.CreditCard object
-	ShoppingCart.PONumber
 *	Get/Set string value of Purchase Order
-	ShoppingCart.CurrentOrder
 *	Returns an SessionCar.Models.Order object with all the above values from session.