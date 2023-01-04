using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalGroupController : ControllerBase
    {
        // GET: api/<LocalGroupController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LocalGroupController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LocalGroupController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LocalGroupController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LocalGroupController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
