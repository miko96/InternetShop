using IShop.BussinesLayer.Entities.Post;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IShop.BussinesLayer.Providers.Interfaces
{
    public interface IPostProvider
    {
        Task<Post> CreatePost(PostCreate postCreate);
        Task<Post> UpdatePost(PostUpdate postUpdate);
        Task DeletePost(int postId);
        Task<Post> GetPost(int postId);
        Task<ICollection<Post>> GetAllPosts();
    }
}
