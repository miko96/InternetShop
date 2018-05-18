using System.IO;

namespace IShop.BussinesLayer.Common.FileSystem
{
    internal class FileProvider : IFileProvider
    {
        public Stream Open(string path, FileMode mode, FileAccess access)
        {
            return File.Open(path, mode, access);
        }

    }
}
