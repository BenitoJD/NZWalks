using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;
using NZWalksAPI.Repositories;

namespace NZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }


        // Create walk
        //POST: /api/walks
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            // Map DTO to Domain Model
           var walkDomainModel =  mapper.Map<Walk>(addWalkRequestDto);
           
           await walkRepository.CreateAsync(walkDomainModel);
           //Map Domain Model in Dto

           return Ok(mapper.Map<WalkDto>(walkDomainModel));


        }

        //GET the Walks
        // GET:/api/walks?filterOn=Name&filterQuery=Track
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy, [FromQuery] bool? IsAscending, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000)
        {
           var walksDomainModel =  await walkRepository.GetallAsync(filterOn,filterQuery,sortBy, IsAscending ?? true, pageNumber,pageSize);

            // Map Domain Model to Dto

            return Ok(mapper.Map<List<WalkDto>>(walksDomainModel));
        }

        //Get Walk by ID
        // GET : /api/walks/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            var walkDomainModel = await walkRepository.GetByIdAsync(id);
            if(walkDomainModel == null)
            {
                return NotFound(id);
            }
            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> update([FromRoute] Guid id, UpdateRegionRequestDto updateRegionRequestDto)
        {
            // Map DTO to Domain Model

            var walkDomainModel = mapper.Map<Walk>(updateRegionRequestDto);

            walkDomainModel = await walkRepository.UpdateAsync(id, walkDomainModel);

            if(walkDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<WalkDto>(walkDomainModel));



        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute]Guid id)
        {
            var deleatedWalkDomainModel =   await walkRepository.DeleteAsync(id);

            if(deleatedWalkDomainModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<WalkDto>(deleatedWalkDomainModel));
        }

    }
}
