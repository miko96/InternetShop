using System.Collections.Generic;
using System.Linq;

namespace IShop.DataLayer.Common
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        void Attach(TEntity entity);
        IQueryable<TEntity> All { get; }
    }
}
