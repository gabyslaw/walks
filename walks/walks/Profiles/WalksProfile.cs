using AutoMapper;
using walks.Models.Domain;

namespace walks.Profiles
{
    public class WalksProfile : Profile
    {
        public WalksProfile()
        {
            CreateMap<Walk, Walk>()
                .ReverseMap();

            CreateMap<WalkDifficulty, WalkDifficulty>()
                .ReverseMap();
        }
    }
}
