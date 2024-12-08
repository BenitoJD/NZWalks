using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;

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

            var regionsDto = new List<RegionDto>();

            foreach (var regionDto in region) {
                regionsDto.Add(new RegionDto()
                {
                    Id = regionDto.Id,
                    Code = regionDto.Code,
                    Name = regionDto.Name,
                    RegionImageUrl  = regionDto.RegionImageUrl,

                });
            }

            return Ok(regionsDto);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetRegionById(Guid id)
        {
            var regionDomain = dbContext.Regions.FirstOrDefault(x=>x.Id == id);

            if (regionDomain == null)
            {
                return NotFound();
            }
            
              var regionDto = new RegionDto()
                {
                    Id = regionDomain.Id,
                    Code = regionDomain.Code,
                    Name = regionDomain.Name,
                    RegionImageUrl = regionDomain.RegionImageUrl,

                };
            
            return Ok(regionDto);
        }

        [HttpPost]
        public IActionResult Create([FromBody]AddRegionDto addRegionDto)
        {
            var regionDomainModel = new Region
            {
                Code = addRegionDto.Code,
                Name = addRegionDto.Name,
                RegionImageUrl = addRegionDto.RegionImageUrl
            };

            dbContext.Regions.Add(regionDomainModel);
            dbContext.SaveChanges();
            var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl,
            };
            return CreatedAtAction(nameof(GetRegionById), new { id = regionDto.Id }, regionDto);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
           var regoinDomainModel =  dbContext.Regions.FirstOrDefault(x => x.Id == id);
            if(regoinDomainModel == null)
            {
                return NotFound();
            }

            
             regoinDomainModel.Code = updateRegionRequestDto.Code;
             regoinDomainModel.Name = updateRegionRequestDto.Name;
             regoinDomainModel.RegionImageUrl = updateRegionRequestDto.RegionImageUrl;

            dbContext.SaveChanges();

            var regionDto = new RegionDto
            {
                Id = regoinDomainModel.Id,
                Code = regoinDomainModel.Code,
                Name = regoinDomainModel.Name,
                RegionImageUrl = regoinDomainModel?.RegionImageUrl,
            };

            return Ok(regionDto);


        }
    }
}
