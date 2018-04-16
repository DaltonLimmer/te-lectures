using m5_LoginSample.Controllers;
using m5_LoginSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace m5_LoginSample.Filters
{
    public class LoginSampleAuthorizeAttribute: AuthorizeAttribute
    {
        private string[] _permissions;

        public LoginSampleAuthorizeAttribute() {
            _permissions = new string[0];
        }

        public LoginSampleAuthorizeAttribute(params string[] permissions)
        {
            this._permissions = permissions;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            User currentUser = httpContext.Session[BaseController.CurrentUserKey] as User;

            if (currentUser != null)
            {
                if (_permissions.Length > 0)
                {
                    foreach(Permission p in currentUser.Permissions)
                    {
                        if (_permissions.Contains(p.Name)) return true;
                    }
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                                       new RouteValueDictionary
                                       {
                                           { "action", "Login" },
                                           { "controller", "Home" }
                                       });
        }


    }
}