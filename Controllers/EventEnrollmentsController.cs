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
    public class EventEnrollmentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EventEnrollmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EventEnrollments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventEnrollment>>> GetEnrollments()
        {
            return await _context.EventEnrollments
                .Include(e => e.Participant)
                .Include(e => e.Category)
                .ToListAsync();
        }

        // GET: api/EventEnrollments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventEnrollment>> GetEnrollment(int id)
        {
            var enrollment = await _context.EventEnrollments
                .Include(e => e.Participant)
                .Include(e => e.Category)
                .FirstOrDefaultAsync(e => e.EnrollmentId == id);

            if (enrollment == null)
                return NotFound();

            return enrollment;
        }

        // POST: api/EventEnrollments
        [HttpPost]
        public async Task<ActionResult<EventEnrollment>> CreateEnrollment(EventEnrollment enrollment)
        {
            _context.EventEnrollments.Add(enrollment);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEnrollment),
                new { id = enrollment.EnrollmentId }, enrollment);
        }

        // PUT: api/EventEnrollments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEnrollment(int id, EventEnrollment enrollment)
        {
            if (id != enrollment.EnrollmentId)
                return BadRequest();

            _context.Entry(enrollment).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/EventEnrollments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnrollment(int id)
        {
            var enrollment = await _context.EventEnrollments.FindAsync(id);

            if (enrollment == null)
                return NotFound();

            _context.EventEnrollments.Remove(enrollment);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}