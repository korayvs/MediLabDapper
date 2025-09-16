using MediLabDapper.Dtos.DepartmentDtos;
using MediLabDapper.Dtos.DoctorDtos;

namespace MediLabDapper.Dtos.AllAppointmentDtos
{
    public class AllGetAppointmentByIdDto
    {
        public int AllAppointmentId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public int DoctorId { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string NameSurname { get; set; }
    }
}
