using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewsPart2.Web.Models;

namespace ViewsPart2.Web.Controllers
{
    /*
    * Each Controller Action below responds to a request from a browser.
    * If the user visits http://localhost/Home/Index then the
    * Index Action will execute, returning the Index view.
    */
    public class HomeController : Controller
    {

        // GET: Home/Index
        // GET: Home/
        // GET: /
        public ActionResult Index()
        {
            return View();
        }


        // GET: Home/Colors
        public ActionResult Colors()
        {
            return View();
        }

        // GET: Home/Team
        public ActionResult Team()
        {
            return View();
        }
    }
}