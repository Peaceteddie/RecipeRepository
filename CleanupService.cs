using Microsoft.EntityFrameworkCore;

namespace RecipeRepository;
public class CleanupService(IServiceScopeFactory scopeFactory) : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory = scopeFactory;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            Cleanup();

            // Wait for 24 hours before running the task again
            await Task.Delay(TimeSpan.FromHours(24), stoppingToken);
        }
    }

    private void Cleanup()
    {
        var scope = _scopeFactory.CreateScope();
        var images = Directory.GetFiles(@"wwwroot/images");
        var dbContext = scope.ServiceProvider.GetRequiredService<RecipeDbContext>();

        // Remove local images that are not associated with any recipe
        foreach (var image in images)
        {
            var imageName = Path.GetFileName(image);
            var recipe =
                dbContext.Recipes
                .Include(r => r.Image)
                .FirstOrDefault(r => r.Image != null && r.Image.Path != null && r.Image.Path.Contains(imageName));

            if (recipe == null)
            {
                File.Delete(image);
            }
        }
    }
}
