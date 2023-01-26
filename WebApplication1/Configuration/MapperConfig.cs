using AutoMapper;
using WebApplication1.MapperModels.RegionDto;
using WebApplication1.Models;

namespace WebApplication1.Configuration
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<RegionGetOneDto, Region>().ReverseMap();
            CreateMap<RegionPostDto, Region>().ReverseMap();
            CreateMap<RegionPutDto, Region>().ReverseMap();
        }
        
    }
}