using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebApplication1.Data;
using WebApplication1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly WebApiDbContext dbContext;
        public PersonController(WebApiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
                
        // GET: api/<PersonController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetAllPersons()
        {
            
            var result = await dbContext.Persons
                .Include(x => x.LocalGroup)
                .ToListAsync();

            return result;
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")] 
        public async Task<ActionResult<Person>> GetPersonById(Guid PersonId)
        {
            var person = await dbContext.Persons.FindAsync(PersonId);
            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        // POST api/<PersonController>
        [HttpPost]
        public async Task<ActionResult<Person>> Post([FromBody] Person newperson)
        {
            if (newperson == null)
            {
                return NotFound();
            }
            else if(dbContext.Persons.Any(x => x.PhoneNumber == newperson.PhoneNumber || x.Email == newperson.Email) )
            {
                return BadRequest("This user is already registered");
            }
            else
            {
                newperson.PersonId = Guid.NewGuid();
            }

            dbContext.Persons.Add(newperson);
            await dbContext.SaveChangesAsync();
            return Ok(newperson);
        }

        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Person>> Put(Guid PersonId, [FromBody] Person updateperson)
        {
            var person = await dbContext.Persons.FindAsync(PersonId);
            if (updateperson == null || person == null )
            {
                return NotFound("User not found");
            }
            else
            {
                PropertyInfo[] fields1 = updateperson.GetType().GetProperties();

                foreach (var item in fields1)
                {
                    var val1 = item.GetValue(person);
                    var val2 = item.GetValue(updateperson);
                    if (val1 != val2 && val2 != null)
                    {
                        item.SetValue(person, val2);
                    }
                }
            }
            dbContext.Persons.Update(person);
            await dbContext.SaveChangesAsync();
            return Ok(person);
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Person>> Delete(Guid PersonId)
        {
            var person = await dbContext.Persons.FindAsync(PersonId);
            if (person == null)
            {
                return NotFound("User not found");
            }
            dbContext.Persons.Remove(person);
            await dbContext.SaveChangesAsync();
            return Ok(person);
        }
    }
}
