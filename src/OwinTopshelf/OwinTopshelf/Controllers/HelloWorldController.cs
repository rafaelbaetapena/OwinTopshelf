using System.Web.Http;

namespace OwinTopshelf.Controllers
{
    [RoutePrefix("api/helloworld")]    
    public class HelloWorldController : ApiController
    {
        [HttpGet]
        public string Get()
        {
            return "Hello World v1";
        }
    }
}