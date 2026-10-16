using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaceDayAPI.Data;
using RaceDayAPI.Models;

namespace RaceDayAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class OrganizersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrganizersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Organizers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Organizer>>> GetOrganizers()
        {
            return await _context.Organizers
                .Include(o => o.User)
                .ToListAsync();
        }

        // GET: api/Organizers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Organizer>> GetOrganizer(int id)
        {
            var organizer = await _context.Organizers
                .Include(o => o.User)
                .FirstOrDefaultAsync(o => o.OrganizerId == id);

            if (organizer == null)
                return NotFound();

            return organizer;
        }

        // POST: api/Organizers
        [HttpPost]
        public async Task<ActionResult<Organizer>> CreateOrganizer(Organizer organizer)
        {
            _context.Organizers.Add(organizer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrganizer),
                new { id = organizer.OrganizerId }, organizer);
        }

        // PUT: api/Organizers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrganizer(int id, Organizer organizer)
        {
            if (id != organizer.OrganizerId)
                return BadRequest();

            _context.Entry(organizer).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Organizers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganizer(int id)
        {
            var organizer = await _context.Organizers.FindAsync(id);

            if (organizer == null)
                return NotFound();

            _context.Organizers.Remove(organizer);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}