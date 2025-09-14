using AutoMapper;
using Ecommerce.Application.Dtos;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Mappings;
public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<Customer, CustomerDto>().ReverseMap();
    }
}
