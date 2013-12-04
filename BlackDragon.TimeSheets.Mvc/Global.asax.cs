using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using StructureMap;
using StructureMap.Configuration.DSL;
using BlackDragon.TimeSheets.Dal;
using BlackDragon.TimeSheets.Shared;
using BlackDragon.TimeSheets.Applications;
using BlackDragon.TimeSheets.Mvc.Models;
using StructureMap.Pipeline;

namespace BlackDragon.TimeSheets.Mvc
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
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
        }
    }

    class ControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (requestContext == null || controllerType == null)
                return null;

            return (IController)ObjectFactory.GetInstance(controllerType);
        }

        public override void ReleaseController(IController controller)
        {
            HttpContextLifecycle.DisposeAndClearAll();

            base.ReleaseController(controller);
        }
    }
}