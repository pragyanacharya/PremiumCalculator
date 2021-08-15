using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PremiumCalculator.UI.Calculator.Constants;
using PremiumCalculator.UI.Calculator.Models.ViewModel;
using PremiumCalculator.UI.Calculator.Services.Interface;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PremiumCalculator.UI.Calculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOccupationService _occupationService;
        private readonly IPremiumService _premiumService;
        private readonly IMapper _mapper;

        public HomeController(IOccupationService occupationService, IMapper mapper, IPremiumService premiumService)
        {
            _occupationService = occupationService;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
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
            if (ModelState.IsValid)
            {
                var response = await _premiumService.GetPremium(premiumViewModel, cancellationToken);
                ViewBag.result = response.PremiumValue;
            }
            else
            {
                ViewBag.error = ErrorConstant.InvalidInput;
            }
            return View("Index", await _occupationService.GetOccupationList());
        }
    }
}
