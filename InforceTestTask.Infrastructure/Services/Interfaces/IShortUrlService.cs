using InforceTestTask.DataBase.Entities;

namespace InforceTestTask.Infrastructure.Services.Interfaces;

public interface IShortUrlService
{
    IEnumerable<ShortenUrl> GetShortenUrls { get; }

    ShortenUrl GetShortenUrl(Guid id);

    void UpdateShortenUrl(ShortenUrl shortenUrl);

    void AddShortenUrl(ShortenUrl shortenUrl);

    void DeleteShortenUrl(Guid id);
}
