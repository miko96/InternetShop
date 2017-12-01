using Microsoft.Extensions.DependencyInjection;

namespace IShop.WebApi
{
    public static class DIContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            DataLayer.DIContainer.RegisterServices(services);

            services.AddMvc();
        }
    }
}
