using MyVaccine.WebApi.Dtos.VaccineCategory;

namespace MyVaccine.WebApi.Dtos.Vaccine
{
    public class VaccineResponseDto
    {
        public int VaccineId { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool RequiresBooster { get; set; }
        public List<VaccineCategoryResponseDto> Categories { get; set; } = new();
    }

}
