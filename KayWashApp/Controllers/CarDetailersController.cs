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
    public class CarDetailersController : ControllerBase
    {
        private readonly KayWashAppContext _context;

        public CarDetailersController(KayWashAppContext context)
        {
            _context = context;
        }

        // GET: api/CarDetailers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarDetailer>>> GetCarDetailer()
        {
            return await _context.CarDetailer.ToListAsync();
        }

        // GET: api/CarDetailers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarDetailer>> GetCarDetailer(long id)
        {
            var carDetailer = await _context.CarDetailer.FindAsync(id);

            if (carDetailer == null)
            {
                return NotFound();
            }

            return carDetailer;
        }

        // PUT: api/CarDetailers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarDetailer(long id, CarDetailer carDetailer)
        {
            if (id != carDetailer.Id)
            {
                return BadRequest();
            }

            _context.Entry(carDetailer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarDetailerExists(id))
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

        // POST: api/CarDetailers
        [HttpPost]
        public async Task<ActionResult<CarDetailer>> PostCarDetailer(CarDetailer carDetailer)
        {
            _context.CarDetailer.Add(carDetailer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarDetailer", new { id = carDetailer.Id }, carDetailer);
        }

        // DELETE: api/CarDetailers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CarDetailer>> DeleteCarDetailer(long id)
        {
            var carDetailer = await _context.CarDetailer.FindAsync(id);
            if (carDetailer == null)
            {
                return NotFound();
            }

            _context.CarDetailer.Remove(carDetailer);
            await _context.SaveChangesAsync();

            return carDetailer;
        }

        private bool CarDetailerExists(long id)
        {
            return _context.CarDetailer.Any(e => e.Id == id);
        }
    }
}
