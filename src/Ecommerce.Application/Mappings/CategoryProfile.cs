using AutoMapper;
using Ecommerce.Application.Dtos;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Mappings;
public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, CategoryDto>().ReverseMap();
    }
}
