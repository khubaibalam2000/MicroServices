using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AdminEventBooking.Database.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserEventBooking.Database;
using UserEventBooking.Database.Entities;
using System.Net.Http.Formatting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// to do : send user event booking notification to attendee managemnet using bus service
namespace UserEventBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserBookingsController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private List<Event> availableEvents;
        private List<Event> unavailableEvents;

        public UserBookingsController(DatabaseContext context)
        {
            _context = context;
            availableEvents = new List<Event>();
            unavailableEvents = new List<Event>();
        }

        // GET: api/UserBookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBooking()
        {
          if (_context.Booking == null)
          {
              return NotFound();
          }
            return await _context.Booking.ToListAsync();
        }

        [HttpGet("getEvents")]
        public async Task<ActionResult<Tuple<List<Event>, List<Event>>>> GetEventAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54540");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("api/AdminEvents").Result;
                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    var eventList = JsonConvert.DeserializeObject<List<Event>>(responseString);
                    if (eventList != null)
                    {
                        foreach (var i in eventList)
                        {
                             if (i.registrationEndTime > DateTime.UtcNow)
                            {
                                availableEvents.Add(i);
                            }
                             else
                            {
                                unavailableEvents.Add(i);
                            }
                        }
                        Tuple<List<Event>, List<Event>> listOfAvailableAndNonAvailableEvents = new Tuple<List<Event>, List<Event>>(availableEvents, unavailableEvents);
                        return listOfAvailableAndNonAvailableEvents;
                    } 
                    else
                    {
                        return NotFound();
                    }
                }
            }
            List<Event> temp1 = new List<Event>();
            List<Event> temp2 = new List<Event>();
            Tuple<List<Event>, List<Event>> temp = new Tuple<List<Event>, List<Event>>(temp1, temp2);
            return temp;
        }

        [HttpGet("search/{toSearch}")]
        public async Task<ActionResult<Tuple<List<Event>, List<Event>>>> PostStringToSearchAsyncInAvailableEvents(string toSearch)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:38014");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("api/UserBookings/getEvents").Result;
                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    var eventList = JsonConvert.DeserializeObject<Tuple<List<Event>, List<Event>>>(responseString);
                    if (eventList != null)
                    {
                        if (!String.IsNullOrEmpty(toSearch))
                        {
                            List<Event> availableSearchedEvents = eventList.Item1.FindAll(s => s.eventName!.Contains(toSearch) || s.organizationName!.Contains(toSearch) || s.categoryName!.Contains(toSearch) ||
                    s.venue!.Contains(toSearch) || s.eventDescription!.Contains(toSearch));

                            List<Event> unavailableSearchedEvents = eventList.Item2.FindAll(s => s.eventName!.Contains(toSearch) || s.organizationName!.Contains(toSearch) || s.categoryName!.Contains(toSearch) ||
                    s.venue!.Contains(toSearch) || s.eventDescription!.Contains(toSearch));

                            Tuple<List<Event>, List<Event>> searchedEvents = new Tuple<List<Event>, List<Event>>(availableSearchedEvents, unavailableSearchedEvents);
                            return searchedEvents;
                        }
                    }
                }
            }
            List<Event> temp1 = new List<Event>();
            List<Event> temp2 = new List<Event>();
            Tuple<List<Event>, List<Event>> temp = new Tuple<List<Event>, List<Event>>(temp1, temp2);
            return temp;

        }

        // GET: api/UserBookings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetBooking(int id)
        {
          if (_context.Booking == null)
          {
              return NotFound();
          }
            var booking = await _context.Booking.FindAsync(id);

            if (booking == null)
            {
                return NotFound();
            }

            return booking;
        }

        // PUT: api/UserBookings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooking(int id, Booking booking)
        {
            if (id != booking.bookingId)
            {
                return BadRequest();
            }

            _context.Entry(booking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExists(id))
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

        // POST: api/UserBookings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Booking>> PostBooking(Booking booking)
        {
          if (_context.Booking == null)
          {
              return Problem("Entity set 'DatabaseContext.Booking'  is null.");
          }
            _context.Booking.Add(booking);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBooking", new { id = booking.bookingId }, booking);
        }

        // DELETE: api/UserBookings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            if (_context.Booking == null)
            {
                return NotFound();
            }
            var booking = await _context.Booking.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }

            _context.Booking.Remove(booking);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookingExists(int id)
        {
            return (_context.Booking?.Any(e => e.bookingId == id)).GetValueOrDefault();
        }
    }
}
