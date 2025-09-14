using Ecommerce.Domain.Repositories;

namespace Ecommerce.Application.Interfaces;
public interface IUnitOfWork : IDisposable
{
    IOrderRepository Orders { get; }
    IOrderProductRepository OrderProducts { get; }
}
