using AutoMapper;
using hdn.net._base.Application.Features.Products.Commands.CreateProduct;
using hdn.net._base.Application.Features.Products.Queries.GetAllProducts;
using hdn.net._base.Domain.Entities;

namespace hdn.net._base.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Product, GetAllProductsViewModel>().ReverseMap();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<GetAllProductsQuery, GetAllProductsParameter>();
        }
    }
}
