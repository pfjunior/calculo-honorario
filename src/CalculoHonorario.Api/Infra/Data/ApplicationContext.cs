using CalculoHonorario.Api.Domain.Entities;
using CalculoHonorario.Api.Domain.Interface;
using Microsoft.EntityFrameworkCore;

namespace CalculoHonorario.Api.Infra.Data;

public class ApplicationContext : DbContext, IUnitOfWork
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        ChangeTracker.AutoDetectChangesEnabled = false;
    }

    public DbSet<Honorario> Honorarios { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string)))) property.SetColumnType("varchar(100)");
        foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(decimal)))) property.SetColumnType("decimal(18,4)");

        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CadastradoEm") != null))
        {
            if (entry.State == EntityState.Added) entry.Property("CadastradoEm").CurrentValue = DateTime.Now;

            if (entry.State == EntityState.Modified) entry.Property("AtualizadoEm").IsModified = false;
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> CommitAsync() => await SaveChangesAsync() > 0;
}
