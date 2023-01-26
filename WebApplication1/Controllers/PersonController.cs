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
        private readonly WebApiDbContext _dbContext;
        public PersonController(WebApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
                
        // GET: api/<PersonController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetAllPersons()
        {
            
            var result = await _dbContext.Persons
                .Include(x => x.LocalGroup)
                .ToListAsync();

            return result;
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")] 
        public async Task<ActionResult<Person>> GetPersonById(Guid personId)
        {
            var person = await _dbContext.Persons.FindAsync(personId);
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
            else if(_dbContext.Persons.Any(x => x.PhoneNumber == newperson.PhoneNumber || x.Email == newperson.Email) )
            {
                return BadRequest("This user is already registered");
            }
            
            newperson.PersonId = Guid.NewGuid();          
            _dbContext.Persons.Add(newperson);
            await _dbContext.SaveChangesAsync();
            return Ok(newperson);
        }

        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Person>> Put(Guid personId, [FromBody] Person updateperson)
        {
            if (personId != updateperson.PersonId)
            {
                return BadRequest();
            }
            
            var person = await _dbContext.Persons.FindAsync(personId);
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
            _dbContext.Persons.Update(person);
            await _dbContext.SaveChangesAsync();
            return Ok(person);
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Person>> Delete(Guid personId)
        {
            var person = await _dbContext.Persons.FindAsync(personId);
            if (person == null)
            {
                return NotFound("User not found");
            }
            _dbContext.Persons.Remove(person);
            await _dbContext.SaveChangesAsync();
            return Ok(person);
        }
    }
}
