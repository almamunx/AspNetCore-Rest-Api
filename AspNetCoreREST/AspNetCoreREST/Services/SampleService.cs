using AspNetCoreREST.Data;
using AspNetCoreREST.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
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
        private readonly IMemoryCache _cache;

        //Constructor
        public SampleService(WebAPIContext context, IMapper mapper, IMemoryCache cache)
        {
            _context = context;
            _mapper = mapper;
            _cache = cache;
        }


        public async Task<List<Sample>> SampleGetAllAsync(int id = 0)
        {
            //Cheaks if there is any cache data with  the name "sampleListCache"
            if (_cache.TryGetValue("sampleListCache", out List<Sample> cacheData))
            {
                return cacheData;
            }
            else
            {
                var data = await _context.Sample.ToListAsync();
                _cache.Set("sampleListCache", data, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(60)
                });
                return data;
            }
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
