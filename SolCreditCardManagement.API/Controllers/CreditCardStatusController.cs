using MediatR;
using Microsoft.AspNetCore.Mvc;
using SolCreditCardManagement.Application.Features.CreditCardStatuses.Commands.CreateCreditCardStatuses;
using SolCreditCardManagement.Application.Features.CreditCardStatuses.Commands.UpdateCreditCardStatuses;
using SolCreditCardManagement.Application.Features.CreditCardStatuses.Queries.GetCreditCardStatusesList;
using SolCreditCardManagement.Data;
using System.Net;

namespace SolCreditCardManagement.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CreditCardStatusController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CreditCardStatusController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetCreditCardStatus")]
        [ProducesResponseType(typeof(IEnumerable<CreditCardStatus>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CreditCardStatus>>> GetCreditCardStatus()
        {
            var query = new GetCreditCardStatusesListQuery();
            var creditcardstatuses = await _mediator.Send(query);

            return Ok(creditcardstatuses);
        }

        [HttpPost(Name = "CreateCreditCardStatus")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateCreditCardStatus([FromBody] CreateCreditCardStatusesCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut(Name = "UpdateCreditCardStatus")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateCreditCardStatus([FromBody] UpdateCreditCardStatusesCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
