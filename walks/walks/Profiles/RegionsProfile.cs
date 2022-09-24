using AutoMapper;
using walks.Models.Domain;
using walks.Models.Dto;

namespace walks.Profiles
{
    public class RegionsProfile : Profile
    {
        public RegionsProfile()
        {
            CreateMap<Region, RegionDto>()
                .ReverseMap();
        }
    }
}
