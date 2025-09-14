using AutoMapper;
using Ecommerce.Application.Dtos;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Repositories;

namespace Ecommerce.Application.Services;
public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public OrderService(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task AddAsync(OrderDto entity)
    {
        var order = _mapper.Map<Order>(entity);
        await _orderRepository.AddAsync(order);
    }

    public async Task DeleteAsync(int id)
    {
        var order = await _orderRepository.GetByIdAsync(id);
        if (order is null)
            throw new Exception("The order does not exist");
        await _orderRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<OrderDto>> GetAllAsync()
    {
        var orders = await _orderRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<OrderDto>>(orders);
    }

    public async Task<OrderDto?> GetByIdAsync(int id)
    {
        var order = await _orderRepository.GetByIdAsync(id);
        return _mapper.Map<OrderDto>(order);
    }

    public async Task UpdateAsync(OrderDto entity)
    {
        var order = _mapper.Map<Order>(entity);
        _orderRepository.Update(order);
        await _orderRepository.SaveChangesAsync();
    }
}
