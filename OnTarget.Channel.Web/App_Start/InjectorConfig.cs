using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using OnTarget.Channel.Business;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Lifestyles;
using SimpleInjector.Integration.WebApi;


namespace OnTarget.Channel.Web.App_Start
{
    public class InjectorConfig
    {
        public static void RegisterInjector()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            Bootstrap.Start(container);
            // Register your types, for instance:

            // This is an extension method from the integration package.
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.EnableHttpRequestMessageTracking(GlobalConfiguration.Configuration);

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}