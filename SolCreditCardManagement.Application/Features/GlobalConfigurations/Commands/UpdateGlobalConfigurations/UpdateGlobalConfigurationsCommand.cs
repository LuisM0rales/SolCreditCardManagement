using MediatR;

namespace SolCreditCardManagement.Application.Features.GlobalConfigurations.Commands.UpdateGlobalConfigurations
{
    public class UpdateGlobalConfigurationsCommand : IRequest
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string ConfigurationVal { get; set; } = string.Empty;
    }
}
