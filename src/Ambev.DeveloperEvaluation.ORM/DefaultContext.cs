using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.ORM.Events;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Ambev.DeveloperEvaluation.ORM;

public class DefaultContext : DbContext
{
    private readonly DomainEventDispatcher? _dispatcher; // Permitir null no DesignTime

    public DbSet<User> Users { get; set; }
    public DbSet<Sale> Sales => Set<Sale>();
    public DbSet<SaleItem> SaleItems { get; set; }

    public DefaultContext(DbContextOptions<DefaultContext> options, DomainEventDispatcher? dispatcher = null) : base(options)
    {
        _dispatcher = dispatcher;
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var domainEntities = ChangeTracker.Entries()
            .Where(x => x.Entity is Sale && x.State is EntityState.Added or EntityState.Modified)
            .Select(x => x.Entity as Sale)
            .Where(x => x!.DomainEvents.Any())
            .ToList();

        var domainEvents = domainEntities
            .SelectMany(x => x!.DomainEvents)
            .ToList();

        var result = await base.SaveChangesAsync(cancellationToken);

        if (_dispatcher != null) // Evita erro no DesignTime
        {
            await _dispatcher.DispatchAsync(domainEvents);
        }

        domainEntities.ForEach(e => e!.ClearDomainEvents());

        return result;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}

public class YourDbContextFactory : IDesignTimeDbContextFactory<DefaultContext>
{
    public DefaultContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<DefaultContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        //builder.UseNpgsql(
        //       connectionString,
        //       b => b.MigrationsAssembly("Ambev.DeveloperEvaluation.WebApi")
        //);

        builder.UseNpgsql(
            connectionString,
            b => b.MigrationsAssembly("Ambev.DeveloperEvaluation.ORM")
        );

        return new DefaultContext(builder.Options);
    }
}