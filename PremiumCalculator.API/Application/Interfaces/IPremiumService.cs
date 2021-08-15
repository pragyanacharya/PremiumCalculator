using PremiumCalculator.API.Application.Queries.GetPremium.Model;

namespace PremiumCalculator.API.Application.Interfaces
{
    public interface IPremiumService
    {
        PremiumResult GetPremium(PremiumModel premium);
    }
}
