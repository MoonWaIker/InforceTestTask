using InforceTestTask.DataBase.Entities;

namespace InforceTestTask.Infrastructure.Interfaces;

public interface IShortUrlService
{
    IEnumerable<ShortenUrl> GetShortenUrls { get; }

    ShortenUrl GetShortenUrl(int id);

    void UpdateShortenUrl(ShortenUrl shortenUrl);

    void AddShortenUrl(ShortenUrl shortenUrl);

    void DeleteShortenUrl(int id);
}
