using System.ComponentModel.DataAnnotations;

namespace MediLabDapper.Dtos.DepartmentDtos
{
    public class CreateDepartmentDto
    {
        public string? ImageUrl { get; set; }
        [Required(ErrorMessage = "Bölüm adı boş geçilemez.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Bölüm adı 3 ile 100 karakter arasında olmalıdır.")]
        public string DepartmentName { get; set; }
        [Required(ErrorMessage = "Açıklama boş geçilemez.")]
        public string Description { get; set; }
    }
}
