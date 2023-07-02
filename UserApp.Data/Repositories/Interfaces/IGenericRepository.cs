using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace UserApp.Data.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        EntityState Add(T entity);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        T Get<TKey>(TKey id);
        EntityState Update(T entity);
    }
}