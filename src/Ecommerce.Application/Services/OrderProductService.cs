using AutoMapper;
using Ecommerce.Application.Dtos;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Repositories;

namespace Ecommerce.Application.Services;
public class OrderProductService : IOrderProductService
{
    private readonly IOrderProductRepository _orderProductRepository;
    private readonly IMapper _mapper;

    public OrderProductService(IOrderProductRepository orderProductRepository, IMapper mapper)
    {
        _orderProductRepository = orderProductRepository;
        _mapper = mapper;
    }

    public async Task AddAsync(OrderProductDto entity)
    {
        var orderProduct = _mapper.Map<OrderProduct>(entity);
        await _orderProductRepository.AddAsync(orderProduct);
    }

    public async Task DeleteAsync(int id)
    {
        var orderProduct = await _orderProductRepository.GetByIdAsync(id);
        if (orderProduct is null)
            throw new Exception("The order product does not exist");
        await _orderProductRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<OrderProductDto>> GetAllAsync()
    {
        var orderProducts = await _orderProductRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<OrderProductDto>>(orderProducts);
    }

    public async Task<OrderProductDto?> GetByIdAsync(int id)
    {
        var orderProduct = await _orderProductRepository.GetByIdAsync(id);
        return _mapper.Map<OrderProductDto>(orderProduct);
    }

    public async Task UpdateAsync(OrderProductDto entity)
    {
        var orderProduct = _mapper.Map<OrderProduct>(entity);
        _orderProductRepository.Update(orderProduct);
        await _orderProductRepository.SaveChangesAsync();
    }
}
