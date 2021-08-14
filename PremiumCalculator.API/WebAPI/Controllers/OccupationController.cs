using MediatR;
using Microsoft.AspNetCore.Mvc;
using PremiumCalculator.API.Application.Queries.GetOccupationList;
using System.Threading;
using System.Threading.Tasks;

namespace Premiumcalculator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OccupationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OccupationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetOccupationListQuery { },cancellationToken);
            return Ok(result);
        }
    }
}
