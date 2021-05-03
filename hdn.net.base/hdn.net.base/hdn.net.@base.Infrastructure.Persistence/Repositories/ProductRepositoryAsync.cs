using hdn.net._base.Application.Interfaces.Repositories;
using hdn.net._base.Domain.Entities;
using hdn.net._base.Infrastructure.Persistence.Contexts;
using hdn.net._base.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace hdn.net._base.Infrastructure.Persistence.Repositories
{
    public class ProductRepositoryAsync : GenericRepositoryAsync<Product>, IProductRepositoryAsync
    {
        private readonly DbSet<Product> _products;

        public ProductRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _products = dbContext.Set<Product>();
        }

        public Task<bool> IsUniqueBarcodeAsync(string barcode)
        {
            return _products
                .AllAsync(p => p.Barcode != barcode);
        }
    }
}
