using System.Data;
using IShop.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace IShop.DataLayer
{
    public class ShopContext : DbContext
    {
        private const string DefaultShema = "ISH";

        public ShopContext(DbContextOptions<ShopContext> options) : base(options) { }

        public DbSet<TestTable> TestTables { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(DefaultShema);
            modelBuilder.Entity<TestTable>().ToTable(nameof(TestTable));
        }
    }
}
