using AutoMapper;
using MyVaccine.WebApi.Dtos.VaccineCategory;
using MyVaccine.WebApi.Models;

namespace MyVaccine.WebApi.Configurations.AutoMapperProfiles
{
    public class VaccineCategoryProfile : Profile
    {
        public VaccineCategoryProfile()
        {
            CreateMap<VaccineCategory, VaccineCategoryResponseDto>();
            CreateMap<VaccineCategoryRequestDto, VaccineCategory>();
        }
    }
}