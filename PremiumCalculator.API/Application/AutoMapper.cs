using AutoMapper;
using PremiumCalculator.API.Application.Queries.GetOccupationList.Models;

namespace PremiumCalculator.API.Application
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<OccupationFactor, Repository.Queries.GetOccupations.Models.OccupationFactor>().ReverseMap();
        }
    }
}
