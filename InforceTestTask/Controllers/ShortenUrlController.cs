using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InforceTestTask.DataBase.Contexts;
using InforceTestTask.DataBase.Entities;
using InforceTestTask.Infrastructure.Interfaces;

namespace InforceTestTask.Controllers;

[Route(ApiRoute)]
[ApiController]
public class ShortenUrlController(IShortUrlService shortUrlService) : ControllerBase
{
    private const string IdRoute = "{id:BigInteger}";
    private const string ApiRoute = "api/[controller]";

    [HttpGet]
    public ActionResult<IEnumerable<ShortenUrl>> GetShortenUrls()
    {
        return Ok(shortUrlService.GetShortenUrls);
    }

    [HttpGet(IdRoute)]
    public ActionResult<ShortenUrl> GetShortenUrl(int id)
    {
        return shortUrlService.GetShortenUrl(id);
    }

    [HttpPut]
    public IActionResult PutShortenUrl(ShortenUrl shortenUrl)
    {
        shortUrlService.UpdateShortenUrl(shortenUrl);

        return NoContent();
    }

    [HttpPost]
    public ActionResult<ShortenUrl> PostShortenUrl(ShortenUrl shortenUrl)
    {
        shortUrlService.AddShortenUrl(shortenUrl);

        return Created();
    }

    [HttpDelete(IdRoute)]
    public IActionResult DeleteShortenUrl(int id)
    {
        shortUrlService.DeleteShortenUrl(id);

        return NoContent();
    }
}
