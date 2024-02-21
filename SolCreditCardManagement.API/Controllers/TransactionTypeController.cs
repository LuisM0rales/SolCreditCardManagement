using MediatR;
using Microsoft.AspNetCore.Mvc;
using SolCreditCardManagement.Application.Features.TransactionTypes.Commands.CreateTransactionTypes;
using SolCreditCardManagement.Application.Features.TransactionTypes.Commands.UpdateTransactionTypes;
using SolCreditCardManagement.Application.Features.TransactionTypes.Queries.GetTransactionTypesList;
using System.Net;

namespace SolCreditCardManagement.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TransactionTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransactionTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetTransactionTypes")]
        [ProducesResponseType(typeof(IEnumerable<TransactionTypeVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<TransactionTypeVm>>> GetTransactionTypes()
        {
            var query = new GetTransactionTypesListQuery();
            var transactionTypes = await _mediator.Send(query);

            return Ok(transactionTypes);
        }

        [HttpPost(Name = "CreateTransactionType")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateTransactionType([FromBody] CreateTransactionTypesCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut(Name = "UpdateTransactionType")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateTransactionType([FromBody] UpdateCreateTransactionTypesCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
