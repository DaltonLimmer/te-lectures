using Ninject;
using Ninject.Web.Common.WebHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using VendingService.File;
using VendingService.Interfaces;
using VendingService.Mock;

namespace VendingWebServices
{
    public class WebApiApplication : NinjectHttpApplication

    {
        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            // Bind Database
            kernel.Bind<IVendingService>().To<MockVendingDBService>();

            // Bind Log Service
            kernel.Bind<ILogService>().To<LogFileService>();

            return kernel;

        }

        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }



    }
}
