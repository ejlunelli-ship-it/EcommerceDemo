using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Repositories;
using Ecommerce.Infaestructure.Data;

namespace Ecommerce.Infaestructure.Repositories;
public class OrderProductRepository : RepositoryBase<OrderProduct>, IOrderProductRepository
{
    public OrderProductRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }

}
