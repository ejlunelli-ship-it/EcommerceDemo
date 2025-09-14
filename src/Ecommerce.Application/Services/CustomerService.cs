using AutoMapper;
using Ecommerce.Application.Dtos;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Repositories;

namespace Ecommerce.Application.Services;
public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task AddAsync(CustomerDto entity)
    {
        var customer = _mapper.Map<Customer>(entity);
        await _customerRepository.AddAsync(customer);
    }

    public async Task DeleteAsync(int id)
    {
        var customer = await _customerRepository.GetByIdAsync(id);
        if (customer is null)
            throw new Exception("The customer does not exist");
        await _customerRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<CustomerDto>> GetAllAsync()
    {
        var customers = await _customerRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<CustomerDto>>(customers);
    }

    public async Task<CustomerDto?> GetByIdAsync(int id)
    {
        var customer = await _customerRepository.GetByIdAsync(id);
        return _mapper.Map<CustomerDto>(customer);
    }

    public async Task UpdateAsync(CustomerDto entity)
    {
        var customer = _mapper.Map<Customer>(entity);
        _customerRepository.Update(customer);
        await _customerRepository.SaveChangesAsync();
    }
}
