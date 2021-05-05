using Hdn.Core.Architecture.Application.Interfaces.Repositories;
using Hdn.Core.Architecture.Domain.Entities;
using Hdn.Core.Architecture.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Hdn.Core.Architecture.Infrastructure.Persistence.Repositories
{
    public class TenantRepository : GenericRepository<Tenant>, ITenantRepository
    {
        private readonly DbSet<Tenant> _tenants;

        public TenantRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _tenants = dbContext.Set<Tenant>();
        }
  
    }
}
