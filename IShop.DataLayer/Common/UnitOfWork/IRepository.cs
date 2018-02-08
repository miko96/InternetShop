using System.Collections.Generic;
using System.Linq;

namespace IShop.DataLayer.Common.UnitOfWork
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IRepository<TEntity> Add(TEntity entity);
        IRepository<TEntity> AddRange(IEnumerable<TEntity> entities);
        IRepository<TEntity> Remove(TEntity entity);
        IRepository<TEntity> RemoveRange(IEnumerable<TEntity> entities);
        IRepository<TEntity> Update(TEntity domain);
        IQueryable<TEntity> All { get; }
    }
}
