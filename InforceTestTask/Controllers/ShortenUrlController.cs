using InforceTestTask.DataBase.Entities;
using InforceTestTask.Infrastructure.DTOs;
using InforceTestTask.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InforceTestTask.Controllers;

[Route(ApiRoute)]
[ApiController]
public class ShortenUrlController(IShortUrlService shortUrlService) : ControllerBase
{
    private const string IdRoute = "{id:guid}";
    private const string ApiRoute = "api/[controller]";

    private readonly IShortUrlService _shortUrlService =
        shortUrlService ?? throw new ArgumentNullException(nameof(shortUrlService));

    [HttpDelete(IdRoute)]
    public IActionResult DeleteShortenUrl(Guid id)
    {
        _shortUrlService.DeleteShortenUrl(id);

        return NoContent();
    }

    [HttpGet(IdRoute)]
    public ActionResult<ShortenUrlDto> GetShortenUrl(Guid id)
    {
        return Ok(_shortUrlService.GetShortenUrl(id));
    }

    [HttpGet]
    public ActionResult<IEnumerable<ShortenUrlEntity>> GetShortenUrls()
    {
        return Ok(_shortUrlService.GetShortenUrls);
    }

    [HttpPost]
    public ActionResult<ShortenUrlEntity> PostShortenUrl([FromBody] ShortenUrlDto shortenUrlEntity)
    {
        return CreatedAtAction(nameof(GetShortenUrl), _shortUrlService.AddShortenUrl(shortenUrlEntity));
    }

    [HttpPut]
    public IActionResult PutShortenUrl([FromBody] ShortenUrlDto shortenUrlEntity)
    {
        _shortUrlService.UpdateShortenUrl(shortenUrlEntity);

        return NoContent();
    }
}
