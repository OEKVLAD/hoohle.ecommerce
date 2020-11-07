using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using adminPanel_api.Data;
using adminPanel_api.Model;

namespace adminPanel_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppConfiguratesController : ControllerBase
    {
        private readonly adminPanel_apiContext _context;

        public AppConfiguratesController(adminPanel_apiContext context)
        {
            _context = context;
        }

        // GET: api/AppConfigurates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppConfigurate>>> GetAppConfigurate()
        {
            return await _context.AppConfigurate.ToListAsync();
        }

        // GET: api/AppConfigurates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppConfigurate>> GetAppConfigurate(int id)
        {
            var appConfigurate = await _context.AppConfigurate.FindAsync(id);

            if (appConfigurate == null)
            {
                return NotFound();
            }

            return appConfigurate;
        }

        // PUT: api/AppConfigurates/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppConfigurate(int id, AppConfigurate appConfigurate)
        {
            if (id != appConfigurate.id_app_configurate)
            {
                return BadRequest();
            }

            _context.Entry(appConfigurate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppConfigurateExists(id))
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

        // POST: api/AppConfigurates
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AppConfigurate>> PostAppConfigurate(AppConfigurate appConfigurate)
        {
            _context.AppConfigurate.Add(appConfigurate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppConfigurate", new { id = appConfigurate.id_app_configurate }, appConfigurate);
        }

        // DELETE: api/AppConfigurates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AppConfigurate>> DeleteAppConfigurate(int id)
        {
            var appConfigurate = await _context.AppConfigurate.FindAsync(id);
            if (appConfigurate == null)
            {
                return NotFound();
            }

            _context.AppConfigurate.Remove(appConfigurate);
            await _context.SaveChangesAsync();

            return appConfigurate;
        }

        private bool AppConfigurateExists(int id)
        {
            return _context.AppConfigurate.Any(e => e.id_app_configurate == id);
        }
    }
}
