using Microsoft.Extensions.DependencyInjection;
using IShop.BussinesLayer.Providers.Interfaces;
using IShop.BussinesLayer.Providers;

namespace IShop.BussinesLayer
{
    public static class DiContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            DataLayer.DiContainer.RegisterServices(services);
            
            services.AddScoped<ICommentProvider, CommentProvider>();
            services.AddScoped<IPostProvider, PostProvider>();
        }
    }
}
