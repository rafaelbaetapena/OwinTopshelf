using Autofac;
using Autofac.Integration.WebApi;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Owin;
using OwinTopshelf.Models;
using System.Reflection;
using System.Web.Http;

namespace OwinTopshelf
{
    public class Startup
    {
        private const string RootPath = @".\wwwroot";

        public void Configuration(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            var config = new HttpConfiguration();

            // Configuration for Autofac
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.Register(c => new TodoRepository()).As<ITodoRepository>().SingleInstance();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(config);

            //
            app.UseWebApi(WebApiConfig.Register(config));

            // Configuration for static files
            var options = new FileServerOptions
            {
                EnableDirectoryBrowsing = true,
                FileSystem = new PhysicalFileSystem(RootPath)
            };
            app.UseFileServer(options);
        }
    }
}