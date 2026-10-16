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
    public class WeatherInformationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WeatherInformationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/WeatherInformations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeatherInformation>>> GetWeatherInformation()
        {
            return await _context.WeatherInformations
                .Include(w => w.Event)
                .ToListAsync();
        }

        // GET: api/WeatherInformations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WeatherInformation>> GetWeatherInformation(int id)
        {
            var weather = await _context.WeatherInformations
                .Include(w => w.Event)
                .FirstOrDefaultAsync(w => w.WeatherId == id);

            if (weather == null)
                return NotFound();

            return weather;
        }

        // POST: api/WeatherInformations
        [HttpPost]
        public async Task<ActionResult<WeatherInformation>> CreateWeatherInformation(WeatherInformation weather)
        {
            _context.WeatherInformations.Add(weather);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetWeatherInformation),
                new { id = weather.WeatherId }, weather);
        }

        // PUT: api/WeatherInformations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWeatherInformation(int id, WeatherInformation weather)
        {
            if (id != weather.WeatherId)
                return BadRequest();

            _context.Entry(weather).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/WeatherInformations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeatherInformation(int id)
        {
            var weather = await _context.WeatherInformations.FindAsync(id);

            if (weather == null)
                return NotFound();

            _context.WeatherInformations.Remove(weather);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}