using System;
using AutoMapper;
using IShop.BussinesLayer.Entities;
using IShop.BussinesLayer.Providers.Interfaces;
using IShop.DataLayer;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain = IShop.DataLayer.Entities;

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

        public async Task<string> CreateProduct(ProductCreate product)
        {
            var domainProduct = _mapper.Map<Domain.ProductItem>(product);

            _shopUnitOfWork.ProductItems.Add(domainProduct);

            await _shopUnitOfWork.SaveAsync();

            return domainProduct.ProductKey;
        }

        public async Task<ICollection<ProductItem>> GetAllProducts()
        {
            var products = await _shopUnitOfWork.ProductItems.All
                .ToListAsync();

            return
                _mapper.Map<ICollection<ProductItem>>(products);
        }

        public async Task<ProductItem> GetProduct(int productId)
        {
            var product = await _shopUnitOfWork.ProductItems.All
                .FirstOrDefaultAsync(x=> x.ProductItemId == productId);

            await Task.Delay(2000);

            if (product == null) 
                throw new Exception();

            return 
                _mapper.Map<ProductItem>(product);
        }
    }
}
