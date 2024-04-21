using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeRepository;

public class Recipe
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Description { get; set; }
    [Required]
    public List<Ingredient> Ingredients { get; set; } = [];
    [Required]
    public List<string> Instructions { get; set; } = [];
    [Required]
    public RecipeImage Image { get; set; } = new RecipeImage();

    [NotMapped]
    public bool IsUploadInProgress = false;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (IsUploadInProgress)
        {
            yield return new ValidationResult(
                "File has not finished uploading yet",
                [nameof(IsUploadInProgress)]);
        }
    }
}
