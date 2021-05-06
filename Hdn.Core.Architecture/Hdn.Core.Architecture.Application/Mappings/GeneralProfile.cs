using AutoMapper;
using Hdn.Core.Architecture.Application.Dtos.Product;
using Hdn.Core.Architecture.Application.Dtos.Tenant;
using Hdn.Core.Architecture.Domain.Entities;

namespace Hdn.Core.Architecture.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<ProductRequest, Product>();
            CreateMap<TenantRequest, Tenant>();
        }
    }
}
