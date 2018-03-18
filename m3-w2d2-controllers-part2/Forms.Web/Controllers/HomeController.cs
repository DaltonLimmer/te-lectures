using Forms.Web.DAL;
using Forms.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forms.Web.Controllers
{
    public class HomeController : Controller
    {
        /* STEPS
         1. (HomeController)    Create the index action for home/index
         2. (Index View)        Create form w/button that submits the data to home/formresult
         3. (HomeController)    Create the FormResult action for home/formresult
         4. (FormResult View)   Create empty view
         5. TEST
         6. (FormModel)         Create a FormModel that holds properties user will search by
         7. (Index View)        Bind the view to a FormModel
         8. (Index View)        Add the HTML fields to search by
         9. TEST
         10. (HomeController)   Add the FormModel as a parameter to the home/formresult action
         11. DEBUG (show it works!)
         12. (HomeController)   Pass incoming parameter in to the FormResult view
         13. (HomeController)   In practice we'd call to the database from our FormResult action and 
                                query it for records that match our parameters.
         13. (FormResult View)  Pass the model into our FormResult view and show that the parameters went from 
                                one page to the next.
         14. PROCLAIM VICTORY
        */


        // GET: Home
        public ActionResult Index()
        {
            return View("Index");
        }

        

        public ActionResult FormResult(FormModel request)
        {
            return View("FormResult", request);
        }
    }
}