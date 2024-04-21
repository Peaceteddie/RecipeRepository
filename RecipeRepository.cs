using Microsoft.EntityFrameworkCore;
namespace RecipeRepository;
public class RecipeDbContext : DbContext
{
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<RecipeImage> RecipeImages { get; set; }
    public async Task<List<Recipe>> GetRecipesWithIngredients()
    => await Recipes.Include(r => r.Ingredients).Include(r => r.Image).ToListAsync();
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string host = DotNetEnv.Env.GetString("POSTGRES_HOST");
        string port = DotNetEnv.Env.GetString("POSTGRES_PORT");
        string database = DotNetEnv.Env.GetString("POSTGRES_DB");
        string username = DotNetEnv.Env.GetString("POSTGRES_USER");
        string password = DotNetEnv.Env.GetString("POSTGRES_PASSWORD");
        optionsBuilder.UseNpgsql($"Host={host};Port={port};Database={database};Username={username};Password={password}");
    }
}
