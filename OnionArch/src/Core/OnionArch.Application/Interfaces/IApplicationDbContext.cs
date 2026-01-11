using Microsoft.EntityFrameworkCore;
using OnionArch.Domain.Entities;

namespace OnionArch.Application.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Category> Categories { get; set; }
    DbSet<Product> Products { get; set; }
    DbSet<Color> Colors { get; set; }
    DbSet<ProductColor> ProductColors { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
