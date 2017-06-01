using AutoMapper;
using vega.Models;
using vega.Controllers.Resources;
namespace vega.MapperProfiles

{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap <Make , MakeResource>();
            CreateMap <Model, ModelResource>();
            
            
        }
    }
}