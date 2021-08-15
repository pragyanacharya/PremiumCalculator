using Moq;
using PremiumCalculator.API.Application.Interfaces;
using PremiumCalculator.API.Application.Queries.GetOccupationList;
using PremiumCalculator.API.Application.Queries.GetOccupationList.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.Tests.Queries.GetOccupationList
{
    public class GetOccupationListQueryTests
    {
        private readonly Mock<IOccupationService> _mockOccupationService = new Mock<IOccupationService>();
        private GetOccupationListQuery query;
        private GetOccupationListQuery.Handler _handler;
        private static readonly CancellationToken CancellationToken = CancellationToken.None;
        public GetOccupationListQueryTests()
        {
            query = new GetOccupationListQuery();
            _handler = new GetOccupationListQuery.Handler(_mockOccupationService.Object);
        }

        [Fact]
        public async Task Should_Return_Empty_When_GetOccupations_Returns_Null()
        {
            // Arrange  
            List<OccupationFactor> response = new List<OccupationFactor>();
            _mockOccupationService.Setup(x => x.GetOccupations(CancellationToken)).Returns(Task.FromResult(response));

            // Act
            var result = await _handler.Handle(query,CancellationToken);

            // Assert  
            Assert.Empty(result);
        }

        [Fact]
        public async Task Should_Not_Return_Empty_When_GetOccupations_Returns_Records()
        {
            // Arrange  
            List<OccupationFactor> response = new List<OccupationFactor> { new OccupationFactor { OccupationName = "Doctor", FactorValue = "1" } };
            _mockOccupationService.Setup(x => x.GetOccupations(CancellationToken)).Returns(Task.FromResult(response));

            // Act
            var result = await _handler.Handle(query, CancellationToken);

            // Assert  
            Assert.NotEmpty(result);
        }

    }
}
