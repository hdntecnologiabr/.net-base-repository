using AutoMapper;
using Hdn.Core.Architecture.Application.Dtos.Tenant;
using Hdn.Core.Architecture.Application.Interfaces.Repositories;
using Hdn.Core.Architecture.Application.Interfaces.Services;
using Hdn.Core.Architecture.Application.Wrappers;
using Hdn.Core.Architecture.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hdn.Core.Architecture.Application.Services
{
    public class TenantService : ITenantService
    {
        private readonly ITenantRepository _tenantRepository;
        private readonly IMapper _mapper;

        public TenantService(ITenantRepository tenantRepository, IMapper mapper)
        {
            _tenantRepository = tenantRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Create(TenantRequest tenantRequest)
        {
            var tenant = _mapper.Map<Tenant>(tenantRequest);
            await _tenantRepository.AddAsync(tenant);
            return new Response<int>(tenant.Id);
        }

        public async Task<Response<int>> Update(TenantRequest tenantRequest)
        {
            var tenant = _mapper.Map<Tenant>(tenantRequest);
            await _tenantRepository.UpdateAsync(tenant);
            return new Response<int>(tenant.Id);
        }

        public async Task<Response<int>> Delete(int id)
        {
            var tenant = new Tenant() { Id = id };
            await _tenantRepository.DeleteAsync(tenant);
            return new Response<int>(tenant.Id);
        }

        public async Task<Response<IReadOnlyList<Tenant>>> Get(int pageNumber, int pageSize)
        {            
            var tenants =  await _tenantRepository.GetPagedReponseAsync(pageNumber, pageSize);
            return new Response<IReadOnlyList<Tenant>>(tenants);
        }

        public async Task<Response<Tenant>> GetById(int id)
        {            
            var tenant = await _tenantRepository.GetByIdAsync(id);
            return new Response<Tenant>(tenant);
        }     
    }
}
