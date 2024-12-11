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
        // GET:/api/walks
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           var walksDomainModel =  await walkRepository.GetallAsync();

            // Map Domain Model to Dto

            return Ok(mapper.Map<List<WalkDto>>(walksDomainModel));
        }


    }
}
