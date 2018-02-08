using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace IShop.WebApi
{
    public static class DIContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            BussinesLayer.DIContainer.RegisterServices(services);

            services.AddMvc()
                .AddJsonOptions(
                        options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );

            services.AddAutoMapper(cfg => cfg.AddProfiles("IShop.WebApi", "IShop.BussinesLayer"));
        }
    }
}
