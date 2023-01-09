using System;
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
    public class UserReviewsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public UserReviewsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/UserReviews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Review>>> GetReview()
        {
          if (_context.Review == null)
          {
              return NotFound();
          }
            return await _context.Review.ToListAsync();
        }

        // GET: api/UserReviews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Review>> GetReview(int id)
        {
          if (_context.Review == null)
          {
              return NotFound();
          }
            var review = await _context.Review.FindAsync(id);

            if (review == null)
            {
                return NotFound();
            }

            return review;
        }

        // PUT: api/UserReviews/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReview(int id, Review review)
        {
            if (id != review.reviewId)
            {
                return BadRequest();
            }

            if (review.review.Length <= 0 || review.review.Length > 1500)
            {
                return Problem("Review length should be less than 1500.");
            }

            review.createdTime = DateTime.Now;
            _context.Entry(review).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewExists(id))
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

        // POST: api/UserReviews
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Review>> PostReview(Review review)
        {
          if (_context.Review == null)
          {
              return Problem("Entity set 'DatabaseContext.Review'  is null.");
          }
          if (review.review.Length <= 0 || review.review.Length > 1500)
            {
                return Problem("Review length should be less than 1500.");
            }
          review.createdTime = DateTime.Now;

            _context.Review.Add(review);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReview", new { id = review.reviewId }, review);
        }

        // DELETE: api/UserReviews/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            if (_context.Review == null)
            {
                return NotFound();
            }
            var review = await _context.Review.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            _context.Review.Remove(review);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReviewExists(int id)
        {
            return (_context.Review?.Any(e => e.reviewId == id)).GetValueOrDefault();
        }
    }
}
