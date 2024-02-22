using Microsoft.AspNetCore.Mvc;
using SolCreditCardManagement.App.APIClients;
using SolCreditCardManagement.App.Models;

namespace SolCreditCardManagement.App.Controllers
{
    public class PurchaseTransactionController : Controller
    {
        private readonly ILogger<PurchaseTransactionController> _logger;
        private readonly CreditCardManagementAPI _ccAPI;

        public PurchaseTransactionController(ILogger<PurchaseTransactionController> logger, CreditCardManagementAPI ccAPI)
        {
            _logger = logger;
            _ccAPI = ccAPI;
        }

        public async Task<IActionResult> Index(int id, string cardnum, string nombre)
        {
            TempData["creditCardId"] = id;
            ViewData["cardnum"] = cardnum;
            ViewData["nombre"] = nombre;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(string FechaPago, decimal MontoPago, string Description)
        {
            TransactionViewModel model = new TransactionViewModel
            {
                TransactionTypeId = 2,
                Description = Description,
                Amount = Convert.ToDouble(MontoPago),
                CreatedDate = Convert.ToDateTime(FechaPago),
                CreditCardId = (int)TempData["creditCardId"]
            };

            var result = await _ccAPI.PostClientHelper("Transaction", model);

            ViewBag.IsSuccess = result.IsSuccessStatusCode;

            return View("Index", new { id = TempData["creditCardId"], cardnum = ViewData["cardnum"], nombre = ViewData["nombre"] });
        }
    }
}
