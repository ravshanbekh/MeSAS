using DAL.Contexts;
using DAL.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DAL.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly AppDbContext appDbContext;
    public readonly DbSet<T> dbSet;
    public Repository(AppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
        dbSet = appDbContext.Set<T>();
    }

    public async Task CrateAsycn(T entity)
    {
        await dbSet.AddAsync(entity);
    }
    public void Update(T entity)
    {
        appDbContext.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(T entity)
    {
        dbSet.Remove(entity);
    }

    public IQueryable<T> GetAll(Expression<Func<T, bool>> expression = null, bool isNotTraces = true, string[] includes = null)
    {
        IQueryable<T> query = expression is null ? dbSet.AsQueryable() : dbSet.Where(expression).AsQueryable();
        query = isNotTraces ? query.AsTracking() : query;

        if (includes is not null)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }
        return query;
    }

    public async Task<T> GetAsync(Expression<Func<T, bool>> expression = null, string[] includes = null)
    {

        IQueryable<T> query = dbSet.Where(expression).AsQueryable();

        if (includes is not null)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }

        var entity = await query.FirstOrDefaultAsync(expression);

        return entity;
    }
    public async Task SaveAsyc()
    {

        await appDbContext.SaveChangesAsync();
    }
}
