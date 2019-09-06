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
    public class WashPackagesController : ControllerBase
    {
        private readonly KayWashAppContext _context;

        public WashPackagesController(KayWashAppContext context)
        {
            _context = context;
        }

        // GET: api/WashPackages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WashPackage>>> GetWashPackage()
        {
            return await _context.WashPackage.ToListAsync();
        }

        // GET: api/WashPackages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WashPackage>> GetWashPackage(long id)
        {
            var washPackage = await _context.WashPackage.FindAsync(id);

            if (washPackage == null)
            {
                return NotFound();
            }

            return washPackage;
        }

        // PUT: api/WashPackages/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWashPackage(long id, WashPackage washPackage)
        {
            if (id != washPackage.Id)
            {
                return BadRequest();
            }

            _context.Entry(washPackage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WashPackageExists(id))
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

        // POST: api/WashPackages
        [HttpPost]
        public async Task<ActionResult<WashPackage>> PostWashPackage(WashPackage washPackage)
        {
            _context.WashPackage.Add(washPackage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWashPackage", new { id = washPackage.Id }, washPackage);
        }

        // DELETE: api/WashPackages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WashPackage>> DeleteWashPackage(long id)
        {
            var washPackage = await _context.WashPackage.FindAsync(id);
            if (washPackage == null)
            {
                return NotFound();
            }

            _context.WashPackage.Remove(washPackage);
            await _context.SaveChangesAsync();

            return washPackage;
        }

        private bool WashPackageExists(long id)
        {
            return _context.WashPackage.Any(e => e.Id == id);
        }
    }
}
