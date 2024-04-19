using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeRepository;

[Table("Recipes")]
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
    public string? Image { get; set; }
}
