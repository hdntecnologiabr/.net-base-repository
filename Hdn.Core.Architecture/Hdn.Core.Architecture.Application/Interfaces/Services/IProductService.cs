using Hdn.Core.Architecture.Application.Dtos.Product;
using Hdn.Core.Architecture.Application.Wrappers;
using System.Threading.Tasks;

namespace Hdn.Core.Architecture.Application.Interfaces.Services
{
    public interface IProductService
    {
        Task<Response<int>> Create(ProductRequest productRequest);
    }
}
