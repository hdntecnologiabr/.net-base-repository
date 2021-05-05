using hdn.net.architecture.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace hdn.net.architecture.Application.Interfaces.Repositories
{
    public interface ITenantRepositoryAsync : IGenericRepositoryAsync<Tenant>
    {
        public Task<Tenant> GetByIdAsync(Guid id);
        
    }
}
