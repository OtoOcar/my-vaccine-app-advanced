using MyVaccine.WebApi.Dtos.Dependent;
using MyVaccine.WebApi.Dtos.User;
using MyVaccine.WebApi.Dtos.Vaccine;

namespace MyVaccine.WebApi.Dtos.VaccineRecord
{
    public class VaccineRecordResponseDto
    {
        public int VaccineRecordId { get; set; }
        public DateTime DateAdministered { get; set; }
        public string AdministeredLocation { get; set; } = string.Empty;
        public string AdministeredBy { get; set; } = string.Empty;

        public UserDto User { get; set; } = new();
        public DependentDto Dependent { get; set; } = new();
        public VaccineResponseDto Vaccine { get; set; } = new();
    }
}