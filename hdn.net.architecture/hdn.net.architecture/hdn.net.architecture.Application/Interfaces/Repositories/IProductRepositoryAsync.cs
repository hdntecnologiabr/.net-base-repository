using hdn.net.architecture.Domain.Entities;
using System.Threading.Tasks;

namespace hdn.net.architecture.Application.Interfaces.Repositories
{
    public interface IProductRepositoryAsync : IGenericRepositoryAsync<Product>
    {
        Task<bool> IsUniqueBarcodeAsync(string barcode);
    }
}
