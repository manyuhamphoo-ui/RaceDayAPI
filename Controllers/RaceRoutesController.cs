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
    public class RaceRoutesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RaceRoutesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/RaceRoutes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RaceRoute>>> GetRoutes()
        {
            return await _context.Routes
                .Include(r => r.Event)
                .ToListAsync();
        }

        // GET: api/RaceRoutes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RaceRoute>> GetRoute(int id)
        {
            var route = await _context.Routes
                .Include(r => r.Event)
                .FirstOrDefaultAsync(r => r.RouteId == id);

            if (route == null)
                return NotFound();

            return route;
        }

        // POST: api/RaceRoutes
        [HttpPost]
        public async Task<ActionResult<RaceRoute>> CreateRoute(RaceRoute route)
        {
            _context.Routes.Add(route);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRoute),
                new { id = route.RouteId }, route);
        }

        // PUT: api/RaceRoutes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoute(int id, RaceRoute route)
        {
            if (id != route.RouteId)
                return BadRequest();

            _context.Entry(route).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/RaceRoutes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoute(int id)
        {
            var route = await _context.Routes.FindAsync(id);

            if (route == null)
                return NotFound();

            _context.Routes.Remove(route);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}