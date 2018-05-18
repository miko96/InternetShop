using System.IO;
using System.Threading.Tasks;
using IShop.BussinesLayer.Common.FileSystem;
using IShop.BussinesLayer.Providers.Interfaces;

namespace IShop.BussinesLayer.Providers
{
    public class ProductImagesProvider : IProductImagesProvider
    {
        private readonly IFileStorage _fileStorage;

        public ProductImagesProvider(IFileStorage fileStorage)
        {
            _fileStorage = fileStorage;
        }

        public Task SaveImage(string imagePath, Stream stream)
        {
            return _fileStorage.CreateFile(imagePath, stream);
        }
    }
}
