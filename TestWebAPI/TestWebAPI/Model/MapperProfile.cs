using AutoMapper;
using TestWebAPI.Data;

namespace TestWebAPI.Model
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Sample, SampleVM>().ReverseMap();
        }

    }
}
