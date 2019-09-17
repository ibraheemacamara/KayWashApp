using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KayWashApp.DataAccess;
using KayWashApp.DataAccess.Model;
using KayWashApp.Services;
using KayWashApp.Dto;

namespace KayWashApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarDetailersController : ControllerBase
    {
        private readonly ICarDetailerService _carDetailerService;

        public CarDetailersController(ICarDetailerService service)
        {
            _carDetailerService = service;
        }

        // GET: api/CarDetailers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarDetailerDto>>> GetCarDetailer()
        {
            var carDetailers = _carDetailerService.GetAll();
            return Ok(carDetailers);
        }

        // GET: api/CarDetailers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarDetailerDto>> GetCarDetailer(long id)
        {
            var carDetailer = _carDetailerService.GetById(id);

            if (carDetailer == null)
            {
                return NotFound();
            }

            return Ok(carDetailer);
        }

        // PUT: api/CarDetailers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarDetailer(long id, CarDetailerDto carDetailer)
        {
            if (id != carDetailer.Id)
            {
                return BadRequest();
            }

            try
            {
                _carDetailerService.Update(id, carDetailer);
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
        public async Task<ActionResult<CarDetailer>> PostCarDetailer(CarDetailerDto carDetailer)
        {
            //TODO validation

            try
            {
                _carDetailerService.Insert(carDetailer);
            }
            catch (Exception ex)
            {
                //TODO log
                return BadRequest();
            }
            
            return CreatedAtAction("GetCarDetailer", new { id = carDetailer.Id }, carDetailer);
        }

        // DELETE: api/CarDetailers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CarDetailerDto>> DeleteCarDetailer(long id)
        {
            var carDetailer = _carDetailerService.GetById(id);
            if (carDetailer == null)
            {
                return NotFound();
            }

            try
            {
                _carDetailerService.Delete(id);
            }
            catch (Exception)
            {

                return BadRequest();
            }

            return carDetailer;
        }

        private bool CarDetailerExists(long id)
        {
            return _carDetailerService.GetAll().Any(e => e.Id == id);
        }
    }
}
