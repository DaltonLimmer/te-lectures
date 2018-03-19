using Forms.Web.DAL;
using Ninject;
using Ninject.Web.Common.WebHost;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Forms.Web
{
    public class MvcApplication : NinjectHttpApplication
    {
        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
       
        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            /* Step 4A */
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            /* Step 4B */
            kernel.Bind<IFilmDAL>().To<FilmDAL>().WithConstructorArgument("connectionString", connectionString);



            return kernel;
        }
    }
}
