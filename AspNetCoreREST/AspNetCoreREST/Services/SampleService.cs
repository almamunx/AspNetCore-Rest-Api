using AspNetCoreREST.Data;
using AspNetCoreREST.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreREST.Services
{
    public class SampleService : ISampleService
    {

        //Private members
        private readonly WebAPIContext _context;
        private readonly IMapper _mapper;

        //Constructor
        public SampleService(WebAPIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<List<Sample>> SampleGetAllAsync(int id = 0)
        {
            return await _context.Sample.ToListAsync();
        }

        public async Task<SampleVM> SampleGetAsync(int id)
        {
            var data = await _context.Sample.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
            return _mapper.Map<SampleVM>(data);
        }

        public async Task<int> SampleSaveAsync(SampleVM model)
        {
            var entity = _mapper.Map<Sample>(model);
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<int> SampleUpdateAsync(SampleVM model)
        {
            var entity = _mapper.Map<Sample>(model);
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task SampleDeleteAsync(int id)
        {
            var data = _context.Sample.FindAsync(id).Result;
            _context.Sample.Remove(data);
            await _context.SaveChangesAsync();
        }
    }
}
