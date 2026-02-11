using InforceTestTask.DataBase.Entities;
using InforceTestTask.Infrastructure.DTOs;

namespace InforceTestTask.Infrastructure.Services.Interfaces;

public interface IShortUrlMapper
{
    ShortenUrlEntity Map(ShortenUrlDto shortenUrlDto);

    ShortenUrlDto Map(ShortenUrlEntity shortenUrlEntity);

    IEnumerable<ShortenUrlDto> Map(IEnumerable<ShortenUrlEntity> shortenUrlEntities);
}
