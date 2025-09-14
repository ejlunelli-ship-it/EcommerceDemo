using AutoMapper;
using Ecommerce.Application.Dtos;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Mappings;
public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
    }
}
