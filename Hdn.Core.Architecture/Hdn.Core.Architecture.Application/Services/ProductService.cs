using AutoMapper;
using Hdn.Core.Architecture.Application.Dtos.Product;
using Hdn.Core.Architecture.Application.Interfaces.Repositories;
using Hdn.Core.Architecture.Application.Interfaces.Services;
using Hdn.Core.Architecture.Application.Wrappers;
using Hdn.Core.Architecture.Domain.Entities;
using System.Threading.Tasks;

namespace Hdn.Core.Architecture.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Create(ProductRequest productRequest)
        {
            var product = _mapper.Map<Product>(productRequest);
            await _productRepository.AddAsync(product);
            return new Response<int>(product.Id);
        }
    }
}
