using PremiumCalculator.UI.Calculator.Models.ViewModel;
using System.Threading;
using System.Threading.Tasks;

namespace PremiumCalculator.UI.Calculator.Services.Interface
{
    public interface IPremiumService
    {
        Task<PremiumResult> GetPremium(PremiumViewModel premium, CancellationToken cancellationToken);
    }
}
