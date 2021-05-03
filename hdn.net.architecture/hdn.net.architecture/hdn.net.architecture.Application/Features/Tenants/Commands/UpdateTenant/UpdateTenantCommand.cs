﻿using hdn.net.architecture.Application.Exceptions;
using hdn.net.architecture.Application.Interfaces.Repositories;
using hdn.net.architecture.Application.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace hdn.net.architecture.Application.Features.Tenants.Commands.UpdateTenant
{
    public class UpdateTenantCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateTenantCommandHandler : IRequestHandler<UpdateTenantCommand, Response<int>>
        {
            private readonly ITenantRepositoryAsync _tenantRepository;
            public UpdateTenantCommandHandler(ITenantRepositoryAsync tenantRepository)
            {
                _tenantRepository = tenantRepository;
            }
            public async Task<Response<int>> Handle(UpdateTenantCommand command, CancellationToken cancellationToken)
            {
                var tenant = await _tenantRepository.GetByIdAsync(command.Id);

                if (tenant == null)
                {
                    throw new ApiException($"Tenant Not Found.");
                }
                else
                {
                    tenant.Name = command.Name;                    
                    await _tenantRepository.UpdateAsync(tenant);
                    return new Response<int>(tenant.Id);
                }
            }
        }
    }
}
