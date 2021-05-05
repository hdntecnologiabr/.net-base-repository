using Hdn.Core.Architecture.Domain.Entities;
using System.Threading.Tasks;

namespace Hdn.Core.Architecture.Application.Interfaces.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        //Task<bool> IsUniqueBarcodeAsync(string barcode);
    }
}
