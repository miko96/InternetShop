using Microsoft.EntityFrameworkCore;

namespace IShop.DataLayer.Common.UnitOfWork
{
    public class UnitOfWorkFactory
    {
        public static IShopUnitOfWork Create()
        {
            var otionBuilder = new DbContextOptionsBuilder();
            otionBuilder.UseSqlServer(AppSettings.ConnectionString);
            return new ShopUnitOfWork(otionBuilder.Options);    
        }
    }
}
