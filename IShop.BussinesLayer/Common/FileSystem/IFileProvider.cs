using System.IO;

namespace IShop.BussinesLayer.Common.FileSystem
{
    internal interface IFileProvider
    {
        Stream Open(string path, FileMode mode, FileAccess access);
    }
}
