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
        /* Steps
            1. (StoreController)    Create Index Action for store/index
            2. (Index View)         Create Index View for store/index
            TEST
            3. (Global.asax)        Configure DI container to inject IProductDAL > FakeProductDAL
            4. (StoreController)    Enable constructor injection for IProductDAL
            5. (StoreController)    Update Index Action to pass products
            6. (Index View)         Display Products
            TEST
            7. (Index View)         Add Form Tag w/ AddToCart button > POST to store/index
                                    Pass Product Id in Form
            8. (StoreController)    Create POST Index Action for store/index, accept product id & 
                                    redirect to store/viewcart            
            9. (StoreController)    Create ViewCart action for store/viewcart
            10.(ViewCart View)      Display empty View Cart View
            TEST
            11.(StoreController)    POST store/index: retrieve product and add to active
                                    shopping cart
            12.(ShoppingCart)       Create Shopping Cart class to add Product & Quantity
            13.(StoreController)    Guarantee ShoppingCart is in session, create if not
            14.(StoreController)    POST store/index: Update shopping cart with new product
            15.(StoreController)    GET store/viewcart: Retrieve shoping cart from session
            16.(ViewCart View)      Bind go ShoppingCart and disply each product in it
        */




    }
}