using AutoMapper;
using Ecommerce.Application.Dtos;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Repositories;

namespace Ecommerce.Application.Services;
public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task AddAsync(OrderDto entity)
    {
        var order = _mapper.Map<Order>(entity);
        await _unitOfWork.Orders.AddAsync(order);
        await _unitOfWork.ComitAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var order = await _unitOfWork.Orders.GetByIdAsync(id);
        if (order is null)
            throw new Exception("The order does not exist");
        await _unitOfWork.DeleteOrderWithProductsAsync(id);
        await _unitOfWork.ComitAsync();
    }

    public async Task<IEnumerable<OrderDto>> GetAllAsync()
    {
        var orders = await _unitOfWork.Orders.GetAllAsync();
        return _mapper.Map<IEnumerable<OrderDto>>(orders);
    }

    public async Task<OrderDto?> GetByIdAsync(int id)
    {
        var order = await _unitOfWork.Orders.GetByIdAsync(id);
        return _mapper.Map<OrderDto>(order);
    }

    public async Task UpdateAsync(OrderDto entity)
    {
        var order = _mapper.Map<Order>(entity);
        _unitOfWork.Orders.Update(order);
        await _unitOfWork.ComitAsync();
    }
}
