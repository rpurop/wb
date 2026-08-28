using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WBTask.Models;
using WBTask.Validator;

namespace WebApplication2.Controllers
{
    
    [ApiController]
    public class ProcessController : ControllerBase
    {
        private readonly WBTaskContext _context;

        public ProcessController(WBTaskContext context)
        {
            _context = context;
        }

        // GET: api/Package/1/Process
        [Route("api/Package/{packId}/[controller]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Process>>> GetProcesses(long packId)
        {
            var packProcessList = new List<Process>();
            foreach(Process p in _context.Processes)
            {
                if (p.PackageId == packId)
                {
                    packProcessList.Add(p);
                }
            }
            return packProcessList;
        }

        // GET: api/Package/1/Process/1
        [Route("api/Package/{packId}/[controller]/{id}")]
        [HttpGet]
        public async Task<ActionResult<Process>> GetProcess(long packId,int id)
        {
            var process = await _context.Processes.FindAsync(packId,id);

            if (process == null)
            {
                return NotFound();
            }

            return process;
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

        // POST: api/Package/1/Process
        [Route("api/Package/{packId}/[controller]")]
        [HttpPost]
        public async Task<ActionResult<Process>> PostProcess([FromBody]Process process,[FromRoute]long packId)
        {
            var validator = new Validator(_context);
            var user = HttpContext.Request.Headers["x-user-id"];

            if (validator.isValidUser(user,"Editor",process.CountryCode)) {
    // {
    //     return Results.Ok("Admin");
    // }
    // return Results.Unauthorized();
                _context.Processes.Add(process);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetProcess", new {packId=process.PackageId, id = process.Id }, process);
            }
            //var result = new UnauthorizedResult();
            return (new UnauthorizedResult());
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

        private bool ProcessExists(long id)
        {
            return _context.Processes.Any(e => e.Id == id);
        }
    }
}
