using System.Linq.Expressions;

namespace DAL.IRepositories;

public interface IRepository<T> where T : class
{
    Task CrateAsycn(T entity);
    void Update(T entity);
    void Delete(T entity);
    IQueryable<T> GetAll(Expression<Func<T, bool>> expression = null, bool isNotTraking = true, string[] includes = null);
    Task<T> GetAsync(Expression<Func<T, bool>> expression = null, string[] includes = null);
    Task SaveAsyc();
}
