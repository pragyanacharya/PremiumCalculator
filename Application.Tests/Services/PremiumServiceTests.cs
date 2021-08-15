using PremiumCalculator.API.Application.Queries.GetPremium.Model;
using PremiumCalculator.API.Application.Services;
using Xunit;

namespace Application.Tests.Services
{
    public class PremiumServiceTests
    {
        private PremiumService premiumService;
        public PremiumServiceTests()
        {
            premiumService = new PremiumService();
        }

        [Fact]
        public void Should_Return_0_When_GetPremium_Returns_0()
        {
            // Arrange  
            var premiumModel = new PremiumModel();

            // Act
            var result = premiumService.GetPremium(premiumModel);

            // Assert  
            Assert.Equal(0,result.PremiumValue);
        }

        [Fact]
        public void Should_Not_Return_0_When_GetPremium_Returns_Value()
        {
            // Arrange  
            var premiumModel = new PremiumModel() {Age=10,FactorRating=10,SumInsured=10 };

            // Act
            var result = premiumService.GetPremium(premiumModel);

            // Assert  
            Assert.Equal(12, result.PremiumValue);
        }
    }
}
