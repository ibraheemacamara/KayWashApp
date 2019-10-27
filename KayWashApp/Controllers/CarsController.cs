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
using Microsoft.AspNetCore.Authorization;
using KayWashApp.Dto;

namespace KayWashApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarsController(ICarService service)
        {
            _carService = service;
        }

        // GET: api/Cars
        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<CarDto>> GetCar()
        {
            var cars = _carService.GetAll();

            return await Task.FromResult(cars);
        }

        // GET: api/Cars/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<CarDto>> GetCar(long id)
        {
            var car = _carService.GetById(id);

            if (car == null)
            {
                return NotFound();
            }

            return await Task.FromResult(car);
        }

        // PUT: api/Cars/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar(long id, CarDto car)
        {
            if (id != car.Id)
            {
                return BadRequest();
            }

            try
            {
                _carService.Update(id, car);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(id))
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

        // POST: api/Cars
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<CarDto>> PostCar(CarDto car)
        {
            try
            {
                _carService.Insert(car);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });
            }
        }

        // DELETE: api/Cars/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CarDto>> DeleteCar(long id)
        {
            var car = _carService.GetById(id);
            if (car == null)
            {
                return NotFound();
            }

            try
            {
                _carService.Delete(id);
            }
            catch (Exception)
            {

                return BadRequest();
            }

            return await Task.FromResult(car);
        }
        private bool CarExists(long id)
        {
            return _carService.GetAll().Any(e => e.Id == id);
        }
    }
}
