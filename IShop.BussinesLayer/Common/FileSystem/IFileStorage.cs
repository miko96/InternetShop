using System.IO;
using System.Threading.Tasks;

namespace IShop.BussinesLayer.Common.FileSystem
{
    public interface IFileStorage
    {
        Task CreateFile(string fileKey, Stream stream);
    }
}
