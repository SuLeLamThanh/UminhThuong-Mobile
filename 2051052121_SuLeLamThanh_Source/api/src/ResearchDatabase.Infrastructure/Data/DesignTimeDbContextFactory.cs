using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using ResearchDatabase.Infrastructure.Data;
using System.IO; // Don't forget to add this

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ResearchDbContext>
{
    public ResearchDbContext CreateDbContext(string[] args)
    {
        // Use ConfigurationBuilder(), not new IConfigurationBuilder()
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory()) // Requires System.IO
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<ResearchDbContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        builder.UseSqlServer(connectionString, 
            options => options.MigrationsAssembly("ResearchDatabase.Infrastructure"));

        return new ResearchDbContext(builder.Options);
    }
}