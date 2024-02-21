using MediatR;
using Microsoft.AspNetCore.Mvc;
using SolCreditCardManagement.Application.Features.Statements.Queries.GetStatementByICreditCardId;
using System.Net;

namespace SolCreditCardManagement.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class StatementController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StatementController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("creditcardid", Name = "GetStatement")]
        [ProducesResponseType(typeof(StatementVm), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<StatementVm>> GetStatement(int creditcardid)
        {
            var query = new GetStatementByICreditCardIdQuery(creditcardid);
            var statement = await _mediator.Send(query);

            return Ok(statement);
        }
    }
}
