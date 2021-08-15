using AutoMapper;
using MediatR;
using Moq;
using PremiumCalculator.API.Application;
using PremiumCalculator.API.Application.Services;
using PremiumCalculator.API.Repository.Queries.GetOccupations;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using OccupationFactor = PremiumCalculator.API.Repository.Queries.GetOccupations.Models.OccupationFactor;

namespace Application.Tests.Services
{
    public class OccupationServiceTests
    {
        private readonly IMapper _mapper = new MapperConfiguration(mp => mp.AddProfile(new AutoMapperProfile())).CreateMapper();
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
        private OccupationService occupationService;
        private static readonly CancellationToken CancellationToken = CancellationToken.None;
        public OccupationServiceTests()
        {
            occupationService = new OccupationService(_mockMediator.Object, _mapper);
        }

        [Fact]
        public async Task Should_Return_Empty_When_GetOccupations_Returns_Null()
        {
            // Arrange  
            List<OccupationFactor> response = null;
            _mockMediator.Setup(x => x.Send(It.IsAny<GetOccupationsQuery>(), CancellationToken)).Returns(Task.FromResult(response));

            // Act
            var result = await occupationService.GetOccupations(CancellationToken);

            // Assert  
            Assert.Empty(result);
        }

        [Fact]
        public async Task Should_Not_Return_Empty_When_GetOccupations_Returns_Records()
        {
            // Arrange  
            List<OccupationFactor> response = new List<OccupationFactor> { new OccupationFactor { OccupationName = "Doctor", FactorValue = "1" } }; 
            _mockMediator.Setup(x => x.Send(It.IsAny<GetOccupationsQuery>(), CancellationToken)).Returns(Task.FromResult(response));

            // Act
            var result = await occupationService.GetOccupations(CancellationToken);

            // Assert  
            Assert.NotEmpty(result);
        }

    }
}
