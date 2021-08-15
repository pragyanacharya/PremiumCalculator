namespace PremiumCalculator.API.Application.Queries.GetPremium.Model
{
    public class PremiumModel
    {
        public int Age { get; set; }

        public decimal FactorRating { get; set; }

        public decimal SumInsured { get; set; }
    }
}
