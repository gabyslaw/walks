using AutoMapper;
using Microsoft.EntityFrameworkCore;
using walks.Data;
using walks.Models.Domain;
using walks.Models.Dto;

namespace walks.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly WalksDbContext _context;
        //private readonly IMapper _mapper;

        public RegionRepository(WalksDbContext context) => _context = context;
/*        public RegionRepository(WalksDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }*/
        public async Task<IEnumerable<Region>> GetAllRegion()
        {
             var regions = await _context.Regions.ToListAsync();
            return regions;
        }
    }
}
