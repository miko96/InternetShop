using IShop.DataLayer.ShopDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IShop.DataLayer
{
    public static class DiContainer
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            ConfigureDbContext(services, configuration);
        }

        private static void ConfigureDbContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IShopDbContext>(sp =>
            {
                var connectionString =
                    configuration.GetConnectionString("ShopDataBase");

                var contextOptions = new DbContextOptionsBuilder()
                    .UseSqlServer(connectionString).Options;

                return new ShopDbContext.ShopDbContext(contextOptions);
            });

        }
    }
}
