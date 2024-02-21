using MediatR;

namespace SolCreditCardManagement.Application.Features.Statements.Queries.GetStatementByICreditCardId
{
    public class GetStatementByICreditCardIdQuery : IRequest<StatementVm>
    {
        public int _id { get; set; } = 0;

        public GetStatementByICreditCardIdQuery(int Id)
        {
            _id = Id;
        }
    }
}
