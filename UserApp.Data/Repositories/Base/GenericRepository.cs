using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UserApp.Data.Repositories.Interfaces;
using UserApp.EFCore.Models;

namespace UserApp.Data.Repositories.Base
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly UserAppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(UserAppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public EntityState Add(T entity)
        {
            return _dbSet.Add(entity).State;
        }

        public EntityState Update(T entity)
        {
            return _dbSet.Update(entity).State;
        }

        public T Get<TKey>(TKey id)
        {
            return _dbSet.Find(id);
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }
    }
}
