using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WBTask.Models;

//PackageVersions can be read and listed

namespace WebApplication2.Controllers
{
    //[Route("api/package/{packId}/[controller]")]
    [ApiController]
    public class PackageVersionController : ControllerBase
    {
        private readonly WBTaskContext _context;

        public PackageVersionController(WBTaskContext context)
        {
            _context = context;
        }

        // GET: api/Package/1/PackageVersion
        [Route("api/Package/{packId}/[controller]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PackageVersion>>> GetPackageVersions(long packId)
        {
            Console.WriteLine("packId:{0}",packId);
            var packVersionsList = new List<PackageVersion>();
            foreach(PackageVersion pv in _context.PackageVersions)
            {
                if (pv.PackageId == packId)
                {
                    packVersionsList.Add(pv);
                }
            }
            return packVersionsList;
        }

        // GET: api/Package/1/PackageVersion/1
        [Route("api/Package/{packId}/[controller]/{id}")]
        [HttpGet]
        public async Task<ActionResult<PackageVersion>> GetPackageVersion(long packId,int id)
        {
            var packVersion = await _context.PackageVersions.FindAsync(packId,id);

            if (packVersion == null)
            {
                return NotFound();
            }

            return packVersion;
        }

        
    }
}
