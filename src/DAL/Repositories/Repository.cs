﻿using DAL.Contexts;
using DAL.IRepositories;
using Domain.Commons;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DAL.Repositories;

public class Repository<T> : IRepository<T> where T : Auditable
{
    private readonly AppDbContext appDbContext;
    public readonly DbSet<T> dbSet;
    public Repository(AppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
        dbSet = appDbContext.Set<T>();
    }

    public async Task AddAsync(T entity)
    {
        await dbSet.AddAsync(entity);
    }
    public void Modify(T entity)
    {
        appDbContext.Entry(entity).State = EntityState.Modified;
    }

    public void Remove(T entity)
    {
        dbSet.Remove(entity);
    }

    public IQueryable<T> SelectAll(Expression<Func<T, bool>> expression = null, bool isNotTraces = true, string[] includes = null)
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

    public async Task<T> SelectAsync(Expression<Func<T, bool>> expression, string[] includes = null)
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
    public async Task SaveAsync()
    {

        await appDbContext.SaveChangesAsync();
    }
}
