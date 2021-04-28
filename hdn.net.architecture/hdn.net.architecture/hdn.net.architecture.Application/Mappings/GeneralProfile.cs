using AutoMapper;
using hdn.net.architecture.Application.Features.Products.Commands.CreateProduct;
using hdn.net.architecture.Application.Features.Products.Queries.GetAllProducts;
using hdn.net.architecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace hdn.net.architecture.Application.Mappings
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
