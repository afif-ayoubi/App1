using Microsoft.AspNetCore.Mvc;
using App1.Data;
using App1.Models.DTO;
using App1.Models.Domain;
using Microsoft.EntityFrameworkCore;
using App1.Repositories;
using AutoMapper;
    using App1.CustomActionFilters;
using Microsoft.AspNetCore.Authorization;
namespace App1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class RegionsController : ControllerBase
    {
        private readonly App1DbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;
        public RegionsController(App1DbContext dbContext, IRegionRepository regionRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            // Get Data From Database - Domain models
            var regionsDomain = await regionRepository.GetAll();

            // Map Domain Models to DTOs
            // Return the DTOs
            return Ok(mapper.Map<List<RegionDto>>(regionsDomain));

        }


        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            // var region = dbContext.Regions.Find(id);
            var regionDomain = await regionRepository.GetById(id);

            if (regionDomain == null)
            {
                return NotFound();
            }


            return Ok(mapper.Map<RegionDto>(regionDomain));
        }

        [HttpPost]
        [ValidateModelAtrribute]

        public async Task<IActionResult> AddRegion([FromBody] AddRegionRequestDto addRegionRequestDto)
        {

            //Map DTO to Domain Model
            var regionDomain = mapper.Map<Region>(addRegionRequestDto);

            //Use Domain Model to create Region
            regionDomain = await regionRepository.create(regionDomain);

            //Map Domain Model to DTO
            var regionDto = mapper.Map<RegionDto>(regionDomain);
            return CreatedAtAction(nameof(GetById), new { id = regionDomain.Id }, regionDomain);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModelAtrribute]
        public async Task<IActionResult> UpdateRegion([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {

            //Map DTO to Domain Model
            var regionDomain = mapper.Map<Region>(updateRegionRequestDto);

            //Use Domain Model to update Region
            regionDomain = await regionRepository.update(id, regionDomain);
            if (regionDomain == null)
            {
                return NotFound();
            }

            //Map Domain Model to DTO
            var regionDto = mapper.Map<RegionDto>(regionDomain);
            return Ok(regionDto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteRegion([FromRoute] Guid id)
        {
            var regionDomain = await regionRepository.delete(id);
            if (regionDomain == null)
            {
                return NotFound();
            }

            //Map Domain Model to DTO
            var regionDto = mapper.Map<RegionDto>(regionDomain);

            return Ok(regionDto);
        }
    }
}