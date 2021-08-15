using MediatR;
using Moq;
using Premiumcalculator.API.Controllers;
using PremiumCalculator.API.Application.Queries.GetOccupationList;
using PremiumCalculator.API.Application.Queries.GetOccupationList.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace WebAPI.Tests.Controllers
{
    public class OccupationControllerTests
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
        private OccupationController occupationController;
        private static readonly CancellationToken CancellationToken = CancellationToken.None;
        public OccupationControllerTests()
        {
            occupationController = new OccupationController(_mockMediator.Object);
        }

        [Fact]
        public async Task Should_Return_Null_When_GetOccupationListQuery_Returns_Null()
        {
            // Arrange  
            List<OccupationFactor> response=null;
            _mockMediator.Setup(x => x.Send(It.IsAny<GetOccupationListQuery>(), CancellationToken)).Returns(Task.FromResult(response));

            // Act
            var result = await occupationController.Get(CancellationToken);

            // Assert  
            Assert.Null(((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value);
        }

        [Fact]
        public async Task Should_NotReturn_Null_When_GetOccupationListQuery_Returns_Value()
        {
            // Arrange  
            List<OccupationFactor> response = new List<OccupationFactor> { new OccupationFactor {OccupationName="Doctor" ,FactorValue="1"} };
            _mockMediator.Setup(x => x.Send(It.IsAny<GetOccupationListQuery>(), CancellationToken)).Returns(Task.FromResult(response));

            // Act
            var result = await occupationController.Get(CancellationToken);

            // Assert  
            Assert.NotNull(((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value);
        }
    }
}
