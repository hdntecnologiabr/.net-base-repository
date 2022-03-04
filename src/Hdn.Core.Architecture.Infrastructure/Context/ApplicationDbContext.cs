using System.Reflection;
using Hdn.Core.Architecture.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Hdn.Core.Architecture.Infrastructure.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                //TODO: adicionar usuario no createBy
                case EntityState.Added:
                    entry.Entity.CreatedBy = string.Empty;
                    entry.Entity.Created = DateTime.Now;
                    break;

                case EntityState.Modified:
                    entry.Entity.LastModifiedBy = string.Empty;
                    entry.Entity.LastModified = DateTime.Now;
                    break;
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}
