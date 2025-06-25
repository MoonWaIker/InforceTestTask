using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InforceTestTask.DataBase.Contexts;
using InforceTestTask.DataBase.Entities;

namespace InforceTestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShortenUrlController : ControllerBase
    {
        private readonly InforceDbContext _context;

        public ShortenUrlController(InforceDbContext context)
        {
            _context = context;
        }

        // GET: api/ShortenUrl
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShortenUrl>>> GetShortenUrls()
        {
            return await _context.ShortenUrls.ToListAsync();
        }

        // GET: api/ShortenUrl/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShortenUrl>> GetShortenUrl(int id)
        {
            var shortenUrl = await _context.ShortenUrls.FindAsync(id);

            if (shortenUrl == null)
            {
                return NotFound();
            }

            return shortenUrl;
        }

        // PUT: api/ShortenUrl/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShortenUrl(int id, ShortenUrl shortenUrl)
        {
            if (id != shortenUrl.Id)
            {
                return BadRequest();
            }

            _context.Entry(shortenUrl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShortenUrlExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ShortenUrl
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ShortenUrl>> PostShortenUrl(ShortenUrl shortenUrl)
        {
            _context.ShortenUrls.Add(shortenUrl);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShortenUrl", new { id = shortenUrl.Id }, shortenUrl);
        }

        // DELETE: api/ShortenUrl/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShortenUrl(int id)
        {
            var shortenUrl = await _context.ShortenUrls.FindAsync(id);
            if (shortenUrl == null)
            {
                return NotFound();
            }

            _context.ShortenUrls.Remove(shortenUrl);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShortenUrlExists(int id)
        {
            return _context.ShortenUrls.Any(e => e.Id == id);
        }
    }
}
