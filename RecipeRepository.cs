using Microsoft.EntityFrameworkCore;
using DotNetEnv;

namespace RecipeRepository;
public class RecipeDbContext : DbContext
{
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<RecipeTag> RecipeTags { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<RecipeImage> RecipeImages { get; set; }
    public DbSet<SeasonalIngredient> SeasonalIngredients { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string host = Env.GetString("POSTGRES_HOST");
        string port = Env.GetString("POSTGRES_PORT");
        string database = Env.GetString("POSTGRES_DB");
        string username = Env.GetString("POSTGRES_USER");
        string password = Env.GetString("POSTGRES_PASSWORD");
        optionsBuilder.UseNpgsql($"Host={host};Port={port};Database={database};Username={username};Password={password}");
    }
}

public class AuthDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string host = Env.GetString("MYSQL_HOST");
        string port = Env.GetString("MYSQL_PORT");
        string database = Env.GetString("MYSQL_DB");
        string username = Env.GetString("MYSQL_USER");
        string password = Env.GetString("MYSQL_PASSWORD");
        optionsBuilder.UseNpgsql($"Host={host};Port={port};Database={database};Username={username};Password={password}");
    }
}
