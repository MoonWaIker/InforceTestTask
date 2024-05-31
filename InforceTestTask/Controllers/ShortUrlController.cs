using System.Data;
using System.Security.Claims;
using InforceTestTask.Context;
using InforceTestTask.Enums;
using InforceTestTask.Models;
using InforceTestTask.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InforceTestTask.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public sealed class ShortUrlController(InforceDbContext context, IShortUrlGenerator generator) : ControllerBase
{
    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<ShortUrlView>>> GetShortUrlViews()
    {
        return await context.ShortUrlViews.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ShortUrlView>> GetShortUrlView(int id)
    {
        var shortUrlView = await context.ShortUrlViews.FindAsync(id);

        if (shortUrlView == null) return NotFound();

        return shortUrlView;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutShortUrlView(int id, ShortUrlView shortUrlView)
    {
        if (id != shortUrlView.Id) return BadRequest();

        context.Entry(shortUrlView).State = EntityState.Modified;

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ShortUrlViewExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<ShortUrlView>> PostShortUrlView(ShortUrlView shortUrlView)
    {
        shortUrlView.ShortUrl = generator.GenerateShortUrl(shortUrlView.Url);
        shortUrlView.CreatorId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)
                                           ?? throw new NoNullAllowedException());

        context.ShortUrlViews.Add(shortUrlView);
        await context.SaveChangesAsync();

        return CreatedAtAction("GetShortUrlView", new { id = shortUrlView.Id }, shortUrlView);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteShortUrlView(int id)
    {
        if (!User.IsInRole(Role.Admin.ToString())
            || context.ShortUrlViews
                .First(u => u.Id == id).CreatorId.ToString() != User.FindFirstValue(ClaimTypes.NameIdentifier))
            return Forbid();

        var shortUrlView = await context.ShortUrlViews.FindAsync(id);
        if (shortUrlView == null) return NotFound();

        context.ShortUrlViews.Remove(shortUrlView);
        await context.SaveChangesAsync();

        return NoContent();
    }

    private bool ShortUrlViewExists(int id)
    {
        return context.ShortUrlViews.Any(e => e.Id == id);
    }
}