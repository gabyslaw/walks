using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using walks.Data;
using walks.Models.Domain;
using walks.Models.Dto;
using walks.Repositories;

namespace walks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;

        //public RegionsController(IRegionRepository regionRepository) => _regionRepository = regionRepository;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            _regionRepository = regionRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRegionsAsync()
        {
            var regions = await _regionRepository.GetAllRegionAsync();

            if (regions == null) return NotFound();

            var regionsDto = _mapper.Map<List<RegionDto>>(regions);

            return Ok(regionsDto);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetRegionAsync(Guid id)
        {
            var region = await _regionRepository.GetRegionAsync(id);

            if (region == null) return NotFound();

            var regionDto = _mapper.Map<RegionDto>(region);

            return Ok(regionDto);
        }

        [HttpPost]
        [ActionName("GetRegionAsync")]
        public async Task<IActionResult> AddRegionsAsync(AddRegionRequestDto regionDto)
        {
            //Validate the request

            if (!ValidateAddRegionAsync(regionDto))
            {
                return BadRequest(ModelState);
            }

            var region = new Region()
            {
                Area = regionDto.Area,
                Code = regionDto.Code,
                Lat = regionDto.Lat,
                Long = regionDto.Long,
                Name = regionDto.Name,
                Population = regionDto.Population
            };

            region = await _regionRepository.AddAsync(region);

            var regionDtoData = new RegionDto()
            {
                Id = region.Id,
                Area = region.Area,
                Code = region.Code,
                Lat = region.Lat,
                Long = region.Long,
                Name = region.Name,
                Population = region.Population
            };

            return CreatedAtAction(nameof(GetRegionAsync), new { id = regionDtoData.Id }, regionDtoData);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRegionAsync(Guid id)
        {

            var regionToDelete = await _regionRepository.DeleteAsync(id);

            if (regionToDelete == null) return NotFound();

            var regionDto = _mapper.Map<RegionDto>(regionToDelete);

            return Ok(regionDto);

        }


        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateRegionAsync([FromRoute] Guid id, [FromBody] UpdateRegionDto regionDto)
        {
            var region = new Region()
            {
                Area = regionDto.Area,
                Code = regionDto.Code,
                Lat = regionDto.Lat,
                Long = regionDto.Long,
                Name = regionDto.Name,
                Population = regionDto.Population
            };

            region = await _regionRepository.UpdateAsync(id, region);

            if (region == null) return NotFound();

            var regionDtoData = new RegionDto()
            {
                Id = region.Id,
                Area = region.Area,
                Code = region.Code,
                Lat = region.Lat,
                Long = region.Long,
                Name = region.Name,
                Population = region.Population
            };

            return Ok(regionDtoData);
        }

        #region Private methods

        private bool ValidateAddRegionAsync(AddRegionRequestDto addRegionRequest)
        {
            if(addRegionRequest == null)
            {
                ModelState.AddModelError(nameof(addRegionRequest), $"cannot be null, empty or with whitespace");
                
                return false;
            }

            if (string.IsNullOrWhiteSpace(addRegionRequest.Code))
            {
                ModelState.AddModelError(nameof(addRegionRequest.Code), $"{nameof(addRegionRequest.Code)} cannot be null, empty or with whitespace");
            }

            if (addRegionRequest.Area <= 0)
            {
                ModelState.AddModelError(nameof(addRegionRequest.Area), $"{nameof(addRegionRequest.Area)} cannot be less than or equals to zero");

            }

            if(ModelState.ErrorCount > 0)
            {
                return false;
            }

            return true;
        }

        #endregion
    }
}
