using SolCreditCardManagement.Domain.Common;

namespace SolCreditCardManagement.Domain
{
    public class Customer : BaseDomainModel
    {
        public string? FirstName { get; set; }
        public string? SecondName { get; set; }
        public string? LastName { get; set; }
        public string? SecondLastName { get; set; }
    }
}
