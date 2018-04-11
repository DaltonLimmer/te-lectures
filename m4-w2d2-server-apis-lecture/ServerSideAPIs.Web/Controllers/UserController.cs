using ServerSideAPIs.Web.DAL;
using ServerSideAPIs.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServerSideAPIs.Web.Controllers
{
    public class UserController : Controller
    {
        private IUserDAL dal;
        public UserController(IUserDAL dal)
        {
            this.dal = dal;
        }


        [HttpGet]
        [Route("users")]
        [Route("api/users")]
        public ActionResult GetAllUsers() {

            var users = dal.GetAllUsers();

            return Json(users, JsonRequestBehavior.AllowGet);

        }


        [HttpGet]
        [Route("users/{id}")]
        [Route("api/users/{id}")]
        public ActionResult GetSingleUser(int id)
        {
            var user = dal.GetUser(id);
            return Json(user, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("users")]
        public ActionResult CreateUser(User user)
        {
            dal.AddUser(user);
            return Json(new { result = "Ok" });
        }


        /* PUT and DELETE are not allowed by default. Please use this link to
         * modify the .vs\config\applicationhost.config file to allow it.
         * http://bit.ly/2lY6zY0         
         */

        [HttpPut]
        [Route("users/{id}")]
        public ActionResult UpdateUser(int id, User updatedUser)
        {
            updatedUser.Id = id;
            dal.UpdateUser(updatedUser);
            return Json(new { result = "Ok" });
        }


        [HttpDelete]
        [Route("users/{id}")]
        public ActionResult DeleteUser(int id)
        {
            dal.DeleteUser(id);
            return Json(new { result = "Ok" });
        }




    }
}