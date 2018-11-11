using System.Collections.Generic;
using IShop.BussinesLayer.Entities.Comment;

namespace IShop.BussinesLayer.Entities.Post
{
    public class PostCreate
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public ICollection<CommentCreate> Comments { get; set; }
    }
}
