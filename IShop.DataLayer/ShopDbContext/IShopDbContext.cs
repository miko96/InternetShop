using IShop.DataLayer.Entities;
using IShop.DataLayer.Common.RepositoryBase;
using System.Threading.Tasks;

namespace IShop.DataLayer.ShopDbContext
{
    public interface IShopDbContext
    {
        IRepository<Post> PostRepository { get; }
        IRepository<Comment> CommentRepository { get; }

        Task SaveAsync();
    }
}
