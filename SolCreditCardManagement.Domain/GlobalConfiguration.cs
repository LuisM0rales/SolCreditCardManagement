using SolCreditCardManagement.Domain.Common;

namespace SolCreditCardManagement.Domain
{
    public class GlobalConfiguration : BaseDomainModel
    {
        public string? Code { get; set; }
        public string? ConfigurationVal { get; set; }
    }
}
