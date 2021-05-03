using hdn.net.architecture.Application.Exceptions;
using hdn.net.architecture.Application.Interfaces.Repositories;
using hdn.net.architecture.Application.Wrappers;
using hdn.net.architecture.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace hdn.net.architecture.Application.Features.Tenants.Queries.GetTenantById
{
    public class GetTenantByIdQuery : IRequest<Response<Tenant>>
    {
        public int Id { get; set; }
        public class GetTenantByIdQueryHandler : IRequestHandler<GetTenantByIdQuery, Response<Tenant>>
        {
            private readonly ITenantRepositoryAsync _tenantRepository;
            public GetTenantByIdQueryHandler(ITenantRepositoryAsync tenantRepository)
            {
                _tenantRepository = tenantRepository;
            }
            public async Task<Response<Tenant>> Handle(GetTenantByIdQuery query, CancellationToken cancellationToken)
            {
                var tenant = await _tenantRepository.GetByIdAsync(query.Id);
                if (tenant == null) throw new ApiException($"Tenant Not Found.");
                return new Response<Tenant>(tenant);
            }
        }
    }
}
