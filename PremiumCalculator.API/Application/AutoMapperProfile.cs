using AutoMapper;
using PremiumCalculator.API.Application.Queries.GetOccupationList.Models;

namespace PremiumCalculator.API.Application
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<OccupationFactor, Repository.Queries.GetOccupations.Models.OccupationFactor>().ReverseMap();
        }
    }
}
