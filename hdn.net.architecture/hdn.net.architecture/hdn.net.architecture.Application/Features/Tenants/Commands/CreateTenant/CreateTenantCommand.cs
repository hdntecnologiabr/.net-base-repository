using AutoMapper;
using hdn.net.architecture.Application.Interfaces.Repositories;
using hdn.net.architecture.Application.Wrappers;
using hdn.net.architecture.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace hdn.net.architecture.Application.Features.Tenants.Commands.CreateTenant
{
    public class CreateTenantCommand : IRequest<Response<Guid>>
    {
        public string Name { get; set; }
    }
    public class CreateTenantCommandHandler : IRequestHandler<CreateTenantCommand, Response<Guid>>
    {
        private readonly ITenantRepositoryAsync _tenantRepository;
        private readonly IMapper _mapper;
        public CreateTenantCommandHandler(ITenantRepositoryAsync tenantRepository, IMapper mapper)
        {
            _tenantRepository = tenantRepository;
            _mapper = mapper;
        }

        public async Task<Response<Guid>> Handle(CreateTenantCommand request, CancellationToken cancellationToken)
        {
            var tenant = _mapper.Map<Tenant>(request);
            await _tenantRepository.AddAsync(tenant);
            return new Response<Guid>(tenant.Id);
        }
    }
}
