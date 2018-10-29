using IShop.DataLayer.Common;
using IShop.DataLayer.Common.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IShop.DataLayer
{
    public static class DIContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped(opt => UnitOfWorkFactory.Create());
        }
    }
}
