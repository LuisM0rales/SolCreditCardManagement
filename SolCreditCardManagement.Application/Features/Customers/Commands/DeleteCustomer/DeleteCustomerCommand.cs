﻿using MediatR;

namespace SolCreditCardManagement.Application.Features.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand: IRequest
    {
        public int Id { get; set; }
    }
}
