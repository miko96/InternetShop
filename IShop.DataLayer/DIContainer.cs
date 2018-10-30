using IShop.DataLayer.Common.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace IShop.DataLayer
{
    public static class DiContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped(opt => UnitOfWorkFactory.Create());
        }
    }
}
