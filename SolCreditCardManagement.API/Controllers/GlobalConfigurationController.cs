using MediatR;
using Microsoft.AspNetCore.Mvc;
using SolCreditCardManagement.Application.Features.GlobalConfigurations.Commands.CreateGlobalConfigurations;
using SolCreditCardManagement.Application.Features.GlobalConfigurations.Queries.GetGlobalConfigurationsList;
using System.Net;

namespace SolCreditCardManagement.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class GlobalConfigurationController : ControllerBase
    {
        private IMediator _mediator;

        public GlobalConfigurationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetGlobalConfigurations")]
        [ProducesResponseType(typeof(IEnumerable<GlobalConfigurationVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<GlobalConfigurationVm>>> GetGlobalConfigurations()
        {
            var query = new GetGlobalConfigurationsListQuery();
            var globalConfigs = await _mediator.Send(query);

            return Ok(globalConfigs);
        }

        [HttpPost(Name = "CreateGlobalConfiguration")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateGlobalConfiguration([FromBody] CreateGlobalConfigurationsCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
