using System.Linq.Expressions;
using ApiTrottling.Application.Common.Interfaces.Repositories;
using ApiTrottling.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ApiTrottling.Infrastructure.Repositories.EF;

public class GenericEFRepository<T> : IEFRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;

    public GenericEFRepository(ApplicationDbContext applicationDbContext)
    {
        _context = applicationDbContext;
    }
     public virtual T Insert(T entity)
    {
        return _context
            .Add(entity)
            .Entity;    
    }

    public virtual T Update(T entity)
    {
        return _context.Update(entity)
            .Entity;    
    }

    public virtual bool Delete(T entity)
    {
        _context.Remove(entity);
        
        var count = _context.SaveChanges();
        return count >= 1;
    }

    public async virtual Task<T?> Get(int id, CancellationToken cancellationToken)
    {
        return await _context.FindAsync<T>(new object[] {id}, cancellationToken);
    }

    public async virtual Task<T?> Get(string id, CancellationToken cancellationToken)
    {
        return await _context.FindAsync<T>(new object[] {id}, cancellationToken);
    }
    
    public async virtual Task<IEnumerable<T?>> Find(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken, bool noTrack = false)
    {
        var query = _context.Set<T>()
            .AsQueryable()
            .Where(predicate);
        
        if(noTrack)
        {
            query = query.AsNoTracking();
        }

        return await query.ToListAsync(cancellationToken);    
    }

    public async Task<IEnumerable<T?>> All(CancellationToken cancellationToken)
    {
        return await _context.Set<T>().ToListAsync(cancellationToken);
    }

    public async Task<bool> Exists(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
    {
        var result =  await _context.Set<T>()
            .AsQueryable()
            .Where(predicate)
            .CountAsync(cancellationToken);

        return result > 0;    }

    public async virtual Task<int> SaveChanges(CancellationToken cancellationToken)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}