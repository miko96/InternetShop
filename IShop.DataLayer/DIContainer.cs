using IShop.DataLayer.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IShop.DataLayer
{
    public static class DIContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddDbContext<ShopContext>(options => options.UseSqlServer(AppSettings.ConnectionString));
            
        }
    }
}
