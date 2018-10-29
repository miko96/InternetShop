using IShop.BussinesLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IShop.BussinesLayer.Providers.Interfaces
{
    public interface IProductItemProvider
    {
        Task<ICollection<ProductItem>> GetAllProducts();
    }
}
