using InforceTestTask.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace InforceTestTask.DataBase.Contexts;

public class InforceDbContext(DbContextOptions<InforceDbContext> options) : DbContext(options)
{
    public DbSet<ShortenUrl> ShortenUrls { get; set; }
}
