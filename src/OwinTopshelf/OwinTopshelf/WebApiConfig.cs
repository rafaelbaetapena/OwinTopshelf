using System.Web.Http;

namespace OwinTopshelf
{
    public class WebApiConfig
    {
        public static HttpConfiguration Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute("DefaultApi",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional });

            return config;
        }
    }
}