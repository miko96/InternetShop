using IShop.BussinesLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IShop.BussinesLayer.Providers.Interfaces
{
    public interface ICommentProvider
    {
        Task CreateComment(Comment comment);
        Task UpdateComment(Comment comment);
        Task DeleteComment(int commentId);
        Task<Comment> GetComment(int commentId);
        Task<ICollection<Comment>> GetAllComments();
        Task<ICollection<Comment>> GetPostComments(int postId);
    }
}
