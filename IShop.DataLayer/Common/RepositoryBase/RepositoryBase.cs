using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace IShop.DataLayer.Common.RepositoryBase
{
    public class RepositoryBase<TDomain> : IRepository<TDomain> where TDomain : class
    {
        private readonly DbSet<TDomain> _set;

        public RepositoryBase(DbContext context)
        {
            _set = context.Set<TDomain>();
        }

        public IRepository<TDomain> Add(TDomain domain)
        {
            _set.Add(domain);
            return this;
        }

        public IRepository<TDomain> AddRange(IEnumerable<TDomain> domains)
        {
            _set.AddRange(domains);
            return this;
        }

        public IRepository<TDomain> Remove(TDomain domain)
        {
            _set.Remove(domain);
            return this;
        }

        public IRepository<TDomain> RemoveRange(IEnumerable<TDomain> domains)
        {
            _set.RemoveRange(domains);
            return this;
        }

        public IRepository<TDomain> Update(TDomain domain)
        {
            _set.Update(domain);
            return this;
        }

        public IQueryable<TDomain> All => _set.AsQueryable();
    }
}
