using InforceTestTask.DataBase.Contexts;
using InforceTestTask.DataBase.Entities;
using InforceTestTask.Infrastructure.DTOs;
using InforceTestTask.Infrastructure.Services.Interfaces;

namespace InforceTestTask.Infrastructure.Services;

public sealed class ShortUrlService(
    InforceDbContext context,
    IShortUrlMapper mapper) : IShortUrlService
{
    private readonly InforceDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

    private readonly IShortUrlMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    public IEnumerable<ShortenUrlDto> GetShortenUrls => _mapper.Map(_context.ShortenUrls);

    public Guid AddShortenUrl(ShortenUrlDto shortenUrlDto)
    {
        var entity = _mapper.Map(shortenUrlDto);
        _context.ShortenUrls.Add(entity);

        _context.SaveChanges();

        return entity.Id;
    }

    public void DeleteShortenUrl(Guid id)
    {
        _context.ShortenUrls.Remove(GetShortenUrl(_context.ShortenUrls, id));

        _context.SaveChanges();
    }

    public ShortenUrlDto GetShortenUrl(Guid id)
    {
        return _mapper.Map(GetShortenUrl(_context.ShortenUrls, id));
    }

    private static ShortenUrlEntity GetShortenUrl(IQueryable<ShortenUrlEntity> entities, Guid id)
    {
        return entities
            .First(url => url.Id == id);
    }

    public void UpdateShortenUrl(ShortenUrlDto shortenUrlDto)
    {
        _context.Update(_mapper.Map(shortenUrlDto));

        _context.SaveChanges();
    }
}
