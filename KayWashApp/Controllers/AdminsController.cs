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
using Dto;

namespace KayWashApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly KayWashAppContext _context;

        private readonly IAdminService _adminService;

        public AdminsController(IAdminService service)
        {
            _adminService = service;
        }

        // GET: api/Admins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminDto>>> GetAdmin()
        {
            var admins = _adminService.GetAll();
            return Ok(admins);
            //return await _context.Admin.ToListAsync();
        }

        // GET: api/Admins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdminDto>> GetAdmin(long id)
        {
            var admin = _adminService.GetById(id);

            if (admin == null)
            {
                return NotFound();
            }

            return Ok(admin);
        }

        // PUT: api/Admins/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdmin(long id, AdminDto admin)
        {
            if (id != admin.Id)
            {
                return BadRequest();
            }


            try
            {
                _adminService.Update(id, admin);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminExists(id))
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

        // POST: api/Admins
        [HttpPost]
        public async Task<ActionResult<AdminDto>> PostAdmin(AdminDto admin)
        {
            _adminService.Insert(admin);

            return CreatedAtAction("GetAdmin", new { id = admin.Id }, admin);
        }

        // DELETE: api/Admins/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AdminDto>> DeleteAdmin(long id)
        {
            var admin = _adminService.GetById(id);
            if (admin == null)
            {
                return NotFound();
            }

            _adminService.Delete(id);

            return admin;
        }

        private bool AdminExists(long id)
        {
            return _adminService.GetAll().Any(e => e.Id == id);
        }
    }
}
