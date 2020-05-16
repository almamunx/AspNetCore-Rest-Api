using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspNetCoreREST.Data;
using AspNetCoreREST.Models;

namespace AspNetCoreREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private readonly ISampleService _sampleService;

        public SampleController(ISampleService sampleService)
        {
            _sampleService = sampleService;
        }
        

        // GET: api/Sample
        [HttpGet]
        // Cache response data to client side for 60 minutes
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Client)]
        public async Task<ActionResult<IEnumerable<Sample>>> GetSample()
        {
            var data = await _sampleService.SampleGetAllAsync();
            return Ok(data);
        }

        // GET: api/Sample/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SampleVM>> GetSample(int id)
        {
            var data = await _sampleService.SampleGetAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        // POST: api/Sample
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<SampleVM>> PostSample(SampleVM model)
        {

            var id = await _sampleService.SampleSaveAsync(model);

            return CreatedAtAction("GetSample", new { id }, model);
        }

        // PUT: api/Sample/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSample(int id, SampleVM model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            await _sampleService.SampleUpdateAsync(model);

            return NoContent();
        }



        // DELETE: api/Sample/5
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
