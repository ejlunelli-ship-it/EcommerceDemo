using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Repositories;
using Ecommerce.Infaestructure.Data;

namespace Ecommerce.Infaestructure.UnitOfWork;
public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _appDbContext;
    public IOrderRepository Orders { get; }

    public IOrderProductRepository OrderProducts { get; }

    public UnitOfWork(AppDbContext appDbContext,
                      IOrderRepository orders,
                      IOrderProductRepository orderProducts)
    {
        _appDbContext = appDbContext;
        Orders = orders;
        OrderProducts = orderProducts;
    }

    public async Task<int> ComitAsync(){
        
        return await _appDbContext.SaveChangesAsync();
    }

    public void Dispose() => _appDbContext.Dispose();
}
