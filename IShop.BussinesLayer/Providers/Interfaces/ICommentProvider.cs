using System.Collections.Generic;
using System.Threading.Tasks;
using IShop.BussinesLayer.Entities.Comment;

namespace IShop.BussinesLayer.Providers.Interfaces
{
    public interface ICommentProvider
    {
        Task<Comment> CreateComment(CommentCreate commentCreate);
        Task<Comment> UpdateComment(CommentUpdate commentUpdate);
        Task DeleteComment(int commentId);
        Task<Comment> GetComment(int commentId);
        Task<ICollection<Comment>> GetAllComments();
        Task<ICollection<Comment>> GetPostComments(int postId);
    }
}
