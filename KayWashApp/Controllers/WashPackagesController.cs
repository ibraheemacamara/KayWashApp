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
    public class WashPackagesController : ControllerBase
    {
        private readonly IWashPackageService _washPackageService;

        public WashPackagesController(IWashPackageService context)
        {
            _washPackageService = context;
        }

        // GET: api/WashPackages
        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<WashPackageDto>> GetWashPackage()
        {
            var packages = _washPackageService.GetAll();

            return await Task.FromResult(packages);
        }

        // GET: api/WashPackages/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<WashPackageDto>> GetWashPackage(long id)
        {
            var package = _washPackageService.GetById(id);

            if (package == null)
            {
                return NotFound();
            }

            return await Task.FromResult(package);
        }

        //// PUT: api/WashPackages/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutWashPackage(long id, WashPackage washPackage)
        //{
        //    if (id != washPackage.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _washPackageService.Entry(washPackage).State = EntityState.Modified;

        //    try
        //    {
        //        await _washPackageService.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!WashPackageExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/WashPackages
        //[HttpPost]
        //public async Task<ActionResult<WashPackage>> PostWashPackage(WashPackage washPackage)
        //{
        //    _washPackageService.WashPackage.Add(washPackage);
        //    await _washPackageService.SaveChangesAsync();

        //    return CreatedAtAction("GetWashPackage", new { id = washPackage.Id }, washPackage);
        //}

        //// DELETE: api/WashPackages/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<WashPackage>> DeleteWashPackage(long id)
        //{
        //    var washPackage = await _washPackageService.WashPackage.FindAsync(id);
        //    if (washPackage == null)
        //    {
        //        return NotFound();
        //    }

        //    _washPackageService.WashPackage.Remove(washPackage);
        //    await _washPackageService.SaveChangesAsync();

        //    return washPackage;
        //}

        //private bool WashPackageExists(long id)
        //{
        //    return _washPackageService.WashPackage.Any(e => e.Id == id);
        //}
    }
}
