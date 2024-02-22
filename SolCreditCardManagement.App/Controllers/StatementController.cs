using Microsoft.AspNetCore.Mvc;
using SolCreditCardManagement.App.APIClients;
using SolCreditCardManagement.App.Models;
using System.Text.Json;

namespace SolCreditCardManagement.App.Controllers
{
    public class StatementController : Controller
    {
        private readonly ILogger<StatementController> _logger;
        private readonly CreditCardManagementAPI _ccAPI;

        public StatementController(ILogger<StatementController> logger, CreditCardManagementAPI ccAPI)
        {
            _logger = logger;
            _ccAPI = ccAPI;
        }

        public async Task<IActionResult> Index(int id)
        {
            var result = await _ccAPI.GetClientHelper("Statement",id);
            var statement = JsonSerializer.Deserialize<StatementViewModel>(result);

            var resultTran = await _ccAPI.GetClientHelper("Transaction/2",id);
            var transactions = JsonSerializer.Deserialize<IEnumerable<TransactionViewModel>>(resultTran);

            ViewData["Transactions"] = transactions;

            return View(statement);
        }
    }
}
