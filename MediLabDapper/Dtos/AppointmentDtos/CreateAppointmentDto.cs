using System.ComponentModel.DataAnnotations;

namespace MediLabDapper.Dtos.AppointmentDtos
{
    public class CreateAppointmentDto
    {
        [Required(ErrorMessage = "Ad soyad boş geçilemez.")]
        [MaxLength(100, ErrorMessage = "Ad soyad en fazla 100 karater olmalıdır.")]
        public string FullName { get; set; }
        public string? Email { get; set; }
        [Required(ErrorMessage = "Telefon numarası boş geçilemez.")]
        [MaxLength(100, ErrorMessage = "Telefon numarası en fazla 15 karater olmalıdır.")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Randevu tarihi boş geçilemez.")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Randevu saati boş geçilemez.")]
        public TimeSpan Time { get; set; }
        public string? Message { get; set; }
        [Required(ErrorMessage = "Lütfen doktor seçin.")]
        public int? DoctorId { get; set; }
        [Required(ErrorMessage = "Lütfen bölüm seçin.")]
        public int? DepartmentId { get; set; }
        public StatusAppointmentDto IsApproved { get; set; }
    }
}
