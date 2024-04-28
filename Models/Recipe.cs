using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeRepository;

public class Recipe
{
    [Key] public int Id { get; set; }
    [Required] public string? Name { get; set; }
    public TimeSpan PreparationTime { get; set; }
    public TimeSpan CookingTime { get; set; }
    [Required] public string? Description { get; set; }
    public List<int> CookingComplexity { get; set; } = [];
    public List<RecipeCategory> Categories { get; set; } = [];
    [Required] public List<Ingredient> Ingredients { get; set; } = [];
    [Required] public List<string> Instructions { get; set; } = [];
    [Required] public RecipeImage? Image { get; set; } = new RecipeImage();
    public int? ImageId { get; set; }
    public List<RecipeTag> Tags { get; set; } = [];
    public List<int> Ratings { get; set; } = [];
    public List<Comment> Comments { get; set; } = [];


    [NotMapped] public bool IsUploadInProgress = false;

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

public class Comment
{
    [Key] public int Id { get; set; }
    [Required] public string? Author { get; set; }
    [Required] public string? Content { get; set; }
    public int Rating { get; set; }
    public Recipe? Recipe { get; set; }
    public int RecipeId { get; set; }
}

public class RecipeTag
{
    [Key] public int Id { get; set; }
    [Required] public string? Name { get; set; }
    public List<Recipe> Recipes { get; set; } = [];
}

public class RecipeCategory
{
    [Key] public int Id { get; set; }
    [Required] public string? Name { get; set; }
    public List<Recipe> Recipes { get; set; } = [];
}