using IShop.BussinesLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IShop.BussinesLayer.Providers.Interfaces
{
    public interface IProductItemProvider
    {
        Task<string> CreateProduct(ProductCreate product);


        Task<ICollection<ProductItem>> GetAllProducts();
        Task<ProductItem> GetProduct(int productId);
    }
}
