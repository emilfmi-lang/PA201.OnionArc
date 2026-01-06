using Microsoft.EntityFrameworkCore;
using OnionArch.Application.Interfaces;
using OnionArch.Domain.Entities;

namespace OnionArch.Persistance.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public DbSet<Category> Categories { get; set; }

    public Task<int> SaveChangesAsync()
    {
        return base.SaveChangesAsync();
    }
}
