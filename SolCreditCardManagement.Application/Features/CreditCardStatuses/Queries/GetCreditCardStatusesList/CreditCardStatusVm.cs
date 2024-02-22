namespace SolCreditCardManagement.Application.Features.CreditCardStatuses.Queries.GetCreditCardStatusesList
{
    public class CreditCardStatusVm
    {
        public int Id { get; set; }
        public string CreditCardStatusCode { get; set; } = string.Empty;
        public string CreditCardStatusName { get; set; } = string.Empty;
    }
}
