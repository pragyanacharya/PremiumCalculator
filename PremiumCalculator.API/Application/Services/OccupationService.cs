using AutoMapper;
using MediatR;
using PremiumCalculator.API.Application.Interfaces;
using PremiumCalculator.API.Application.Queries.GetOccupationList.Models;
using PremiumCalculator.API.Repository.Queries.GetOccupations;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PremiumCalculator.API.Application.Services
{
    public class OccupationService: IOccupationService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public OccupationService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<List<OccupationFactor>> GetOccupations(CancellationToken cancellationToken)
        {
            var result= await _mediator.Send(new GetOccupationsQuery { }, cancellationToken);
            return _mapper.Map<List<OccupationFactor>>(result);
        }
        
    }
}
