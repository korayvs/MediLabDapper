using System.ComponentModel.DataAnnotations;

namespace MediLabDapper.Dtos.DoctorDtos
{
    public class UpdateDoctorDto
    {
        public int DoctorId { get; set; }
        [Required(ErrorMessage = "Ad soyad boş geçilemez.")]
        [StringLength(75, MinimumLength = 5, ErrorMessage = "Ad soyad 5 ile 75 karakter arasında olmalıdır.")]
        public string NameSurname { get; set; }
        public string? ImageUrl { get; set; }
        [Required(ErrorMessage = "Açıklama boş geçilemez.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Bölüm bilgisi boş geçilemez.")]
        public int? DepartmentId { get; set; }
        public string? SocialMedia1 { get; set; }
        public string? SocialMedia2 { get; set; }
        public string? SocialMedia3 { get; set; }
        public string? SocialMedia4 { get; set; }
        public string? SocialMediaIcon { get; set; }
    }
}
