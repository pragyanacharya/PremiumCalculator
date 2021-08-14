using PremiumCalculator.API.Application.Queries.GetOccupationList.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PremiumCalculator.API.Application.Interfaces
{
    public interface IOccupationService
    {
        Task<List<OccupationFactor>> GetOccupations(CancellationToken cancellationToken);
    }
}
