using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.DAL;
using Web.Models;

namespace Web.Controllers
{
    public class StoreController : Controller
    {

        /* Step 4 - Set up constructor to accept injected IProductDAL */
        private IProductDAL _dal;
        public StoreController(IProductDAL dal)
        {
            _dal = dal;
        }

        /* Steps
            *1. (StoreController)    Create Index Action for store/index
            *2. (Index View)         Create Index View for store/index
            *TEST
            *3A. (IProductDAL)       Create Interface and Implement
            *3B. (Global.asax)       Configure DI container to inject IProductDAL > MockProductDAL
            *4. (StoreController)    Enable constructor injection for IProductDAL
            *5. (StoreController)    Update Index Action to pass products
            *6. (Index View)         Display Products
            *TEST
            *7. (Index View)         Add Form Tag w/ AddToCart button > POST to store/index
                                    Pass Product Id in Form
            *8. (StoreController)    Create POST Index Action for store/index, accept product id & 
                                     redirect to store/viewcart            
            *9. (StoreController)    Create ViewCart action for store/viewcart
            *10.(ViewCart View)      Display empty View Cart View
            *TEST
            *11.(ShoppingCart)       Create Shopping Cart class to add Product & Quantity
            *12.(StoreController)    Guarantee ShoppingCart is in session, create if not
            *13.(StoreController)    POST store/index: Update shopping cart with new product
            *14.(StoreController)    GET store/viewcart: Retrieve shoping cart from session
            *15.(ViewCart View)      Bind go ShoppingCart and disply each product in it
        */

        /* Step 1 */
        public ActionResult Index()
        {
            /* Step 5 - Retrieve and Pass Products to View */
            IList<Product> products = _dal.GetProducts();
            return View(products);
        }

        /* Step 8 */
        [HttpPost]
        public ActionResult Index(int productId)
        {
            /* Step 13 - Retrieve product and add to shopping cart */
            Product productToAdd = _dal.GetProduct(productId);

            ShoppingCart cart = GetActiveShoppingCart();
            cart.AddToCart(productToAdd);

            return RedirectToAction("ViewCart");
        }

        /* Step 9 */
        public ActionResult ViewCart()
        {
            /* Step 14 */
            ShoppingCart cart = GetActiveShoppingCart();
            return View(cart);
        }


        [HttpPost]
        public ActionResult ViewCart(int productId)
        {

            Product product = _dal.GetProduct(productId);

            ShoppingCart cart = GetActiveShoppingCart();

            cart.RemoveOneFromCart(product);

            return RedirectToAction("ViewCart");

        }



        /* Step 12 */
        private ShoppingCart GetActiveShoppingCart()
        {
            ShoppingCart cart = null;

            //See if the user has a shopping cart already
            if(Session["ShoppingCart"] == null)
            {

                //If not, create one and save it.
                cart = new ShoppingCart();
                Session["ShoppingCart"] = cart; //  <-- Saves the shopping cart into the session
            }
            else
            {
                cart = Session["ShoppingCart"] as ShoppingCart;     //  <-- Gets the shopping cart out of the session
            }

            return cart;
        }










    }
}