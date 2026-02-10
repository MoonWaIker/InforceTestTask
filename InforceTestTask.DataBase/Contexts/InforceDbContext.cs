using InforceTestTask.DataBase.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InforceTestTask.DataBase.Contexts;

public sealed class InforceDbContext(DbContextOptions<InforceDbContext> options)
    : IdentityDbContext<User, IdentityRole<Guid>, Guid>(options)
{
    public DbSet<ShortenUrl> ShortenUrls { get; set; }
}
