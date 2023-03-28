using System.Reflection;
using ApiTrottling.Application.Common.Interfaces;
using ApiTrottling.Domain.Entities;
using ApiTrottling.Domain.Entities.EF;
using Microsoft.EntityFrameworkCore;

namespace ApiTrottling.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    private readonly IConfig _config;

    public ApplicationDbContext(IConfig config)
    {
        _config = config;
    }

    public DbSet<PrefDbLoginPerson> PrefDbLoginPersonSet { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var sqlTimeout = 600;
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = _config.ApplicationSettingsConfig.DbConnectionString();
            optionsBuilder.UseSqlServer(connectionString,
                    opts => opts.CommandTimeout(sqlTimeout))
                .EnableSensitiveDataLogging(true)
                .EnableDetailedErrors(true)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        optionsBuilder.LogTo(Console.WriteLine);
        base.OnConfiguring(optionsBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }
}
