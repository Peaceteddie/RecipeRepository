
using System.ComponentModel.DataAnnotations;

namespace RecipeRepository;
public enum Season
{
    Spring,
    Summer,
    Autumn,
    Winter
}
public class SeasonalIngredient
{
    [Key]
    public int Id { get; set; }
    [Required]
    public required string Name { get; set; }
    [Required]
    public required Season Season { get; set; }
    [Required]
    public required string Image { get; set; }
    public List<Recipe> Recipes { get; set; }

    public SeasonalIngredient()
    {
        Recipes = [.. new RecipeDbContext().Recipes.Where(r => r.Ingredients.Any(I => I.Name != null && Name != null && I.Name.Contains(Name)))];
    }
}