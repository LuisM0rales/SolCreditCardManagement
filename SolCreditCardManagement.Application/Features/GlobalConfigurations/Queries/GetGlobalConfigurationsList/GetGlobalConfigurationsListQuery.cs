using MediatR;

namespace SolCreditCardManagement.Application.Features.GlobalConfigurations.Queries.GetGlobalConfigurationsList
{
    public class GetGlobalConfigurationsListQuery : IRequest<List<GlobalConfigurationVm>>
    {
        public GetGlobalConfigurationsListQuery() 
        {

        }
    }
}
