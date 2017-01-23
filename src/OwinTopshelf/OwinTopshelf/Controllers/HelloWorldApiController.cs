using System.Web.Http;

namespace OwinTopshelf.Controllers
{
    [Route("api/[controller]")]
    public class HelloWorldApiController : ApiController
    {
        [HttpGet]
        public string Get()
        {
            return "Hello World";
        }
    }
}