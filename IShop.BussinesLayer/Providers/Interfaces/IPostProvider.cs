using IShop.BussinesLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IShop.BussinesLayer.Providers.Interfaces
{
    public interface IPostProvider
    {
        Task CreatePost(Post post);
        Task UpdatePost(Post post);
        Task DeletePost(int postId);
        Task<Post> GetPost(int postId);
        Task<ICollection<Post>> GetAllPosts();
    }
}
