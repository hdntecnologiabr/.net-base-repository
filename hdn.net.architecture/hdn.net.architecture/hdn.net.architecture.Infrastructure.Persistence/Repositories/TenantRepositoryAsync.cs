using hdn.net.architecture.Application.Interfaces.Repositories;
using hdn.net.architecture.Domain.Entities;
using hdn.net.architecture.Infrastructure.Persistence.Contexts;
using hdn.net.architecture.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;

namespace hdn.net.architecture.Infrastructure.Persistence.Repositories
{
    public class TenantRepositoryAsync : GenericRepositoryAsync<Tenant>, ITenantRepositoryAsync
    {
        private readonly DbSet<Tenant> _tenants;

        public TenantRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _tenants = dbContext.Set<Tenant>();
        }
    }
}
