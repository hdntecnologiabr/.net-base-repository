using AutoMapper;
using hdn.net.architecture.Application.Features.Products.Commands.CreateProduct;
using hdn.net.architecture.Application.Features.Products.Queries.GetAllProducts;
using hdn.net.architecture.Application.Features.Tenants.Commands.CreateTenant;
using hdn.net.architecture.Application.Features.Tenants.Queries.GetAllTenants;
using hdn.net.architecture.Domain.Entities;

namespace hdn.net.architecture.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            //Product
            CreateMap<Product, GetAllProductsViewModel>().ReverseMap();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<GetAllProductsQuery, GetAllProductsParameter>();

            //Tenant
            CreateMap<Tenant, GetAllTenantsViewModel>().ReverseMap();
            CreateMap<CreateTenantCommand, Tenant>();
            CreateMap<GetAllTenantsQuery, GetAllTenantsParameter>();
        }
    }
}
