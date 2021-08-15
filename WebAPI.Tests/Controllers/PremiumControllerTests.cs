using MediatR;
using Moq;
using Premiumcalculator.API.Controllers;
using PremiumCalculator.API.Application.Queries.GetPremium;
using PremiumCalculator.API.Application.Queries.GetPremium.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace WebAPI.Tests.Controllers
{
    public class PremiumControllerTests
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
        private PremiumController premiumController;
        private static readonly CancellationToken CancellationToken = CancellationToken.None;
        public PremiumControllerTests()
        {
            premiumController = new PremiumController(_mockMediator.Object);
        }

        [Fact]
        public async Task Should_Return_Null_When_GetPremiumQuery_Returns_Null()
        {
            // Arrange  
            var premiumModel = new PremiumModel();
            PremiumResult response = null;
            _mockMediator.Setup(x => x.Send(It.IsAny<GetPremiumQuery>(), CancellationToken)).Returns(Task.FromResult(response));

            // Act
            var result = await premiumController.Post(premiumModel,CancellationToken);

            // Assert  
            Assert.Null(((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value);
        }

        [Fact]
        public async Task Should_NotReturn_Null_When_GetPremiumQuery_Returns_Value()
        {
            //Arrange
            var premiumModel = new PremiumModel();
            PremiumResult response = new PremiumResult() { PremiumValue=1};
            _mockMediator.Setup(x => x.Send(It.IsAny<GetPremiumQuery>(), CancellationToken)).Returns(Task.FromResult(response));

            // Act
            var result = await premiumController.Post(premiumModel, CancellationToken);

            // Assert  
            Assert.NotNull(((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value);
        }

    }
}
