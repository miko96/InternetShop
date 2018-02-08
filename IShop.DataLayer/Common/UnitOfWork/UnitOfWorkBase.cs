using System;
using System.Collections.Concurrent;
using Microsoft.EntityFrameworkCore;

namespace IShop.DataLayer.Common.UnitOfWork
{
    public class UnitOfWorkBase : DbContext, IUnitOfWork
    {
        public UnitOfWorkBase(DbContextOptions options) : base(options) { }

        private readonly ConcurrentDictionary<Type, object> _repositoryCache = new ConcurrentDictionary<Type, object>();

        public IRepository<TDomain> GetRepository<TDomain>()
            where TDomain : class
        {
            return
                (RepositoryBase<TDomain>)
                _repositoryCache.GetOrAdd(typeof(TDomain), new RepositoryBase<TDomain>(this));
        }
    }
}
