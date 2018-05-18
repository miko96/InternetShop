using Microsoft.Extensions.DependencyInjection;
using IShop.BussinesLayer.Providers.Interfaces;
using IShop.BussinesLayer.Providers;
using IShop.BussinesLayer.Common.FileSystem;

namespace IShop.BussinesLayer
{
    public static class DiContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            DataLayer.DiContainer.RegisterServices(services);
            
            //providers
            services.AddScoped<ICommentProvider, CommentProvider>();
            services.AddScoped<IPostProvider, PostProvider>();
            services.AddScoped<IProductItemProvider, ProductItemProvider>();
            services.AddScoped<IProductImagesProvider, ProductImagesProvider>();

            //common
            services.AddScoped<IFileProvider, FileProvider>();

            services.AddScoped<IFileStorage, FileStorage>(sp =>
            {
                var fileProvider = sp.GetService<IFileProvider>();
                return new FileStorage(@"wwwroot\\images", fileProvider);
            });
        }
    }
}
