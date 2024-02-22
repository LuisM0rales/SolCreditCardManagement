using MediatR;
using Microsoft.AspNetCore.Mvc;
using SolCreditCardManagement.Application.Features.Transactions.Commands.CreateTransactions;
using SolCreditCardManagement.Application.Features.Transactions.Queries.GetTransactionsList;
using SolCreditCardManagement.Application.Features.Transactions.Queries.GetTransactionsListByTypeAndCC;
using System.Net;

namespace SolCreditCardManagement.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetTransactions")]
        [ProducesResponseType(typeof(IEnumerable<TransactionVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<TransactionVm>>> GetTransactions()
        {
            var query = new GetTransactionsListQuery();
            var transactions = await _mediator.Send(query);

            return Ok(transactions);
        }

        [HttpGet("{transactionTypeId}/{creditCardId}",Name = "GetTransactionsByTypeAndCreditCard")]
        [ProducesResponseType(typeof(IEnumerable<TransactionVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<TransactionVm>>> GetTransactionsByTypeAndCreditCard(int transactionTypeId, int creditCardId)
        {
            var query = new GetTransactionsListByTypeAndCCQuery(transactionTypeId,creditCardId);
            var transactions = await _mediator.Send(query);

            return Ok(transactions);
        }

        [HttpPost(Name = "CreateTransaction")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateTransaction([FromBody] CreateTransactionsCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
