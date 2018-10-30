using IShop.DataLayer.Common.UnitOfWork;
using IShop.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace IShop.DataLayer
{
    public class ShopUnitOfWork : UnitOfWorkBase, IShopUnitOfWork
    {
        public IRepository<Post> Posts => GetRepository<Post>();
        public IRepository<Comment> Comments => GetRepository<Comment>();

        private const string DefaultShema = "ISH";
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(DefaultShema);

            modelBuilder.Entity<Post>().ToTable(nameof(Post));
            modelBuilder.Entity<Comment>().ToTable(nameof(Comment));
        }

        public async Task SaveAsync()
        {
            await SaveChangesAsync();
        }

        public ShopUnitOfWork(DbContextOptions options) : base(options) { }
    }
}
