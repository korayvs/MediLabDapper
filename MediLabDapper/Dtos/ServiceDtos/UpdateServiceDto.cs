using System.ComponentModel.DataAnnotations;

namespace MediLabDapper.Dtos.ServiceDtos
{
    public class UpdateServiceDto
    {
        public int ServiceId { get; set; }
        [Required(ErrorMessage = "İkon bilgisi boş geçilemez.")]
        public string ServiceIcon { get; set; }
        [Required(ErrorMessage = "Başlık boş geçilemez.")]
        [MaxLength(100, ErrorMessage = "Başlık en fazla 100 karakter olmalıdır.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Açıklama boş geçilemez.")]
        [MaxLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olmalıdır.")]
        public string Description { get; set; }
    }
}
