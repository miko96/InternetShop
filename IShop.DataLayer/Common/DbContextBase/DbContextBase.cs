using System;
using System.Collections.Concurrent;
using IShop.DataLayer.Common.RepositoryBase;
using Microsoft.EntityFrameworkCore;

namespace IShop.DataLayer.Common.DbContextBase
{
    public class DbContextBase : DbContext
    {
        public DbContextBase(DbContextOptions options) : base(options) { }

        private readonly ConcurrentDictionary<Type, object> _repositoryCache = new ConcurrentDictionary<Type, object>();

        public IRepository<TDomain> GetRepository<TDomain>() where TDomain : class
        {
            return (RepositoryBase<TDomain>)
                _repositoryCache.GetOrAdd(typeof(TDomain), new RepositoryBase<TDomain>(this));
        }
    }
}
