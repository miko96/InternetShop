using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IShop.WebApi.Entities.Comment
{
    public class CommentCreate
    {
        public int PostId { get; set; }
        public string CommentText { get; set; }
    }

    public class CommentCreateValidatable : CommentCreate, IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (PostId < 1)
                yield return new ValidationResult("Should have positive value", new[] { nameof(PostId) });

            if (string.IsNullOrEmpty(CommentText))
                yield return new ValidationResult("Should have not empty value", new[] { nameof(CommentText) });
        }
    }
}
