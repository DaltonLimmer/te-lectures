using System;
using System.Web.Mvc;
using Forms.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Forms.Web.Tests
{
    [TestClass]
    public class HomeControllerTests
    {
        // Unit tests for MVC check 
        // to see if a Controller Action returns the correct
        // type of Action Result.
        [TestMethod]
        public void Index_ReturnsIndexView()
        {
            var controller = new HomeController();

            var result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);
        }
    }
}
