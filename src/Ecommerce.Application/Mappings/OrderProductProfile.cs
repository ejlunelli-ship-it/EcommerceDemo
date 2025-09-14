using AutoMapper;
using Ecommerce.Application.Dtos;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Mappings;
public class OrderProductProfile : Profile
{
    public OrderProductProfile()
    {
        CreateMap<OrderProduct,OrderProductDto>().ReverseMap();
    }
}
