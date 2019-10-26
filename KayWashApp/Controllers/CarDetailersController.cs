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
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Options;
using KayWashApp.Common;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
//using System.Web.Http;

namespace KayWashApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarDetailersController : ControllerBase
    {
        private readonly ICarDetailerService _carDetailerService;
        private readonly AppSettings _appSettings;

        public CarDetailersController(ICarDetailerService service,
            IOptions<AppSettings> appSettings)
        {
            _carDetailerService = service;

            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<object> Authenticate([FromBody]CarDetailerDto carDetailerDto)
        {
            var carDatiler = _carDetailerService.Authenticate(carDetailerDto.Phone, carDetailerDto.Password);

            if(carDatiler == null)
            {
                return BadRequest(new { message = "Le numéro de téléphone ou le mot de pass est incorrect" });
            }

            var tokenString = TokenProvider.CreateToken(_appSettings.Secret, carDatiler.Id.ToString()+ ",carDetailer");

            return await Task.FromResult(new
            {
                Id = carDatiler.Id,
                Phone = carDatiler.Phone,
                FirstName = carDatiler.FirstName,
                LastName = carDatiler.LastName,
                Token = tokenString
            });

        }

        // GET: api/CarDetailers
        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<CarDetailerDto>> GetCarDetailer()
        {
            var carDetailers = _carDetailerService.GetAll();

            return await Task.FromResult(carDetailers);
        }

        [Authorize]
        // GET: api/CarDetailers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarDetailerDto>> GetCarDetailer(long id)
        {
            var carDetailer = _carDetailerService.GetById(id);

            if (carDetailer == null)
            {
                return NotFound();
            }

            return await Task.FromResult(carDetailer);
        }

        // PUT: api/CarDetailers/5
        [Authorize]
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
        [Authorize]
        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody]CarDetailerDto carDetailer)
        {
            //TODO validation

            try
            {
                _carDetailerService.Insert(carDetailer);
                return Ok();
            }
            catch (Exception ex)
            {
                //TODO log
                return BadRequest(new { message = ex.Message});
            }
          
        }

        // DELETE: api/CarDetailers/5
        [Authorize]
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
