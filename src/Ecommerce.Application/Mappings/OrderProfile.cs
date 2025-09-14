using AutoMapper;
using Ecommerce.Application.Dtos;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Mappings;
public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<Order,OrderDto>().ReverseMap();
    }
}
