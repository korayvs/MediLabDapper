using System.ComponentModel.DataAnnotations;

namespace MediLabDapper.Dtos.ContactDtos
{
    public class UpdateContactDto
    {
        public int ContactId { get; set; }
        [Required(ErrorMessage = "Adres boş geçilemez.")]
        public string Location { get; set; }
        [Required(ErrorMessage = "Telefon numarası boş geçilemez.")]
        [Phone(ErrorMessage = "Geçerli bir telefon numarası girin.")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "E-posta adresi boş geçilemez.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi girin.")]
        public string Email { get; set; }
    }
}
