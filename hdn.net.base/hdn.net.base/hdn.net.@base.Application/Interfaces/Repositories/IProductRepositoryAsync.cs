using hdn.net._base.Domain.Entities;
using System.Threading.Tasks;

namespace hdn.net._base.Application.Interfaces.Repositories
{
    public interface IProductRepositoryAsync : IGenericRepositoryAsync<Product>
    {
        Task<bool> IsUniqueBarcodeAsync(string barcode);
    }
}
