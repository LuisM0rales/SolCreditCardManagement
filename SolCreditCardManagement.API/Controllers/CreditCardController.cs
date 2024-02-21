using MediatR;
using Microsoft.AspNetCore.Mvc;
using SolCreditCardManagement.Application.Features.CreditCards.Commands.CreateCreditCard;
using SolCreditCardManagement.Application.Features.CreditCards.Commands.UpdateCreditCard;
using SolCreditCardManagement.Application.Features.CreditCards.Queries.GetCreditCardsList;
using SolCreditCardManagement.Data;
using System.Net;

namespace SolCreditCardManagement.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CreditCardController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CreditCardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name ="GetCreditCard")]
        [ProducesResponseType(typeof(IEnumerable<CreditCard>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CreditCard>>> GetCreditCard()
        {
            var query = new GetCreditCardsListQuery();
            var creditcards = await _mediator.Send(query);

            return Ok(creditcards);
        }

        [HttpPost(Name = "CreateCreditCard")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateCreditCard([FromBody] CreateCreditCardCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut(Name = "UpdateCreditCard")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateCreditCard([FromBody] UpdateCreditCardCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
