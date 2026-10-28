using Microsoft.AspNetCore.Mvc;
using WcagEnterprise.Business.Services;

namespace WcagEnterprise.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWcagService _wcagService;

        public HomeController(IWcagService wcagService)
        {
            _wcagService = wcagService;
        }

        public async Task<IActionResult> Index()
        {
            // Fetch data securely via the Business Layer
            var rules = await _wcagService.GetComplianceRulesAsync();
            return View(rules);
        }
    }
}
