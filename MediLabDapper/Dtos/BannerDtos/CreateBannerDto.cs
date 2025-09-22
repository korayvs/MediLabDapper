using System.ComponentModel.DataAnnotations;

namespace MediLabDapper.Dtos.BannerDtos
{
    public class CreateBannerDto
    {
        [MaxLength(100, ErrorMessage = "İkon bilgisi en fazla 100 karakter olmalıdır.")]
        public string? Icon { get; set; }
        [Required(ErrorMessage = "Başlık boş geçilemez.")]
        [MaxLength(50, ErrorMessage = "Başlık en fazla 50 karakter olmalıdır.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Açıklama boş geçilemez.")]
        [MaxLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olmalıdır.")]
        public string Description { get; set; }
    }
}
