using InforceTestTask.DataBase.Entities;
using InforceTestTask.Infrastructure.DTOs;
using InforceTestTask.Infrastructure.Services.Interfaces;
using MapsterMapper;

namespace InforceTestTask.Infrastructure.Services;

public sealed class ShortUrlMapper(IMapper mapper) : IShortUrlMapper
{
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    public ShortenUrlEntity Map(ShortenUrlDto shortenUrlDto)
    {
        return _mapper.Map<ShortenUrlEntity>(shortenUrlDto);
    }

    public ShortenUrlDto Map(ShortenUrlEntity shortenUrlEntity)
    {
        return _mapper.Map<ShortenUrlDto>(shortenUrlEntity);
    }

    public IEnumerable<ShortenUrlDto> Map(IEnumerable<ShortenUrlEntity> shortenUrlEntities)
    {
        return _mapper.Map<IEnumerable<ShortenUrlDto>>(shortenUrlEntities);
    }
}
