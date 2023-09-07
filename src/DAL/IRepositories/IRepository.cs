using Domain.Commons;
using System.Linq.Expressions;

namespace DAL.IRepositories;

public interface IRepository<T> where T : Auditable
{
    Task AddAsync(T entity);
    void Modify(T entity);
    void Remove(T entity);
    IQueryable<T> SelectAll(Expression<Func<T, bool>> expression = null, bool isNotTraking = true, string[] includes = null);
    Task<T> SelectAsync(Expression<Func<T, bool>> expression = null, string[] includes = null);
    Task SaveAsync();
}
