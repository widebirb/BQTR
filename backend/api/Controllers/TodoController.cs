using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        // Static in-memory list — shared across all requests for the lifetime of the app
        private static readonly List<string> _todos = new()
        {
            "Buy groceries",
            "Walk the dog",
            "Finish homework"
        };

        // GET api/todo
        [HttpGet]
        public ActionResult<List<string>> GetAll()
        {
            return Ok(_todos);
        }

        // GET api/todo/0
        [HttpGet("{id}")]
        public ActionResult<string> GetById(int id)
        {
            if (id < 0 || id >= _todos.Count)
                return NotFound($"No todo at index {id}");

            return Ok(_todos[id]);
        }

        // POST api/todo
        [HttpPost]
        public ActionResult Add([FromBody] string todo)
        {
            _todos.Add(todo);
            return Ok(_todos); // ✅ returns the updated list
        }

        // DELETE api/todo/0
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id < 0 || id >= _todos.Count)
                return NotFound($"No todo at index {id}");

            _todos.RemoveAt(id);
            return Ok(_todos);
        }

        // PUT api/todo/0
        public ActionResult Update(int id, [FromBody] string todo)
        {
            if (id < 0 || id >= _todos.Count)
                return NotFound($"No todo at index {id}");

            _todos[id] = todo;
            return Ok(_todos);
        }
    }
}