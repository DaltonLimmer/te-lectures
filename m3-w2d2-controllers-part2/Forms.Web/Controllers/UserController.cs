using Forms.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forms.Web.Controllers
{
    public class UserController : Controller
    {
        /* STEPS
         1. (UserController)    Create the registration action for user/registration
         2. (Registration View) Create form w/button that submits POST request to user/registration
         3. (UserController)    Create the registration action POST for user/registration & redirect to Success
         4. (UserController)    Create success action for user/success
         5. (Success View)      Create empty view
         5. TEST
         6. (UserRegistrationModel) Create a UserRegistrationModel that holds properties user register with
         7. (Registration View) Bind the view to a UserRegistrationModel
         8. (Registration View) Add the HTML fields
         9. TEST
         10. (UserController)   Add the UserRegistrationModel as a parameter to the user/registration action
         11. DEBUG (show it works!)
         12. DAL                If a DAL were used, show where we would save the data to the db         
         13. PROCLAIM VICTORY

         If necessary, demonstrate the reason behind post-redirect-get by posting to an action that returns
         a view and not a redirect. Show that when the browser is refreshed, the request is submitted again.
        */

        // GET: User
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(UserRegistrationModel model)
        {
            // code that calls DAL
            return RedirectToAction("Success"); 
        }

        public ActionResult Success()
        {
            return View();
        }
    }
}