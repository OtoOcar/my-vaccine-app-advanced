using AutoMapper;
using MyVaccine.WebApi.Dtos.Allergy;
using MyVaccine.WebApi.Dtos.User;
using MyVaccine.WebApi.Models;

namespace MyVaccine.WebApi.Configurations.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // User Mappings
            CreateMap<User, UserDto>().ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.AspNetUser.Email));
            CreateMap<Dependent, DependentDto>();

            CreateMap<User, UserResponseDto>();
            CreateMap<UserRequestDto, User>();
            CreateMap<Allergy, AllergyResponseDto>();

        }
    }
}