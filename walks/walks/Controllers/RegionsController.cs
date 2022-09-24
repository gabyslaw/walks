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
        public async Task<IActionResult> GetAllRegions()
        {
            var regions = await _regionRepository.GetAllRegion();

            if(regions == null) return NotFound();

            var regionsDto = _mapper.Map<List<RegionDto>>(regions);

            return Ok(regionsDto);
        }
    }
}
