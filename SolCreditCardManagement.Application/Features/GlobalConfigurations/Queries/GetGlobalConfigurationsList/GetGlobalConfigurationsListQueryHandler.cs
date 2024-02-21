using AutoMapper;
using MediatR;
using SolCreditCardManagement.Application.Contracts.Persistence;
using SolCreditCardManagement.Domain;

namespace SolCreditCardManagement.Application.Features.GlobalConfigurations.Queries.GetGlobalConfigurationsList
{
    public class GetGlobalConfigurationsListQueryHandler : IRequestHandler<GetGlobalConfigurationsListQuery, List<GlobalConfigurationVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetGlobalConfigurationsListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<GlobalConfigurationVm>> Handle(GetGlobalConfigurationsListQuery request, CancellationToken cancellationToken)
        {
            var globalConfigList = await _unitOfWork.Repository<GlobalConfiguration>().GetAllAsync();

            return _mapper.Map<List<GlobalConfigurationVm>>(globalConfigList);
        }
    }
}
