using AutoMapper;
using MyVaccine.WebApi.Dtos.VaccineRecord;
using MyVaccine.WebApi.Models;

namespace MyVaccine.WebApi.Configurations.AutoMapperProfiles
{
    public class VaccineRecordProfile : Profile
    {
        public VaccineRecordProfile()
        {
            CreateMap<VaccineRecord, VaccineRecordResponseDto>();
            CreateMap<VaccineRecordRequestDto, VaccineRecord>();
        }
    }
}