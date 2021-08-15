using PremiumCalculator.API.Application.BusinessLogic;
using PremiumCalculator.API.Application.Interfaces;
using PremiumCalculator.API.Application.Queries.GetPremium.Model;

namespace PremiumCalculator.API.Application.Services
{
    public class PremiumService : IPremiumService
    {
        public PremiumResult GetPremium(PremiumModel premium)
        {
            var premiumValue = BusinessLogic.Helper.Calculate(premium.SumInsured, premium.FactorRating, premium.Age);

            return new PremiumResult
            {
                PremiumValue = premiumValue
            };
        }
    }
}
