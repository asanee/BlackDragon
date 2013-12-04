using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using StructureMap;
using BlackDragon.TimeSheets.Dal;
using BlackDragon.TimeSheets.Applications;
using BlackDragon.TimeSheets.Shared;
using StructureMap.Configuration.DSL;
using BlackDragon.TimeSheets.Mvc.Models;

namespace BlackDragon.TimeSheets.Mvc
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            Action<IInitializationExpression> action = x => 
                {
                    var registry = new Registry();

                    registry.For<Applications.IContext>()
                        .HybridHttpOrThreadLocalScoped()
                        .Use<TimeSheetContext>();

                    x.AddRegistry(registry);

                    x.For<IMembershipService>().Use<MembershipService>();
                    x.For<IProfileService>().Use<ProfileService>();
                    x.For<IFormsAuthenticationService>()
                        .Use<FormsAuthenticationService>();
                };

            ObjectFactory.Initialize(action);

            ControllerBuilder.Current.SetControllerFactory(new ControllerFactory());

            RegisterRoutes(RouteTable.Routes);
        }
    }

    class ControllerFactory: DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (requestContext == null || controllerType == null)
                return null;

            return (IController)ObjectFactory.GetInstance(controllerType);
        }
    }
}