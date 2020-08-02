using AspNetCoreREST.Data;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreREST.Models
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Sample, SampleVM>().ReverseMap();
        }

    }
}
