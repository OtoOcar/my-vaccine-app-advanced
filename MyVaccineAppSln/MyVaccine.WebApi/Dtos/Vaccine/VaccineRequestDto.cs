namespace MyVaccine.WebApi.Dtos.Vaccine
{
    public class VaccineRequestDto
    {
        public string Name { get; set; } = string.Empty;
        public bool RequiresBooster { get; set; }
        public List<int> CategoryIds { get; set; } = new(); // obligatorio
    }
}