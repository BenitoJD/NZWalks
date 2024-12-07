using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;

        public RegionsController(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAll()
        {

            var region = dbContext.Regions.ToList();

            return Ok(region);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetRegionById(Guid id)
        {
            var regions = dbContext.Regions.Find(id);
            if (regions == null)
            {
                return NotFound();
            }
            return Ok(regions);
        }

    }
}
