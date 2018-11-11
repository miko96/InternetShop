using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IShop.WebApi.Entities.Comment;

namespace IShop.WebApi.Entities.Post
{
    public class PostCreate
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public ICollection<CommentCreate> Comments { get; set; }
    }

    public class PostCreateValidatable : PostCreate, IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Title))
                yield return new ValidationResult("Post should have a title", new[] { nameof(Title) });

            if (string.IsNullOrEmpty(Content))
                yield return new ValidationResult("Post should have content", new[] { nameof(Content) });

            if (Comments == null || Comments.Count < 1)
                yield return new ValidationResult("Post should have at least one comment", new[] { nameof(Comments) });
        }
    }
}
