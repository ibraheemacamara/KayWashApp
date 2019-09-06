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
    public class WashRequestsController : ControllerBase
    {
        private readonly KayWashAppContext _context;

        public WashRequestsController(KayWashAppContext context)
        {
            _context = context;
        }

        // GET: api/WashRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WashRequest>>> GetWashRequest()
        {
            return await _context.WashRequest.ToListAsync();
        }

        // GET: api/WashRequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WashRequest>> GetWashRequest(long id)
        {
            var washRequest = await _context.WashRequest.FindAsync(id);

            if (washRequest == null)
            {
                return NotFound();
            }

            return washRequest;
        }

        // PUT: api/WashRequests/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWashRequest(long id, WashRequest washRequest)
        {
            if (id != washRequest.Id)
            {
                return BadRequest();
            }

            _context.Entry(washRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WashRequestExists(id))
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

        // POST: api/WashRequests
        [HttpPost]
        public async Task<ActionResult<WashRequest>> PostWashRequest(WashRequest washRequest)
        {
            _context.WashRequest.Add(washRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWashRequest", new { id = washRequest.Id }, washRequest);
        }

        // DELETE: api/WashRequests/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WashRequest>> DeleteWashRequest(long id)
        {
            var washRequest = await _context.WashRequest.FindAsync(id);
            if (washRequest == null)
            {
                return NotFound();
            }

            _context.WashRequest.Remove(washRequest);
            await _context.SaveChangesAsync();

            return washRequest;
        }

        private bool WashRequestExists(long id)
        {
            return _context.WashRequest.Any(e => e.Id == id);
        }
    }
}
