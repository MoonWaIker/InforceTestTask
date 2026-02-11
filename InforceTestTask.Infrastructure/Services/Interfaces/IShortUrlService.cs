using InforceTestTask.Infrastructure.DTOs;

namespace InforceTestTask.Infrastructure.Services.Interfaces;

public interface IShortUrlService
{
    IEnumerable<ShortenUrlDto> GetShortenUrls { get; }

    Guid AddShortenUrl(ShortenUrlDto shortenUrlDto);

    void DeleteShortenUrl(Guid id);

    ShortenUrlDto GetShortenUrl(Guid id);

    void UpdateShortenUrl(ShortenUrlDto shortenUrlDto);
}
