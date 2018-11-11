namespace IShop.WebApi.Entities.Comment
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public string CommentText { get; set; }
    }
}
