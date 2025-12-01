using AutoMapper;
using MyVaccine.WebApi.Dtos.FamilyGroup;
using MyVaccine.WebApi.Models;

namespace MyVaccine.WebApi.Configurations.AutoMapperProfiles
{
    public class FamilyGroupProfile : Profile
    {
        public FamilyGroupProfile()
        {
            CreateMap<FamilyGroup, FamilyGroupResponseDto>();
            CreateMap<FamilyGroupRequestDto, FamilyGroup>();
        }
    }
}