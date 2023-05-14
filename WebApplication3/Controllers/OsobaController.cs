using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using WebApplication3;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OsobaController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public OsobaController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/Osoba
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Osoba>>> GetOsoba()
        {
            return await _context.Osoba.ToListAsync();
            //return _context.Osoba.ToList();
        }

        // GET: api/Osoba/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Osoba>> GetOsoba(int id)
        {
            var osoba = await _context.Osoba.FindAsync(id);

            if (osoba == null)
            {
                return NotFound();
            }

            return osoba;
        }

        // PUT: api/Osoba/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOsoba(int id, Osoba osoba)
        {
            if (id != osoba.Id)
            {
                return BadRequest();
            }

            _context.Entry(osoba).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OsobaExists(id))
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

        // POST: api/Osoba
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Osoba>> PostOsoba(Osoba osoba)
        {
            _context.Osoba.Add(osoba);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOsoba", new { id = osoba.Id }, osoba);
        }

        // DELETE: api/Osoba/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOsoba(int id)
        {
            var osoba = await _context.Osoba.FindAsync(id);
            if (osoba == null)
            {
                return NotFound();
            }

            _context.Osoba.Remove(osoba);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OsobaExists(int id)
        {
            return _context.Osoba.Any(e => e.Id == id);
        }
    }
}
