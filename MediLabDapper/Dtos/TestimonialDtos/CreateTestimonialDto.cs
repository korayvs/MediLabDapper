using System.ComponentModel.DataAnnotations;

namespace MediLabDapper.Dtos.TestimonialDtos
{
    public class CreateTestimonialDto
    {
        public string? ImageUrl { get; set; }
        [Required(ErrorMessage = "Ad soyad boş geçilemez.")]
        [MaxLength(75, ErrorMessage = "Ad soyad en fazla 75 karakter olmalıdır.")]
        public string NameSurname { get; set; }
        public string? JobName { get; set; }
        public int Review { get; set; }
        [Required(ErrorMessage = "Yorum boş geçilemez.")]
        [MaxLength(300, ErrorMessage = "Yorum en fazla 300 karakter olmalıdır.")]
        public string Comment { get; set; }
    }
}
