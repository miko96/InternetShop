using AutoMapper;
using IShop.BussinesLayer.Providers.Interfaces;
using IShop.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IShop.WebApi.Controllers
{
    [Route("api/products")]
    public class ProductItemController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProductItemProvider _productItemProvider;

        public ProductItemController(
            IMapper mapper,
            IProductItemProvider productItemProvider)
        {
            _mapper = mapper;
            _productItemProvider = productItemProvider;
        }

        [HttpGet, Route("all")]
        public async Task<ICollection<ProductItem>> AllProducts()
        {
            return 
                _mapper.Map<ICollection<ProductItem>>(
                    await _productItemProvider.GetAllProducts()
                );
        }

    }
}
