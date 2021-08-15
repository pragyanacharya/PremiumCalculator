using AutoMapper;
using Moq;
using PremiumCalculator.UI.Calculator.Controllers;
using PremiumCalculator.UI.Calculator.Models.ViewModel;
using PremiumCalculator.UI.Calculator.Services.Interface;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PremiumCalculator.UI.Calculator.Tests.Controllers
{
    public class HomeControllerTests
    {
        private readonly Mock<IOccupationService> _mockOccupationService = new Mock<IOccupationService>();
        private readonly Mock<IPremiumService> _mockPremiumService = new Mock<IPremiumService>();
        private HomeController homeController;
        private static readonly CancellationToken CancellationToken = CancellationToken.None;
        public HomeControllerTests()
        {
            homeController=  new HomeController(_mockOccupationService.Object, _mockPremiumService.Object);
        }

        [Fact]
        public void Should_Return_View_When_GetOccupationList_Is_Null()
        {
            // Arrange  
            var model = new PremiumViewModel();
            _mockOccupationService.Setup(x => x.GetOccupationList()).Returns(Task.FromResult(model));

            // Act
            var result = homeController.Index();

            // Assert  
            Assert.NotNull(result);
        }

        [Fact]
        public void Should_Calculate_Premium_When_Model_Is_Valid()
        {
            // Arrange  
            var premiumServiceMock = new Mock<IPremiumService>();
            var mapperMock = new Mock<IMapper>();
            var premiumViewModel = new PremiumViewModel
            {
                Name = "TestUser",
                Age = "30",
                DateOfBirth = "01/03/1988",
                SumInsured = "30000",
                FactorRating = "1.5"
            };
            var premiumResult = new PremiumResult
            {
                PremiumValue = 756
            };
            var premiums = new PremiumViewModel
            {
                Name = "TestUser",
                Age = "30",
                SumInsured = "30000",
                FactorRating = "1.5"
            };
            _mockPremiumService.Setup(_ => _.GetPremium(premiums, CancellationToken)).Returns(Task.FromResult(premiumResult));

            // Act
            var result = homeController.Calculate(premiumViewModel, CancellationToken);

            // Assert  
            Assert.NotNull(result);
        }
    }
}
