using AspNetCoreREST.Data;
using AspNetCoreREST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreREST
{
    public interface ISampleService
    {
        #region Sample
        Task<List<Sample>> SampleGetAllAsync(int id = 0);
        Task<SampleVM> SampleGetAsync(int id);
        Task<int> SampleSaveAsync(SampleVM model);
        Task<int> SampleUpdateAsync(SampleVM model);
        Task SampleDeleteAsync(int id);
        #endregion
    }
}
