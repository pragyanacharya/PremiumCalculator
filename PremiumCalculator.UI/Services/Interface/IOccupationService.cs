using PremiumCalculator.UI.Calculator.Models.ViewModel;
using System.Threading.Tasks;

namespace PremiumCalculator.UI.Calculator.Services.Interface
{
    public interface IOccupationService
    {
        Task<PremiumViewModel> GetOccupationList();
    }
}
