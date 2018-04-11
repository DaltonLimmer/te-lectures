using GetExercises.Web.DAL;
using GetExercises.Web.DAL.Interfaces;
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

namespace WebApiReview
{
    public class WebApiApplication : NinjectHttpApplication
    {
        protected override void OnApplicationStarted()
        {

            base.OnApplicationStarted();

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=DVDStore;Integrated Security=True";

            kernel.Bind<IFilmDAL>().To<FilmDAL>().WithConstructorArgument("connectionString", connectionString);
            kernel.Bind<IActorDAL>().To<ActorDAL>().WithConstructorArgument("connectionString", connectionString);
            kernel.Bind<ICustomerDAL>().To<CustomerDAL>().WithConstructorArgument("connectionString", connectionString);

            return kernel;
        }
    }
}
