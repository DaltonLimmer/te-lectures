using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VendingWeb.Models;

namespace VendingWeb.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Register(UserModel model)
        {
            if(!ModelState.IsValid)
            {
                return View("Index", model);
            }


            //Persist the user to the DB

            return View();
        }



    }
}