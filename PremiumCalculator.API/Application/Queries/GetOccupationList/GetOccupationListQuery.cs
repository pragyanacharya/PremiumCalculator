using MediatR;
using PremiumCalculator.API.Application.Interfaces;
using PremiumCalculator.API.Application.Queries.GetOccupationList.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PremiumCalculator.API.Application.Queries.GetOccupationList
{
    public class GetOccupationListQuery: IRequest<List<OccupationFactor>>
    {
        public class Handler:IRequestHandler<GetOccupationListQuery, List<OccupationFactor>>
        {
            private readonly IOccupationService _occupationService;
            public Handler(IOccupationService occupationService)
            {
                _occupationService = occupationService;
            }

            public async Task<List<OccupationFactor>> Handle(GetOccupationListQuery query, CancellationToken cancellationToken)
            {
                return await _occupationService.GetOccupations(cancellationToken);
            }
        }
    }
}
