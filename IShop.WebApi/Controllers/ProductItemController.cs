using System;
using AutoMapper;
using IShop.BussinesLayer.Providers.Interfaces;
using IShop.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using Business = IShop.BussinesLayer.Entities;

namespace IShop.WebApi.Controllers
{
    [Route("api/products")]
    public class ProductItemController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProductItemProvider _productItemProvider;
        private readonly IProductImagesProvider _productImagesProvider;

        public ProductItemController(
            IMapper mapper,
            IProductItemProvider productItemProvider,
            IProductImagesProvider productImagesProvider)
        {
            _mapper = mapper;
            _productItemProvider = productItemProvider;
            _productImagesProvider = productImagesProvider;
        }

        [HttpPost, Route("create")]
        public async Task<string> CreateProduct([FromForm] ProductCreate product)
        {
            var productKey = Guid.NewGuid().ToString();
            var imageKey = $"{productKey}{Path.GetExtension(product.File.FileName)}";

            using (var source = product.File.OpenReadStream())
            {
                await _productImagesProvider.SaveImage(imageKey, source);
            }

            return await _productItemProvider.CreateProduct(
                new Business.ProductCreate
                {
                    ProductKey = productKey,
                    Name = product.Name,
                    Description = product.Description,
                    ImageKey = imageKey
                });
        }

        [HttpGet, Route("all")]
        public async Task<ICollection<ProductItem>> AllProducts()
        {
            var products = await _productItemProvider.GetAllProducts();

            return
                _mapper.Map<ICollection<ProductItem>>(products);
        }

        [HttpGet, Route("{productKey}")]
        public async Task<ProductItem> GetProduct(int productKey)
        {
            var product =
                await _productItemProvider.GetProduct(productKey);

            return
                _mapper.Map<ProductItem>(product);
        }

    }
}
