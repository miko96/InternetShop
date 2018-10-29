using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using IShop.BussinesLayer.Mapping;
using IShop.BussinesLayer.Providers.Interfaces;
using IShop.BussinesLayer.Providers;

namespace IShop.BussinesLayer
{
    public static class DIContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            DataLayer.DIContainer.RegisterServices(services);
            
            services.AddScoped<ICommentProvider, CommentProvider>();
            services.AddScoped<IPostProvider, PostProvider>();
        }
    }
}
