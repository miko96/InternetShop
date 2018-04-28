using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace IShop.WebApi
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        private static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureServices(DiContainer.RegisterServices)
                .UseStartup<Startup>()
                .UseUrls("http://localhost:8181/")
                .Build();
    }
}
