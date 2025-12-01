namespace MyVaccine.WebApi.Dtos.Allergy
{
    public class AllergyResponseDto
    {
        public int AllergyId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int UserId { get; set; }
    }
}