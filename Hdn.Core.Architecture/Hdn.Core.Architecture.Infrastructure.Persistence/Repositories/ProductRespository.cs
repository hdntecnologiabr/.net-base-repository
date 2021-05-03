using Hdn.Core.Architecture.Application.Interfaces.Repositories;
using Hdn.Core.Architecture.Domain.Entities;
using Hdn.Core.Architecture.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hdn.Core.Architecture.Infrastructure.Persistence.Repositories
{
    public class ProductRepository: GenericRepository<Product>, IProductRepository
    {
        private readonly DbSet<Product> _products;

        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _products = dbContext.Set<Product>();
        }

        //public Task<bool> IsUniqueBarcodeAsync(string barcode)
        //{
        //    return _products
        //        .AllAsync(p => p.Barcode != barcode);
        //}
    }
}
