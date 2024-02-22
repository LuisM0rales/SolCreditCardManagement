using Microsoft.AspNetCore.Mvc;
using SolCreditCardManagement.App.APIClients;
using SolCreditCardManagement.App.Models;
using System.Text.Json;

namespace SolCreditCardManagement.App.Controllers
{
    public class TransactionHistoryController : Controller
    {
        private readonly ILogger<TransactionHistoryController> _logger;
        private readonly CreditCardManagementAPI _ccAPI;

        public TransactionHistoryController(ILogger<TransactionHistoryController> logger, CreditCardManagementAPI ccAPI)
        {
            _logger = logger;
            _ccAPI = ccAPI;
        }

        public async Task<IActionResult> Index(int id, string cardnum, string nombre)
        {
            TempData["creditCardId"] = id;
            ViewData["cardnum"] = cardnum;
            ViewData["nombre"] = nombre;
            var resultTran = await _ccAPI.GetClientHelper("Transaction");
            var transactions = JsonSerializer.Deserialize<IEnumerable<TransactionViewModel>>(resultTran);

            return View(transactions);
        }
    }
}
