﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserEventBooking.Database;
using UserEventBooking.Database.Entities;

namespace UserEventBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRatingsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public UserRatingsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/UserRatings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rating>>> GetRating()
        {
          if (_context.Rating == null)
          {
              return NotFound();
          }
            return await _context.Rating.ToListAsync();
        }

        // GET: api/UserRatings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rating>> GetRating(int id)
        {
          if (_context.Rating == null)
          {
              return NotFound();
          }
            var rating = await _context.Rating.FindAsync(id);

            if (rating == null)
            {
                return NotFound();
            }

            return rating;
        }

        // PUT: api/UserRatings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRating(int id, Rating rating)
        {
            if (id != rating.ratingId)
            {
                return BadRequest();
            }

            if (rating.rating <= 0 || rating.rating > 5)
            {
                return Problem("Review length should be less than 1500.");
            }

            rating.createdTime = DateTime.Now;
            _context.Entry(rating).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RatingExists(id))
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

        // POST: api/UserRatings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Rating>> PostRating(Rating rating)
        {
          if (_context.Rating == null)
          {
              return Problem("Entity set 'DatabaseContext.Rating'  is null.");
          }

            if (rating.rating <= 0 || rating.rating > 5)
            {
                return Problem("Review length should be less than 1500.");
            }

            rating.createdTime = DateTime.Now;
            _context.Rating.Add(rating);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRating", new { id = rating.ratingId }, rating);
        }

        // DELETE: api/UserRatings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRating(int id)
        {
            if (_context.Rating == null)
            {
                return NotFound();
            }
            var rating = await _context.Rating.FindAsync(id);
            if (rating == null)
            {
                return NotFound();
            }

            _context.Rating.Remove(rating);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RatingExists(int id)
        {
            return (_context.Rating?.Any(e => e.ratingId == id)).GetValueOrDefault();
        }
    }
}
