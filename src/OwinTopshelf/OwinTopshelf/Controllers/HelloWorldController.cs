using System.Web.Http;

namespace OwinTopshelf.Controllers
{
    [Route("api/[controller]")]    
    public class HelloWorldController : ApiController
    {
        [HttpGet]
        public string Get()
        {
            return "Hello World v1";
        }
    }
}