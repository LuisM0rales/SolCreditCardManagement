using Microsoft.AspNetCore.Mvc;
using SolCreditCardManagement.App.APIClients;
using SolCreditCardManagement.App.Models;
using System.Text.Json;

namespace SolCreditCardManagement.App.Controllers
{
    public class GlobalConfigurationController : Controller
    {
        private readonly ILogger<GlobalConfigurationController> _logger;
        private readonly CreditCardManagementAPI _ccAPI;

        public GlobalConfigurationController(ILogger<GlobalConfigurationController> logger, CreditCardManagementAPI ccAPI)
        {
            _logger = logger;
            _ccAPI = ccAPI;
        }

        // GET: GlobalConfigurationController
        public async Task<ActionResult> Index()
        {
            var result = await _ccAPI.GetClientHelper("GlobalConfiguration");
            var globalConfigurations = JsonSerializer.Deserialize<List<GlobalConfigurationViewModel>>(result);

            return View(globalConfigurations);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: GlobalConfigurationController/Create
        [HttpPost]
        public async Task<ActionResult> Create(string code, string configVal)
        {
            GlobalConfigurationViewModel model = new GlobalConfigurationViewModel
            {
                Code = code,
                ConfigurationVal = configVal
            };

            var result = await _ccAPI.PostClientHelper("GlobalConfiguration", model);

            ViewBag.IsSuccess = result.IsSuccessStatusCode;

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int Id, string Code, string ConfigurationVal)
        {
            return View();
        }

        // POST: GlobalConfigurationController/Edit/5
        [HttpPost]
        public async Task<ActionResult> EditAsync(int id, string code, string configVal)
        {
            GlobalConfigurationViewModel model = new GlobalConfigurationViewModel
            {
                Id = id,
                Code = code,
                ConfigurationVal = configVal
            };

            var result = await _ccAPI.PutClientHelper("GlobalConfiguration",model);

            ViewBag.IsSuccess = result.IsSuccessStatusCode;

            return View();
        }
    }
}
