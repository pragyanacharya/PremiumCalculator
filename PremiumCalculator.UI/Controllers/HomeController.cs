using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PremiumCalculator.UI.Calculator.Services.Interface;
using System;
using System.Threading.Tasks;

namespace PremiumCalculator.UI.Calculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOccupationService premiumService;
        private readonly IMapper _mapper;

        public HomeController(IOccupationService premiumService, IMapper mapper)
        {
            this.premiumService = premiumService;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await premiumService.GetOccupationList());
        }
    }
}
