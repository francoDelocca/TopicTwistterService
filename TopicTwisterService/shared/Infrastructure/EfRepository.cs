using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TopicTwisterService.shared.Domain;

public class EfRepository<T> : IAsyncRepository<T> where T : class
{

    #region Fields

    protected DataContext Context;

    #endregion

    public EfRepository(DataContext context)
    {
        Context = context;
    }

    #region Public Methods

    public async Task<T> GetById(int id) => await Context.Set<T>().FindAsync(id);

    public Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate)
        => Context.Set<T>().FirstOrDefaultAsync(predicate);

    public async Task Add(T entity)
    {
        // await Context.AddAsync(entity);
        await Context.Set<T>().AddAsync(entity);
        await Context.SaveChangesAsync();
    }

    public Task Update(T entity)
    {
        // In case AsNoTracking is used
        Context.Entry(entity).State = EntityState.Modified;
        return Context.SaveChangesAsync();
    }

    public Task Remove(T entity)
    {
        Context.Set<T>().Remove(entity);
        return Context.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await Context.Set<T>().ToListAsync();
    }

    public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
    {
        return await Context.Set<T>().Where(predicate).ToListAsync();
    }

    public Task<int> CountAll() => Context.Set<T>().CountAsync();

    public Task<int> CountWhere(Expression<Func<T, bool>> predicate)
        => Context.Set<T>().CountAsync(predicate);

    public async Task<bool> Any(Expression<Func<T, bool>> predicate) => await Context.Set<T>().AnyAsync(predicate);
    

    #endregion

}

