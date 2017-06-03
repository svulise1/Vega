using AutoMapper;
using vega.Models;
using vega.Controllers.Resources;
using Vega.Models;
using Vega.Controllers.Resources;

namespace vega.MapperProfiles

{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap <Make , MakeResource>();
            CreateMap <Model, ModelResource>();
            CreateMap<Feature, FeatureResource>();
            //hello
            
            
        }
    }
}