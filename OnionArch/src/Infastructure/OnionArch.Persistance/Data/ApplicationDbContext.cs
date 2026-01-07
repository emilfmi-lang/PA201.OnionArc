using Microsoft.EntityFrameworkCore;
using OnionArch.Application.Interfaces;
using OnionArch.Domain.Entities;

namespace OnionArch.Persistance.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options), IApplicationDbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<ProductColor> ProductColors { get; set; }

    public Task<int> SaveChangesAsync()
    {
        return base.SaveChangesAsync();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
