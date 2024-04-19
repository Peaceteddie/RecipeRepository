using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeRepository;

[Table("Recipes")]
public class Recipe
{
    [Key]
    public int Id { get; set; }
    [Required]
    public required string Name { get; set; }
    [Required]
    public required string Description { get; set; }
    [Required]
    public required List<Ingredient> Ingredients { get; set; }
    [Required]
    public required List<string> Instructions { get; set; }
    [Required]
    public required string Image { get; set; }
}
