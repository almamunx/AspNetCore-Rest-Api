using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspNetCoreREST.Data;
using AspNetCoreREST.Services;
using AspNetCoreREST.Models;

namespace AspNetCoreREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SamplesController : ControllerBase
    {
        private readonly ISampleService _sampleService;

        public SamplesController(ISampleService sampleService)
        {
            _sampleService = sampleService;
        }

        // GET: api/Samples
        [HttpGet]
        // Cache response data to client side for 10 minutes
        [ResponseCache(Duration = 10, Location = ResponseCacheLocation.Client)]
        public async Task<ActionResult<IEnumerable<Sample>>> GetSample()
        {
            return await _sampleService.SampleGetAllAsync();
        }

        // GET: api/Samples/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SampleVM>> GetSample(int id)
        {
            var data = await _sampleService.SampleGetAsync(id);

            //if (data == null)
            //{
            //    return NotFound();
            //}
            //return data;

            return data == null ? NotFound() : (ActionResult<SampleVM>)data;
        }


        // POST: api/Samples
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Sample>> PostSample(SampleVM model)
        {
            var id = await _sampleService.SampleSaveAsync(model);

            return CreatedAtAction("GetSample", new { id }, model);
        }

        // PUT: api/Samples/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSample(int id, SampleVM model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            await _sampleService.SampleUpdateAsync(model);

            return CreatedAtAction("GetSample", new { id }, model);

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!SampleExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return NoContent();
        }
        

        // DELETE: api/Samples/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SampleVM>> DeleteSample(int id)
        {
            var data = await _sampleService.SampleGetAsync(id);
            if (data == null)
            {
                return NotFound();
            }

            await _sampleService.SampleDeleteAsync(id);

            return data;
        }
    }
}
