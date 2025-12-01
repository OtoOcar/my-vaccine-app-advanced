using AutoMapper;
using MyVaccine.WebApi.Dtos.Allergy;
using MyVaccine.WebApi.Dtos.Dependent;
using MyVaccine.WebApi.Models;

namespace MyVaccine.WebApi.Configurations.AutoMapperProfiles;

public class DependentProfile : Profile
{
    public DependentProfile()
    {
        CreateMap<Dependent, DependentRequestDto>().ReverseMap();
        CreateMap<Dependent, DependentResponseDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DependentId)).ReverseMap();

        CreateMap<Allergy, AllergyResponseDto>();
        CreateMap<AllergyRequestDto, Allergy>();

    }
}
