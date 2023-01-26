using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using AutoMapper;
using WebApplication1.MapperModels.RegionDto;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly WebApiDbContext dbContext;
        private readonly IMapper mapper;
        public RegionController(WebApiDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        //GET: api/<RegionControler>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegionGetOneDto>>> GetAllRegion()
        {
            var regions = await dbContext.Regions.ToListAsync();
            var regionsDtos  = mapper.Map<IEnumerable<RegionGetOneDto>>(regions);
            return Ok(regionsDtos);
        }

        //GET api/<RegionController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RegionGetOneDto>> GetRegionById(Guid regionId)
        {
            var region = await dbContext.Regions.FindAsync(regionId);
            
            if (region == null)
            {
                return NotFound();
            }
            var regionDto = mapper.Map<RegionGetOneDto>(region);
            return Ok(regionDto);
        }

        [HttpPost]
        public async Task<ActionResult<RegionPostDto>> Post([FromBody] RegionPostDto regionDto)
        {
            if (regionDto == null)
            {
                return NotFound();
            }
            var region = mapper.Map<Region>(regionDto);
            region.RegionId = Guid.NewGuid();
            

            dbContext.Regions.Add(region);
            await dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAllRegion), new { id = region.RegionId}, regionDto);
        }

        //PUT api/<RegionController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<RegionPutDto>> Put(Guid regionId, [FromBody] RegionPutDto regionDto)
        {
            if (regionId != regionDto.RegionId)
            {
                return BadRequest();
            }
            var region = await dbContext.Regions.FindAsync(regionId);
            if (region == null || region == null)
            {
                return NotFound("Region not fount");
            }
            mapper.Map(region, regionDto);

            dbContext.Regions.Update(region);
            await dbContext.SaveChangesAsync();
            return Ok(region);
        }

        //DELETE api/<RegionController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Region>> Delete(Guid regionId)
        {
            var region = await dbContext.Regions.FindAsync(regionId);
            if (region == null)
            {
                return NotFound();
            }
            dbContext.Regions.Remove(region);
            await dbContext.SaveChangesAsync();
            return Ok(region);
        }
    }
}