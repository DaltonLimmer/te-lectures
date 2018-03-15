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
            Person person = new Person
            {
                FirstName = "Han",
                LastName = "Solo",
                Hometown = "???",
                Interests = new List<string>()
                {
                    "Flying",
                    "Wookies"
                }
            };

            return View(person);
        }


        // GET: Home/Colors
        public ActionResult Colors()
        {
            List<string> colors = new List<string>();
            colors.Add("green");
            colors.Add("red");
            colors.Add("blue");
            colors.Add("darkgray");

            return View(colors);
        }

        // GET: Home/Team
        public ActionResult Team()
        {
            List<Person> team = new List<Person>();
            team.Add(new Person { FirstName = "Luke", LastName = "Skywalker", Hometown = "Tatooine" });
            team.Add(new Person { FirstName = "Anakin", LastName = "Skywalker", Hometown = "Tatooine" });
            team.Add(new Person { FirstName = "Rey", LastName = "?", Hometown = "Jakku" });

            return View(team);
        }
    }
}