namespace IShop.WebApi.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int? PostId { get; set; }
        public string CommentText { get; set; }
    }
}