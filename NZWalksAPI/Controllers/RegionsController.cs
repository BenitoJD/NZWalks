using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalksAPI.CustomActionFilters;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;
using NZWalksAPI.Repositories;
using System.Globalization;
using System.Text.Json;

namespace NZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;
        private readonly ILogger<RegionsController> logger;

        public RegionsController(NZWalksDbContext dbContext,
            IRegionRepository regionRepository,IMapper mapper,ILogger<RegionsController> logger)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
            this.logger = logger;
        }
        [HttpGet]
       // [Authorize(Roles ="READER,WRITER")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var region = await regionRepository.GetAllAsync();

                logger.LogInformation($"Fininshed GetAllRegions Request with data: {JsonSerializer.Serialize(region)}");


                var regionsDto = mapper.Map<List<RegionDto>>(region);

                return Ok(regionsDto);
            }
            catch (Exception ex)
            {
                logger.LogError(ex,ex.Message);
                throw;
            }
           
        }

        [HttpGet]
        [Route("{id:guid}")]
      //  [Authorize(Roles = "READER")]

        public async Task<IActionResult> GetRegionById(Guid id)
        {
            var regionDomain = await regionRepository.GetByIdAsync(id);

            if (regionDomain == null)
            {
                return NotFound();
            }            
            var regionDto = mapper.Map<RegionDto> (regionDomain);           
            return Ok(regionDto);
        }

        [HttpPost]
        [ValidateModel]
       // [Authorize(Roles = "WRITER")]

        public async Task<IActionResult> Create([FromBody]AddRegionDto addRegionDto)
        {           
                var regionDomainModel = mapper.Map<Region>(addRegionDto);
                regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);
                var regionDto = mapper.Map<RegionDto>(regionDomainModel);
                return CreatedAtAction(nameof(GetRegionById), new { id = regionDto.Id }, regionDto);  
        }

        [HttpPut]
        [Route("{id:guid}")]
      //  [Authorize(Roles = "WRITER")]
        public async Task<IActionResult> update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            var regoinDomainModel = mapper.Map<Region>(updateRegionRequestDto);

            regoinDomainModel =  await regionRepository.UpdateAsync(id, regoinDomainModel);

            if(regoinDomainModel == null)
            {
                return NotFound();
            }
          

            var regionDto = mapper.Map<RegionDto>(regoinDomainModel);
            return Ok(regionDto);


        }

        [HttpDelete]
        [Route("{id:guid}")]
      //  [Authorize(Roles = "WRITER")]
        public async Task<IActionResult> Delete([FromRoute]Guid id)
        {

            var regionExist = await regionRepository.DeleteAsync(id);
            if (regionExist == null)
            {
                return NotFound();
            }

            var regionDto = mapper.Map<RegionDto>(regionExist);
            return Ok(regionDto);
        }
    }
}
