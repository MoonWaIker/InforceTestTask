using InforceTestTask.DataBase.Contexts;
using InforceTestTask.DataBase.Entities;
using InforceTestTask.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InforceTestTask.Infrastructure.Services;

public class ShortUrlService(InforceDbContext context) : IShortUrlService
{
    public IEnumerable<ShortenUrl> GetShortenUrls => context.ShortenUrls;

    public ShortenUrl GetShortenUrl(int id)
    {
        return context.ShortenUrls
        .Include(url => url.User)
        .First(url => url.Id == id);
    }

    public void UpdateShortenUrl(ShortenUrl shortenUrl)
    {
        context.Update(shortenUrl);

        context.SaveChanges();
    }

    public void AddShortenUrl(ShortenUrl shortenUrl)
    {
        context.ShortenUrls.Add(shortenUrl);

        context.SaveChanges();
    }

    public void DeleteShortenUrl(int id)
    {
        context.ShortenUrls.Remove(GetShortenUrl(id));

        context.SaveChanges();
    }
}
