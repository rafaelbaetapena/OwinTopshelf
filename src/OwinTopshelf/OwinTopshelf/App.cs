using Microsoft.Owin.Hosting;
using Serilog;
using System;
using System.Configuration;

namespace OwinTopshelf
{
    public class App
    {
        private IDisposable _webApplication;

        public App()
        {
            Log.Logger =
                new LoggerConfiguration()
                    .ReadFrom.AppSettings()
                    .CreateLogger();
        }

        public void Start()
        {
            int port;
            if (!int.TryParse(ConfigurationManager.AppSettings["port"], out port))
            {
                Log.Error("Service port not configured");
                return;
            }

            var uri = $"http://localhost:{port}";
            Log.Information($"Starting the service in {uri}");
            _webApplication = WebApp.Start<Startup>(uri);
        }

        public void Stop()
        {
            _webApplication.Dispose();
        }
    }
}