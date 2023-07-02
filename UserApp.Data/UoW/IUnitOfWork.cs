using UserApp.Data.Repositories.Interfaces;

namespace UserApp.Data.UoW
{
    public interface IUnitOfWork
    {
        int Commit();
        Task<int> CommitAsync();
        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
    }
}