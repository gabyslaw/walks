using walks.Models.Domain;
using walks.Models.Dto;

namespace walks.Repositories
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAllRegionAsync();
        Task<Region> GetRegionAsync(Guid Id);
        Task<Region> AddAsync(Region region);
        Task<Region> DeleteAsync(Guid Id);
        Task<Region> UpdateAsync(Guid Id, Region region);

    }
}
