using InforceTestTask.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace InforceTestTask.DataBase.Contexts;

public class InforceDbContext : DbContext
{
    public DbSet<ShortenUrl> ShortenUrls { get; set; }
}
