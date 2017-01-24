using Microsoft.Practices.Unity;
using OwinTopshelf.DependencyResolver;
using OwinTopshelf.Models;
using System.Web.Http;

namespace OwinTopshelf
{
    public class WebApiConfig
    {
        public static HttpConfiguration Register()
        {
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute("DefaultApi",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional });

            var container = new UnityContainer();
            container.RegisterType<ITodoRepository, TodoRepository>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

            return config;
        }
    }
}