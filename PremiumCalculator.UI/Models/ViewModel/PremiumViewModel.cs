using System.Collections.Generic;

namespace PremiumCalculator.UI.Calculator.Models.ViewModel
{
    public class PremiumViewModel
    {
        public string Name { get; set; }

        public string Age { get; set; }

        public string DateOfBirth { get; set; }

        public string FactorRating { get; set; }

        public IEnumerable<OccupationFactor> Occupation { get; set; }

        public string SumInsured { get; set; }
    }
}
