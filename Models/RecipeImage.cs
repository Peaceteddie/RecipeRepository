using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace RecipeRepository;

public class RecipeImage
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string? Path { get; set; }
    [Required]
    public string? OriginalName { get; set; }
}