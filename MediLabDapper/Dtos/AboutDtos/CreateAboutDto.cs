using System.ComponentModel.DataAnnotations;

namespace MediLabDapper.Dtos.AboutDtos
{
    public class CreateAboutDto
    {
        [Required(ErrorMessage = "Açıklama boş geçilemez.")]
        [MaxLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olmalıdır.")]
        public string AboutDescription { get; set; }
        [Required(ErrorMessage = "Başlık - 1 boş geçilemez.")]
        [MaxLength(100, ErrorMessage = "Başlık - 1 en fazla 100 karakter olmalıdır.")]
        public string Title1 { get; set; }
        [Required(ErrorMessage = "Alt açıklama - 1 boş geçilemez.")]
        [MaxLength(500, ErrorMessage = "Alt açıklama - 1 en fazla 250 karakter olmalıdır.")]
        public string Description1 { get; set; }
        [Required(ErrorMessage = "Başlık - 2 boş geçilemez.")]
        [MaxLength(100, ErrorMessage = "Başlık - 2 en fazla 100 karakter olmalıdır.")]
        public string Title2 { get; set; }
        [Required(ErrorMessage = "Alt açıklama - 2 boş geçilemez.")]
        [MaxLength(500, ErrorMessage = "Alt açıklama - 2 en fazla 250 karakter olmalıdır.")]
        public string Description2 { get; set; }
        [Required(ErrorMessage = "Başlık - 3 boş geçilemez.")]
        [MaxLength(100, ErrorMessage = "Başlık - 3 en fazla 100 karakter olmalıdır.")]
        public string Title3 { get; set; }
        [Required(ErrorMessage = "Alt açıklama - 3 boş geçilemez.")]
        [MaxLength(500, ErrorMessage = "Alt açıklama - 3 en fazla 250 karakter olmalıdır.")]
        public string Description3 { get; set; }
    }
}
