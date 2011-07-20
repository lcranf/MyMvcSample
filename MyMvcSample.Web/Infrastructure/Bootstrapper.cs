using System.Data.Entity;
using System.Diagnostics;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Practices.ServiceLocation;
using MyMvcSample.Common.ModelBinders;
using MyMvcSample.Domain.Db;

namespace MyMvcSample.Infrastructure
{
    public class Bootstrapper
    {
        public static void Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            RegisterViewEngine();
            RegisterModelBinder();
            RegisterDatabaseInitializer();
        }

        private static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        private static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Orders", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
        }

        private static void RegisterViewEngine()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
        }

        [Conditional("DEBUG")]
        private static void RegisterDatabaseInitializer()
        {
            Database.SetInitializer(new MyMvcSampleContextInitializer());
        }

        private static void RegisterModelBinder()
        {
            ModelBinders.Binders.DefaultBinder = ServiceLocator.Current.GetInstance<SmartModelBinder>();
        }
    }
}