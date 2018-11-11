using IShop.BussinesLayer.Providers;
using IShop.BussinesLayer.Providers.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IShop.BussinesLayer
{
    public static class DiContainer
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            DataLayer.DiContainer.ConfigureServices(services, configuration);
            
            services.AddScoped<ICommentProvider, CommentProvider>();
            services.AddScoped<IPostProvider, PostProvider>();
        }
    }
}
