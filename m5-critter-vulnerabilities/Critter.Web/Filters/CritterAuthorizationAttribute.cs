using Critter.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Critter.Web.Filters
{
    public class CritterAuthorizationAttribute : AuthorizeAttribute
    {
        private readonly string[] allowedRoles;

        public CritterAuthorizationAttribute()
        {

        }

        public CritterAuthorizationAttribute(params string[] roles)
        {
            this.allowedRoles = roles;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //gets the username from the url
            var username = httpContext.Request.RequestContext.RouteData.Values["username"] as string;
            if (username == null) username = httpContext.Request["username"] as string;

            if (username != null)
            {

                var loggedInUser = httpContext.Session[CritterController.UsernameKey] as string;

                if (loggedInUser == null)
                {
                    return false;
                }
                else
                {
                    return loggedInUser == username;
                }

            }

            return true;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new HttpStatusCodeResult(403);
        }



    }
}