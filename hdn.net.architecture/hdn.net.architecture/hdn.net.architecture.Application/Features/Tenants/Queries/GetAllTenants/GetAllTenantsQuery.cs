using AutoMapper;
using hdn.net.architecture.Application.Interfaces.Repositories;
using hdn.net.architecture.Application.Wrappers;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace hdn.net.architecture.Application.Features.Tenants.Queries.GetAllTenants
{
    public class GetAllTenantsQuery : IRequest<PagedResponse<IEnumerable<GetAllTenantsViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllTenantsQueryHandler : IRequestHandler<GetAllTenantsQuery, PagedResponse<IEnumerable<GetAllTenantsViewModel>>>
    {
        private readonly ITenantRepositoryAsync _tenantRepository;
        private readonly IMapper _mapper;
        public GetAllTenantsQueryHandler(ITenantRepositoryAsync tenantRepository, IMapper mapper)
        {
            _tenantRepository = tenantRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllTenantsViewModel>>> Handle(GetAllTenantsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllTenantsParameter>(request);
            var tenant = await _tenantRepository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var tenantViewModel = _mapper.Map<IEnumerable<GetAllTenantsViewModel>>(tenant);
            return new PagedResponse<IEnumerable<GetAllTenantsViewModel>>(tenantViewModel, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
