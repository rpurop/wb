using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WBTask.Models;


//Package can be created and listed

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly WBTaskContext _context;

        public PackageController(WBTaskContext context)
        {
            _context = context;
        }

        // GET: api/Package
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Package>>> GetPackages()
        {
            return await _context.Packages.ToListAsync();
        }

        // GET: api/Package/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Package>> GetPackage(long id)
        {
            var package = await _context.Packages.FindAsync(id);

            if (package == null)
            {
                return NotFound();
            }

            return package;
        }

        // PUT: api/Process/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutProcess(long id, Process process)
        // {
        //     if (id != process.Id)
        //     {
        //         return BadRequest();
        //     }

        //     _context.Entry(process).State = EntityState.Modified;

        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!ProcessExists(id))
        //         {
        //             return NotFound();
        //         }
        //         else
        //         {
        //             throw;
        //         }
        //     }

        //     return NoContent();
        // }

        // POST: api/ProcessTasks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Package>> PostPackage(Package package)
        {
            // var userRole = HttpContext.Request.Headers["x-user-role"];
            // if (userRole == "Admin") {
                

                _context.Packages.Add(package);
                    Console.WriteLine("Package ID:{0:G}",package.Id);

                var packageVersion = new PackageVersion() 
                {
                    PackageId = package.Id,
                    Id = 1,
                    PackageContent = package.PackageContent
                };
                _context.PackageVersions.Add(packageVersion);
                
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetPackage", new { id = package.Id }, package);
            // }
            // //var result = new UnauthorizedResult();
            // return (new UnauthorizedResult());
        }

        // DELETE: api/ProcessTasks/5
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteProcessTask(long id)
        // {
        //     var processTask = await _context.Processes.FindAsync(id);
        //     if (processTask == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.Processes.Remove(processTask);
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }

        // private bool ProcessExists(long id)
        // {
        //     return _context.Processes.Any(e => e.Id == id);
        // }
    }
}
