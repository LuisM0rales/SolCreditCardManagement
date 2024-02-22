using Microsoft.AspNetCore.Mvc;
using SolCreditCardManagement.App.APIClients;
using SolCreditCardManagement.App.Models;
using System.Diagnostics;
using System.Text.Json;

namespace SolCreditCardManagement.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CreditCardManagementAPI _ccAPI;

        public HomeController(ILogger<HomeController> logger, CreditCardManagementAPI ccAPI)
        {
            _logger = logger;
            _ccAPI = ccAPI;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _ccAPI.GetClientHelper("CreditCard");
            var creditCards = JsonSerializer.Deserialize<List<CreditCardViewModel>>(result);

            return View(creditCards);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}