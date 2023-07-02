using UserApp.Data.Repositories.Base;
using UserApp.Data.Repositories.Interfaces;
using UserApp.EFCore.Models;

namespace UserApp.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private UserAppDbContext _dbContext;
        private Dictionary<Type, object> _repositories;

        public UnitOfWork(UserAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }
        public async Task<int> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            _repositories = _repositories ?? new Dictionary<Type, object>();

            var type = typeof(TEntity);
            if (!_repositories.ContainsKey(type))
            {
                _repositories[type] = new GenericRepository<TEntity>(_dbContext);
            }
            return (IGenericRepository<TEntity>)_repositories[type];
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_dbContext != null)
                {
                    _dbContext.Dispose();
                    _dbContext = null;
                }
            }
        }
    }
}
