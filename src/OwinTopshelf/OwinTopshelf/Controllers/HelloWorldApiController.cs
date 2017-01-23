using System.Web.Http;

namespace OwinTopshelf.Controllers
{
    public class HelloWorldApiController : ApiController
    {
        [HttpGet]
        public string Get()
        {
            return "Hello World";
        }
    }
}