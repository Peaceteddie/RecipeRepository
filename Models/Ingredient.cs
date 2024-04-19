using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeRepository;

[Table("Ingredients")]
public class Ingredient
{
    [Key]
    public int Id { get; set; }
    [Required]
    public required string Name { get; set; }
    [Required]
    public float Quantity { get; set; }
    [Required]
    public IngredientUnit Unit { get; set; }
    public int RecipeId { get; set; }
    public Recipe? Recipe { get; set; }
}
