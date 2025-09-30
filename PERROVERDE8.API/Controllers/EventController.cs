using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PERROVERDE8.API.Data;
using PERROVERDE8.API.Models;

namespace PERROVERDE8.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EventsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> Get()
            => await _context.Events.ToListAsync();

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Event>> Get(int id)
        {
            var evt = await _context.Events.FindAsync(id);
            return evt is null ? NotFound() : evt;
        }

        [HttpPost]
        public async Task<ActionResult<Event>> Post(Event evt)
        {
            _context.Events.Add(evt);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = evt.Id }, evt);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, Event evt)
        {
            if (id != evt.Id) return BadRequest();
            _context.Entry(evt).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var evt = await _context.Events.FindAsync(id);
            if (evt is null) return NotFound();
            _context.Events.Remove(evt);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}