using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Sports.WebUI.Infrastructure;
using System.Web.Optimization;
using Sports.Domain.Concrete;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using WebMatrix.WebData;

namespace Sports.WebUI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            
           Database.SetInitializer<EFDbContext>(null);
           try
           {
             using (var context = new EFDbContext())
             {
               if (!context.Database.Exists())
               {
                 // Create the SimpleMembership database without Entity Framework migration schema
                 ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
               }
             }
             WebSecurity.InitializeDatabaseConnection("EFDbContext", "UserProfile", "UserId", "Email", autoCreateTables: true);
           }
           catch (Exception ex)
           {
             throw new InvalidOperationException("The ASP.NET Simple Membership database could not be initialized.", ex);
           }


            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
        }
    }
}