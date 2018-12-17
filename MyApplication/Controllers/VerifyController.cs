using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApplication.Models;
using MyApplication.Functions;

namespace MyApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VerifyController : ControllerBase
    {
        private readonly WantedBundleContext _context;

        public VerifyController(WantedBundleContext context)
        {
            _context = context;
        }

        // GET: api/Verify
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WantedBundle>>> GetWantedBundle()
        {
            return await _context.WantedBundle.ToListAsync();
        }

        // GET: api/Verify/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WantedBundle>> GetWantedBundle(long id)
        {
            var wantedBundle = await _context.WantedBundle.FindAsync(id);

            if (wantedBundle == null)
            {
                return NotFound();
            }

            return wantedBundle;
        }

        // POST: api/Verify
        [HttpPost]
        public async Task<ActionResult<WantedBundle>> PostWantedBundle(WantedBundle wantedBundle)
        {

            string reasonCode = Verify.CheckValidity(wantedBundle);

            if (reasonCode == "No reason")
                return wantedBundle;
            else
                return BadRequest(reasonCode);

        }
    }
}