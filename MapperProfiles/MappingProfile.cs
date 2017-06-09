using AutoMapper;
using vega.Models;
using vega.Controllers.Resources;
using Vega.Models;
using Vega.Controllers.Resources;
using System.Linq;
using System.Linq;
using System.Collections.Generic;

namespace vega.MapperProfiles

{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to Api Resource
            CreateMap <Make , MakeResource>();
            CreateMap <Model, ModelResource>();
            CreateMap<Feature, FeatureResource>();
            CreateMap<Vechile, VechileResource>().
                ForMember(vr => vr.Contact, opt => opt.MapFrom(v => new ContactResource { ContactName = v.ContactName, ContactEmail = v.ContactEmail, ContactPhone = v.ContactPhone }))
                .ForMember(vr => vr.Features, opt => opt.MapFrom(v => v.Features.Select(vf => vf.FeatureId)));


            //Api Resource to Domain.
            CreateMap<VechileResource, Vechile>().
                ForMember(v => v.Id, opt => opt.Ignore()).
                ForMember(v => v.ContactName, opt => opt.MapFrom(vr => vr.Contact.ContactName))
                .ForMember(v => v.ContactEmail, opt => opt.MapFrom(vr => vr.Contact.ContactEmail))
                .ForMember(v => v.ContactPhone, opt => opt.MapFrom(vr => vr.Contact.ContactPhone))
                .ForMember(v => v.Features, opt => opt.Ignore())
                .AfterMap((vr, v) => {
                    var removefeatures = new List<VechileFeature>();
                    foreach (var f in v.Features)
                        if (!vr.Features.Contains(f.FeatureId))
                            removefeatures.Add(f);

                    foreach (var f in removefeatures)
                        v.Features.Remove(f);

                    // add new features
                    foreach (var id in vr.Features)
                        if (!v.Features.Any(f => f.FeatureId == id))
                        {
                            v.Features.Add(new VechileFeature { FeatureId = id });
                        }
                });



        }
    }
}