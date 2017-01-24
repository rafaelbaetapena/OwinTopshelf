using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Owin;

namespace OwinTopshelf
{
    public class Startup
    {
        private const string RootPath = @".\wwwroot";

        public void Configuration(IAppBuilder app)
        {
            app.UseWebApi(WebApiConfig.Register());

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