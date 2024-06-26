using System.ComponentModel.DataAnnotations;

namespace RecipeRepository;

public class Ingredient
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public float Quantity { get; set; }
    [Required]
    public IngredientUnit Unit { get; set; }
    public int RecipeId { get; set; }
    public Recipe? Recipe { get; set; }
}
