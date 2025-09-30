using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PERROVERDE8.API.Data; 
using PERROVERDE8.API.Models;

namespace PERROVERDE8.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupportTicketsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public SupportTicketsController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupportTicket>>> GetSupportTickets()
            => await _context.SupportTickets.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<SupportTicket>> GetSupportTicket(int id)
        {
            var ticket = await _context.SupportTickets.FindAsync(id);
            return ticket == null ? NotFound() : ticket;
        }

        [HttpPost]
        public async Task<ActionResult<SupportTicket>> PostSupportTicket(SupportTicket ticket)
        {
            if (string.IsNullOrWhiteSpace(ticket.Status)) ticket.Status = "Open";
            if (ticket.OpenedAt == default) ticket.OpenedAt = DateTime.UtcNow;

            _context.SupportTickets.Add(ticket);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSupportTicket), new { id = ticket.Id }, ticket);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupportTicket(int id, SupportTicket ticket)
        {
            if (id != ticket.Id) return BadRequest();
            _context.Entry(ticket).State = EntityState.Modified;

            try { await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.SupportTickets.Any(e => e.Id == id)) return NotFound();
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupportTicket(int id)
        {
            var ticket = await _context.SupportTickets.FindAsync(id);
            if (ticket == null) return NotFound();
            _context.SupportTickets.Remove(ticket);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}