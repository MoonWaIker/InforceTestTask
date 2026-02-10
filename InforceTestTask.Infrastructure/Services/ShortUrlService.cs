using InforceTestTask.DataBase.Contexts;
using InforceTestTask.DataBase.Entities;
using InforceTestTask.Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InforceTestTask.Infrastructure.Services;

public sealed class ShortUrlService(InforceDbContext context) : IShortUrlService
{
    private readonly InforceDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

    public IEnumerable<ShortenUrl> GetShortenUrls => _context.ShortenUrls;

    // TODO Do you really need to get the shorten with the owner?
    public ShortenUrl GetShortenUrl(Guid id)
    {
        return _context.ShortenUrls
            .Include(static url => url.User)
            .First(url => url.Id == id);
    }

    public void UpdateShortenUrl(ShortenUrl shortenUrl)
    {
        _context.Update(shortenUrl);

        _context.SaveChanges();
    }

    public void AddShortenUrl(ShortenUrl shortenUrl)
    {
        _context.ShortenUrls.Add(shortenUrl);

        _context.SaveChanges();
    }

    public void DeleteShortenUrl(Guid id)
    {
        _context.ShortenUrls.Remove(GetShortenUrl(id));

        _context.SaveChanges();
    }
}
