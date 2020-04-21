using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestWebAPI.Data;

namespace TestWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private readonly WebAPIContext _context;

        public SampleController(WebAPIContext context)
        {
            _context = context;
        }

        // GET: api/Sample
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sample>>> GetSample()
        {
            return await _context.Sample.ToListAsync();
        }

        // GET: api/Sample/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sample>> GetSample(int id)
        {
            var sample = await _context.Sample.FindAsync(id);

            if (sample == null)
            {
                return NotFound();
            }

            return sample;
        }

        // PUT: api/Sample/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSample(int id, Sample sample)
        {
            if (id != sample.Id)
            {
                return BadRequest();
            }

            _context.Entry(sample).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SampleExists(id))
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

        // POST: api/Sample
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Sample>> PostSample(Sample sample)
        {
            _context.Sample.Add(sample);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSample", new { id = sample.Id }, sample);
        }

        // DELETE: api/Sample/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sample>> DeleteSample(int id)
        {
            var sample = await _context.Sample.FindAsync(id);
            if (sample == null)
            {
                return NotFound();
            }

            _context.Sample.Remove(sample);
            await _context.SaveChangesAsync();

            return sample;
        }

        private bool SampleExists(int id)
        {
            return _context.Sample.Any(e => e.Id == id);
        }
    }
}
