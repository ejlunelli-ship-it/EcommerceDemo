using Ecommerce.Domain.Repositories;
using Ecommerce.Infaestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infaestructure.Repositories;
public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    private readonly AppDbContext _appDbContext;

    public RepositoryBase(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task AddAsync(T entity)
    {
        await _appDbContext.Set<T>().AddAsync(entity);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = GetByIdAsync(id);
        if (entity != null)
        {
            _appDbContext.Set<T>().Remove(entity.Result!);
            await _appDbContext.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _appDbContext.Set<T>().ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _appDbContext.Set<T>().FindAsync(id);
    }
    public void Update(T entity)
    {
      _appDbContext.Set<T>().Update(entity);
    }

    public async Task SaveChangesAsync()
    {
        await _appDbContext.SaveChangesAsync();
    }
}
