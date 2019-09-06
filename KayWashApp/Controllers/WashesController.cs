using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KayWashApp.DataAccess;
using KayWashApp.DataAccess.Model;

namespace KayWashApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WashesController : ControllerBase
    {
        private readonly KayWashAppContext _context;

        public WashesController(KayWashAppContext context)
        {
            _context = context;
        }

        // GET: api/Washes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Wash>>> GetWash()
        {
            return await _context.Wash.ToListAsync();
        }

        // GET: api/Washes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Wash>> GetWash(long id)
        {
            var wash = await _context.Wash.FindAsync(id);

            if (wash == null)
            {
                return NotFound();
            }

            return wash;
        }

        // PUT: api/Washes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWash(long id, Wash wash)
        {
            if (id != wash.Id)
            {
                return BadRequest();
            }

            _context.Entry(wash).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WashExists(id))
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

        // POST: api/Washes
        [HttpPost]
        public async Task<ActionResult<Wash>> PostWash(Wash wash)
        {
            _context.Wash.Add(wash);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWash", new { id = wash.Id }, wash);
        }

        // DELETE: api/Washes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Wash>> DeleteWash(long id)
        {
            var wash = await _context.Wash.FindAsync(id);
            if (wash == null)
            {
                return NotFound();
            }

            _context.Wash.Remove(wash);
            await _context.SaveChangesAsync();

            return wash;
        }

        private bool WashExists(long id)
        {
            return _context.Wash.Any(e => e.Id == id);
        }
    }
}
