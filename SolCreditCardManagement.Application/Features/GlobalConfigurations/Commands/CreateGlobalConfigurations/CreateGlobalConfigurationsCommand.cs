using MediatR;

namespace SolCreditCardManagement.Application.Features.GlobalConfigurations.Commands.CreateGlobalConfigurations
{
    public class CreateGlobalConfigurationsCommand : IRequest<int>
    {
        public string Code { get; set; } = string.Empty;
        public string ConfigurationVal { get; set; } = string.Empty;
    }
}
