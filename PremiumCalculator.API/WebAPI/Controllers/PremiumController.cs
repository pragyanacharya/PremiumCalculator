using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PremiumCalculator.API.Application.Queries.GetOccupationList;
using PremiumCalculator.API.Application.Queries.GetPremium;
using PremiumCalculator.API.Application.Queries.GetPremium.Model;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Premiumcalculator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PremiumController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PremiumController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]   
        public ActionResult Get()
        {
            var result = string.Empty;
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PremiumModel premiumModel, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetPremiumQuery
            {
                PremiumModel = premiumModel
            }, cancellationToken);
            return Ok(result);
        }

    }
}
