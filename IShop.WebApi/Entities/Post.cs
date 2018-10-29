using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IShop.WebApi.Entities
{
    public class Post : IValidatableObject
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public ICollection<Comment> Comments { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Title))
                yield return new ValidationResult("Post should have a title", new[] { nameof(Title) });

            if (string.IsNullOrEmpty(Content))
                yield return new ValidationResult("Post should have content", new[] { nameof(Content) });

            if (Comments?.Count > 0)
                yield break;
            else
                yield return new ValidationResult("Post should have at least one comment", new[] { nameof(Comments) });
        }
    }
}
