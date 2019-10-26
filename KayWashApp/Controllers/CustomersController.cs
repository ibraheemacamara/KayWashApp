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
using KayWashApp.Common;
using Microsoft.Extensions.Options;
using KayWashApp.Dto;
using Microsoft.AspNetCore.Authorization;

namespace KayWashApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly AppSettings _appSettings;

        public CustomersController(ICustomerService service, IOptions<AppSettings> appSettings)
        {
            _customerService = service;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<object> Authenticate([FromBody]CustomerDto carDetailerDto)
        {
            var customer = _customerService.Authenticate(carDetailerDto.Phone, carDetailerDto.Password);

            if (customer == null)
            {
                return BadRequest(new { message = "Le numéro de téléphone ou le mot de pass est incorrect" });
            }

            var tokenString = TokenProvider.CreateToken(_appSettings.Secret, customer.Id.ToString()+",customer");

            return await Task.FromResult(new
            {
                Id = customer.Id,
                Phone = customer.Phone,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Token = tokenString
            });

        }

        // GET: api/Customers
        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<CustomerDto>> GetCustomer()
        {
            var customers = _customerService.GetAll();

            return await Task.FromResult(customers);
        }

        // GET: api/Customers/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> GetCustomer(long id)
        {
            var customer = _customerService.GetById(id);

            if (customer == null)
            {
                return NotFound();
            }

            return await Task.FromResult(customer);
        }

        // PUT: api/Customers/5
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(long id, CustomerDto customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            try
            {
                _customerService.Update(id, customer);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return  NoContent();
        }

        // POST: api/Customers
        [Authorize]
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<Customer>> Register(CustomerDto customer)
        {
            //TODO validation

            try
            {
                _customerService.Insert(customer);
                return Ok();
            }
            catch (Exception ex)
            {
                //TODO log
                return BadRequest(new { message = ex.Message });
            }
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomerDto>> DeleteCustomer(long id)
        {
            var customer = _customerService.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }

            try
            {
                _customerService.Delete(id);
            }
            catch (Exception)
            {

                return BadRequest();
            }

            return await Task.FromResult(customer);
        }

        private bool CustomerExists(long id)
        {
            return _customerService.GetAll().Any(e => e.Id == id);
        }
    }
}
