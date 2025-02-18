using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ResearchDatabase.Infrastructure.Data;

public class DatabaseMigrationService
{
    private readonly ResearchDbContext _context;
    private readonly ILogger<DatabaseMigrationService> _logger;

    public DatabaseMigrationService(
        ResearchDbContext context, 
        ILogger<DatabaseMigrationService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task MigrateAsync()
    {
        try 
        {
            // Apply pending migrations
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Database migration failed");
            throw;
        }
    }
}