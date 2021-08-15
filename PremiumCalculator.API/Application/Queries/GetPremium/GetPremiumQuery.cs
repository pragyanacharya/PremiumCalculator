using MediatR;
using PremiumCalculator.API.Application.Interfaces;
using PremiumCalculator.API.Application.Queries.GetPremium.Model;
using System.Threading;
using System.Threading.Tasks;

namespace PremiumCalculator.API.Application.Queries.GetPremium
{
    public class GetPremiumQuery : IRequest<PremiumResult>
    {
        public PremiumModel PremiumModel { get; set; }
        public class Handler : IRequestHandler<GetPremiumQuery, PremiumResult>
        {
            private readonly IPremiumService _premiumService;
            public Handler(IPremiumService premiumService)
            {
                _premiumService = premiumService;
            }

            public async Task<PremiumResult> Handle(GetPremiumQuery query, CancellationToken cancellationToken)
            {
                return _premiumService.GetPremium(query.PremiumModel);
            }
        }
    }
}
