using OwinTopshelf.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace OwinTopshelf.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : ApiController
    {
        public TodoController()
        {
            TodoItems = new TodoRepository();
        }

        private ITodoRepository TodoItems { get; set; }

        [HttpGet]
        public IEnumerable<TodoItem> Get()
        {
            return TodoItems.GetAll();
        }

        [Route("{id}", Name = "GetTodo")]
        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            var item = TodoItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public IHttpActionResult Create([FromBody] TodoItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            TodoItems.Add(item);
            return CreatedAtRoute("DefaultApi", new { id = item.Key }, item);
        }

        [HttpPut]
        public IHttpActionResult Update(string id, [FromBody] TodoItem item)
        {
            if (item == null || item.Key != id)
            {
                return BadRequest();
            }

            var todo = TodoItems.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            TodoItems.Update(item);
            return Ok();
        }
    }
}