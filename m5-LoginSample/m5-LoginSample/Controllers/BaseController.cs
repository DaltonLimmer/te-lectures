using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace m5_LoginSample.Controllers
{
    public class BaseController: Controller
    {
        public const string CurrentUserKey = "CURRENT_USER";
        public const string ErrorMessageKey = "ERROR_MESSAGE";
    }
}