using System.ComponentModel.DataAnnotations;

namespace MediLabDapper.Dtos.AllAppointmentDtos
{
    public class AllCreateAppointmentDto
    {
        [Required(ErrorMessage = "Randevu tarihi boş geçilemez.")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Randevu saati boş geçilemez.")]
        public TimeSpan Time { get; set; }
        [Required(ErrorMessage = "Lütfen bölüm seçin.")]
        public int DoctorId { get; set; }
        [Required(ErrorMessage = "Lütfen doktor seçin.")]
        public int DepartmentId { get; set; }
    }
}
