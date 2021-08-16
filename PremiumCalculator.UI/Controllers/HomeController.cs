using Microsoft.AspNetCore.Mvc;
using PremiumCalculator.UI.Calculator.Models.ViewModel;
using PremiumCalculator.UI.Calculator.Services.Interface;
using System.Threading;
using System.Threading.Tasks;

namespace PremiumCalculator.UI.Calculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOccupationService _occupationService;
        private readonly IPremiumService _premiumService;

        public HomeController(IOccupationService occupationService, IPremiumService premiumService)
        {
            _occupationService = occupationService;
            _premiumService = premiumService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _occupationService.GetOccupationList());
        }

        [HttpPost]
        public async Task<IActionResult> Calculate(PremiumViewModel premiumViewModel, CancellationToken cancellationToken)
        {
            var response = await _premiumService.GetPremium(premiumViewModel, cancellationToken);
            ViewBag.result = response.PremiumValue;
            return View("Index", await _occupationService.GetOccupationList());
        }

        [HttpPost]
        public async Task<PartialViewResult> IndexPartial(PremiumViewModel premiumViewModel, CancellationToken cancellationToken)
        {
            var response = await _premiumService.GetPremium(premiumViewModel, cancellationToken);
            ViewBag.result = response.PremiumValue;
            return PartialView("_Result");
        }
    }
}
