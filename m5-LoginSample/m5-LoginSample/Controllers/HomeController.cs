using m5_LoginSample.DAL;
using m5_LoginSample.Filters;
using m5_LoginSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace m5_LoginSample.Controllers
{
    public class HomeController : BaseController
    {
        private ILoginDAL _loginDal;
        public HomeController(ILoginDAL loginDal)
        {
            this._loginDal = loginDal;
        }


        [LoginSampleAuthorize]
        public ActionResult Index()
        {
            return View();

        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DoLogin(User user)
        {
            var isValidUser = _loginDal.ValidateLogin(user.Username, user.Password);

            if(isValidUser)
            {
                var currentUser = _loginDal.GetUser(user.Username);
                Session[CurrentUserKey] = currentUser;
                return RedirectToAction("UserInfo");
            }

            TempData[ErrorMessageKey] = "Invalid login credentials.";
            return RedirectToAction("Login");

        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return View("Login");
        }

        [LoginSampleAuthorize]
        public ActionResult UserInfo()
        {
            var currentUser = Session[CurrentUserKey] as User;
            return View(currentUser);
        }

        [LoginSampleAuthorize("SuperSecret")]
        public ActionResult SuperSecret()
        {
            return View();
        }

    }
}