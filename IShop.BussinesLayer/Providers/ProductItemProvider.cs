using AutoMapper;
using IShop.BussinesLayer.Entities;
using IShop.BussinesLayer.Providers.Interfaces;
using IShop.DataLayer;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IShop.BussinesLayer.Providers
{
    public class ProductItemProvider : IProductItemProvider
    {
        private readonly IMapper _mapper;
        private readonly IShopUnitOfWork _shopUnitOfWork;

        public ProductItemProvider(
            IMapper mapper,
            IShopUnitOfWork shopUnitOfWork)
        {
            _mapper = mapper;
            _shopUnitOfWork = shopUnitOfWork;
        }

        public async Task<ICollection<ProductItem>> GetAllProducts()
        {
            var products = await _shopUnitOfWork.ProductItems.All
                .ToListAsync();

            return
                _mapper.Map<ICollection<ProductItem>>(products);
        }
    }
}
