using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebAPI.Data;
using TestWebAPI.Model;

namespace TestWebAPI.Services
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
