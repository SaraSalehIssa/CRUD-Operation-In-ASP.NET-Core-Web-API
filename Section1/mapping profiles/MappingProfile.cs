using AutoMapper;
using Section1.Core.Entities;
using Section1.Core.Entities.DTO;

namespace Section1.API.mapping_profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>().
                ForMember(To => To.Category_Name, from => from.MapFrom(x => x.Category != null? x.Category.Name: null));
        }
    }
}
