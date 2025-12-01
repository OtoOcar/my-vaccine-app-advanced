using AutoMapper;
using MyVaccine.WebApi.Dtos.Vaccine;
using MyVaccine.WebApi.Models;

namespace MyVaccine.WebApi.Configurations.AutoMapperProfiles
{
    public class VaccineProfile : Profile
    {
        public VaccineProfile()
        {
            CreateMap<Vaccine, VaccineResponseDto>()
            .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.Categories));
            CreateMap<VaccineRequestDto, Vaccine>();

        }
    }
}