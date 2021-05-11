using Hdn.Core.Architecture.Application.Dtos.Tenant;
using Hdn.Core.Architecture.Application.Wrappers;
using Hdn.Core.Architecture.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hdn.Core.Architecture.Application.Interfaces.Services
{
    public interface ITenantService
    {
        Task<Response<int>> Create(TenantRequest tenantRequest);
        Task<Response<int>> Update(TenantRequest tenantRequest);
        Task<Response<int>> Delete(int id);
        Task<Response<Tenant>> GetById(int id);
        Task<Response<IReadOnlyList<Tenant>>> Get(int pageNumber, int pageSize);
    }
}
