using System.IO;
using System.Threading.Tasks;

namespace IShop.BussinesLayer.Providers.Interfaces
{
    public interface IProductImagesProvider
    {
        Task SaveImage(string imageName, Stream stream);
    }
}
