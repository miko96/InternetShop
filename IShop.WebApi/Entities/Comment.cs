namespace IShop.WebApi.Entities
{
    public class Comment //: IValidatableObject
    {
        public int CommentId { get; set; }
        public int? PostId { get; set; }
        public string CommentText { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    List<ValidationResult> errors = new List<ValidationResult>();

        //    if (CommentText.Length > 255)
        //    {
        //        errors.Add(new ValidationResult($"parameter '{nameof(CommentText)}' so long"));
        //    }

        //    if (PostId == null)
        //    {
        //        errors.Add(new ValidationResult($"parameter '{nameof(PostId)}' is required"));
        //    }

        //    return errors;
        //}
    }
}
