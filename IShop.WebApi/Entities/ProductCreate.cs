using Microsoft.AspNetCore.Http;

namespace IShop.WebApi.Entities
{
    public class ProductCreate
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile File { get; set; }
    }
}
