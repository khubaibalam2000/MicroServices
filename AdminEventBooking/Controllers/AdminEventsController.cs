using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdminEventBooking.Database;
using AdminEventBooking.Database.Entities;
using Microsoft.AspNetCore.Authorization;

namespace AdminEventBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminEventsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public AdminEventsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/AdminEvents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvent()
        {
          if (_context.Event == null)
          {
              return NotFound();
          }
            return await _context.Event.ToListAsync();
        }

        [HttpGet("search/{toSearch}")]
        public IQueryable PostStringToSearch(string toSearch)
        {
            var events = from e in _context.Event
                         select e;

            if (!String.IsNullOrEmpty(toSearch))
            {
                events = events.Where(s => s.eventName!.Contains(toSearch) || s.organizationName!.Contains(toSearch) || s.categoryName!.Contains(toSearch) || 
                    s.venue!.Contains(toSearch) || s.eventDescription!.Contains(toSearch));
            }
#pragma warning disable CS8603 // Possible null reference return.
            return events;
#pragma warning restore CS8603 // Possible null reference return.
        }

        // GET: api/AdminEvents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEvent(int id)
        {
          if (_context.Event == null)
          {
              return NotFound();
          }
            var @event = await _context.Event.FindAsync(id);

            if (@event == null)
            {
                return NotFound();
            }

            return @event;
        }

        // PUT: api/AdminEvents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(int id, Event @event)
        {
            if (id != @event.eventId)
            {
                return BadRequest();
            }

            _context.Entry(@event).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
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

        // POST: api/AdminEvents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Event>> PostEvent(Event @event)
        {
          if (_context.Event == null)
          {
              return Problem("Entity set 'DatabaseContext.Event'  is null.");
          }
            _context.Event.Add(@event);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvent", new { id = @event.eventId }, @event);
        }

        // DELETE: api/AdminEvents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            if (_context.Event == null)
            {
                return NotFound();
            }
            var @event = await _context.Event.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }

            _context.Event.Remove(@event);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventExists(int id)
        {
            return (_context.Event?.Any(e => e.eventId == id)).GetValueOrDefault();
        }
    }
}
