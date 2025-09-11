namespace MediLabDapper.Dtos.TestimonialDtos
{
    public class CreateTestimonialDto
    {
        public string? ImageUrl { get; set; }
        public string NameSurname { get; set; }
        public string JobName { get; set; }
        public int Review { get; set; }
        public string Comment { get; set; }
    }
}
