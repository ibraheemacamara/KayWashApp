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
using KayWashApp.Common;

namespace KayWashApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WashRequestsController : ControllerBase
    {
        private readonly IWashRequestService _washRequestService;

        public WashRequestsController(IWashRequestService service)
        {
            _washRequestService = service;
        }

        // GET: api/WashRequests
        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<WashRequestDto>> GetWashRequest()
        {
            var washRequests = _washRequestService.GetAll();

            return await Task.FromResult(washRequests);
        }

        // GET: api/WashRequests/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<WashRequestDto>> GetWashRequest(long id)
        {

            var washRequest = _washRequestService.GetById(id);

            if (washRequest == null)
            {
                return NotFound();
            }

            return await Task.FromResult(washRequest);
        }

        [Authorize]
        [HttpGet("{reference}")]
        public async Task<ActionResult<WashRequestDto>> GetWashRequest(string reference)
        {

            var washRequest = _washRequestService.GetByRef(reference);

            if (washRequest == null)
            {
                return NotFound();
            }

            return await Task.FromResult(washRequest);
        }

        // PUT: api/WashRequests/5
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWashRequest(long id, WashRequestDto washRequest)
        {
            if (id != washRequest.Id)
            {
                return BadRequest();
            }

            try
            {
                _washRequestService.Update(id, washRequest);
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
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<WashRequestDto>> PostWashRequest(WashRequestDto washRequest)
        {
            washRequest.WashRequestRef = Helper.GenerateRef();

            try
            {
                _washRequestService.Insert(washRequest);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });
            }
        }

        // DELETE: api/WashRequests/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<WashRequestDto>> DeleteWashRequest(long id)
        {
            var washRequest = _washRequestService.GetById(id);
            if (washRequest == null)
            {
                return NotFound();
            }

            try
            {
                _washRequestService.Delete(id);
            }
            catch (Exception)
            {

                return BadRequest();
            }

            return await Task.FromResult(washRequest);
        }

        private bool WashRequestExists(long id)
        {
            return _washRequestService.GetAll().Any(e => e.Id == id);
        }
    }
}
