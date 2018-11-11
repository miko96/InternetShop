using IShop.DataLayer.Common.DbContextBase;
using IShop.DataLayer.Common.RepositoryBase;
using IShop.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace IShop.DataLayer.ShopDbContext
{
    public class ShopDbContext : DbContextBase, IShopDbContext
    {
        public IRepository<Post> PostRepository => GetRepository<Post>();
        public IRepository<Comment> CommentRepository => GetRepository<Comment>();


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

        public ShopDbContext(DbContextOptions options) : base(options) { }
    }
}
