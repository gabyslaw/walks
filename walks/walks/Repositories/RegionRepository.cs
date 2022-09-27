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

        public async Task<Region> AddAsync(Region region)
        {
            region.Id = Guid.NewGuid();

            await _context.AddAsync(region);

            await _context.SaveChangesAsync();

            return region;
        }

        public async Task<Region> DeleteAsync(Guid Id)
        {
            var region = await _context.Regions.FirstOrDefaultAsync(x => x.Id == Id);

            if(region == null)
            {
                return null;
            }
            //Delete Region

            _context.Regions.Remove(region);
            await _context.SaveChangesAsync();
            return region;
        }

        /*        public RegionRepository(WalksDbContext context, IMapper mapper)
       {
           _context = context;
           _mapper = mapper;
       }*/
        public async Task<IEnumerable<Region>> GetAllRegionAsync()
        {
             var regions = await _context.Regions.ToListAsync();
            return regions;
        }

        public async Task<Region> GetRegionAsync(Guid Id)
        {
            var region = await _context.Regions.FirstOrDefaultAsync(x => x.Id == Id);

            return region;
        }

        public async Task<Region> UpdateAsync(Guid Id, Region region)
        {
            var regionData = await _context.Regions.FirstOrDefaultAsync(x => x.Id == Id);

            if (regionData == null) return null;

            regionData.Area = region.Area;
            regionData.Code = region.Code;
            regionData.Name = region.Name;
            regionData.Lat = region.Lat;
            regionData.Long = region.Long;
            regionData.Population = region.Population;


            //_context.Regions.Update(region);

            await _context.SaveChangesAsync();

            return regionData;


        }
    }
}
