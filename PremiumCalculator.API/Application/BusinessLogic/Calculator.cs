using System;

namespace PremiumCalculator.API.Application.BusinessLogic
{
    public static class Calculator
    {
        public static decimal Calculate(decimal sumInsured, decimal ratingFactor,int age)
        {
            var premium = (sumInsured * ratingFactor * age) / 1000 * 12;
            return Math.Round(premium, 2);
        }
    }
}
