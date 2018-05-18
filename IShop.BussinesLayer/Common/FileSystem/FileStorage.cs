using System.IO;
using System.Threading.Tasks;

namespace IShop.BussinesLayer.Common.FileSystem
{
    internal class FileStorage : IFileStorage
    {
        private readonly string _root;
        private readonly IFileProvider _fileProvider;

        public FileStorage(string storagePath, IFileProvider fileProvider)
        {
            _root = storagePath;
            _fileProvider = fileProvider;
        }

        public async Task CreateFile(string path, Stream source)
        {
            var fullPath = CombinePath(path);
            using (var target = _fileProvider.Open(fullPath, FileMode.Create, FileAccess.Write))
            {
                await source.CopyToAsync(target);
            }
        }

        private string CombinePath(string path)
        {
            return Path.Combine(_root, path);
        }
    }
}
