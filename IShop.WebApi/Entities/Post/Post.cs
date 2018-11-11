using System.Collections.Generic;

namespace IShop.WebApi.Entities.Post
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public ICollection<Comment.Comment> Comments { get; set; }
    }
}
