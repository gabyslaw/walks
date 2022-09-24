using walks.Models.Domain;
using walks.Models.Dto;

namespace walks.Repositories
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAllRegion();
    }
}
