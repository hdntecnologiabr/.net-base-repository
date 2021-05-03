using hdn.net.architecture.Application.Exceptions;
using hdn.net.architecture.Application.Interfaces.Repositories;
using hdn.net.architecture.Application.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace hdn.net.architecture.Application.Features.Tenants.Commands.DeleteTenant
{
    public class DeleteTenantByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeleteTenantByIdCommandHandler : IRequestHandler<DeleteTenantByIdCommand, Response<int>>
        {
            private readonly ITenantRepositoryAsync _tenantRepository;
            public DeleteTenantByIdCommandHandler(ITenantRepositoryAsync tenantRepository)
            {
                _tenantRepository = tenantRepository;
            }
            public async Task<Response<int>> Handle(DeleteTenantByIdCommand command, CancellationToken cancellationToken)
            {
                var tenant = await _tenantRepository.GetByIdAsync(command.Id);
                if (tenant == null) throw new ApiException($"Tenant Not Found.");
                await _tenantRepository.DeleteAsync(tenant);
                return new Response<int>(tenant.Id);
            }
        }
    }
}
