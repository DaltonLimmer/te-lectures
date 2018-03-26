using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VendingWeb.Controllers
{
    public enum FlashMessageType
    {
        Success,
        Warning,
        Error
    }

    public class ControllerBase : Controller
    {

        protected void SetFlashMessage(string messageText, FlashMessageType type = FlashMessageType.Success)
        {
            TempData["FlashMessage.Text"] = messageText;
            TempData["FlashMessage.Type"] = type;
        }


    }
}