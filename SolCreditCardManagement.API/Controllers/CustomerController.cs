using MediatR;
using Microsoft.AspNetCore.Mvc;
using SolCreditCardManagement.Application.Features.Customers.Commands.CreateCustomer;
using SolCreditCardManagement.Application.Features.Customers.Commands.UpdateCustomer;
using SolCreditCardManagement.Application.Features.Customers.Queries.GetCustomersList;
using System.Net;

namespace SolCreditCardManagement.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet("{customername}",Name="GetCustomer")]
        [ProducesResponseType(typeof(IEnumerable<CustomerVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CustomerVm>>> GetCustomersByName(string customername)
        {
            var query = new GetCustomersListQuery(customername);
            var customers = await _mediator.Send(query);

            return Ok(customers);
        }

        [HttpPost(Name ="CreateCustomer")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateCustomer([FromBody] CreateCustomerCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut(Name = "UpdateCustomer")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateCustomer([FromBody] UpdateCustomerCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        //[HttpDelete("{id}", Name ="DeleteCustomer")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesDefaultResponseType]
        //public async Task<ActionResult> DeleteCustomer(int id)
        //{
        //    var command = new DeleteCustomerCommand 
        //    {
        //        Id = id
        //    };

        //    await _mediator.Send(command);

        //    return NoContent();
        //}
    }
}
