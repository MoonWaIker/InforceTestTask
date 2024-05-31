using InforceTestTask.Models;
using Microsoft.EntityFrameworkCore;

namespace InforceTestTask.Context;

public sealed class InforceDbContext : DbContext
{
    public InforceDbContext(DbContextOptions<InforceDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<User> Users { get; set; }

    public DbSet<ShortUrlView> ShortUrlViews { get; set; }
}