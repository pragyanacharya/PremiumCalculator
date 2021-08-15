using Moq;
using PremiumCalculator.API.Application.Interfaces;
using PremiumCalculator.API.Application.Queries.GetPremium;
using PremiumCalculator.API.Application.Queries.GetPremium.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.Tests.Queries.GetPremium
{
    public class GetPremiumQueryTests
    {
        private readonly Mock<IPremiumService> _mockPremiumService = new Mock<IPremiumService>();
        private GetPremiumQuery query;
        private GetPremiumQuery.Handler _handler;
        private static readonly CancellationToken CancellationToken = CancellationToken.None;
        public GetPremiumQueryTests()
        {
            query = new GetPremiumQuery();
            _handler = new GetPremiumQuery.Handler(_mockPremiumService.Object);
        }

        [Fact]
        public async Task Should_Return_0_When_GetPremium_Returns_0()
        {
            // Arrange  
            var premiumModel = new PremiumModel();
            var premiumResult = new PremiumResult() { PremiumValue=0};
            query.PremiumModel = premiumModel;
            _mockPremiumService.Setup(x => x.GetPremium(premiumModel)).Returns(premiumResult);

            // Act
            var result = await _handler.Handle(query, CancellationToken);

            // Assert  
            Assert.Equal(0, result.PremiumValue);
        }

        [Fact]
        public async Task Should_Not_Return_0_When_GetPremium_Returns_Value()
        {
            // Arrange  
            var premiumModel = new PremiumModel() { Age = 10, FactorRating = 10, SumInsured = 10 };
            var premiumResult = new PremiumResult() { PremiumValue=12};
            query.PremiumModel = premiumModel;

            _mockPremiumService.Setup(x => x.GetPremium(premiumModel)).Returns(premiumResult);
            // Act
            var result = await _handler.Handle(query, CancellationToken);

            // Assert  
            Assert.Equal(12, result.PremiumValue);
        }
    }
}
