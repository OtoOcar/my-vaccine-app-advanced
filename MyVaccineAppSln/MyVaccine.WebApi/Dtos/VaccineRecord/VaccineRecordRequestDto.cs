namespace MyVaccine.WebApi.Dtos.VaccineRecord
{
    public class VaccineRecordRequestDto
    {
        public int UserId { get; set; }      // 👈 obligatorio
        public int DependentId { get; set; } // 👈 obligatorio
        public int VaccineId { get; set; }   // 👈 obligatorio
        public DateTime DateAdministered { get; set; }
        public string AdministeredLocation { get; set; } = string.Empty;
        public string AdministeredBy { get; set; } = string.Empty;
    }
}