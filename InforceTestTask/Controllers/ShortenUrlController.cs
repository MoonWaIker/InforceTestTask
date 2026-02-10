using InforceTestTask.DataBase.Entities;
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
    public ActionResult<ShortenUrl> GetShortenUrl(Guid id)
    {
        return Ok(_shortUrlService.GetShortenUrl(id));
    }

    [HttpGet]
    public ActionResult<IEnumerable<ShortenUrl>> GetShortenUrls()
    {
        return Ok(_shortUrlService.GetShortenUrls);
    }

    [HttpPost]
    public ActionResult<ShortenUrl> PostShortenUrl(ShortenUrl shortenUrl)
    {
        _shortUrlService.AddShortenUrl(shortenUrl);

        return Created();
    }

    [HttpPut]
    public IActionResult PutShortenUrl(ShortenUrl shortenUrl)
    {
        _shortUrlService.UpdateShortenUrl(shortenUrl);

        return NoContent();
    }
}
