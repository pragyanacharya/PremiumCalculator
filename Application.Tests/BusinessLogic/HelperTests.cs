using PremiumCalculator.API.Application.BusinessLogic;
using PremiumCalculator.API.Application.Queries.GetPremium.Model;
using Xunit;

namespace Application.Tests.BusinessLogic
{
    public class HelperTests
    {
        [Fact]
        public void Should_Return_0_When_GetPremium_Returns_0()
        {
            // Arrange  
            var premiumModel = new PremiumModel();

            // Act
            var result = Helper.Calculate(premiumModel.SumInsured, premiumModel.FactorRating, premiumModel.Age);

            // Assert  
            Assert.Equal(0, result);
        }

        [Fact]
        public void Should_Not_Return_0_When_GetPremium_Returns_Value()
        {
            // Arrange  
            var premiumModel = new PremiumModel() { Age = 10, FactorRating = 10, SumInsured = 10 };

            // Act
            var result = Helper.Calculate(premiumModel.SumInsured, premiumModel.FactorRating, premiumModel.Age);

            // Assert  
            Assert.Equal(12, result);
        }
    }
}
